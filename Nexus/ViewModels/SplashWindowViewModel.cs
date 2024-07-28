using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nexus.ViewModels
{
    public partial class SplashWindowViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string _startUpMessage = "Nexus is loading...";
    }
}
