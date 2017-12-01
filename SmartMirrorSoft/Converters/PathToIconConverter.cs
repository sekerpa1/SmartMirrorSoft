using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace SmartMirrorSoft.Converters
{
    public class PathToIconConverter : IValueConverter
    {

        public PathToIconConverter()
        {
            if (!Directory.Exists((string)App.Current.Resources["PathToIcons"]))
            {
                throw new FileNotFoundException("Please supply a correct path to the icons file.");
            }
        }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (!value.GetType().Equals(typeof(string)))
            {
                throw new InvalidCastException("The supported type is incorrect. Supported value must be of type 'string'.");
            }

            var str = string.Format("{0}/{1}", (string)App.Current.Resources["PathToIcons"], value as string);

            if (!File.Exists(str))
            {
                throw new FileNotFoundException(string.Format("File not found. Supported path {0} is either incorrect or the icon file is missing",str));
            }

            var img = new BitmapImage(new Uri(string.Format("{0}/{1}", "ms-appx://SmartMirrorSoft", str)));
            return img;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {

            if (!value.GetType().Equals(typeof(BitmapImage)))
            {
                throw new InvalidCastException("The supported type is incorrect. Supported value must be of type 'BitmapImage'.");
            }

            var path = ((BitmapImage)value).UriSource.OriginalString;
            return path;
        }
    }
}
