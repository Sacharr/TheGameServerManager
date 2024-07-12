using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
//using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Windows.Media.Animation;

namespace ValheimServer.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {

        public MainWindowViewModel()
        {

            _installFolder = AppSettings.Default.InstallFolder;

        }

        [RelayCommand]
        private void SteamButtonClick()
        {
            Process.Start("steamcmd.exe", "+quit");
        }
        private bool _uselessCheckBox = false;

        public bool UselessCheckBox
        {
            get
            {
                return _uselessCheckBox;
            }

            set
            {
                SetProperty(ref _uselessCheckBox, value);
            }
        }

        [RelayCommand]
        private void UpdateValheimButtonClick()
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            var result = folderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                InstallFolder = folderBrowserDialog.SelectedPath;

            }
            
            Process.Start("steamcmd.exe", $"+login anonymous +force_install_dir {_installFolder} +app_update 896660 validate +quit");
        }

        private string _installFolder;

        public string InstallFolder
        {
            get
            {
                return _installFolder;
            }

            set
            {
                SetProperty(ref _installFolder, value);
            }
        }


        private string _serverTextBox;

        public string ServerTextBox
        {
            get
            {
                return _serverTextBox;
            }

            set
            {
                SetProperty(ref _serverTextBox, value);
            }
        }

        [RelayCommand]
        private void OpenFileDialogClick()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
        }

        [RelayCommand]
        private void FolderBrowserDialogClick()
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            var result = folderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                FolderName = folderBrowserDialog.SelectedPath;
            }
        }


        private string _folderName;

        public string FolderName
        {
            get
            {
                return _folderName;
            }

            set
            {
                SetProperty(ref _folderName, value);
            }
        }

        private string _portTextBox;

        public string PortTextBox
        {
            get
            {
                return _portTextBox;
            }

            set
            {
                SetProperty(ref _portTextBox, value);
            }
        }

        private string _worldTextBox;

        public string WorldTextBox
        {
            get
            {
                return _worldTextBox;
            }

            set
            {
                SetProperty(ref _worldTextBox, value);
            }

        }

        private string _passwordTextBox;

        public string PaswordTextBox
        {
            get
            {
                return _passwordTextBox;
            }

            set
            {
                SetProperty(ref _passwordTextBox, value);
            }

        }

        private string _hiddenTextBox;

        public string HiddenTextBox
        {
            get
            {
                return _hiddenTextBox;
            }

            set
            {
                SetProperty(ref _hiddenTextBox, value);
            }

        }


        [RelayCommand]
        private void ServerStartButtonClick()
        {
        
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $@"/K set SteamAppId=892970 && {_installFolder}\\valheim_server.exe -nographics -batchmode -name ""{ _serverTextBox }"" -port {_portTextBox} -world ""{_worldTextBox}"" -password ""{_passwordTextBox}"" -public 1",
                UseShellExecute = false
            };
           
            Process.Start(startInfo);


        }


    }

}
