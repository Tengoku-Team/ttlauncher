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
using Microsoft.Win32;

namespace TTLauncher{
    public partial class Form1 : Form{
        private string serverIp = "127.0.0.1";//ip адрес сервера
        private string serverPort = "7777";//порт сервера

        public Form1(){
            InitializeComponent();
            if (getRegistryKey("Nickname") == ""){
                createRegistryKey();
            }
            else{
                nicknameTextBox.Text = getRegistryKey("Nickname");
            }
        }

        private void playButton_Click(object sender, EventArgs e){
            if (nicknameTextBox.TextLength >= 3 && nicknameTextBox.TextLength <= 24){//проверка на длину никнейма
                string nickName = nicknameTextBox.Text;
                string path = "C:\\Users\\dimas\\Desktop\\gta-sa.exe.lnk";
                string arguments = $"\"{serverIp}:{serverPort}\" \"-n {nickName}\"";
                if(getRegistryKey("Nickname") != nickName){
                    updateRegistryKey("Nickname",nickName);
                }
                Process.Start(path, arguments);
            }
            else{
                MessageBox.Show("Длина никнейма может быть от 3-24 символов!");
            }
        }

        private void createRegistryKey(){
            RegistryKey regKey = Registry.CurrentUser.CreateSubKey("Software\\Tengoku-Team",true);
            RegistryKey settings = regKey.CreateSubKey("Launcher Settings",true);
            settings.SetValue("Nickname", "");
            regKey.Close();
        }

        private void updateRegistryKey(string name, string value){
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("Software\\Tengoku-Team",true);
            RegistryKey settings = regKey.OpenSubKey("Launcher Settings",true);
            settings.SetValue(name, value);
            regKey.Close();
        }

        private string getRegistryKey(string name){
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("Software\\Tengoku-Team",true);
            RegistryKey settings = regKey.OpenSubKey("Launcher Settings",true);
            string value = settings.GetValue(name).ToString();
            regKey.Close();
            return value;
        }
    }
}
