using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SmartMirrorSoft.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SmartMirrorSoft.ViewModels
{
    public class AppStoreAlternativeViewModel : ViewModelBase
    {
        private IRegistrationServiceSimple _RegistrationServiceSimple;

        
        private ICommand _InstallApp;
        public ICommand InstallApp
        {
            get
            {
                return _InstallApp;
            }
            set
            {
                _InstallApp = value;
                RaisePropertyChanged("InstallApp");
            }
        }

        private ICommand _UninstallApp;
        public ICommand UninstallApp
        {
            get
            {
                return _UninstallApp;
            }
            set
            {
                _UninstallApp = value;
                RaisePropertyChanged("UninstallApp");
            }
        }


        public void RegisterApp(string path)
        {
            _RegistrationServiceSimple.InstallApp(path);
        }

        public void UnregisterApp(string path)
        {
            _RegistrationServiceSimple.UninstallApp(path);
        }

        public void something()
        {
            string s = "1231231";
            string a = "222222";
            string u = s + a;
        }

        public AppStoreAlternativeViewModel(IRegistrationServiceSimple regService)
        {
            InstallApp = new RelayCommand<string>(this.RegisterApp);
            UninstallApp = new RelayCommand<string>(this.UnregisterApp);
            _RegistrationServiceSimple = regService;
        }
    }
}
