using System;

namespace MyCompany.Models
{
    public class CalendarDay
    {
        private DateTime _date;

        public CalendarDay(DateTime date)
        {
            _date = date;
        }

        public CalendarDay(DateTime date, float workTime)
        {
            _date = date;
            WorkTime = workTime;
        }

        public int NumberOfWeek
        {
            get
            {
                var calendar = GlobalSetting.Instance.Calendar;
                var calendarWeekRule = GlobalSetting.Instance.CalendarWeekRule;

                return calendar.GetWeekOfYear(_date, calendarWeekRule, DayOfWeek.Monday);
            }
        }

        public DateTime Date
        {
            get { return _date; }
        }

        public DayOfWeek DayOfWeek
        {
            get { return _date.DayOfWeek; }
        }

        public int Day
        {
            get { return _date.Day; }
        }

        public float WorkTime { get; }
    }
}
