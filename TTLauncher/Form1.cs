using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using SampQueryApi;

namespace TTLauncher{
    public partial class Form1 : Form{
        private string serverIp = "127.0.0.1";
        private string serverPort = "7777";

        public Form1(){
            InitializeComponent();
        }

        private void playButton_Click(object sender, EventArgs e){
            if (nicknameTextBox.TextLength >= 3 && nicknameTextBox.TextLength <= 24){
                string nickName = nicknameTextBox.Text;
                string path = "C:\\Users\\dimas\\Desktop\\gta-sa.exe.lnk";
                string arguments = $"\"{serverIp}:{serverPort}\" \"-n {nickName}\"";
                Process.Start(path, arguments);
            }
            else{
                MessageBox.Show("Длина никнейма может быть от 3-24 символов!");
            }
        }
    }
}
