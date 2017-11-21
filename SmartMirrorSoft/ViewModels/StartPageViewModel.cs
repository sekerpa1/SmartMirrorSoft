using GalaSoft.MvvmLight;
using SmartMirrorSoft.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            
            FCPortCollection = new ObservableCollection<Module>();
            FCPortCollection.Add(new Module("anc", "ms-appx://SmartMirrorSoft/Icons/001-sunset-1.png"));
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
