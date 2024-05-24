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

namespace ValheimServer.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {

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
            Process.Start("steamcmd.exe", "+login anonymous +force_install_dir \"C:\\ValheimServer\" +app_update 896660 validate +quit");
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
            Process.Start("C:\\valheimserver\\valheim_server.exe", "-nographics -batchmode -name \"USER_ENTERED_NAME\" -port USER_ENTERED_PORT -world \"USER_ENTERED_WORLD\" -password \"USER_ENTERED_PW\" -public 1\"");
        }


    }

}
