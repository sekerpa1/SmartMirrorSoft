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
            string price, string installed)
        {
            switch (name)
            {
                case "Calculator":
                    var cal = new Calculator();
                    cal.Description = description;
                    cal.IconPath = iconPath;
                    if (installed.ToLower().Equals("yes"))
                        cal.Installed = true;
                    else
                        cal.Installed = false;
                    cal.Name = name;
                    cal.Price = price;
                    cal.Version = version;
                    return cal;
                case "Calendar":
                    var cale = new Calculator();
                    cale.Description = description;
                    cale.IconPath = iconPath;
                    if (installed.ToLower().Equals("yes"))
                        cale.Installed = true;
                    else
                        cale.Installed = false;
                    cale.Name = name;
                    cale.Price = price;
                    cale.Version = version;
                    return cale;
                case "Chrome":
                    var chr = new Calculator();
                    chr.Description = description;
                    chr.IconPath = iconPath;
                    if (installed.ToLower().Equals("yes"))
                        chr.Installed = true;
                    else
                        chr.Installed = false;
                    chr.Name = name;
                    chr.Price = price;
                    chr.Version = version;
                    return chr;
                default:
                    throw new ArgumentException(string.Format("Could not load module with the name {0}", name));

            }
        }
    }
}
