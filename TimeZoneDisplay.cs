using System;
class TimeZoneDisplay
{
    static void Main(string[] args)
    {
        DateTimeOffset utcNow = DateTimeOffset.Now;
        TimeZoneInfo ist = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        TimeZoneInfo pst = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");

        DateTimeOffset istTime = TimeZoneInfo.ConvertTime(utcNow, ist);
        DateTimeOffset pstTime = TimeZoneInfo.ConvertTime(utcNow, pst);

        Console.WriteLine(string.Format("UTC Time: {0}",utcNow));
        Console.WriteLine(string.Format("IST Time: {0}",istTime));
        Console.WriteLine(string.Format("PST Time: {0}",pstTime));
    }
}