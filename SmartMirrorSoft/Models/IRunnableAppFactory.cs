using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMirrorSoft.Models
{
    public interface IRunnableAppFactory
    {
        BaseRunnableApp GetInstance(string name, string iconPath,
            string version, string description,
            string price, string installed);
    }
}
