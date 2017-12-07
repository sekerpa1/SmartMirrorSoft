using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartMirrorSoft.Models;

namespace SmartMirrorSoft.Services
{
    public class RegistrationServiceSimple : IRegistrationServiceSimple
    {
        List<string> _Apps;

        public List<string> GetInstalled()
        {
            return _Apps;
        }

        public void InstallApp(string iconPath)
        {
            _Apps.Add(iconPath);
        }

        public void UninstallApp(string iconPath)
        {
            _Apps.Remove(iconPath);
        }

        public RegistrationServiceSimple()
        {
            _Apps = new List<string>();
            _Apps.Add("chrome_by_dtafalonso-d67pbhl.png");
        }
    }
}
