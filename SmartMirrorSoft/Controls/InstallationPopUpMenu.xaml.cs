using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace SmartMirrorSoft.Controls
{
    public sealed partial class InstallationPopUpMenu : UserControl
    {
        public static readonly DependencyProperty InstallCmdProperty = DependencyProperty.Register("InstallCmd", typeof(ICommand), typeof(InstallationPopUpMenu), null);

        public ICommand InstallCmd
        {
            get { return (ICommand)GetValue(InstallCmdProperty); }
            set { SetValue(InstallCmdProperty, value); }
        }

        public static readonly DependencyProperty UninstallCmdProperty = DependencyProperty.Register("UninstallCmd", typeof(ICommand), typeof(InstallationPopUpMenu), null);

        public ICommand UninstallCmd
        {
            get { return (ICommand)GetValue(UninstallCmdProperty); }
            set { SetValue(UninstallCmdProperty, value); }
        }

        //public static readonly DependencyProperty IconPathProperty = DependencyProperty.Register("IconPath", typeof(string), typeof(InstallationPopUpMenu), null);

        //public string IconPath
        //{
        //    get { return GetValue(IconPathProperty) as string; }
        //    set { SetValue(IconPathProperty, value); }
        //}
        
        public InstallationPopUpMenu()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }
    }
}
