using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace DesktopLayoutSaver
{
    public class ProfileManager
    {
        private const string ProfileFilePath = "Profiles.json";
        private Dictionary<string, List<WindowInfo>> _profiles;

        public ProfileManager()
        {
            _profiles = new Dictionary<string, List<WindowInfo>>();
            LoadProfiles();
        }

        public void SaveProfile(string profileName)
        {
            var windows = WindowInfo.GetOpenWindows();
            _profiles[profileName] = windows;
            SaveProfiles();
        }

        public void RestoreProfile(string profileName)
        {
            if (_profiles.TryGetValue(profileName, out var windows))
            {
                foreach (var window in windows)
                {
                    window.Restore();
                }
            }
        }

        public void DeleteProfile(string profileName)
        {
            if (_profiles.Remove(profileName))
            {
                SaveProfiles();
            }
        }

        public List<string> GetProfiles()
        {
            return _profiles.Keys.ToList();
        }

        private void LoadProfiles()
        {
            if (File.Exists(ProfileFilePath))
            {
                var json = File.ReadAllText(ProfileFilePath);
                _profiles = JsonConvert.DeserializeObject<Dictionary<string, List<WindowInfo>>>(json) ?? new Dictionary<string, List<WindowInfo>>();
            }
        }

        private void SaveProfiles()
        {
            var json = JsonConvert.SerializeObject(_profiles, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(ProfileFilePath, json);
        }
    }
}
