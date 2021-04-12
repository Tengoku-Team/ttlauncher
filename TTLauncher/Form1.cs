using System;
using System.Windows.Forms;
using System.Diagnostics;
using SampQueryApi;
using System.Collections.Generic;
using System.Net;

namespace TTLauncher{
    public partial class Form1 : Form{
        private ushort[] serversPort = { 7777 , 7777};
        private string[] serversIp = { "185.169.134.3", "185.169.134.59" };
        private string[] serversName = { "Phoenix" , "Mesa"};

        private int selectedServer = 0;

        private string serverSite = "https://github.com/Tengoku-Team";//Ссылка на сайт
        private string serverVk = "https://vk.com/d1maz.community";//Ссылка на ВК

        List<string> serverInfo = new List<string>();

        ListViewItem nameServerItem;
        ListViewItem nameModeItem;
        ListViewItem playersItem;
        
        public Form1(){
            if ((serversPort.Length == serversIp.Length) && (serversIp.Length == serversName.Length)){
                for (int i = 0; i < serversIp.Length; i++){
                    if (!IPAddress.TryParse(serversIp[i].ToString(), out _)){
                        MessageBox.Show("В списке серверов не найдено ни одного сервера,\nлибо один из серверов имеет неверный формат адреса!");
                        Close();
                        break;
                    }
                }
                RegKeys rg = new RegKeys();
                selectedServer = Convert.ToInt32(rg.getRegistryKey("SelectedServer"));
                if (serversIp[selectedServer] != "127.0.0.1"){
                    getServerStats(selectedServer, true);
                    if (serverInfo.Count >= 1){
                        InitializeComponent();
                        for (int i = 0; i < serversIp.Length; i++){
                            serversComboBox.Items.Add(serversName[i] + " #" + (i + 1) + " " + serversIp[i] + ":" + serversPort[i]);
                        }
                        serversComboBox.SelectedIndex = selectedServer;
                        versionLabel.Text = ProductVersion;
                        authorLabel.Text = CompanyName;
                        if ((serverInfoListView.Width + serverInfo[2].Length) > Width){
                            Width += serverInfo[2].Length;
                            serverInfoListView.Width += serverInfo[2].Length;
                            serversComboBox.Width += serverInfo[2].Length;
                        }
                        serverInfo.Clear();
                        refreshServerInfoTimer.Start();
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
        }
        
        private void getServerStats(int serverId, bool fullStats){
            SampQuery api = new SampQuery(serversIp[serverId], serversPort[serverId], 'i');
            if (fullStats){
                foreach (KeyValuePair<string, string> kvp in api.read(true)){
                    if (kvp.Key == "gamemode" || kvp.Key == "players" || kvp.Key == "maxplayers" || kvp.Key == "hostname"){
                        serverInfo.Add(kvp.Value);
                    }
                }
            }
            else{
                foreach (KeyValuePair<string, string> kvp in api.read(true)){
                    if (kvp.Key == "players" || kvp.Key == "maxplayers"){
                        serverInfo.Add(kvp.Value);
                    }
                }
            }
        }

        private void playButton_Click(object sender, EventArgs e){
            RegKeys rg = new RegKeys();
            if (rg.getRegistryKey("Path").Length >= 1){
                if (System.IO.File.Exists(rg.getRegistryKey("Path"))){
                    if (nicknameTextBox.TextLength >= 3 && nicknameTextBox.TextLength <= 24){//проверка на длину никнейма
                        string nickName = nicknameTextBox.Text;
                        string path = rg.getRegistryKey("Path");
                        string arguments = $"\"{serversIp[selectedServer]}:{serversPort[selectedServer]}\" \"-n {nickName}\"";
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
            getServerStats(selectedServer, false);
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

        private void serversComboBox_SelectedIndexChanged(object sender, EventArgs e){
            selectedServer = serversComboBox.SelectedIndex;
            RegKeys rg = new RegKeys();
            rg.updateRegistryKey("SelectedServer", selectedServer.ToString());
            getServerStats(selectedServer, true);
            serverInfoListView.Items.Clear();
            nameServerItem = serverInfoListView.Items.Add("Название: " + serverInfo[2]);
            nameModeItem = serverInfoListView.Items.Add("Название мода: " + serverInfo[3]);
            playersItem = serverInfoListView.Items.Add("Игроки: " + serverInfo[0] + "/" + serverInfo[1]);
        }
    }
}