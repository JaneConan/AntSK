namespace AntSK
{
    public static class DateTimeExtension
    {
        private const int Second = 1;
        private const int Minute = 60 * Second;
        private const int Hour = 60 * Minute;
        private const int Day = 24 * Hour;
        private const int Month = 30 * Day;

        // todo: Need to be localized
        public static string ToFriendlyDisplay(this DateTime dateTime)
        {
            var ts = DateTime.Now - dateTime;
            var delta = ts.TotalSeconds;
            if (delta < 0)
            {
                return "not yet";
            }
            if (delta < 1 * Minute)
            {
                return ts.Seconds == 1 ? "1 second ago" : ts.Seconds + " seconds ago";
            }
            if (delta < 2 * Minute)
            {
                return "1 minute ago";
            }
            if (delta < 45 * Minute)
            {
                return ts.Minutes + "minute";
            }
            if (delta < 90 * Minute)
            {
                return "1 hour ago";
            }
            if (delta < 24 * Hour)
            {
                return ts.Hours + " hours ago";
            }
            if (delta < 48 * Hour)
            {
                return "yesterday";
            }
            if (delta < 30 * Day)
            {
                return ts.Days + " days ago";
            }
            if (delta < 12 * Month)
            {
                var months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "A month ago" : months + " months ago";
            }
            else
            {
                var years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
                return years <= 1 ? "a year ago" : years + " years ago";
            }
        }


        #region 获取 本周、本月、本季度、本年 的开始时间或结束时间
        /// <summary>
        /// 获取 本周、本月、本季度、本年 的开始时间
        /// </summary>
        /// <param name="now">当前时间</param>
        /// <param name="TimeType">Week、Month、Season、Year</param>
        /// <returns></returns>
        public static DateTime GetTimeStartByType(this DateTime now, string TimeType)
        {
            switch (TimeType)
            {
                case "Week":
                    return now.AddDays(-(int)now.DayOfWeek + 1);
                case "Month":
                    return now.AddDays(-now.Day + 1);
                case "Season":
                    var time = now.AddMonths(0 - ((now.Month - 1) % 3));
                    return time.AddDays(-time.Day + 1);
                case "Year":
                    return now.AddDays(-now.DayOfYear + 1);
                default:
                    return now;
            }
        }
        /// <summary>
        /// 获取 本周、本月、本季度、本年 的结束时间
        /// </summary>
        /// <param name="now">当前时间</param>
        /// <param name="TimeType">Week、Month、Season、Year</param>
        /// <returns></returns>
        public static DateTime GetTimeEndByType(this DateTime now, string TimeType)
        {
            switch (TimeType)
            {
                case "Week":
                    return now.AddDays(7 - (int)now.DayOfWeek);
                case "Month":
                    return now.AddMonths(1).AddDays(-now.AddMonths(1).Day + 1).AddDays(-1);
                case "Season":
                    var time = now.AddMonths((3 - ((now.Month - 1) % 3) - 1));
                    return time.AddMonths(1).AddDays(-time.AddMonths(1).Day + 1).AddDays(-1);
                case "Year":
                    var time2 = now.AddYears(1);
                    return time2.AddDays(-time2.DayOfYear);
                default:
                    return now;
            }
        }
        #endregion

    }
}