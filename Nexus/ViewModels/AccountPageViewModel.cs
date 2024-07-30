using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluentAvalonia.UI.Controls;
using Nexus.ViewModels.Dialogs;
using Nexus.Views.Dialogs;
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
        private string _username = "vefixx";

        [ObservableProperty]
        private string _countCreatedPosts = "0";

        [ObservableProperty]
        public string _countMaxPosts = "3";

        [ObservableProperty]
        private string _countMaxPostsString;

        [ObservableProperty]
        private string _countSentPosts = "0";

        public AccountPageViewModel()
        {
            _countMaxPostsString = $"из {_countMaxPosts}";
        }

        [RelayCommand]
        private void OpenLoginPage()
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://vscripts.ru/login",
                UseShellExecute = true
            });
        }

        [RelayCommand]
        private async void ShowTokenWriteDialogAsync()
        {
            var dialog = new ContentDialog()
            {
                Title = "Добавление токена",
                PrimaryButtonText = "Отправить",
                CloseButtonText = "Отменить"
            };

            var dialogViewModel = new TokenDialogViewModel();

            dialog.Content = new TokenDialogView()
            {
                DataContext = dialogViewModel
            };

            var result = await dialog.ShowAsync();
        }
    }
}
