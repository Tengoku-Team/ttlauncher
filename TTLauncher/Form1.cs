using System;
using System.Windows.Forms;
using System.Diagnostics;
using SampQueryApi;
using System.Collections.Generic;

namespace TTLauncher{
    public partial class Form1 : Form{
        //private string serverIp = "185.169.134.83";//ip адрес сервера
        private string serverIp = "46.174.52.246";//ip адрес сервера
        private ushort serverPort = 7777;//порт сервера

        List<string> serverInfo = new List<string>();

        public Form1(){
            InitializeComponent();
            SampQuery api = new SampQuery(serverIp,serverPort, 'i');
            foreach (KeyValuePair<string, string> kvp in api.read(true)){
                serverInfo.Add(kvp.Value);
            }
            if ((serverInfoListView.Width + serverInfo[3].Length) > Width){
                Width += serverInfo[3].Length;
                serverInfoListView.Width += serverInfo[3].Length;
            }
            serverInfoListView.Items.Add("Название: " + serverInfo[3]);
            serverInfoListView.Items.Add("Название мода: " + serverInfo[4]);
            serverInfoListView.Items.Add("Игроки: " + serverInfo[1] + "/" + serverInfo[2]);
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
                if (System.IO.File.Exists(rg.getRegistryKey("Path"))){
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
                    MessageBox.Show("Путь к игре указан неверно!");
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