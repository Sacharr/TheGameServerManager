using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValheimServer.ViewModels
{
    public class MainWindowViewModel
    {
        private string _steamButtonText = "Update SteamCmd";
        public string SteamButtonText
        { 
            get { return _steamButtonText; }
        }
        
    }
}
