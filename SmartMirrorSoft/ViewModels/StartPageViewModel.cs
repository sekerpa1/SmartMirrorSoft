using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SmartMirrorSoft.Models;
using SmartMirrorSoft.Services;
using SmartMirrorSoft.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace SmartMirrorSoft.ViewModels
{
    public class StartPageViewModel : ViewModelBase
    {
        private bool _isLoading = false;
        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                _isLoading = value;
                RaisePropertyChanged("IsLoading");

            }
        }

        private string _title;
        public string Title
        {

            get
            {
                return _title;
            }
            set
            {
                if (value != _title)
                {
                    _title = value;
                    RaisePropertyChanged("Title");
                }
            }
        }

        public ICommand StartCommand
        {
            get
            {
                return new RelayCommand(async () =>
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
        }

        private ImageSource _IconPath;
        public ImageSource IconPath
        {

            get
            {
                return _IconPath;
            }
            set
            {
                if (value != _IconPath)
                {
                    _IconPath = value;
                    RaisePropertyChanged("IconPath");
                }
            }
        }

        private int _IconWidth;
        public int IconWidth
        {

            get
            {
                return _IconWidth;
            }
            set
            {
                if (value != _IconWidth)
                {
                    _IconWidth = value;
                    RaisePropertyChanged("IconWidth");
                }
            }
        }


        private ObservableCollection<Module> _FCPortCollection;
        public ObservableCollection<Module> FCPortCollection
        {
            get
            {
                return _FCPortCollection;
            }
            set
            {
                _FCPortCollection = value;
                RaisePropertyChanged("FCPortCollection");

            }
        }

        public StartPageViewModel()
        {

            Title = "Hello Joel";
            IconPath = new BitmapImage(new Uri("ms-appx://SmartMirrorSoft/Icons/appbar.paw.png"));
            FCPortCollection = new ObservableCollection<Module>();
            FCPortCollection.Add(new Module("anc", "ms-appx://SmartMirrorSoft/Icons/appbar.paw.png"));
            FCPortCollection.Add(new Module("anc", "ms-appx://SmartMirrorSoft/Icons/002-moai.png"));
            FCPortCollection.Add(new Module("anc", "ms-appx://SmartMirrorSoft/Icons/005-map.png"));
            FCPortCollection.Add(new Module("anc", "ms-appx://SmartMirrorSoft/Icons/005-map.png"));
            FCPortCollection.Add(new Module("anc", "ms-appx://SmartMirrorSoft/Icons/005-map.png"));
            FCPortCollection.Add(new Module("anc", "ms-appx://SmartMirrorSoft/Icons/005-map.png"));
            FCPortCollection.Add(new Module("anc", "ms-appx://SmartMirrorSoft/Icons/005-map.png"));
            FCPortCollection.Add(new Module("anc", "ms-appx://SmartMirrorSoft/Icons/005-map.png"));
            FCPortCollection.Add(new Module("anc", "ms-appx://SmartMirrorSoft/Icons/005-map.png"));
            FCPortCollection.Add(new Module("anc", "ms-appx://SmartMirrorSoft/Icons/005-map.png"));
        }
    }
}
