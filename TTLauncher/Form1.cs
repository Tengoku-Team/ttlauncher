using System;
using System.Windows.Forms;
using System.Diagnostics;
using SampQueryApi;

namespace TTLauncher{
    public partial class Form1 : Form{
        private string serverIp = "127.0.0.1";//ip адрес сервера
        private string serverPort = "7777";//порт сервера

        public Form1(){
            InitializeComponent();
            RegKeys rg = new RegKeys();
            if (rg.existRegistryKey()){
                nicknameTextBox.Text = rg.getRegistryKey("Nickname");
            }
            else{
                rg.createRegistryKey();
            }
        }

        private void playButton_Click(object sender, EventArgs e){
            RegKeys rg = new RegKeys();
            if (rg.getRegistryKey("Path") != ""){
                if (nicknameTextBox.TextLength >= 3 && nicknameTextBox.TextLength <= 24){//проверка на длину никнейма
                    string nickName = nicknameTextBox.Text;
                    string path = rg.getRegistryKey("Path");
                    string arguments = $"\"{serverIp}:{serverPort}\" \"-n {nickName}\"";
                    if (rg.getRegistryKey("Nickname") != nickName){
                        rg.updateRegistryKey("Nickname", nickName);
                    }
                    Process.Start(path, arguments);
                }
                else{
                    MessageBox.Show("Длина никнейма может быть от 3-24 символов!");
                }
            }
            else{
                MessageBox.Show("Вы не указали путь к игре!");
            }
        }

        private void settingsButton_Click(object sender, EventArgs e){
            settingsForm sf = new settingsForm();
            RegKeys rg = new RegKeys();
            sf.pathToGameTextBox.Text = rg.getRegistryKey("Path"); 
            sf.Show();
        }
    }
}