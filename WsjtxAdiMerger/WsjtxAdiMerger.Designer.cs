namespace WsjtxAdiMerger
{
    partial class WsjtxAdiMerger
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WsjtxAdiMerger));
            labFile1 = new Label();
            BWsjtx1 = new Button();
            BWsjtx2 = new Button();
            labFile2 = new Label();
            CB144 = new CheckBox();
            CB432 = new CheckBox();
            BFusion = new Button();
            toolStrip1 = new ToolStrip();
            toolStripLabel1 = new ToolStripLabel();
            toolStripComboBoxLang = new ToolStripComboBox();
            toolStripButtonAbout = new ToolStripButton();
            BQrzAdi = new Button();
            labFileQRZ = new Label();
            PB1 = new ProgressBar();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // labFile1
            // 
            labFile1.AutoSize = true;
            labFile1.Location = new Point(108, 52);
            labFile1.Name = "labFile1";
            labFile1.Size = new Size(191, 15);
            labFile1.TabIndex = 0;
            labFile1.Text = "Selectionner le fichier wsjtx_log.adi";
            // 
            // BWsjtx1
            // 
            BWsjtx1.Location = new Point(27, 48);
            BWsjtx1.Name = "BWsjtx1";
            BWsjtx1.Size = new Size(75, 23);
            BWsjtx1.TabIndex = 1;
            BWsjtx1.Text = "Wsjt-x (1)";
            BWsjtx1.UseVisualStyleBackColor = true;
            BWsjtx1.Click += BWsjtx1_Click;
            // 
            // BWsjtx2
            // 
            BWsjtx2.Location = new Point(27, 77);
            BWsjtx2.Name = "BWsjtx2";
            BWsjtx2.Size = new Size(75, 23);
            BWsjtx2.TabIndex = 3;
            BWsjtx2.Text = "Wsjt-x (2)";
            BWsjtx2.UseVisualStyleBackColor = true;
            BWsjtx2.Click += BWsjtx2_Click;
            // 
            // labFile2
            // 
            labFile2.AutoSize = true;
            labFile2.Location = new Point(108, 81);
            labFile2.Name = "labFile2";
            labFile2.Size = new Size(191, 15);
            labFile2.TabIndex = 2;
            labFile2.Text = "Selectionner le fichier wsjtx_log.adi";
            // 
            // CB144
            // 
            CB144.AutoSize = true;
            CB144.Location = new Point(33, 145);
            CB144.Name = "CB144";
            CB144.Size = new Size(164, 19);
            CB144.TabIndex = 4;
            CB144.Text = "Générer wsjtx_144MHz.adi";
            CB144.UseVisualStyleBackColor = true;
            // 
            // CB432
            // 
            CB432.AutoSize = true;
            CB432.Location = new Point(240, 145);
            CB432.Name = "CB432";
            CB432.Size = new Size(164, 19);
            CB432.TabIndex = 5;
            CB432.Text = "Générer wsjtx_432MHz.adi";
            CB432.UseVisualStyleBackColor = true;
            // 
            // BFusion
            // 
            BFusion.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            BFusion.Location = new Point(108, 170);
            BFusion.Name = "BFusion";
            BFusion.Size = new Size(252, 32);
            BFusion.TabIndex = 6;
            BFusion.Text = "Fusionner puis remplacer les .ADI";
            BFusion.UseVisualStyleBackColor = true;
            BFusion.Click += BFusion_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel1, toolStripComboBoxLang, toolStripButtonAbout });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(459, 38);
            toolStrip1.TabIndex = 10;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(46, 35);
            toolStripLabel1.Text = "Langue";
            // 
            // toolStripComboBoxLang
            // 
            toolStripComboBoxLang.Name = "toolStripComboBoxLang";
            toolStripComboBoxLang.Size = new Size(80, 38);
            toolStripComboBoxLang.SelectedIndexChanged += toolStripComboBoxLang_SelectedIndexChanged;
            // 
            // toolStripButtonAbout
            // 
            toolStripButtonAbout.Image = (Image)resources.GetObject("toolStripButtonAbout.Image");
            toolStripButtonAbout.ImageTransparentColor = Color.Magenta;
            toolStripButtonAbout.Name = "toolStripButtonAbout";
            toolStripButtonAbout.Size = new Size(59, 35);
            toolStripButtonAbout.Text = "A propos";
            toolStripButtonAbout.TextImageRelation = TextImageRelation.ImageAboveText;
            toolStripButtonAbout.Click += toolStripButtonAbout_Click;
            // 
            // BQrzAdi
            // 
            BQrzAdi.Location = new Point(27, 106);
            BQrzAdi.Name = "BQrzAdi";
            BQrzAdi.Size = new Size(75, 23);
            BQrzAdi.TabIndex = 12;
            BQrzAdi.Text = "QRZ ADI";
            BQrzAdi.UseVisualStyleBackColor = true;
            BQrzAdi.Click += BQrzAdi_Click;
            // 
            // labFileQRZ
            // 
            labFileQRZ.AutoSize = true;
            labFileQRZ.Location = new Point(108, 110);
            labFileQRZ.Name = "labFileQRZ";
            labFileQRZ.Size = new Size(148, 15);
            labFileQRZ.TabIndex = 11;
            labFileQRZ.Text = "Fichier QRZ.com à intégrer";
            // 
            // PB1
            // 
            PB1.Location = new Point(28, 208);
            PB1.Name = "PB1";
            PB1.Size = new Size(408, 16);
            PB1.TabIndex = 13;
            // 
            // WsjtxAdiMerger
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(459, 230);
            Controls.Add(PB1);
            Controls.Add(BQrzAdi);
            Controls.Add(labFileQRZ);
            Controls.Add(toolStrip1);
            Controls.Add(BFusion);
            Controls.Add(CB432);
            Controls.Add(CB144);
            Controls.Add(BWsjtx2);
            Controls.Add(labFile2);
            Controls.Add(BWsjtx1);
            Controls.Add(labFile1);
            Name = "WsjtxAdiMerger";
            Text = "WsjtxAdiMerger by F4LAA (V1.0 2024/02/16)";
            FormClosing += WsjtxAdiMerger_FormClosing;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labFile1;
        private Button BWsjtx1;
        private Button BWsjtx2;
        private Label labFile2;
        private CheckBox CB144;
        private CheckBox CB432;
        private Button BFusion;
        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripComboBox toolStripComboBoxLang;
        private ToolStripButton toolStripButtonAbout;
        private Button BQrzAdi;
        private Label labFileQRZ;
        private ProgressBar PB1;
    }
}
