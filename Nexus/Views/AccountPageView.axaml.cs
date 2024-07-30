using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Nexus.ViewModels;
using System;
using System.ComponentModel;

namespace Nexus.Views;

public partial class AccountPageView : UserControl { 
    private AccountPageViewModel viewModel = new AccountPageViewModel();
    public AccountPageView()
    {
        InitializeComponent();

        viewModel.PropertyChanged += ViewModel_PropertyChanged;

        viewModel.IsLogin = true;
}

    private void ViewModel_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(viewModel.IsLogin))
        {
            UpdateUI();
        }
    }

    private void UpdateUI()
    {
        Grid headerGrid = this.FindControl<Grid>("HeaderGrid")!;

        Button buttonLogin = new Button()
        {
            HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Right,
            Margin = new Thickness(left: 0, top: 10, right: 20, bottom: 0)
        };

        if (!viewModel.IsLogin)
        {
            buttonLogin.Content = "Войти";
            buttonLogin.Command = viewModel.OpenLoginPageCommand;
        } 
        else
        {
            buttonLogin.Content = viewModel.Username;
        }

        Grid.SetRow(buttonLogin, 0);

        headerGrid.Children.Add(buttonLogin);

    }
}