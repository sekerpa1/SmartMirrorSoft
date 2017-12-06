using GalaSoft.MvvmLight;
using SmartMirrorSoft.Models;
using SmartMirrorSoft.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMirrorSoft.ViewModels
{
    public class DesktopLeftViewModel : ViewModelBase
    {
        private IRegistrationService _RegistrationService;

        private ObservableCollection<BaseRunnableApp> _ProgramsCollection;
        public ObservableCollection<BaseRunnableApp> ProgramsCollection
        {
            get
            {
                return _ProgramsCollection;
            }
            set
            {
                _ProgramsCollection = value;
                RaisePropertyChanged("ProgramsCollection");

            }
        }

        public DesktopLeftViewModel(IRegistrationService registrationService)
        {
            ProgramsCollection = new ObservableCollection<BaseRunnableApp>();
            this._RegistrationService = registrationService;

            foreach (var item in registrationService.GetInstalledApps())
            {
                ProgramsCollection.Add(item);
            }
 
        }
    }
}
