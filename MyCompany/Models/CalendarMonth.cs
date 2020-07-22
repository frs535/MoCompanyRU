using System;
using System.Linq;
using System.Collections.Generic;

namespace MyCompany.Models
{
    public class CalendarMonth: List<CalendarWeek>
    {
        public CalendarMonth(CalendarWeek[] calendarWeeks) : base(calendarWeeks)
        {
            DateTime date = this.FirstOrDefault().CalendarDays.FirstOrDefault().Date;

            Header = string.Format("{0:MMMM yy}", date);
        }

        public string Header { get; set; }
    }
}
