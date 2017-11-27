using GalaSoft.MvvmLight.Command;
using SmartMirrorSoft.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SmartMirrorSoft.Programs
{
    /// <summary>
    /// Class launches Calculator. It's example of an app for testing purposes.
    /// </summary>
    public class Calculator : Models.BaseRunnableApp
    {
        public Calculator() : base()
        {
            cmd = new RelayCommand(async () =>
            {
                CoreApplicationView newView = CoreApplication.CreateNewView();
                int newViewId = 0;
                await newView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    Frame frame = new Frame();
                    frame.Navigate(typeof(CalculatorPage), null);
                    Window.Current.Content = frame;
                    // You have to activate the window in order to show it later.
                    Window.Current.Activate();

                    newViewId = ApplicationView.GetForCurrentView().Id;
                });
                bool viewShown = await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newViewId);
            });
        }

        private ICommand cmd;

        public override ICommand LaunchAppCmd
        {
            get
            {
                return cmd;
            }
        }
            
    }
}
