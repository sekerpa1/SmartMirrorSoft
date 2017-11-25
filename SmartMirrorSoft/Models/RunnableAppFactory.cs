using SmartMirrorSoft.Programs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace SmartMirrorSoft.Models
{
    public class RunnableAppFactory : IRunnableAppFactory
    {
        public BaseRunnableApp GetInstance(string name, string iconPath,
            string version, string description,
            string price, bool installed)
        {
            switch (name)
            {
                case "Calculator":
                    var cal = new Calculator();
                    cal.Description = description;
                    cal.IconPath = iconPath;
                    cal.Installed = installed;
                    cal.Name = name;
                    cal.Price = price;
                    cal.Version = version;
                    return cal;
                default:
                    throw new ArgumentException(string.Format("Could not load module with the name {0}", name));

            }
        }
    }
}
