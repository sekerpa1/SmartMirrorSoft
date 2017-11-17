using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace SmartMirrorSoft.Models
{
    public class Module
    {
        public string Name { get; set; }
        public Image IconPath { get; set; }

        public Module(string Name, string Path)
        {
            this.Name = Name;
            //BitmapImage image = new BitmapImage();
            //image.UriSource = new Uri(Path);
            //IconPath.Source = image;
        }
        
    }
}
