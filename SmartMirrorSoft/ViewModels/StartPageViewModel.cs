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

            BitmapImage image = new BitmapImage();
            image.UriSource = new Uri("C://Users//Pavol//Documents//Visual Studio 2017//Projects//SmartMirrorSoft//SmartMirrorSoft//Icons//004-sunset.png");
            IconPath = image;

            FCPortCollection = new ObservableCollection<Module>();
            FCPortCollection.Add(new Module("anc", "C://Users//Pavol//Documents//Visual Studio 2017//Projects//SmartMirrorSoft//SmartMirrorSoft//Icons//004-sunset.png"));
            FCPortCollection.Add(new Module("anc", "C://Users//Pavol//Documents//Visual Studio 2017//Projects//SmartMirrorSoft//SmartMirrorSoft//Icons//004-sunset.png"));
            FCPortCollection.Add(new Module("anc", "C://Users//Pavol//Documents//Visual Studio 2017//Projects//SmartMirrorSoft//SmartMirrorSoft//Icons//004-sunset.png"));
        }
    }
}
