namespace WsjtxAdiMerger
{
    partial class About
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labVersion = new Label();
            label2 = new Label();
            label3 = new Label();
            BClose = new Button();
            linkLabel1 = new LinkLabel();
            SuspendLayout();
            // 
            // labVersion
            // 
            labVersion.AutoSize = true;
            labVersion.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labVersion.Location = new Point(22, 21);
            labVersion.Name = "labVersion";
            labVersion.Size = new Size(157, 21);
            labVersion.TabIndex = 0;
            labVersion.Text = "WsjtxAdiMerger V1.1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 48);
            label2.Name = "label2";
            label2.Size = new Size(330, 15);
            label2.TabIndex = 2;
            label2.Text = "Programme permettant de fusionner les fichiers wsjtx_log.adi";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 73);
            label3.Name = "label3";
            label3.Size = new Size(159, 15);
            label3.TabIndex = 3;
            label3.Text = "de deux instances de WSJT-X";
            // 
            // BClose
            // 
            BClose.Location = new Point(144, 125);
            BClose.Name = "BClose";
            BClose.Size = new Size(75, 23);
            BClose.TabIndex = 4;
            BClose.Text = "Fermer";
            BClose.UseVisualStyleBackColor = true;
            BClose.Click += BClose_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(25, 98);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(303, 15);
            linkLabel1.TabIndex = 5;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "https://github.com/Christian-ALLEGRE/WsjtxAdiMerger";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // About
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(387, 160);
            Controls.Add(linkLabel1);
            Controls.Add(BClose);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(labVersion);
            Name = "About";
            Text = "About";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labVersion;
        private Label label2;
        private Label label3;
        private Button BClose;
        private LinkLabel linkLabel1;
    }
}