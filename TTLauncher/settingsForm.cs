using System;
using System.Windows.Forms;

namespace TTLauncher{
    public partial class settingsForm : Form{
        public settingsForm(){
            InitializeComponent();
        }

        private void pathToGameButton_Click(object sender, EventArgs e){
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "SAMP|samp.exe";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK){
                pathToGameTextBox.Text = openFileDialog.FileName;
                RegKeys rg = new RegKeys();
                rg.updateRegistryKey("Path", openFileDialog.FileName);
            }
        }
    }
}
