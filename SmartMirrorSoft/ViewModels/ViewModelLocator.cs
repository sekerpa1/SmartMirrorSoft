using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using SmartMirrorSoft.Models;
using SmartMirrorSoft.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace SmartMirrorSoft.ViewModels
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary> 
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            if (ViewModelBase.IsInDesignModeStatic)
            {
                // Create design time view services and models
            }
            else
            {
                // Create run time view services and models
            }

            //Register your services used here
            SimpleIoc.Default.Register<INavigationService, NavigationService>();
            SimpleIoc.Default.Register<StartPageViewModel>();
            SimpleIoc.Default.Register<AppStoreViewModel>();
            SimpleIoc.Default.Register<IRunnableAppFactory, RunnableAppFactory>();
            SimpleIoc.Default.Register<IRegistrationService>(() => new RegistrationService(RunnableAppFactoryInstance));

            var RegistrationServiceInstan = (RegistrationService)RegistrationServiceInstance;
            RegistrationServiceInstan.readFromXMLFile();

        }


        // <summary>
        // Gets the StartPage view model.
        // </summary>
        // <value>
        // The StartPage view model.
        // </value>
        public StartPageViewModel StartPageInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<StartPageViewModel>();
            }
        }

        public AppStoreViewModel AppStoreInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AppStoreViewModel>();
            }
        }

        public IRegistrationService RegistrationServiceInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IRegistrationService>();
            }
        }
        
        public IRunnableAppFactory RunnableAppFactoryInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IRunnableAppFactory>();
            }
        }

        // <summary>
        // The cleanup.
        // </summary>
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}
