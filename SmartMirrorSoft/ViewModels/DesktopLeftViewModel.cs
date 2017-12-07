﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SmartMirrorSoft.Models;
using SmartMirrorSoft.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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

        public ICommand RefreshCmd
        {
            get
            {
                return new RelayCommand(Refresh);
            }
        }

        public DesktopLeftViewModel(IRegistrationServiceSimple registrationService)
        {
            this._RegistrationService = registrationService;
            this.Refresh();
        }

        public void Refresh()
        {
            ProgramsCollection = new ObservableCollection<BaseRunnableApp>();
            foreach (var item in _RegistrationService.GetInstalled())
            {
                ProgramsCollection.Add(new BaseRunnableApp { IconPath = item });
            }
        }
    }
}
