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
 * V1.1a (17/02/2024)
 *   - Fix issue #1 : Fail to start after fresh install coz Lang used when not initialized
 * 
 * V1.1b (17/02/2024)
 *   - Fix issue2 : Fail to create wsjtx_144MHz if input filename do not contain _log string
 *   - Check that input filenames contains wsjtx_log.adi string
 *   - Backup files before overwriting them
 * 
 * V1.1c (19/02/2024 20:00)
 *   - More explicit final message
 * 
 * V1.2 (20/02/2024 18:48)
 *   - More explicit final message
 * 
 * ***************************************************************/
using System.Collections;
using System.Runtime.InteropServices;
using System.Text;

namespace WsjtxAdiMerger
{
    public partial class WsjtxAdiMerger : Form
    {
        private string VERSION = "WsjtxAdiMerger par F4LAA V1.2 (20/02/2024 18:48)";
        protected ACRegistry reg;
        string STR_FileFilter;
        string STR_NoRecordFound;
        string STR_NoHeaderFound;
        string STR_Result;
        string STR_MsgCompleted;
        string STR_MsgFileMerged;
        string STR_File144Created;
        string STR_File432Created;
        string STR_FileLabel;
        string STR_FileQRZ;
        string STR_MSG1;
        string STR_MSG2;
        string STR_MSG3;
        string STR_MSG4;
        string STR_MSG5;
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
                    STR_Result = "Résultat de la fusion";
                    STR_MsgCompleted = "$1 enregistrement ajouté au fichier\r\n%1\r\n\r\n$2 enregistrement ajouté au fichier\r\n%2\r\n";
                    STR_MsgFileMerged = "\r\nLes deux fichiers ont été fusionnés et remis en place.";
                    STR_File144Created = "\r\nLe fichier wsjtx_144MHz a été créé.";
                    STR_File432Created = "\r\nLe fichier wsjtx_432MHz a été créé.";
                    STR_FileLabel = "Selectionner le fichier wsjtx_log.adi";
                    STR_FileQRZ = "Fichier QRZ.com à intégrer";
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
                    STR_Result = "Merge result";
                    STR_MsgCompleted = "$1 record added to file\r\n%1\r\n\r\n$2 record added to file\r\n%2\r\n";
                    STR_MsgFileMerged = "\r\nThe two files have been merged and replaced.";
                    STR_File144Created = "\r\nThe file wsjtx_144MHz has been created.";
                    STR_File432Created = "\r\nThe file wsjtx_432MHz has been created.";
                    STR_FileLabel = "Select the wsjtx_log.adi file";
                    STR_FileQRZ = "QRZ.com ADI file to add";
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
            if (labFile1.Text.Length == 0)
            {
                labFile1.Text = STR_FileLabel;
                labFile2.Text = STR_FileLabel;
            }
            labFileQRZ.Text = STR_FileQRZ;
            PB1.Hide();
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
        private void BQrzAdi_Click(object sender, EventArgs e)
        {
            labFileQRZ.Text = STR_FileQRZ;
            var fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"..\local";
            fileDialog.Filter = STR_FileFilter;
            if (fileDialog.ShowDialog() == DialogResult.OK)
                labFileQRZ.Text = fileDialog.FileName;
        }

