using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace SmartMirrorSoft.ViewModels
{
    public class AppStoreViewModel : ViewModelBase
    {
        private ImageSource _InstalledAppsIcon;
        public ImageSource InstalledAppsIcon
        {

            get
            {
                return _InstalledAppsIcon;
            }
            set
            {
                if (value != _InstalledAppsIcon)
                {
                    _InstalledAppsIcon = value;
                    RaisePropertyChanged("InstalledAppsIcon");
                }
            }
        }

        private ImageSource _AvailableAppsIcon;
        public ImageSource AvailableAppsIcon
        {

            get
            {
                return _AvailableAppsIcon;
            }
            set
            {
                if (value != _AvailableAppsIcon)
                {
                    _AvailableAppsIcon = value;
                    RaisePropertyChanged("AvailableAppsIcon");
                }
            }
        }

        private ImageSource _AllAppsIcon;
        public ImageSource AllAppsIcon
        {

            get
            {
                return _AllAppsIcon;
            }
            set
            {
                if (value != _AllAppsIcon)
                {
                    _AllAppsIcon = value;
                    RaisePropertyChanged("AllAppsIcon");
                }
            }
        }

        public AppStoreViewModel()
        {
            InstalledAppsIcon = new BitmapImage(new Uri("ms-appx://SmartMirrorSoft/Icons/appbar.social.dropbox.png"));
            AllAppsIcon = new BitmapImage(new Uri("ms-appx://SmartMirrorSoft/Icons/appbar.resource.group.png"));
            AvailableAppsIcon = new BitmapImage(new Uri("ms-appx://SmartMirrorSoft/Icons/appbar.resource.png"));
        }

    }
}
