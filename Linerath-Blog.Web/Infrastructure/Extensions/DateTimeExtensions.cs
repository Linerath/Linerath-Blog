using System;
using System.Globalization;

namespace Linerath_Blog.Web.Infrastructure.Extensions
{
    public static class DateTimeExtensions
    {
        public static String ToUIString(this DateTime dateTime)
        {
            CultureInfo cultureInfo = new CultureInfo("ru-RU");

            return dateTime.ToString("dddd, dd MMMM yyyy HH:ss", cultureInfo);
        }
    }
}
