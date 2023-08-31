using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValheimServer.ViewModels
{
    public partial class MainWindowViewModel: ObservableObject
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

        private string _userInputTextBox = "Text goes here";

        public string UserInputTextBox
        {
            get
            {
                return _userInputTextBox;
            }

            set
            { 
                _userInputTextBox = value; 
            }

        }


    }
}
