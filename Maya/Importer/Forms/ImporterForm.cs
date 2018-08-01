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

namespace Maya2Babylon.Importer.Forms
{
    public partial class ImporterForm : Form
    {
        public event Action On_importerFormClosed;
        private BabylonImporter importer;

        public ImporterForm()
        {
            InitializeComponent();

            //txtFilename.GotFocus += ;
            //txtFilename.LostFocus += ;
        }



        private void butImport_Click(object sender, EventArgs e)
        {
            // check the values
            string file = txtFilename.Text;
            // show an error if any
            if (!ValidateFile(txtFilename.Text, out string errorMsg))
            {
                // Cancel the event and select the text to be corrected by the user.
                txtFilename.Select(0, txtFilename.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                errorProviderFileName.SetError(labelFileName, errorMsg);
            }


            // else call the importer

            importer = new BabylonImporter();

            bool success = importer.ImportGLTF(file);
        }

        private void butBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            //openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "glTF files (*.gltf;*.glb)|*.gltf;*.glb|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    txtFilename.Text = openFileDialog.FileName;
                    ClearError();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void ImporterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            On_importerFormClosed();
        }

        private bool ValidateFile(string file, out string errorMsg)
        {
            if(file == "")
            {
                errorMsg = "Required";
                return false;
            }

            if (!File.Exists(file))
            {
                errorMsg = "Invalid file";
                return false;
            }

            errorMsg = "";
            return true;
        }

        private void ClearError()
        {
            errorProviderFileName.SetError(labelFileName, "");
        }
    }
}
