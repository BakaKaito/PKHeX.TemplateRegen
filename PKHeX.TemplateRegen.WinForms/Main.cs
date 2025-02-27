using LibGit2Sharp;
using PKHeX.TemplateRegen;
using PKHeX.TemplateRegen.WinForms;
using System.Text.Json;

namespace PKHeXBrowse.TemplateRegen.WinForms
{
    public partial class Main : Form
    {
        private static readonly string SettingsFilePath = "settings.json";
        private void PKHeXFolderButtonClick(object sender, EventArgs e) => SelectFolder(PKHeXPathBox, Repo.EventsGallery);
        private void EGFolderButtonClick(object sender, EventArgs e) => SelectFolder(EventsGalleryPathBox, Repo.EventsGallery);
        private void PGETFolderButtonClick(object sender, EventArgs e) => SelectFolder(PGETPathBox, Repo.PoGoEncTool);

        public Main()
        {
            InitializeComponent();
            LoadPaths();
        }

        private async void UpdateClick(object sender, EventArgs e)
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

                // Update local repos
                if (CB_PullLatestEG.Checked)
                {
                    StatusLabel.Text = "Updating Events Gallery Repo...";
                    await Task.Delay(500);
                    UpdateEventsGalleryRepo(Repo.EventsGallery);
                }

                if (CB_PullLatestPGET.Checked)
                {
                    StatusLabel.Text = "Updating PoGoEncTool Repo...";
                    await Task.Delay(500);
                    UpdateEventsGalleryRepo(Repo.PoGoEncTool);
                }

                // Update pkl files
                StatusLabel.Text = "Gathering Files...";
                var mgdb = new MGDBPickler(settings.RepoPathPKHeX, settings.RepoPathEvGal);
                var PGET = new POGOPickler(settings.RepoPathPKHeX, settings.RepoPathPGET);

                StatusLabel.Text = "Updating WC Pickles...";
                mgdb.Update();
                await Task.Delay(500);

                StatusLabel.Text = "Updating POGO Pickles...";
                PGET.Update();
                await Task.Delay(500);
                StatusLabel.Text = "Update Complete";

                WinFormsUtil.Alert("Done!");
            }
            catch (OperationCanceledException ex)
            {
                WinFormsUtil.Alert($"Operation Cancelled: {ex.Message}");
            }
            catch (Exception ex)
            {
                WinFormsUtil.Alert($"An error occurred: {ex.Message}");
            }
        }

        private void UpdateEventsGalleryRepo(Repo repo)
        {
            (string path, string branch) = repo switch
            {
                Repo.EventsGallery => (EventsGalleryPathBox.Text, "master"),
                Repo.PoGoEncTool => (PGETPathBox.Text, "main"),
                _ => (string.Empty, string.Empty)
            };

            if (!Repository.IsValid(path))
            {
                throw new OperationCanceledException($"Invalid {repo} path.");
            }

            try
            {
                using var localRepo = new Repository(path);
                var remote = localRepo.Network.Remotes["origin"];
                var fetchOptions = new FetchOptions();

                Commands.Fetch(localRepo, remote.Name, remote.FetchRefSpecs.Select(x => x.Specification), fetchOptions, "Fetching latest changes...");
                Branch localBranch = localRepo.Branches[branch];
                Branch remoteBranch = localRepo.Branches[$"origin/{branch}"] ?? throw new OperationCanceledException($"Remote branch \"{branch}\" not found.");
                Commands.Checkout(localRepo, localBranch);
                localRepo.Reset(ResetMode.Hard, remoteBranch.Tip);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private static void SelectFolder(TextBox targetTextBox, Repo type)
        {
            using FolderBrowserDialog folderDialog = new();
            var desc = type switch
            {
                Repo.PKHeX => "Select the PKHeX Repository Folder",
                Repo.EventsGallery => "Select the EventsGallery Repository Folder",
                Repo.PoGoEncTool => "Select the PoGoEncTool Repository Folder",
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

        private enum Repo
        {
            PKHeX,
            EventsGallery,
            PoGoEncTool
        }
    }
}
