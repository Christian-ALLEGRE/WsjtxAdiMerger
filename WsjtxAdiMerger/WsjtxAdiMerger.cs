/*******************************************************************
 * F4LAA : WsjtxAdiMerger
 * 
 * Programme de fusion de deux fichiers .ADI de Wsjt-X
 * 
 * V1.0 (16/02/2024)
 *   - Création du programme
 *
 * V1.1 (17/02/2024)
 *   - Ajout Langues FR/US + About dlg
 * 
 * ***************************************************************/
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WsjtxAdiMerger
{
    public partial class WsjtxAdiMerger : Form
    {
        private string VERSION = "WsjtxAdiMerger par F4LAA V1.1b (17/02/2024 23:13)";
        protected ACRegistry reg;
        string STR_FileFilter;
        string STR_NoRecordFound;
        string STR_NoHeaderFound;
        string STR_MsgCompleted;
        string STR_MSG1;
        string STR_MSG2;
        string STR_MSG3;
        string STR_MSG4;
        string STR_MSG5;

        void setLang(int lang)
        {
            switch (toolStripComboBoxLang.SelectedIndex)
            {
                case 0:
                    toolStripLabel1.Text = "Langue";
                    toolStripButtonAbout.Text = "A propos";
                    BFusion.Text = "Fusionner puis remplacer les .ADI";
                    CB144.Text = "Générer wsjtx_144MHz.adi";
                    CB432.Text = "Générer wsjtx_432MHz.adi";
                    STR_FileFilter = "Fichiers ADI (*.adi)|*.adi";
                    STR_NoRecordFound = "ERREUR: Aucun enregistrement trouvé dans le fichier wsjtx_log.adi du 1er WSJT-X";
                    STR_NoHeaderFound = "ERREUR: L'entête attendue n'a pas été trouvée dans le fichier wsjtx_log.adi du 1er WSJT-X";
                    STR_MsgCompleted = "$ enregistrements ajoutés. Fichiers fusionnés et remplacés.";
                    STR_MSG1 = "Il faut choisir deux fichiers wsjtx_log.adi dans deux dossiers différents";
                    STR_MSG2 = "Choisissez le fichier wsjtx_log.adi du 2ème Wsjt-x";
                    STR_MSG3 = "Il faut choisir le fichier wsjtx_log.adi du 2ème Wsjt-x";
                    STR_MSG4 = "Choisissez le fichier wsjtx_log.adi du 1er Wsjt-x";
                    STR_MSG5 = "Il faut choisir le fichier wsjtx_log.adi du 1er Wsjt-x";
                    VERSION = VERSION.Replace("by", "par");
                    break;

                case 1:
                    toolStripLabel1.Text = "Language";
                    toolStripButtonAbout.Text = "About";
                    BFusion.Text = "Merge then Replace .ADI files";
                    CB144.Text = "Generate wsjtx_144MHz.adi file";
                    CB432.Text = "Generate wsjtx_432MHz.adi file";
                    STR_FileFilter = "ADI File (*.adi)|*.adi";
                    STR_NoRecordFound = "ERROR: No record found in the wsjtx_log.adi file of the 1st WSJT-X";
                    STR_NoHeaderFound = "ERROR: The expected header has not been found in the wsjtx_log.adi file of the 1st WSJT-X";
                    STR_MsgCompleted = "$ records added. Files merged and replaced.";
                    STR_MSG1 = "You must select two wsjtx_log.adi files in two differents directories";
                    STR_MSG2 = "Select the wsjtx_log.adi file for the 2nd Wsjt-x";
                    STR_MSG3 = "You must select the wsjtx_log.adi file of the 2nd Wsjt-x";
                    STR_MSG4 = "Select the wsjtx_log.adi file for the 1st Wsjt-x";
                    STR_MSG5 = "You must select the wsjtx_log.adi file of the 1st Wsjt-x";
                    VERSION = VERSION.Replace("par", "by");
                    break;
            }
            Text = VERSION;
        }
        private void toolStripComboBoxLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            setLang(toolStripComboBoxLang.SelectedIndex);
        }
        public WsjtxAdiMerger()
        {
            InitializeComponent();
            reg = new ACRegistry(@"SOFTWARE\F4LAA\WsjtxAdiMerger", true);

            string sReg = reg.GetKey("Top");
            int lang = 0; // Default to Français
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
                lang = int.Parse(reg.GetKey("Lang"));
            }

            toolStripComboBoxLang.Items.Add("Français");
            toolStripComboBoxLang.Items.Add("English");
            toolStripComboBoxLang.SelectedIndex = lang;
        }

        private void BWsjtx1_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"..\local";
            fileDialog.Filter = STR_FileFilter; 
            if (fileDialog.ShowDialog() == DialogResult.OK)
                labFile1.Text = fileDialog.FileName;
        }

        private void BWsjtx2_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"..\local";
            fileDialog.Filter = STR_FileFilter;
            if (fileDialog.ShowDialog() == DialogResult.OK)
                labFile2.Text = fileDialog.FileName;
        }

        private int _loadFile(string filename, SortedList dict)
        {
            int result = 0;
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

                    if (!dict.ContainsKey(key)) // Ignore duplicate key (coz 2nd file may already contains lines from 1st file)
                    {
                        result++;
                        dict.Add(key, line);
                    }
                }
            }
            return result;
        }

        private int FusionADI()
        {
            // Chargement des fichiers en mémoire
            SortedList dict = new SortedList();

            // Stream d'ecriture dans le fichier de trace
            int nbRecFile1 = _loadFile(labFile1.Text, dict);
            if (nbRecFile1 == 0)
            {
                MessageBox.Show(STR_NoRecordFound);
                return -1;
            }
            int result = _loadFile(labFile2.Text, dict);

            // Recopie Header file
            string[] sHeader = new string[6];
            int cpt = 0;
            foreach (string line in File.ReadLines(labFile1.Text))
            {
                sHeader[cpt++] = line;
                if (cpt == 6)
                    break; // End of Header file
            }
            if (cpt != 6)
            {
                MessageBox.Show(STR_NoHeaderFound);
                return -1;
            }

            // Sauvegarde des fichiers 
            DateTime now = DateTime.Now;
            string mm = now.Month.ToString();
            if (now.Month < 10)
                mm = "0" + mm;
            string dd = now.Day.ToString();
            if (now.Day < 10)
                dd = "0" + dd;
            string hh = now.Hour.ToString();
            if (now.Hour < 10)
                hh = "0" + hh;
            string mi = now.Minute.ToString();
            if (now.Minute < 10)
                mi = "0" + mi;
            string ss = now.Second.ToString();
            if (now.Second < 10)
                ss = "0" + ss;
            string ext = ".bak_" + now.Year + mm + dd + hh + mi + ss;
            File.Copy(labFile1.Text, labFile1.Text + ext, true);
            File.Copy(labFile2.Text, labFile2.Text + ext, true);

            // Ecriture
            FileStream fileOut1 = new FileStream(labFile1.Text, FileMode.Create, FileAccess.Write, FileShare.Write, 4096, false);
            FileStream fileOut2 = new FileStream(labFile2.Text, FileMode.Create, FileAccess.Write, FileShare.Write, 4096, false);
            FileStream fileOut144 = null;
            if (CB144.Checked)
                fileOut144 = new FileStream(labFile1.Text.Replace("_log", "_144MHz"), FileMode.Create, FileAccess.Write, FileShare.Write, 4096, false);
            FileStream fileOut432 = null;
            if (CB432.Checked)
                fileOut432 = new FileStream(labFile1.Text.Replace("_log", "_432MHz"), FileMode.Create, FileAccess.Write, FileShare.Write, 4096, false);

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

            return result;
        }

        private string saisieOK()
        {
            string result = "";
            if (labFile1.Text == labFile2.Text)
                result = STR_MSG1; // "Il faut choisir deux fichiers wsjtx_log.adi dans deux dossiers différents";
            if (result.Length == 0)
            {
                if (labFile2.Text.IndexOf("Select") >= 0)
                    result = STR_MSG2; // "Choisissez le fichier wsjtx_log.adi du 2ème Wsjt-x";
                else if (labFile2.Text.IndexOf("wsjtx_log.adi") < 0)
                    result = STR_MSG3; // "Il faut choisir le fichier wsjtx_log.adi du 2ème Wsjt-x";
            }
            if (result.Length == 0)
            {
                if (labFile1.Text.IndexOf("Select") >= 0)
                    result = STR_MSG4; // "Choisissez le fichier wsjtx_log.adi du 1er Wsjt-x";
                else if (labFile1.Text.IndexOf("wsjtx_log.adi") < 0)
                    result = STR_MSG5; // "Il faut choisir le fichier wsjtx_log.adi du 1er Wsjt-x";
            }
            return result;
        }
        private void BFusion_Click(object sender, EventArgs e)
        {
            string message = saisieOK();
            if (message.Length > 0)
                MessageBox.Show(message);
            else
            {
                int nbRecAdded = FusionADI();
                if (nbRecAdded >= 0)
                    MessageBox.Show(STR_MsgCompleted.Replace("$", nbRecAdded.ToString()));
            }
        }

        private void toolStripButtonAbout_Click(object sender, EventArgs e)
        {
            About dlg = new About(VERSION, toolStripComboBoxLang.SelectedIndex)
            {
                StartPosition = FormStartPosition.Manual,
                Left = this.Left + 20,
                Top = this.Top + 30
            };
            dlg.ShowDialog();
        }
        private void WsjtxAdiMerger_FormClosing(object sender, FormClosingEventArgs e)
        {
            reg.SetKey("Top", "" + Top);
            reg.SetKey("Left", "" + Left);
            reg.SetKey("File1", labFile1.Text);
            reg.SetKey("File2", labFile2.Text);
            reg.SetKey("CB144", CB144.Checked ? "1" : "0");
            reg.SetKey("CB432", CB432.Checked ? "1" : "0");
            reg.SetKey("Lang", toolStripComboBoxLang.SelectedIndex.ToString());
        }
    }
}
