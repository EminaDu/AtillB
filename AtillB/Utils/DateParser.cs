using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtillB.Utils
{
    public static class DateParser
    {
        private static string format = "yyyy-MM-dd HH:mm:ss";
        private static string formatJustDate = "yyyy-MM-dd";
        private static string formatJustTime = "HH:mm:ss";
        public static string DateToString(DateTime date)
        {
            string dt = date.ToString(format);
            return dt;
        }

        public static string JustDateToString(DateTime date)
        {
            string dt = date.ToString(formatJustDate);
            return dt;
        }

        public static string JustTimeToString(DateTime date)
        {
            string dt = date.ToString(formatJustTime);
            return dt;
        }

        public static string DateTimeToString(DateTime date, DateTime time)
        {
            string dt = date.ToString(formatJustDate);
            string dtt = time.ToString(formatJustTime);
            return dt+ " " + dtt;
        }

        public static DateTime StringToDate(string date)
        {
            DateTime dt = DateTime.ParseExact(date, format, CultureInfo.InvariantCulture);
            return dt;
        }
    }
}
