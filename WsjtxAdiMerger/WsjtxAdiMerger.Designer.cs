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
            labFile1 = new Label();
            BWsjtx1 = new Button();
            BWsjtx2 = new Button();
            labFile2 = new Label();
            CB144 = new CheckBox();
            CB432 = new CheckBox();
            BFusion = new Button();
            SuspendLayout();
            // 
            // labFile1
            // 
            labFile1.AutoSize = true;
            labFile1.Location = new Point(89, 14);
            labFile1.Name = "labFile1";
            labFile1.Size = new Size(191, 15);
            labFile1.TabIndex = 0;
            labFile1.Text = "Selectionner le fichier wsjtx_log.adi";
            // 
            // BWsjtx1
            // 
            BWsjtx1.Location = new Point(8, 10);
            BWsjtx1.Name = "BWsjtx1";
            BWsjtx1.Size = new Size(75, 23);
            BWsjtx1.TabIndex = 1;
            BWsjtx1.Text = "Wsjt-x (1)";
            BWsjtx1.UseVisualStyleBackColor = true;
            BWsjtx1.Click += BWsjtx1_Click;
            // 
            // BWsjtx2
            // 
            BWsjtx2.Location = new Point(8, 39);
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
            labFile2.Location = new Point(89, 43);
            labFile2.Name = "labFile2";
            labFile2.Size = new Size(191, 15);
            labFile2.TabIndex = 2;
            labFile2.Text = "Selectionner le fichier wsjtx_log.adi";
            // 
            // CB144
            // 
            CB144.AutoSize = true;
            CB144.Location = new Point(14, 73);
            CB144.Name = "CB144";
            CB144.Size = new Size(164, 19);
            CB144.TabIndex = 4;
            CB144.Text = "Générer wsjtx_144MHz.adi";
            CB144.UseVisualStyleBackColor = true;
            // 
            // CB432
            // 
            CB432.AutoSize = true;
            CB432.Location = new Point(205, 73);
            CB432.Name = "CB432";
            CB432.Size = new Size(164, 19);
            CB432.TabIndex = 5;
            CB432.Text = "Générer wsjtx_432MHz.adi";
            CB432.UseVisualStyleBackColor = true;
            // 
            // BFusion
            // 
            BFusion.Location = new Point(99, 107);
            BFusion.Name = "BFusion";
            BFusion.Size = new Size(196, 23);
            BFusion.TabIndex = 6;
            BFusion.Text = "Fusionner puis remplacer les .ADI";
            BFusion.UseVisualStyleBackColor = true;
            BFusion.Click += BFusion_Click;
            // 
            // WsjtxAdiMerger
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(514, 153);
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
    }
}
