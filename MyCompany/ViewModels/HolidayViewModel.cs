using MyCompany.Services.Holidays;
using System.Collections.ObjectModel;
using MyCompany.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.ViewModels
{
    public class HolidayViewModel : BaseViewModel
    {
        private IHolidaysService service;

        public HolidayViewModel()
        {
#if DEBUG
            Task.Run(async () => await CreateTestCalendarWeek());
#endif
        }

        #region Properties

        private ObservableCollection<CalendarMonth> calendars = new ObservableCollection<CalendarMonth>();
        public ObservableCollection<CalendarMonth> Calendars
        {
            get { return calendars; }
            set
            {
                calendars = value;
                OnPropertyChanged("Calendars");
            }
        }

        #endregion

        #region Private methods

        private async Task CreateTestCalendarWeek()
        {
            IsBusy = true;

            //await Task.Delay(1000);

            calendars.Clear();

            for (int i = 1; i <= 12; i++)
            {
                var days = CreateTestCalendarDay(i);
                var arr = days.GroupBy(p => p.NumberOfWeek).Select(p => new CalendarWeek(p.Select(n => n).ToArray()));

                CalendarMonth calendarMonth = new CalendarMonth(arr.ToArray());
                calendars.Add(calendarMonth);
            }

            IsBusy = false;
        }

        private List<CalendarDay> CreateTestCalendarDay(int month)
        {
            List<CalendarDay> result = new List<CalendarDay>();

            int year = DateTime.Now.Year;
            int days = DateTime.DaysInMonth(year, month);

            Random random = new Random(0);

            for (int i = 1; i <= days; i++)
            {
                var date = new DateTime(year, month, i);
                CalendarDay calDay;

                if (date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday)
                    calDay = new CalendarDay(date, 0);
                else
                    calDay = new CalendarDay(date, random.Next(7, 9));

                result.Add(calDay);
            }

            return result;
        }

        #endregion Private methods
    }
}
