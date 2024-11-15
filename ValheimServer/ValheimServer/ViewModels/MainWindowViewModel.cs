using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
    /// <summary>
    /// Represents the main window view model.
    /// </summary>
    public partial class MainWindowViewModel : ObservableObject
    {
        private bool _uselessCheckBox = false;
        private string _installFolder;
        private string _serverTextBox;
        private string _folderName;
        private string _portTextBox;
        private string _worldTextBox;
        private string _passwordTextBox;
        private string _hiddenTextBox;
        private bool _serverVisibilityCheckBox = true;
        private bool _serverCrossPlayCheckBox = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        public MainWindowViewModel()
        {
            _installFolder = AppSettings.Default.InstallFolder;
            _serverTextBox = AppSettings.Default.ServerName;
            _passwordTextBox = AppSettings.Default.Password;
            _portTextBox = AppSettings.Default.PortNumber;
            _worldTextBox = AppSettings.Default.WorldName;
            _serverVisibilityCheckBox = AppSettings.Default.ServerVisibility;

            // insert commented code once crossplay code is merged
            // _serverCrossPlayCheckBox = AppSettings.Default.Crossplay;
            _folderName = string.Empty;
            _hiddenTextBox = string.Empty;
        }

        /// <summary>
        /// Gets or Sets a value indicating whether the Checkbox is checked.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the install folder.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the server name.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the folder name.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the port number.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the world name.
        /// </summary>
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

        /// <summary>
        /// Gets or Sets the password.
        /// </summary>
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

        /// <summary>
        /// Gets or Sets the hidden text box.
        /// </summary>
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

        /// <summary>
        /// Gets or Sets a value indicating whether the checkbox is visible.
        /// </summary>
        public bool ServerVisibilityCheckBox
        {
            get
            {
                return _serverVisibilityCheckBox;
            }

            set
            {
                SetProperty(ref _serverVisibilityCheckBox, value);
            }
        }

        /// <summary>
        /// Gets or Sets a value indicating whether the checkbox is visible.
        /// </summary>
        public bool ServerCrossPlayCheckBox
        {
            get
            {
                return _serverCrossPlayCheckBox;
            }

            set
            {
                SetProperty(ref _serverCrossPlayCheckBox, value);
            }
        }

        private int ServerVisibiltyCheck
        {
            get
            {
                if (_serverVisibilityCheckBox == true)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        private string ServerCrossPlayCheck
        {
            get
            {
                if (_serverCrossPlayCheckBox == true)
                {
                    return "-crossplay";
                }
                else
                {
                    return " ";
                }
            }
        }

        [RelayCommand]
        private void SteamButtonClick()
        {
            Process.Start("steamcmd.exe", "+quit");
        }

        [RelayCommand]
        private void UpdateValheimButtonClick()
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            var result = folderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                InstallFolder = folderBrowserDialog.SelectedPath;
                AppSettings.Default.InstallFolder = InstallFolder;
                AppSettings.Default.Save();
            }

            Process.Start("steamcmd.exe", $"+login anonymous +force_install_dir {_installFolder} +app_update 896660 validate +quit");
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

        [RelayCommand]
        private void ServerStartButtonClick()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $@"/K set SteamAppId=892970 && {_installFolder}\\valheim_server.exe -nographics -batchmode -name ""{_serverTextBox}"" -port {_portTextBox} -world ""{_worldTextBox}"" -password ""{_passwordTextBox}"" -public {ServerVisibiltyCheck} {ServerCrossPlayCheck}",
                UseShellExecute = false,
            };

            Process.Start(startInfo);

            AppSettings.Default.ServerName = ServerTextBox;
            AppSettings.Default.Password = PaswordTextBox;
            AppSettings.Default.PortNumber = PortTextBox;
            AppSettings.Default.WorldName = WorldTextBox;
            AppSettings.Default.ServerVisibility = ServerVisibilityCheckBox;

            // insert commented code once crossplay code is merged
            // AppSettings.Default.Crossplay = ServerCrossPlayCheckBox;
            AppSettings.Default.Save();
        }
    }
}
