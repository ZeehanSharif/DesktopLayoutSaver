using System;
using System.Linq;
using System.Windows;
using DesktopLayoutSaver;

namespace DesktopLayoutSaver
{
    public partial class MainWindow : Window
    {
        private ProfileManager _profileManager;

        public MainWindow()
        {
            InitializeComponent();
            _profileManager = new ProfileManager();
            LoadProfiles();
            ProfileNameTextBox.TextChanged += (s, e) => PlaceholderTextBlock.Visibility = string.IsNullOrEmpty(ProfileNameTextBox.Text) ? Visibility.Visible : Visibility.Hidden;
        }

        private void SaveProfileButton_Click(object sender, RoutedEventArgs e)
        {
            string profileName = ProfileNameTextBox.Text;
            if (string.IsNullOrWhiteSpace(profileName))
            {
                MessageBox.Show("Profile name cannot be empty.");
                return;
            }

            _profileManager.SaveProfile(profileName);
            LoadProfiles();
        }

        private void RestoreProfileButton_Click(object sender, RoutedEventArgs e)
        {
            string profileName = (string)ProfilesListBox.SelectedItem;
            if (profileName == null)
            {
                MessageBox.Show("Please select a profile to restore.");
                return;
            }

            _profileManager.RestoreProfile(profileName);
        }

        private void DeleteProfileButton_Click(object sender, RoutedEventArgs e)
        {
            string profileName = (string)ProfilesListBox.SelectedItem;
            if (profileName == null)
            {
                MessageBox.Show("Please select a profile to delete.");
                return;
            }

            _profileManager.DeleteProfile(profileName);
            LoadProfiles();
        }

        private void LoadProfiles()
        {
            ProfilesListBox.ItemsSource = _profileManager.GetProfiles();
        }
    }
}
