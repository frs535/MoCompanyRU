using System;
using System.Collections.Generic;
using MyCompany.Services.Schedules;
using MyCompany.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using MyCompany.Helpers;

namespace MyCompany.ViewModels
{
    public class ScheduleViewModel : BaseViewModel
    {
        private bool _isFirstLoad = true;

        public ICommand AppearingCommand => new Command(async () => await AppearingCommandExecute());

        private IScheduleService service;

        public ScheduleViewModel()
        {
#if DEBUG
            Months.Add(new DateTime(2016, 1, 1));
            Months.Add(new DateTime(2016, 2, 1));
            Months.Add(new DateTime(2016, 3, 1));
            Months.Add(new DateTime(2016, 4, 1));
            Months.Add(new DateTime(2016, 5, 1));
            Months.Add(new DateTime(2016, 6, 1));
            Months.Add(new DateTime(2016, 7, 1));
            Months.Add(new DateTime(2016, 8, 1));
#endif
            if (itemsSource != null)
                itemsSource.CollectionChanged += ItemsSource_CollectionChanged;
        }

        #region Properties

        private ObservableCollection<CalendarWeek> itemsSource = new ObservableCollection<CalendarWeek>();
        public ObservableCollection<CalendarWeek> ItemsSource
        {
            get { return itemsSource; }
            set { SetProperty(ref itemsSource, value); }
        }

        private ObservableCollection<DateTime> monts = new ObservableCollection<DateTime>();
        public ObservableCollection<DateTime> Months
        {
            get { return monts; }
            set
            {
                monts = value;
                OnPropertyChanged("Months");
            }
        }

        private DateTime selectedMonths = DateTime.MinValue;
        public DateTime SelectedMonths
        {
            get { return selectedMonths; }
            set 
            {
                selectedMonths = value;
                OnPropertyChanged("SelectedMonths");
            }
        }

        public int TotalWorkDays
        {
            get { return itemsSource.Sum(p => p.CalendarDays.Count()); }
        }

        public float TotalWorkTime
        {
            get { return itemsSource.Sum(p => p.CalendarDays.Sum(n => n.WorkTime)); }
        }

        #endregion Properties

        #region Private methods

        private async Task AppearingCommandExecute()
        {
            if(_isFirstLoad)
                service = DependencyService.Get<IScheduleService>();
                

            await LoadSchedule();

            if (_isFirstLoad)
                _isFirstLoad = false;
        }

        private async Task LoadSchedule()
        {
            if (IsBusy) return;

            IsBusy = true;

            if (SelectedMonths == DateTime.MinValue)
            {
                IsBusy = false;
                return;
            }

            var serviceResult = await service.GetSheduleAsync(DateTime.Now);
            if(!serviceResult.Contune)
            {
                System.Diagnostics.Debug.WriteLine(serviceResult.Exception);
                await MVVMHelper.DisplayAlert("Сообщение", "Произошла ошибка получчения данных. Попробуйте снова минут через 5");
                IsBusy = false;
                return;
            }

            IsBusy = false;
        }

        private void ItemsSource_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("TotalWorkDays");
            OnPropertyChanged("TotalWorkTime");
        }

        private CalendarDay[] CreateTestData()
        {
            List<CalendarDay> result = new List<CalendarDay>();

            int month = selectedMonths.Month;
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

            return result.ToArray();
        }

        private async Task FillCalendar()
        {
            if (IsBusy)
                return;

            if (Months.Count == 0)
                for (int i = 1; i <= 12; i++)
                    Months.Add(new DateTime(2019, i, 1));

            if (selectedMonths == DateTime.MinValue)
                return;

            IsBusy = true;

            await Task.Delay(3000);

            itemsSource.Clear();

            CalendarDay[] calendarDays = CreateTestData();
            var arr = calendarDays.GroupBy(p => p.NumberOfWeek).Select(p=> new CalendarWeek(p.Select(n=>n).ToArray()));
            foreach (var a in arr)
                itemsSource.Add(a);
            
            IsBusy = false;
        }

        #endregion Private methods
    }
}

