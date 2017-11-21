using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace SmartMirrorSoft.Models
{
    public class BaseRunnableApp
    {
        public ImageSource Icon { get; set; }
        public string IconPath { get; set; }
        public string ClassName { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public bool Installed { get; set; }
        public virtual void Run()
        {
            throw new NotImplementedException("App does not contain the implementation of runnable interface.");
        }
    }
}
