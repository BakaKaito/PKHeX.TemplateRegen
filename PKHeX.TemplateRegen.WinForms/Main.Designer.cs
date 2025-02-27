﻿namespace PKHeXBrowse.TemplateRegen.WinForms
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            PKHeXPathBox = new TextBox();
            EventsGalleryPathBox = new TextBox();
            PGETPathBox = new TextBox();
            PKHeXBrowse = new Button();
            EventsGalleryBrowse = new Button();
            PGETBrowse = new Button();
            PKHeXPathLabel = new Label();
            EventsGalleryPathLabel = new Label();
            PGETPathLabel = new Label();
            Update = new Button();
            StatusLabel = new Label();
            L_Version = new Label();
            CB_PullLatestPGET = new CheckBox();
            CB_PullLatestEG = new CheckBox();
            SuspendLayout();
            // 
            // PKHeXPathBox
            // 
            PKHeXPathBox.BackColor = SystemColors.ControlLight;
            PKHeXPathBox.Location = new Point(12, 50);
            PKHeXPathBox.Name = "PKHeXPathBox";
            PKHeXPathBox.Size = new Size(504, 39);
            PKHeXPathBox.TabIndex = 0;
            // 
            // EventsGalleryPathBox
            // 
            EventsGalleryPathBox.BackColor = SystemColors.ControlLight;
            EventsGalleryPathBox.Location = new Point(12, 135);
            EventsGalleryPathBox.Name = "EventsGalleryPathBox";
            EventsGalleryPathBox.Size = new Size(504, 39);
            EventsGalleryPathBox.TabIndex = 1;
            // 
            // PGETPathBox
            // 
            PGETPathBox.BackColor = SystemColors.ControlLight;
            PGETPathBox.Location = new Point(12, 226);
            PGETPathBox.Name = "PGETPathBox";
            PGETPathBox.Size = new Size(504, 39);
            PGETPathBox.TabIndex = 2;
            // 
            // PKHeXBrowse
            // 
            PKHeXBrowse.BackColor = SystemColors.ControlLight;
            PKHeXBrowse.Location = new Point(522, 50);
            PKHeXBrowse.Name = "PKHeXBrowse";
            PKHeXBrowse.Size = new Size(54, 47);
            PKHeXBrowse.TabIndex = 4;
            PKHeXBrowse.Text = "📂";
            PKHeXBrowse.UseVisualStyleBackColor = false;
            PKHeXBrowse.Click += PKHeXFolderButtonClick;
            // 
            // EventsGalleryBrowse
            // 
            EventsGalleryBrowse.BackColor = SystemColors.ControlLight;
            EventsGalleryBrowse.Location = new Point(522, 135);
            EventsGalleryBrowse.Name = "EventsGalleryBrowse";
            EventsGalleryBrowse.Size = new Size(54, 49);
            EventsGalleryBrowse.TabIndex = 5;
            EventsGalleryBrowse.Text = "📂";
            EventsGalleryBrowse.UseVisualStyleBackColor = false;
            EventsGalleryBrowse.Click += EGFolderButtonClick;
            // 
            // PGETBrowse
            // 
            PGETBrowse.BackColor = SystemColors.ControlLight;
            PGETBrowse.Location = new Point(522, 226);
            PGETBrowse.Name = "PGETBrowse";
            PGETBrowse.Size = new Size(54, 47);
            PGETBrowse.TabIndex = 6;
            PGETBrowse.Text = "📂";
            PGETBrowse.UseVisualStyleBackColor = false;
            PGETBrowse.Click += PGETFolderButtonClick;
            // 
            // PKHeXPathLabel
            // 
            PKHeXPathLabel.AutoSize = true;
            PKHeXPathLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            PKHeXPathLabel.Location = new Point(12, 15);
            PKHeXPathLabel.Name = "PKHeXPathLabel";
            PKHeXPathLabel.Size = new Size(214, 32);
            PKHeXPathLabel.TabIndex = 7;
            PKHeXPathLabel.Text = "PKHeX Repo Path";
            // 
            // EventsGalleryPathLabel
            // 
            EventsGalleryPathLabel.AutoSize = true;
            EventsGalleryPathLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            EventsGalleryPathLabel.Location = new Point(12, 100);
            EventsGalleryPathLabel.Name = "EventsGalleryPathLabel";
            EventsGalleryPathLabel.Size = new Size(298, 32);
            EventsGalleryPathLabel.TabIndex = 8;
            EventsGalleryPathLabel.Text = "Events Gallery Repo Path";
            // 
            // PGETPathLabel
            // 
            PGETPathLabel.AutoSize = true;
            PGETPathLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            PGETPathLabel.Location = new Point(12, 191);
            PGETPathLabel.Name = "PGETPathLabel";
            PGETPathLabel.Size = new Size(195, 32);
            PGETPathLabel.TabIndex = 9;
            PGETPathLabel.Text = "PGET Repo Path";
            // 
            // Update
            // 
            Update.BackColor = Color.FromArgb(85, 85, 226);
            Update.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            Update.ForeColor = Color.White;
            Update.Location = new Point(10, 381);
            Update.Margin = new Padding(1);
            Update.Name = "Update";
            Update.Size = new Size(568, 56);
            Update.TabIndex = 10;
            Update.Text = "Update";
            Update.UseVisualStyleBackColor = false;
            Update.Click += UpdateClick;
            // 
            // StatusLabel
            // 
            StatusLabel.BackColor = Color.Transparent;
            StatusLabel.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StatusLabel.Location = new Point(10, 438);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(522, 32);
            StatusLabel.TabIndex = 11;
            StatusLabel.Text = "Ready";
            // 
            // L_Version
            // 
            L_Version.AutoSize = true;
            L_Version.Font = new Font("Segoe UI", 7F);
            L_Version.Location = new Point(538, 445);
            L_Version.Name = "L_Version";
            L_Version.Size = new Size(45, 25);
            L_Version.TabIndex = 12;
            L_Version.Text = "v1.1";
            // 
            // CB_PullLatestPGET
            // 
            CB_PullLatestPGET.AutoSize = true;
            CB_PullLatestPGET.Location = new Point(12, 289);
            CB_PullLatestPGET.Name = "CB_PullLatestPGET";
            CB_PullLatestPGET.Size = new Size(401, 36);
            CB_PullLatestPGET.TabIndex = 13;
            CB_PullLatestPGET.Text = "Pull Latest PoGoEncTool Commits";
            CB_PullLatestPGET.UseVisualStyleBackColor = true;
            // 
            // CB_PullLatestEG
            // 
            CB_PullLatestEG.AutoSize = true;
            CB_PullLatestEG.Location = new Point(12, 331);
            CB_PullLatestEG.Name = "CB_PullLatestEG";
            CB_PullLatestEG.Size = new Size(412, 36);
            CB_PullLatestEG.TabIndex = 14;
            CB_PullLatestEG.Text = "Pull Latest Events Gallery Commits";
            CB_PullLatestEG.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(588, 470);
            Controls.Add(CB_PullLatestEG);
            Controls.Add(CB_PullLatestPGET);
            Controls.Add(L_Version);
            Controls.Add(Update);
            Controls.Add(PGETPathLabel);
            Controls.Add(EventsGalleryPathLabel);
            Controls.Add(PKHeXPathLabel);
            Controls.Add(PGETBrowse);
            Controls.Add(EventsGalleryBrowse);
            Controls.Add(PKHeXBrowse);
            Controls.Add(PKHeXPathBox);
            Controls.Add(PGETPathBox);
            Controls.Add(EventsGalleryPathBox);
            Controls.Add(StatusLabel);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TemplateRegen";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox PKHeXPathBox;
        private TextBox EventsGalleryPathBox;
        private TextBox PGETPathBox;
        private Button PKHeXBrowse;
        private Button EventsGalleryBrowse;
        private Button PGETBrowse;
        private Label PKHeXPathLabel;
        private Label EventsGalleryPathLabel;
        private Label PGETPathLabel;
        private Button Update;
        private Label StatusLabel;
        private Label L_Version;
        private CheckBox CB_PullLatestPGET;
        private CheckBox CB_PullLatestEG;
    }
}
