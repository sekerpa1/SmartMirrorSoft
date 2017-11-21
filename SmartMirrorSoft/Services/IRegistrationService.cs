using SmartMirrorSoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMirrorSoft.Services
{
    interface IRegistrationService
    {
        List<BaseRunnableApp> GetAllApps();
        List<BaseRunnableApp> GetInstalledApps();
        List<BaseRunnableApp> GetAvailableApps();
        void InstallApp(string name);
        void UninstallApp(string name);
    }
}
