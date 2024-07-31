using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluentAvalonia.UI.Controls;
using Nexus.ViewModels.DialogsViewModels;
using Nexus.Views.DialogsViews;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus.ViewModels
{
    public partial class AccountPageViewModel : ViewModelBase
    {
        [ObservableProperty]
        private bool _isLogin;

        [ObservableProperty]
        private string _username;

        [RelayCommand]
        private async void ShowAccountInfoDialogAsync()
        {
            ViewModelBase dialogViewModel = new AccountInfoDialogViewModel();

            ContentDialog dialog = new ContentDialog()
            {
                Title = "Аккаунт",
                CloseButtonText = "Закрыть"
            };

            dialog.Content = new AccountInfoDialogView()
            {
                DataContext = dialogViewModel
            };

            await dialog.ShowAsync();
        }
    }
}
