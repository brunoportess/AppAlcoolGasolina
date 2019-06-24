using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AlcoolGasolina.Helpers.Converters
{
    public class StringNullOrEmptyBoolConverter : IValueConverter
    {
        /// <summary>Returns false if string is null or empty
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value == null ? false : true;
            //return (bool)value;
            //var s = value as string;
            //var s = value.GetType() ==  typeof(string) ? value as string : value as double;
            //return !string.IsNullOrWhiteSpace(s);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
