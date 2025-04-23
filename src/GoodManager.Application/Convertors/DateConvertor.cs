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

    //public static string ToUserShortTime(this DateTime dateUtc)
    //{
    //    var userCulture = Thread.CurrentThread.CurrentCulture;

    //    var userTimeZone = TimeZoneInfo.FindSystemTimeZoneById(SystemTimeZones.GetTimeZoneStandardNameByCultureName(userCulture.Name));

    //    return TimeZoneInfo.ConvertTimeFromUtc(dateUtc, userTimeZone).ToString("t", userCulture.DateTimeFormat);
    //}

    //public static string ToUserLongTime(this DateTime dateUtc)
    //{
    //    var userCulture = Thread.CurrentThread.CurrentCulture;

    //    var userTimeZone = TimeZoneInfo.FindSystemTimeZoneById(SystemTimeZones.GetTimeZoneStandardNameByCultureName(userCulture.Name));

    //    return TimeZoneInfo.ConvertTimeFromUtc(dateUtc, userTimeZone).ToString("HH:mm:ss", userCulture.DateTimeFormat);
    //}

    //public static string ToUserDate(this DateTime dateUtc)
    //{
    //    var userCulture = Thread.CurrentThread.CurrentCulture;

    //    var userTimeZone = TimeZoneInfo.FindSystemTimeZoneById(SystemTimeZones.GetTimeZoneStandardNameByCultureName(userCulture.Name));

    //    return TimeZoneInfo.ConvertTimeFromUtc(dateUtc, userTimeZone).ToString("yyyy/MM/dd", userCulture.DateTimeFormat);
    //}

    //public static DateTime? ParseUserDateToUTC(this string dateTime)
    //{
    //    var userCulture = Thread.CurrentThread.CurrentCulture;

    //    var userTimeZone = TimeZoneInfo.FindSystemTimeZoneById(SystemTimeZones.GetTimeZoneStandardNameByCultureName(userCulture.Name));

    //    var successfullyParsed = DateTime.TryParse(dateTime, out DateTime parsedDateTime);

    //    if (successfullyParsed)
    //    {
    //        return TimeZoneInfo.ConvertTimeToUtc(parsedDateTime, userTimeZone);
    //    }
    //    else
    //    {
    //        return null;
    //    }

    //}

    //public static DateTime? ParseUserDateToUTC(this DateTime dateTime)
    //{
    //    var userCulture = Thread.CurrentThread.CurrentCulture;

    //    var userTimeZone = TimeZoneInfo.FindSystemTimeZoneById(SystemTimeZones.GetTimeZoneStandardNameByCultureName(userCulture.Name));

    //    return TimeZoneInfo.ConvertTimeToUtc(dateTime, userTimeZone);

    //}

    //public static string ToUserLongDateTime(this DateTime dateUtc)
    //{
    //    var userCulture = Thread.CurrentThread.CurrentCulture;

    //    var userTimeZone = TimeZoneInfo.FindSystemTimeZoneById(SystemTimeZones.GetTimeZoneStandardNameByCultureName(userCulture.Name));

    //    return TimeZoneInfo.ConvertTimeFromUtc(dateUtc, userTimeZone).ToString("yyyy/MM/dd HH:mm:ss", userCulture.DateTimeFormat);
    //}

    //public static string ToUserLongDateTimeWithoutSecond(this DateTime dateUtc)
    //{
    //    var userCulture = Thread.CurrentThread.CurrentCulture;

    //    var userTimeZone = TimeZoneInfo.FindSystemTimeZoneById(SystemTimeZones.GetTimeZoneStandardNameByCultureName(userCulture.Name));

    //    return TimeZoneInfo.ConvertTimeFromUtc(dateUtc, userTimeZone).ToString("yyyy/MM/dd HH:mm", userCulture.DateTimeFormat);
    //}

    //public static string ToUserTimeHourMinute(this DateTime dateUtc)
    //{
    //    var userCulture = Thread.CurrentThread.CurrentCulture;

    //    var userTimeZone = TimeZoneInfo.FindSystemTimeZoneById(SystemTimeZones.GetTimeZoneStandardNameByCultureName(userCulture.Name));

    //    return TimeZoneInfo.ConvertTimeFromUtc(dateUtc, userTimeZone).ToString(" HH:mm", userCulture.DateTimeFormat);
    //}

    //public static string ToUserShortDateTime(this DateTime dateUtc)
    //{
    //    var userCulture = Thread.CurrentThread.CurrentCulture;

    //    var userTimeZone = TimeZoneInfo.FindSystemTimeZoneById(SystemTimeZones.GetTimeZoneStandardNameByCultureName(userCulture.Name));

    //    return TimeZoneInfo.ConvertTimeFromUtc(dateUtc, userTimeZone).ToString("yyyy/MM/dd HH:mm", userCulture.DateTimeFormat);
    //}


}

public enum ShamsiDateType
{
    Default,
    ShamsiYear,
    NumericDayNameMonth
}