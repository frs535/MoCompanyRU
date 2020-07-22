using System;
using System.Linq;
using System.Collections.Generic;

namespace MyCompany.Models
{
    public class CalendarWeek
    {
        private List<CalendarDay> _calendarDays;

        public CalendarWeek(DateTime[] dates)
        {
            _calendarDays = dates.Select(d => new CalendarDay(d)).ToList();
        }

        public CalendarWeek(CalendarDay[] calendarDays)
        {
            _calendarDays = new List<CalendarDay>(calendarDays);
        }

        public List<CalendarDay> CalendarDays
        {
            get { return _calendarDays; }
        }

        public int NumberOfWeek
        {
            get
            {
                var date = _calendarDays.FirstOrDefault().Date;

                var calendar = GlobalSetting.Instance.Calendar;
                var calendarWeekRule = GlobalSetting.Instance.CalendarWeekRule;

                return calendar.GetWeekOfYear(date, calendarWeekRule, DayOfWeek.Monday);
            }
        }

        public int NumberOfMonth { get { return _calendarDays.FirstOrDefault().Date.Month; } }

        public CalendarDay Monday
        {
             get { return _calendarDays.FirstOrDefault(p => p.DayOfWeek == DayOfWeek.Monday); }
        }

        public CalendarDay Tuesday
        {
            get { return _calendarDays.FirstOrDefault(p => p.DayOfWeek == DayOfWeek.Tuesday); }
        }

        public CalendarDay Wednesday
        {
            get { return _calendarDays.FirstOrDefault(p => p.DayOfWeek == DayOfWeek.Wednesday); }
        }

        public CalendarDay Thursday
        {
            get { return _calendarDays.FirstOrDefault(p => p.DayOfWeek == DayOfWeek.Thursday); }
        }

        public CalendarDay Friday
        {
            get { return _calendarDays.FirstOrDefault(p => p.DayOfWeek == DayOfWeek.Friday); }
        }

        public CalendarDay Saturday
        {
            get { return _calendarDays.FirstOrDefault(p => p.DayOfWeek == DayOfWeek.Saturday); }
        }

        public CalendarDay Sunday
        {
            get { return _calendarDays.FirstOrDefault(p => p.DayOfWeek == DayOfWeek.Sunday); }
        }
    }
}
