using System;
using System.Globalization;

namespace Linerath_Blog.DAL.Extensions
{
    public static class DateTimeExtensions
    {
        public static String ToSqlString(this DateTime dateTime)
        {
            CultureInfo enUS = new CultureInfo("en-US");

            return dateTime.ToString("yyyyMMdd hh:mm:ss tt", enUS);
        }
    }
}
