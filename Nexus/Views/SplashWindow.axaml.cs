using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Chrome;
using Avalonia.Markup.Xaml;
using FluentAvalonia.UI.Windowing;

namespace Nexus;

public partial class SplashWindow : AppWindow
{
    public SplashWindow()
    {
        InitializeComponent();

        TitleBar.ExtendsContentIntoTitleBar = true;
        TitleBar.TitleBarHitTestType = TitleBarHitTestType.Complex;
    }
}