using System;
using System.Windows.Forms;
using System.Diagnostics;
using SampQueryApi;
using System.Collections.Generic;

namespace TTLauncher{
    public partial class Form1 : Form{
        private string serverIp = "185.169.134.4";//ip адрес сервера
        private ushort serverPort = 7777;//порт сервера

        List<string> serverInfo = new List<string>();

        ListViewItem playersItem;

        public Form1(){
            InitializeComponent();
            versionLabel.Text = ProductVersion;
            authorLabel.Text = CompanyName;
            SampQuery api = new SampQuery(serverIp,serverPort, 'i');
            foreach (KeyValuePair<string, string> kvp in api.read(true)){
                if (kvp.Key == "gamemode" || kvp.Key == "players" || kvp.Key == "maxplayers" || kvp.Key == "hostname"){
                    serverInfo.Add(kvp.Value);
                }
            }
            if ((serverInfoListView.Width + serverInfo[2].Length) > Width){
                Width += serverInfo[2].Length;
                serverInfoListView.Width += serverInfo[2].Length;
            }
            ListViewItem hostnameItem = serverInfoListView.Items.Add("Название: " + serverInfo[2]);
            ListViewItem gamemodeItem = serverInfoListView.Items.Add("Название мода: " + serverInfo[3]);
            playersItem = serverInfoListView.Items.Add("Игроки: " + serverInfo[0] + "/" + serverInfo[1]);
            serverInfo.Clear();
            refreshServerInfoTimer.Start();
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
            if (rg.getRegistryKey("Path").Length >= 1){
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

        private void refreshServerInfoTimer_Tick(object sender, EventArgs e){            
            SampQuery api = new SampQuery(serverIp, serverPort, 'i');
            foreach (KeyValuePair<string, string> kvp in api.read(true)){
                if (kvp.Key == "players" || kvp.Key == "maxplayers"){
                    serverInfo.Add(kvp.Value);
                }
            }
            if(serverInfo.Count == 2){
                playersItem.Text = "Игроки: " + serverInfo[0] + "/" + serverInfo[1];
            }
            serverInfo.Clear();
        }

        private void Form1_Activated(object sender, EventArgs e){
            if (!refreshServerInfoTimer.Enabled){
                refreshServerInfoTimer.Start();
            }
        }

        private void Form1_Deactivate(object sender, EventArgs e){
            if (refreshServerInfoTimer.Enabled){
                refreshServerInfoTimer.Stop();
            }
        }
    }
}