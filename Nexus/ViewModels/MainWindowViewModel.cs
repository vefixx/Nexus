using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using Nexus.Helpers;
using System;
using System.Collections.ObjectModel;

namespace Nexus.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty]
        private NavigationItem _selectedNavigationItem;

        [ObservableProperty]
        private ViewModelBase _currentPage;

        public ObservableCollection<NavigationItem> NavigationItems = new()
        {
            new NavigationItem(typeof(HomePageViewModel), "home_regular")
        };
    }

    public class NavigationItem
    {
        public NavigationItem(Type viewModelType, string iconKey)
        {
            ViewModelType = viewModelType;
            Title = viewModelType.Name.Replace("PageViewModel", "");

            Application.Current!.TryFindResource(iconKey, out var res);
            NavigationItemIcon = (StreamGeometry)res!;

            Tag = viewModelType.Name.Replace("ViewModel", "");
        }

        public string Title { get; }
        public string Tag { get; }
        public StreamGeometry NavigationItemIcon { get; }
        public Type ViewModelType { get; }
    }
}
