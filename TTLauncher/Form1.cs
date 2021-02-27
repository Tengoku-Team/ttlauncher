using System;
using System.Windows.Forms;
using System.Diagnostics;
using SampQueryApi;
using System.Collections.Generic;

namespace TTLauncher{
    public partial class Form1 : Form{
        private string serverIp = "127.0.0.1";//ip адрес сервера
        private ushort serverPort = 7777;//порт сервера

        private string serverSite = "https://github.com/Tengoku-Team";//Ссылка на сайт
        private string serverVk = "https://vk.com/d1maz.community";//Ссылка на ВК

        List<string> serverInfo = new List<string>();

        ListViewItem playersItem;

        public Form1(){
            if (serverIp != "localhost" && serverIp != "127.0.0.1"){
                SampQuery api = new SampQuery(serverIp, serverPort, 'i');
                foreach (KeyValuePair<string, string> kvp in api.read(true)){
                    if (kvp.Key == "gamemode" || kvp.Key == "players" || kvp.Key == "maxplayers" || kvp.Key == "hostname"){
                        serverInfo.Add(kvp.Value);
                    }
                }
                if (serverInfo.Count >= 1){
                    InitializeComponent();
                    versionLabel.Text = ProductVersion;
                    authorLabel.Text = CompanyName;
                    if ((serverInfoListView.Width + serverInfo[2].Length) > Width){
                        Width += serverInfo[2].Length;
                        serverInfoListView.Width += serverInfo[2].Length;
                    }
                    serverInfoListView.Items.Add("Название: " + serverInfo[2]);
                    serverInfoListView.Items.Add("Название мода: " + serverInfo[3]);
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
                else{
                    MessageBox.Show("Недостаточно данных о сервере для запуска лаунчера!\n\nВозможно сервер отключен.");
                    Close();
                }
            }
            else{
                MessageBox.Show("Для вывода данных сервера не должен использоваться локальный хостинг!");
                Close();
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

        private void webButton_Click(object sender, EventArgs e){
            Process.Start(serverSite);
        }

        private void button1_Click(object sender, EventArgs e){
            Process.Start(serverVk);
        }
    }
}