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

        public ObservableCollection<NavigationItem> NavigationItems { get; } = new()
        {
            new NavigationItem(typeof(HomePageViewModel), "Главная", "Home", "Об авторе, программе и условия пользования.")
        };

        partial void OnSelectedNavigationItemChanged(NavigationItem value)
        {
            if (value is null) return;

            var instance = Activator.CreateInstance(value.ViewModelType);

            if (instance is null) return;

            CurrentPage = (ViewModelBase)instance;
        }
    }

    public class NavigationItem
    {
        public NavigationItem(Type viewModelType, string title, string iconKey, string toolTipString)
        {
            ViewModelType = viewModelType;
            Title = title;

            NvItemIconSource = iconKey;

            Tag = viewModelType.Name.Replace("ViewModel", "");

            ToolTipString = toolTipString;
        }

        public string Title { get; }
        public string Tag { get; }
        public string NvItemIconSource { get; }
        public Type ViewModelType { get; }
        public string ToolTipString {  get; }
    }
}
