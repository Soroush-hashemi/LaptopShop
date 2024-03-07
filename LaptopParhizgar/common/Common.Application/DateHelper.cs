using System.Globalization;
using System.Runtime.Serialization;

namespace Common.Application;
public static class DateHelper
{
    public static string ToPersianDate(this DateTime dateTime)
    {
        PersianCalendar pc = new PersianCalendar();
        try
        {
            return string.Format("{0}/{1}/{2}", pc.GetYear(dateTime).ToString().PadLeft(4, '0'),
                pc.GetMonth(dateTime).ToString().PadLeft(2, '0'),
                pc.GetDayOfMonth(dateTime).ToString().PadLeft(2, '0'));
        }
        catch
        {
            return "";
        }
    }
}