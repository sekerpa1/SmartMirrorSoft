using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using SmartMirrorSoft.Converters;
using SmartMirrorSoft.Models;
using SmartMirrorSoft.Services;
using SmartMirrorSoft.Views;
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

            var nav = new NavigationService();
            nav.Configure("AppStorePageAlternative", typeof(AppStorePageAlternative));
            nav.Configure("StartPageAlternative", typeof(StartPageAlternative));


            SimpleIoc.Default.Register<INavigationService, NavigationService>();
            //SimpleIoc.Default.Unregister<StartPageViewModel>();
            //SimpleIoc.Default.Register<StartPageViewModel>(() => new StartPageViewModel(nav));
            
            SimpleIoc.Default.Register<IRunnableAppFactory, RunnableAppFactory>();

            SimpleIoc.Default.Unregister<IRegistrationService>();
            SimpleIoc.Default.Register<IRegistrationService>(() => new RegistrationService(RunnableAppFactoryInstance));
            SimpleIoc.Default.Register<CalculatorViewModel>();

            
            SimpleIoc.Default.Register<PathToIconConverter>();
            //SimpleIoc.Default.Unregister<AppStoreViewModel>();
            //SimpleIoc.Default.Register<AppStoreViewModel>(() => new AppStoreViewModel(RegistrationServiceInstance, PathToIconConverterInstance, nav));

            SimpleIoc.Default.Register<IRegistrationServiceSimple, RegistrationServiceSimple>();

            SimpleIoc.Default.Unregister<AppStoreAlternativeViewModel>();
            SimpleIoc.Default.Register<AppStoreAlternativeViewModel>(() => new AppStoreAlternativeViewModel(RegistrationServiceSimpleInstance, nav));

            SimpleIoc.Default.Unregister<DesktopLeftViewModel>();
            SimpleIoc.Default.Register<DesktopLeftViewModel>(() => new DesktopLeftViewModel(RegistrationServiceSimpleInstance, nav));

        }


        // <summary>
        // Gets the StartPage view model.
        // </summary>
        // <value>
        // The StartPage view model.
        // </value>

        public PathToIconConverter PathToIconConverterInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PathToIconConverter>();
            }
        }

        public CalculatorViewModel CalculatorInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CalculatorViewModel>();
            }
        }

        public StartPageViewModel StartPageInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<StartPageViewModel>();
            }
        }

        public AppStoreAlternativeViewModel AppStoreAlternativeInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AppStoreAlternativeViewModel>();
            }
        }

        public AppStoreViewModel AppStoreInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AppStoreViewModel>();
            }
        }

        public DesktopLeftViewModel DesktopLeftInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DesktopLeftViewModel>();
            }
        }

        public IRegistrationServiceSimple RegistrationServiceSimpleInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IRegistrationServiceSimple>();
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
