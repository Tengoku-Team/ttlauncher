using Microsoft.Win32;

namespace TTLauncher{
    class RegKeys{
        public void createRegistryKey(){
            RegistryKey regKey = Registry.CurrentUser.CreateSubKey("Software\\Tengoku-Team", true);
            RegistryKey settings = regKey.CreateSubKey("Launcher Settings", true);
            settings.SetValue("Nickname", "");
            settings.SetValue("Path", "");
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

        public bool existRegistryKey(){
            if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\Tengoku-Team\Launcher Settings", "Nickname", null) == null){
                return false;
            }
            return true;
        }
    }
}
