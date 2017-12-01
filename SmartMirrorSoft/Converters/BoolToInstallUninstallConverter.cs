using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace SmartMirrorSoft.Converters
{
    public class BoolToInstallUninstallConverter : IValueConverter
    {
        public BoolToInstallUninstallConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (!value.GetType().Equals(typeof(bool)))
            {
                throw new InvalidCastException("The supported type is incorrect. Supported value must be of type 'bool'.");
            }
            if ((bool)value) return "Uninstall";
            else return " Install ";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {

            if (!value.GetType().Equals(typeof(string)))
            {
                throw new InvalidCastException("The supported type is incorrect. Supported value must be of type 'string'.");
            }

            switch ((string)value)
            {
                case "Install":
                    return (object)false;
                case "Uninstall":
                    return (object)true;
                default:
                    return false;
            }
        }
    }
}
