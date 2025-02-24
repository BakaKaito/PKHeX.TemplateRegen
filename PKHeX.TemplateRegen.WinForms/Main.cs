using PKHeX.TemplateRegen;
using PKHeX.TemplateRegen.WinForms;
using System.Text.Json;

namespace PKHeXBrowse.TemplateRegen.WinForms
{
    public partial class Main : Form
    {
        private static readonly string SettingsFilePath = "settings.json";
        private void PKHeXFolderButtonClick(object sender, EventArgs e) => SelectFolder(PKHeXPathBox, FolderType.EventsGallery);
        private void EGFolderButtonClick(object sender, EventArgs e) => SelectFolder(EventsGalleryPathBox, FolderType.EventsGallery);
        private void PGETFolderButtonClick(object sender, EventArgs e) => SelectFolder(PGETPathBox, FolderType.PoGoEncTool);

        public Main()
        {
            InitializeComponent();
            LoadPaths();
        }

        private void UpdateClick(object sender, EventArgs e)
        {
            SaveSettings();
            try
            {
                var settings = GetSettings();
                if (string.IsNullOrWhiteSpace(settings.RepoPathPKHeX) ||
                     string.IsNullOrWhiteSpace(settings.RepoPathEvGal) ||
                     string.IsNullOrWhiteSpace(settings.RepoPathPGET))
                {
                    WinFormsUtil.Alert("One or more required paths are empty.");
                    return;
                }

                var mgdb = new MGDBPickler(settings.RepoPathPKHeX, settings.RepoPathEvGal);
                var PGET = new POGOPickler(settings.RepoPathPKHeX, settings.RepoPathPGET);
                StatusLabel.Text = "Updating WC Pickles...";
                mgdb.Update();
                StatusLabel.Text = "Updating POGO Pickles...";
                PGET.Update();
                StatusLabel.Text = "";

                WinFormsUtil.Alert("Done!");
            }
            catch (Exception ex)
            {
                WinFormsUtil.Alert($"An error occurred: {ex.Message}");
            }
        }

        private static void SelectFolder(TextBox targetTextBox, FolderType type)
        {
            using FolderBrowserDialog folderDialog = new();
            var desc = type switch
            {
                FolderType.PKHeX => "Select the PKHeX Repository Folder",
                FolderType.EventsGallery => "Select the EventsGallery Repository Folder",
                FolderType.PoGoEncTool => "Select the PoGoEncTool Repository Folder",
                _ => "Select a Folder"
            };
            folderDialog.Description = desc;
            folderDialog.ShowNewFolderButton = true;

            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                targetTextBox.Text = folderDialog.SelectedPath;
            }
        }

        private void LoadPaths()
        {
            var settings = GetSettings();
            PKHeXPathBox.Text = settings.RepoPathPKHeX;
            EventsGalleryPathBox.Text = settings.RepoPathEvGal;
            PGETPathBox.Text = settings.RepoPathPGET;
        }

        private void SaveSettings()
        {
            var settings = new ProgramSettings
            {
                RepoPathPKHeX = PKHeXPathBox.Text,
                RepoPathEvGal = EventsGalleryPathBox.Text,
                RepoPathPGET = PGETPathBox.Text
            };

            File.WriteAllText(SettingsFilePath, JsonSerializer.Serialize(settings, ProgramSettingsContext.Default.ProgramSettings));
        }

        private static ProgramSettings GetSettings()
        {
            if (!File.Exists(SettingsFilePath))
            {
                var defaultSettings = new ProgramSettings
                {
                    RepoPathPKHeX = "",
                    RepoPathEvGal = "",
                    RepoPathPGET = ""
                };

                File.WriteAllText(SettingsFilePath, JsonSerializer.Serialize(defaultSettings, ProgramSettingsContext.Default.ProgramSettings));
                return defaultSettings;
            }

            var text = File.ReadAllText(SettingsFilePath);
            return JsonSerializer.Deserialize(text, ProgramSettingsContext.Default.ProgramSettings) ?? new ProgramSettings();
        }

        private enum FolderType
        {
            PKHeX,
            EventsGallery,
            PoGoEncTool
        }
    }
}
