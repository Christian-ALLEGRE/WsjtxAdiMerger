/*******************************************************************
 * F4LAA : WsjtxAdiMerger
 * 
 * Programme de fusion de deux fichiers .ADI de Wsjt-X
 * 
 * V1.0 (16/02/2024)
 *   - Création du programme
 * 
 * ***************************************************************/
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WsjtxAdiMerger
{
    public partial class WsjtxAdiMerger : Form
    {
        private string VERSION = "WsjtxAdiMerger by F4LAA V1.0 (16/02/2024)";
        protected ACRegistry reg;
        public WsjtxAdiMerger()
        {
            InitializeComponent();
            Text = VERSION;
            reg = new ACRegistry("WsjtxAdiMerger", true);

            string sReg = reg.GetKey("Top");
            if ((sReg != null) && (sReg != ""))
            {
                StartPosition = FormStartPosition.Manual;
                Top = int.Parse(sReg);
                sReg = reg.GetKey("Left");
                Left = int.Parse(sReg);
                labFile1.Text = reg.GetKey("File1");
                labFile2.Text = reg.GetKey("File2");
                CB144.Checked = (reg.GetKey("CB144") == "1");
                CB432.Checked = (reg.GetKey("CB432") == "1");
            }
        }

        private void BWsjtx1_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"..\local";
            fileDialog.Filter = "Fichiers ADI (*.adi)|*.adi";
            if (fileDialog.ShowDialog() == DialogResult.OK)
                labFile1.Text = fileDialog.FileName;
        }

        private void BWsjtx2_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"..\local";
            fileDialog.Filter = "Fichiers ADI (*.adi)|*.adi";
            if (fileDialog.ShowDialog() == DialogResult.OK)
                labFile2.Text = fileDialog.FileName;
        }

        private void _loadFile(string filename, SortedList dict)
        {
            foreach (string line in File.ReadLines(filename))
            {
                string toFind = "<gridsquare:";
                int pos = line.IndexOf(toFind);
                if (pos > 0)
                {
                    int pos2 = line.LastIndexOf(">", pos);
                    pos2++; // skip >
                    string callSign = line.Substring(pos2, pos - pos2);

                    toFind = "<qso_date:8>";
                    pos = line.IndexOf(toFind);
                    string key = line.Substring(pos + toFind.Length, 8);

                    toFind = "<time_on:6>";
                    pos = line.IndexOf(toFind);
                    key += "|" + line.Substring(pos + toFind.Length, 6);

                    key += "|" + callSign;

                    if (! dict.ContainsKey(key)) // Ignore duplicate key (coz 2nd file may already contains lines from 1st file)
                        dict.Add(key, line);
                }
            }
        }

        private void FusionADI()
        {
            // Chargement des fichiers en mémoire
            SortedList dict = new SortedList();

            // Stream d'ecriture dans le fichier de trace
            _loadFile(labFile1.Text, dict);
            _loadFile(labFile2.Text, dict);

            // Recopie Header file
            string[] sHeader = new string[6];
            int cpt = 0;
            foreach (string line in File.ReadLines(labFile1.Text))
            {
                sHeader[cpt++] = line;
                if (cpt == 6)
                    break; // End of Header file
            }

            // Ecriture
            FileStream fileOut1 = new FileStream(labFile1.Text, FileMode.Create, FileAccess.Write, FileShare.Write, 4096, false);
            FileStream fileOut2 = new FileStream(labFile2.Text, FileMode.Create, FileAccess.Write, FileShare.Write, 4096, false);
            FileStream fileOut144 = null;
            if (CB144.Checked)
                fileOut144 = new FileStream(labFile1.Text.Replace("_log", "_144MHz.adi"), FileMode.Create, FileAccess.Write, FileShare.Write, 4096, false);
            FileStream fileOut432 = null;
            if (CB432.Checked)
                fileOut432 = new FileStream(labFile1.Text.Replace("_log", "_432MHz.adi"), FileMode.Create, FileAccess.Write, FileShare.Write, 4096, false);

            for (int i = 0; i < 6; i++)
            {
                byte[] msg = new UTF8Encoding(true).GetBytes(sHeader[i] + "\r\n");
                fileOut1.Write(msg, 0, msg.Length);
                fileOut2.Write(msg, 0, msg.Length);
                if (CB144.Checked)
                    fileOut144.Write(msg, 0, msg.Length);
                if (CB432.Checked)
                    fileOut432.Write(msg, 0, msg.Length);
            }

            IDictionaryEnumerator dicEnum = dict.GetEnumerator();
            while (dicEnum.MoveNext())
            {
                string line = dicEnum.Value.ToString();
                byte[] msg = new UTF8Encoding(true).GetBytes(line + "\r\n");
                fileOut1.Write(msg, 0, msg.Length);
                fileOut2.Write(msg, 0, msg.Length);
                if (CB144.Checked)
                    if (line.IndexOf(">2m ") > 0)
                        fileOut144.Write(msg, 0, msg.Length);
                if (CB432.Checked)
                    if (line.IndexOf(">70cm ") > 0)
                        fileOut432.Write(msg, 0, msg.Length);
            }

            fileOut1.Close();
            fileOut2.Close();
            if (CB144.Checked)
                fileOut144.Close();
            if (CB432.Checked)
                fileOut432.Close();

            MessageBox.Show("Fichiers fusionnés et remplacé.");
        }

        private string saisieOK()
        {
            string result = "";
            if (labFile1.Text == labFile2.Text)
                result = "Il faut choisir deux fichiers .adi dans deux dossiers différents";
            if (labFile2.Text.IndexOf("Select") >= 0)
                result = "Choisissez le fichier .adi du 2ème Wsjt-x";
            if (labFile1.Text.IndexOf("Select") >= 0)
                result = "Choisissez le fichier .adi du 1er Wsjt-x";
            return result;
        }
        private void BFusion_Click(object sender, EventArgs e)
        {
            string message = saisieOK();
            if (message.Length > 0)
                MessageBox.Show(message);
            else
                FusionADI();
        }

        private void WsjtxAdiMerger_FormClosing(object sender, FormClosingEventArgs e)
        {
            reg.SetKey("Top", "" + Top);
            reg.SetKey("Left", "" + Left);
            reg.SetKey("File1", labFile1.Text);
            reg.SetKey("File2", labFile2.Text);
            reg.SetKey("CB144", CB144.Checked ? "1" : "0");
            reg.SetKey("CB432", CB432.Checked ? "1" : "0");
        }
    }
}
