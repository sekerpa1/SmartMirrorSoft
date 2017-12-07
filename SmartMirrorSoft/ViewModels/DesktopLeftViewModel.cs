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
        private IRegistrationServiceSimple _RegistrationService;

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

        public DesktopLeftViewModel(IRegistrationServiceSimple registrationService)
        {
            ProgramsCollection = new ObservableCollection<BaseRunnableApp>();
            this._RegistrationService = registrationService;

            foreach (var item in registrationService.GetInstalled())
            {
                ProgramsCollection.Add(new BaseRunnableApp { IconPath=item });
            }
 
        }
    }
}
