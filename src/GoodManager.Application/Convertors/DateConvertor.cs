using System.Globalization;

namespace GoodManager.Application.Convertors;

public static class DateConvertor
{
    public static string ToFullPersianDate(this DateTime dateTime)
    {
        PersianCalendar persianCalendar = new PersianCalendar();
        string year = persianCalendar.GetYear(dateTime).ToString();
        string month = persianCalendar.GetMonth(dateTime).ToString()
                       .PadLeft(2, '0');
        string day = persianCalendar.GetDayOfMonth(dateTime).ToString()
                       .PadLeft(2, '0');
        string hour = dateTime.Hour.ToString().PadLeft(2, '0');
        string minute = dateTime.Minute.ToString().PadLeft(2, '0');
        string second = dateTime.Second.ToString().PadLeft(2, '0');
        return String.Format("{0}/{1}/{2} {3}:{4}:{5}", year, month, day, hour, minute, second);
    }

    public static string ToPersianDateWithoutClock(this DateTime dateTime)
    {
        PersianCalendar persianCalendar = new PersianCalendar();
        string year = persianCalendar.GetYear(dateTime).ToString();
        string month = persianCalendar.GetMonth(dateTime).ToString().PadLeft(2, '0');
        string day = persianCalendar.GetDayOfMonth(dateTime).ToString().PadLeft(2, '0');

        return String.Format("{0}/{1}/{2}", year, month, day);
    }

    public static string GetPersianMonthName(int month)
    {
        string[] monthNames = { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور",
                           "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" };

        return monthNames[month - 1];
    }

    public static string GetPersianDayOfWeekName(int dayOfWeek)
    {
        string[] dayOfWeekNames = { "شنبه", "یکشنبه", "دوشنبه", "سه شنبه",
                                "چهارشنبه", "پنجشنبه", "جمعه" };

        return dayOfWeekNames[dayOfWeek - 1];
    }
}