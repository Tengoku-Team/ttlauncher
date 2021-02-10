﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTLauncher{
    class RegKeys{
        public void createRegistryKey(){
            RegistryKey regKey = Registry.CurrentUser.CreateSubKey("Software\\Tengoku-Team", true);
            RegistryKey settings = regKey.CreateSubKey("Launcher Settings", true);
            settings.SetValue("Nickname", "");
            regKey.Close();
        }

        public void updateRegistryKey(string name, string value){
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("Software\\Tengoku-Team", true);
            RegistryKey settings = regKey.OpenSubKey("Launcher Settings", true);
            settings.SetValue(name, value);
            regKey.Close();
        }

        public string getRegistryKey(string name){
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("Software\\Tengoku-Team", true);
            RegistryKey settings = regKey.OpenSubKey("Launcher Settings", true);
            string value = settings.GetValue(name).ToString();
            regKey.Close();
            return value;
        }
    }
}