        private int _loadFile(string filename, int numfile, SortedList dict, bool wsjtx, bool count, int max)
        {
            int result = 0;
            string sLine = "";
            if (!count)
            {
                PB1.Minimum = 0;
                PB1.Maximum = max;
                PB1.Value = 0;
                PB1.SetState(numfile); // Weird color change !!!
                PB1.Show();
            }
            int cptPB = 0;
            foreach (string line in File.ReadLines(filename))
            {
                if (count)
                    result++;
                else
                {
                    // Animate ProgressBar
                    cptPB++;
                    if (cptPB % 100  == 0) 
                        PB1.Value = cptPB;

                    sLine += line;

                    if (sLine.IndexOf("<eoh>") >= 0)
                        sLine = "";

                    if (sLine.IndexOf("<eor>") >= 0)
                    {
                        string toFind = "<call:";
                        int pos = sLine.IndexOf(toFind);
                        if (pos >= 0)
                        {
                            pos = sLine.IndexOf(">", pos);
                            pos++; // skip >
                            int pos2 = sLine.IndexOf("<", pos);
                            string callSign = sLine.Substring(pos, pos2 - pos);

                            toFind = "<qso_date:";
                            pos = sLine.IndexOf(toFind);
                            pos = sLine.IndexOf(">", pos);
                            pos++; // skip >
                            pos2 = sLine.IndexOf("<", pos);
                            string key = sLine.Substring(pos, pos2 - pos);

                            toFind = "<time_on:";
                            pos = sLine.IndexOf(toFind);
                            pos = sLine.IndexOf(">", pos);
                            pos++; // skip >
                            pos2 = sLine.IndexOf("<", pos);
                            string time = sLine.Substring(pos, pos2 - pos);
                            if (time.Length == 4)
                                time += "00"; // QRZ.com do not contains seconds
                            key += "|" + time;
                            key += "|" + callSign;

                            bool digital = wsjtx;
                            if (!digital)
                            {
                                toFind = "<mode:";
                                pos = sLine.IndexOf(toFind);
                                pos = sLine.IndexOf(">", pos);
                                pos++; // skip >
                                pos2 = sLine.IndexOf("<", pos);
                                string mode = sLine.Substring(pos, pos2 - pos);
                                digital = ((mode.IndexOf("FT8") >= 0) || (mode.IndexOf("FT4") >= 0) || (mode.IndexOf("MFSK") >= 0));
                            }

                            if (digital)
                                if (!dict.ContainsKey(key)) // Ignore duplicate key (coz 2nd file may already contains lines from 1st file)
                                {
                                    result++;
                                    dict.Add(key, sLine);
                                }
                        }
                        sLine = "";
                    }
                }
            }
            PB1.Hide();
            return result;
        }

