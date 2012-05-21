using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Globalization;

namespace IM.Framework
{
    public static class FormatingHelper
    {
        public static DateTime ConvertToDateTime(this string date)
        {
            if (!string.IsNullOrEmpty(date))
            {
                CultureInfo culture = new CultureInfo("en-GB");

                return Convert.ToDateTime(date, culture);
            }
            else
            {
                return DateTime.MinValue;
            }
        }
        public static string ConvertDateToString(this DateTime date)
        {
            string dateFormat = ConfigurationManager.AppSettings.Get("DateFormat").ToString();
            return date.ToString(dateFormat);
        }
    }
}
