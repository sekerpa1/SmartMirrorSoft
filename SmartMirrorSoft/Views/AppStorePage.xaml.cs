using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// Dokumentaci k šabloně Prázdná aplikace najdete na adrese https://go.microsoft.com/fwlink/?LinkId=234238

namespace SmartMirrorSoft.Views
{
    /// <summary>
    /// Prázdná stránka, která se dá použít samostatně nebo se na ni dá přejít v rámci
    /// </summary>
    public sealed partial class AppStorePage : Page
    {
        public AppStorePage()
        {
            this.InitializeComponent();
            //AllPrograms.Header = new BitmapImage(new Uri("ms-appx://SmartMirrorSoft/Icons/appbar.resource.group.png"));
            //InstalledPrograms.Header = new BitmapImage(new Uri("ms-appx://SmartMirrorSoft/Icons/appbar.resource.png"));
            //AvailablePrograms.Header = new BitmapImage(new Uri("ms-appx://SmartMirrorSoft/Icons/appbar.social.dropbox.png"));
            //AllPrograms.Source = new BitmapImage(new Uri("ms-appx://SmartMirrorSoft/Icons/appbar.resource.group.png"));
            //InstalledPrograms.Source = new BitmapImage(new Uri("ms-appx://SmartMirrorSoft/Icons/appbar.resource.png"));
            //AvailablePrograms.Source = new BitmapImage(new Uri("ms-appx://SmartMirrorSoft/Icons/appbar.social.dropbox.png"));

        }
    }
}