        private string FusionADI()
        {
            string result = STR_MsgCompleted
                           .Replace("%1", labFile1.Text)
                           .Replace("%2", labFile2.Text);

            // Chargement des fichiers en mémoire
            SortedList dict = new SortedList();

            int nbLinesFile1 = _loadFile(labFile1.Text, 1, dict, true, true, 0);
            int nbRecFile1 = _loadFile(labFile1.Text, 1, dict, true, false, nbLinesFile1);
            if (nbRecFile1 == 0)
                return STR_NoRecordFound;

            // Memorize Header file
            string[] sHeader = new string[10];
            int headerLen = 0;
            foreach (string line in File.ReadLines(labFile1.Text))
            {
                sHeader[headerLen++] = line;
                if (line.IndexOf("<eoh>") >= 0)
                    break; // End of Header 
                if (headerLen == 10)
                    break;
            }
            if (headerLen == 10)
                return STR_NoHeaderFound;

            // Count added record for each files
            int nbLinesFile2 = _loadFile(labFile2.Text, 2, dict, true, true, 0);
            int nbRecAdded1 = _loadFile(labFile2.Text, 2, dict, true, false, nbLinesFile2);

            dict = new SortedList(); // Reset dict
            _loadFile(labFile2.Text, 2, dict, true, false, nbLinesFile2);
            int nbRecAdded2 = _loadFile(labFile1.Text, 1, dict, true, false, nbLinesFile1);

            if (labFileQRZ.Text != STR_FileQRZ)
            {
                // Fichier QRZ.com a ajouter
                int nbLineQRZ = _loadFile(labFileQRZ.Text, 3, dict, false, true, 0);
                int nbRecQRZ = _loadFile(labFileQRZ.Text, 3, dict, false, false, nbLineQRZ);
                nbRecAdded1 += nbRecQRZ;
                nbRecAdded2 += nbRecQRZ;
                labFileQRZ.Text = STR_FileQRZ; // used
            }

            if (nbRecAdded1 == 0)
            {
                result = result.Replace("$1 enregistrement", "Aucun enregistrement");
                result = result.Replace("$1 record", "No record");
            }
            else if (nbRecAdded1 > 1)
            {
                result = result.Replace("$1 enregistrement ajouté", "$1 enregistrements ajoutés");
                result = result.Replace("$1 record added", "$1 records added");
            }
            result = result.Replace("$1", nbRecAdded1.ToString());

            if (nbRecAdded2 == 0)
            {
                result = result.Replace("$2 enregistrement", "Aucun enregistrement");
                result = result.Replace("$2 record", "No record");
            }
            else if (nbRecAdded2 > 1)
            {
                result = result.Replace("$2 enregistrement ajouté", "$2 enregistrements ajoutés");
                result = result.Replace("$2 record added", "$2 records added");
            }
            result = result.Replace("$2", nbRecAdded2.ToString());

            bool filesChanged = ((nbRecAdded1 + nbRecAdded2) > 0);
            if (filesChanged)
                result += STR_MsgFileMerged;

            FileStream fileOut1 = null;
            FileStream fileOut2 = null;
            FileStream fileOut144 = null;
            FileStream fileOut432 = null;
            if (CB144.Checked)
            {
                fileOut144 = new FileStream(labFile1.Text.Replace("_log", "_144MHz"), FileMode.Create, FileAccess.Write, FileShare.Write, 4096, false);
                // Header of added files
                for (int i = 0; i < headerLen; i++)
                {
                    byte[] msg = new UTF8Encoding(true).GetBytes(sHeader[i] + "\r\n");
                    fileOut144.Write(msg, 0, msg.Length);
                }
                result += STR_File144Created;
            }

            if (CB432.Checked)
            {
                fileOut432 = new FileStream(labFile1.Text.Replace("_log", "_432MHz"), FileMode.Create, FileAccess.Write, FileShare.Write, 4096, false);
                // Header of added files
                for (int i = 0; i < headerLen; i++)
                {
                    byte[] msg = new UTF8Encoding(true).GetBytes(sHeader[i] + "\r\n");
                    fileOut432.Write(msg, 0, msg.Length);
                }
                result += STR_File432Created;
            }

            if (filesChanged)
            {
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

                // RéEcriture des fichiers
                fileOut1 = new FileStream(labFile1.Text, FileMode.Create, FileAccess.Write, FileShare.Write, 4096, false);
                fileOut2 = new FileStream(labFile2.Text, FileMode.Create, FileAccess.Write, FileShare.Write, 4096, false);
                // Header of files
                for (int i = 0; i < headerLen; i++)
                {
                    byte[] msg = new UTF8Encoding(true).GetBytes(sHeader[i] + "\r\n");
                    fileOut1.Write(msg, 0, msg.Length);
                    fileOut2.Write(msg, 0, msg.Length);
                }
            }

            if (filesChanged || CB144.Checked || CB432.Checked)
            {
                PB1.Minimum = 0;
                PB1.Maximum = dict.Count;
                PB1.Value = 0;
                PB1.ForeColor = Color.Yellow;
                PB1.SetState(1); // = Color.Green;
                PB1.Show();
                int cptPB = 0;
                IDictionaryEnumerator dicEnum = dict.GetEnumerator();
                while (dicEnum.MoveNext())
                {
                    // Animate ProgressBar
                    cptPB++;
                    PB1.Value = cptPB;

                    string line = dicEnum.Value.ToString();
                    byte[] msg = new UTF8Encoding(true).GetBytes(line + "\r\n");
                    if (filesChanged)
                    {
                        fileOut1.Write(msg, 0, msg.Length);
                        fileOut2.Write(msg, 0, msg.Length);
                    }
                    if (CB144.Checked && (line.IndexOf(">2m ") > 0))
                        fileOut144.Write(msg, 0, msg.Length);
                    if (CB432.Checked && (line.IndexOf(">70cm ") > 0))
                        fileOut432.Write(msg, 0, msg.Length);
                }
                if (filesChanged)
                {
                    fileOut1.Close();
                    fileOut2.Close();
                }
                if (CB144.Checked)
                    fileOut144.Close();
                if (CB432.Checked)
                    fileOut432.Close();
                PB1.Hide();
            }
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
            string msg = saisieOK();
            if (msg.Length == 0)
                msg = FusionADI();
            MessageBox.Show(msg, STR_Result);
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

    public static class ModifyProgressBarColor
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);
        public static void SetState(this ProgressBar pBar, int state)
        {
            SendMessage(pBar.Handle, 1040, (IntPtr)state, IntPtr.Zero);
        }
    }
}
