using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace GoodManager.Application.Tools;

public static class CommonTools
{
    public static string GetEnumName(this Enum myEnum)
    {
        var enumDisplayName = myEnum.GetType()
            .GetMember(myEnum.ToString())
            .FirstOrDefault();

        if (enumDisplayName != null)
            return enumDisplayName.GetCustomAttribute<DisplayAttribute>()?.GetName() ?? enumDisplayName.Name;

        return "";
    }

    public static string ToRelativeTime(this DateTime uploadTime)
    {
        TimeSpan timeDifference = DateTime.UtcNow - uploadTime;

        int totalSeconds = (int)timeDifference.TotalSeconds;
        if (totalSeconds < 60)
        {
            return $"{(int)totalSeconds} ثانیه پیش";
        }
        
        int totalMinutes = (int)timeDifference.TotalMinutes;
        if (totalMinutes < 60)
        {
            return $"{(int)totalMinutes} دقیقه پیش";
        }
        
        int totalHours = (int)timeDifference.TotalHours;
        if (totalHours < 24)
        {
            return $"{(int)totalHours} ساعت پیش";
        }

        int totalDays = (int)timeDifference.TotalDays;
        if (totalDays < 30)
        {
            return $"{(int)totalDays} روز پیش";
        }
        if (totalDays < 365)
        {
            return $"{(int)(totalDays / 30)} ماه پیش";
        }
        return $"{(int)(totalDays / 365)} سال پیش";
    }
}
