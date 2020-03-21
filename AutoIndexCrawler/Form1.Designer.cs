using System.Windows.Forms;

namespace AutoIndexCrawler
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;    // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ResultsList = new System.Windows.Forms.ListBox();
            this.StartingPointLabel = new System.Windows.Forms.Label();
            this.FullIndex = new System.Windows.Forms.RadioButton();
            this.DirectoryOnly = new System.Windows.Forms.RadioButton();
            this.FileOnly = new System.Windows.Forms.RadioButton();
            this.ExportLocationButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.ExportLocationDialog = new System.Windows.Forms.SaveFileDialog();
            this.InputTextBox = new System.Windows.Forms.TextBox();
            this.DataSourceRefresher = new System.Windows.Forms.Timer(this.components);
            this.Refresh = new System.Windows.Forms.Label();
            this.ClearResults = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Stats = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AutoScroll = new System.Windows.Forms.Label();
            this.AutoRefresh = new System.Windows.Forms.Label();
            this.Runtime = new System.Windows.Forms.Label();
            this.StatsRefresher = new System.Windows.Forms.Timer(this.components);
            this.LinkValidator = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ResultsList
            // 
            this.ResultsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResultsList.FormattingEnabled = true;
            this.ResultsList.Location = new System.Drawing.Point(12, 12);
            this.ResultsList.Name = "ResultsList";
            this.ResultsList.Size = new System.Drawing.Size(888, 277);
            this.ResultsList.Sorted = true;
            this.ResultsList.TabIndex = 0;
            this.ResultsList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ResultsList_MouseDoubleClick);
            // 
            // StartingPointLabel
            // 
            this.StartingPointLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.StartingPointLabel.AutoSize = true;
            this.StartingPointLabel.Location = new System.Drawing.Point(11, 321);
            this.StartingPointLabel.Name = "StartingPointLabel";
            this.StartingPointLabel.Size = new System.Drawing.Size(148, 13);
            this.StartingPointLabel.TabIndex = 2;
            this.StartingPointLabel.Text = "AutoIndex List (1 URL / Line):";
            // 
            // FullIndex
            // 
            this.FullIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.FullIndex.AutoSize = true;
            this.FullIndex.Checked = true;
            this.FullIndex.Location = new System.Drawing.Point(668, 339);
            this.FullIndex.Name = "FullIndex";
            this.FullIndex.Size = new System.Drawing.Size(70, 17);
            this.FullIndex.TabIndex = 3;
            this.FullIndex.TabStop = true;
            this.FullIndex.Text = "Full Index";
            this.FullIndex.UseVisualStyleBackColor = true;
            // 
            // DirectoryOnly
            // 
            this.DirectoryOnly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DirectoryOnly.AutoSize = true;
            this.DirectoryOnly.Location = new System.Drawing.Point(668, 361);
            this.DirectoryOnly.Name = "DirectoryOnly";
            this.DirectoryOnly.Size = new System.Drawing.Size(91, 17);
            this.DirectoryOnly.TabIndex = 3;
            this.DirectoryOnly.Text = "Directory Only";
            this.DirectoryOnly.UseVisualStyleBackColor = true;
            // 
            // FileOnly
            // 
            this.FileOnly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.FileOnly.AutoSize = true;
            this.FileOnly.Location = new System.Drawing.Point(668, 383);
            this.FileOnly.Name = "FileOnly";
            this.FileOnly.Size = new System.Drawing.Size(65, 17);
            this.FileOnly.TabIndex = 3;
            this.FileOnly.Text = "File Only";
            this.FileOnly.UseVisualStyleBackColor = true;
            // 
            // ExportLocationButton
            // 
            this.ExportLocationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExportLocationButton.Location = new System.Drawing.Point(786, 333);
            this.ExportLocationButton.Name = "ExportLocationButton";
            this.ExportLocationButton.Size = new System.Drawing.Size(114, 23);
            this.ExportLocationButton.TabIndex = 4;
            this.ExportLocationButton.Text = "Export Location...";
            this.ExportLocationButton.UseVisualStyleBackColor = true;
            this.ExportLocationButton.Click += new System.EventHandler(this.ExportLocationButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.StartButton.Enabled = false;
            this.StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartButton.Location = new System.Drawing.Point(786, 362);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(114, 38);
            this.StartButton.TabIndex = 4;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // InputTextBox
            // 
            this.InputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputTextBox.Location = new System.Drawing.Point(13, 339);
            this.InputTextBox.Multiline = true;
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.Size = new System.Drawing.Size(649, 61);
            this.InputTextBox.TabIndex = 5;
            this.InputTextBox.TextChanged += new System.EventHandler(this.StartingPoint_TextChanged);
            this.InputTextBox.DoubleClick += new System.EventHandler(this.InputTextBox_DoubleClick);
            this.InputTextBox.GotFocus += new System.EventHandler(this.InputTextBox_GotFocus);
            this.InputTextBox.LostFocus += new System.EventHandler(this.InputTextBox_LostFocus);
            // 
            // DataSourceRefresher
            // 
            this.DataSourceRefresher.Enabled = true;
            this.DataSourceRefresher.Interval = 350;
            this.DataSourceRefresher.Tick += new System.EventHandler(this.DataSourceRefresher_Tick);
            // 
            // Refresh
            // 
            this.Refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Refresh.AutoSize = true;
            this.Refresh.BackColor = System.Drawing.SystemColors.Control;
            this.Refresh.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Refresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Refresh.Location = new System.Drawing.Point(607, 4);
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(61, 13);
            this.Refresh.TabIndex = 6;
            this.Refresh.Text = "[Refresh]";
            // 
            // ClearResults
            // 
            this.ClearResults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearResults.AutoSize = true;
            this.ClearResults.BackColor = System.Drawing.SystemColors.Control;
            this.ClearResults.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearResults.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClearResults.Location = new System.Drawing.Point(666, 4);
            this.ClearResults.Name = "ClearResults";
            this.ClearResults.Size = new System.Drawing.Size(85, 13);
            this.ClearResults.TabIndex = 6;
            this.ClearResults.Text = "[Free Up RAM]";
            this.ClearResults.Click += new System.EventHandler(this.ClearResults_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.Stats);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.AutoScroll);
            this.panel1.Controls.Add(this.AutoRefresh);
            this.panel1.Controls.Add(this.Refresh);
            this.panel1.Controls.Add(this.ClearResults);
            this.panel1.Controls.Add(this.Runtime);
            this.panel1.Location = new System.Drawing.Point(12, 289);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(888, 22);
            this.panel1.TabIndex = 7;
            // 
            // Stats
            // 
            this.Stats.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Stats.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Stats.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(75)))));
            this.Stats.Location = new System.Drawing.Point(3, 4);
            this.Stats.Name = "Stats";
            this.Stats.Size = new System.Drawing.Size(265, 13);
            this.Stats.TabIndex = 9;
            this.Stats.Text = "[Total Links: 0000]  [Total Files: 0000]";
            this.Stats.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(750, -3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = ".";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(598, -3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = ".";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // AutoScroll
            // 
            this.AutoScroll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AutoScroll.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutoScroll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.AutoScroll.Location = new System.Drawing.Point(483, 4);
            this.AutoScroll.Name = "AutoScroll";
            this.AutoScroll.Size = new System.Drawing.Size(115, 13);
            this.AutoScroll.TabIndex = 8;
            this.AutoScroll.Text = "[Auto Scroll: Off]";
            this.AutoScroll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AutoScroll.Click += new System.EventHandler(this.AutoScroll_Click);
            // 
            // AutoRefresh
            // 
            this.AutoRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AutoRefresh.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutoRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.AutoRefresh.Location = new System.Drawing.Point(368, 4);
            this.AutoRefresh.Name = "AutoRefresh";
            this.AutoRefresh.Size = new System.Drawing.Size(121, 13);
            this.AutoRefresh.TabIndex = 7;
            this.AutoRefresh.Text = "[Auto Refresh: On]";
            this.AutoRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AutoRefresh.Click += new System.EventHandler(this.AutoRefresh_Click);
            // 
            // Runtime
            // 
            this.Runtime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Runtime.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Runtime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Runtime.Location = new System.Drawing.Point(757, 4);
            this.Runtime.Name = "Runtime";
            this.Runtime.Size = new System.Drawing.Size(126, 13);
            this.Runtime.TabIndex = 10;
            this.Runtime.Text = "[Runtime: 00:00:00]";
            this.Runtime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StatsRefresher
            // 
            this.StatsRefresher.Enabled = true;
            this.StatsRefresher.Tick += new System.EventHandler(this.StatsRefresher_Tick);
            // 
            // LinkValidator
            // 
            this.LinkValidator.Enabled = true;
            this.LinkValidator.Tick += new System.EventHandler(this.LinkValidator_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 411);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.InputTextBox);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.ExportLocationButton);
            this.Controls.Add(this.FileOnly);
            this.Controls.Add(this.DirectoryOnly);
            this.Controls.Add(this.FullIndex);
            this.Controls.Add(this.StartingPointLabel);
            this.Controls.Add(this.ResultsList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "AutoIndex Crawler";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ResultsList;
        private System.Windows.Forms.Label StartingPointLabel;
        private System.Windows.Forms.RadioButton FullIndex;
        private System.Windows.Forms.RadioButton DirectoryOnly;
        private System.Windows.Forms.RadioButton FileOnly;
        private System.Windows.Forms.Button ExportLocationButton;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.SaveFileDialog ExportLocationDialog;
        private System.Windows.Forms.TextBox InputTextBox;
        private System.Windows.Forms.Timer DataSourceRefresher;
        private System.Windows.Forms.Label Refresh;
        private System.Windows.Forms.Label ClearResults;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Stats;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label AutoScroll;
        private System.Windows.Forms.Label AutoRefresh;
        private System.Windows.Forms.Timer StatsRefresher;
        private Timer LinkValidator;
        private Label Runtime;
        private Label label1;
        private Timer FinishCheck;
    }
}

