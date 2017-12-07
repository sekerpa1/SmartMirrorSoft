using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMirrorSoft.Services
{
    public interface IRegistrationServiceSimple
    {
        void InstallApp(string iconPath);
        void UninstallApp(string iconPath);
        List<string> GetInstalled();
    }
}
