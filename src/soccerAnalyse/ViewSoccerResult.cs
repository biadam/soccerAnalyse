using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace soccerAnalyse
{
    public partial class ViewSoccerResult : Form
    {
        private string _appPath = Path.GetDirectoryName(Application.ExecutablePath);
        private IList<SoccerResultsItem> soccerResultTable = new List<SoccerResultsItem>();
        private AnaylseSoccerData analyser = new AnaylseSoccerData();
        public ViewSoccerResult()
        {
            InitializeComponent();
            dataGridViewSoccerResult.DataSource = soccerResultTable;
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = _appPath;
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                AnalyseAndShowData(openFileDialog.FileName);
            }
        }

        //Function analyse Data of selected File and in Sucess show Data in DataGrid
        private void AnalyseAndShowData(string fileName)
        {
            var resultMsg = "";
            if (!analyser.AnalyseFile(fileName, out resultMsg))
            {
                MessageBox.Show(resultMsg, "Fehler bei der Analyse", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGridViewSoccerResult.DataSource = null;
                lblFilename.Text = "";
            }
            else
            {
                dataGridViewSoccerResult.DataSource = analyser.GetSoccerResultTableList();
                lblFilename.Text = Path.GetFileName(fileName);
            }
        }

        private void btnExportData_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = _appPath;
            saveFileDialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //write Result to XML File
                    if (analyser.WriteDataToFile(saveFileDialog.FileName))
                    {
                        MessageBox.Show("Datei wurde erfolgreich geschrieben", "Erfolgreich", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Fehler beim Schreiben", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


    }
}
