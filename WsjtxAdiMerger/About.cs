using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WsjtxAdiMerger
{
    public partial class About : Form
    {
        public About(string version, int lang)
        {
            InitializeComponent();
            int pos = version.IndexOf(' ');
            Text = version.Substring(0, pos);
            labVersion.Text = version;
            switch(lang)
            {
                case 0:
                    label2.Text = "Programme conçu pour fusionner les fichiers wsjtx_log.adi";
                    label3.Text = "de deux instances de WSJT-X.";
                    BClose.Text = "Fermer";
                    break; 
                case 1:
                    label2.Text = "Program designed to merge and replace wsjtx_log.adi files";
                    label3.Text = "for two WSJT-X instances.";
                    BClose.Text = "Close";
                    break;
            }
        }

        private void BClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var p = new Process();
            p.StartInfo.FileName = linkLabel1.Text;
            p.StartInfo.UseShellExecute = true;
            p.Start();
        }
    }
}
