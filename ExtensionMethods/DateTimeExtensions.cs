using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionMethods
{
    static class DateTimeExtensions
    {
        public static string ToFormatYYYYMMdd(this DateTime val)
        {
            // return $"{val.Year}{val.Month}{val.Day}";
            return val.ToString("yyyyMMdd");
        }
        public static string ToFormatYYYYMMddSep(this DateTime val, string sep)
        {
            return val.ToString("yyyy" + sep + "MM" + sep+ "dd");
        }
    }
}
