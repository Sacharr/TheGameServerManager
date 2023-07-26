using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ValheimServer.ViewModels
{
    public partial class MainWindowViewModel
    {
        private string _steamButtonText = "Update SteamCmd";
        public string SteamButtonText
        {
            get { return _steamButtonText; }
        }

        [RelayCommand]
        private void SteamButtonClick()
        {
            Process.Start("steamcmd.exe", "+quit");
        }

    }
}
