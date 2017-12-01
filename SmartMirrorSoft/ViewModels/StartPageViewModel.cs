using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
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
        private INavigationService _NavigationService;

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
        public ICommand NavigateCommand
        {
            get
            {
                return new RelayCommand(() => _NavigationService.NavigateTo("AppStorePage"));
            }
        }

        //public ICommand StartCommand
        //{
        //    get
        //    {
        //        return new RelayCommand(async () =>
        //        {
        //            CoreApplicationView newView = CoreApplication.CreateNewView();
        //            int newViewId = 0;
        //            await newView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
        //            {
        //                Frame frame = new Frame();
        //                frame.Navigate(typeof(AppStorePage), null);
        //                Window.Current.Content = frame;
        //                // You have to activate the window in order to show it later.
        //                Window.Current.Activate();

        //                newViewId = ApplicationView.GetForCurrentView().Id;
        //            });
        //            bool viewShown = await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newViewId);
        //        });
        //    }
        //}

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

        public StartPageViewModel(INavigationService navigationService)
        {

            Title = "Hello Joel";
            FCPortCollection = new ObservableCollection<Module>();
            IconPath = new BitmapImage(new Uri("ms-appx://SmartMirrorSoft/Icons/store.png"));
            FCPortCollection.Add(new Module("anc", "ms-appx://SmartMirrorSoft/Icons/chrome_by_dtafalonso-d67pbhl.png"));
            FCPortCollection.Add(new Module("anc", "ms-appx://SmartMirrorSoft/Icons/niexjjzstcseuzdzkvoq.png"));
            FCPortCollection.Add(new Module("anc", "ms-appx://SmartMirrorSoft/Icons/calendar-512.png"));
            _NavigationService = navigationService;
        }
    }
}
