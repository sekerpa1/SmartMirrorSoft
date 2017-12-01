using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using SmartMirrorSoft.Models;
using SmartMirrorSoft.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace SmartMirrorSoft.ViewModels
{
    public class AppStoreViewModel : ViewModelBase
    {

        private INavigationService _NavigationService;
        private IRegistrationService _RegistrationService;
        private IValueConverter _PathToIconConverter;
        
        private ObservableCollection<BaseRunnableApp> _Programs;
        private ObservableCollection<BaseRunnableApp> _InstalledPrograms;
        private ObservableCollection<BaseRunnableApp> _AvailablePrograms;
        private BaseRunnableApp _SelectedProgram;

        public ICommand NavigateCommand
        {
            get
            {
                return new RelayCommand(() => _NavigationService.NavigateTo("StartPage"));
            }
        }

        public IValueConverter PathToIconConverter
        {
            get
            {
                return _PathToIconConverter;
            }
            set
            {
                _PathToIconConverter = value;
                RaisePropertyChanged("PathToIconConverter");
            }
        }

        public BaseRunnableApp SelectedProgram
        {
            get
            {
                return _SelectedProgram;
            }
            set
            {
                _SelectedProgram = value;
                RaisePropertyChanged("SelectedProgram");

            }
        }

        public ObservableCollection<BaseRunnableApp> Programs
        {
            get
            {
                return _Programs;
            }
            set
            {
                _Programs = value;
                RaisePropertyChanged("Programs");

            }
        }

        public ObservableCollection<BaseRunnableApp> InstalledPrograms
        {
            get
            {
                return _InstalledPrograms;
            }
            set
            {
                _InstalledPrograms = value;
                RaisePropertyChanged("Programs");

            }
        }

        public ObservableCollection<BaseRunnableApp> AvailablePrograms
        {
            get
            {
                return _AvailablePrograms;
            }
            set
            {
                _AvailablePrograms = value;
                RaisePropertyChanged("Programs");

            }
        }

        public AppStoreViewModel(IRegistrationService regService, IValueConverter pathToIconConverter, INavigationService navigationService)
        {
            _RegistrationService = regService;
            _PathToIconConverter = pathToIconConverter;
            _NavigationService = navigationService;
            LoadPrograms();
        }

        private void LoadPrograms()
        {
            _Programs = new ObservableCollection<BaseRunnableApp>();
            foreach (var item in _RegistrationService.GetAllApps()) 
            {
                _Programs.Add(item);
            }

            _AvailablePrograms = new ObservableCollection<BaseRunnableApp>();
            foreach (var item in _RegistrationService.GetAvailableApps())
            {
                _AvailablePrograms.Add(item);
            }

            _InstalledPrograms = new ObservableCollection<BaseRunnableApp>();
            foreach (var item in _RegistrationService.GetInstalledApps())
            {
                _InstalledPrograms.Add(item);
            }
            
            SelectedProgram = _Programs[0];
        }

    }
}
