using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using MyCompany.Models;
using Xamarin.Forms;
using MyCompany.Services.PaySlips;
using MyCompany.Validations;
using System.Linq;

namespace MyCompany.ViewModels
{
    public class PaySlipViewModel : BaseViewModel
    {
        private Guid id;

        private IPaySlipService service;

        public ICommand LoadDataCommand => new Command(async () => await ExecuteLoadDataCommand());
        public ICommand PrintCommand => new Command(async () => await ExecutePrint());

        public PaySlipViewModel()
        {
            service = DependencyService.Get<IPaySlipService>();

#if DEBUG
            Task.Run(async () => await FillTestData());
#endif
        }

        private ObservableCollection<DateTime> avalibleMonth = new ObservableCollection<DateTime>();
        public ObservableCollection<DateTime> AvalibleMonth
        {
            get{ return avalibleMonth; }
            set
            {
                avalibleMonth = value;
                OnPropertyChanged("AvalibleMonth");
            }
        }

        private DateTime selectedMonth;
        public DateTime SelectedMonth
        {
            get { return selectedMonth; }
            set
            {
                selectedMonth = value;
                OnPropertyChanged("SelectedMonth");

#if DEBUG
                Task.Run(async () => await FillTestData());
#endif
            }
        }

        #region Properties

        private string organisation;
        public string Organisation
        {
            get { return organisation; }
            set
            {
                organisation = value;
                OnPropertyChanged("Organisation");
            }
        }

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        private string middleName;
        public string MiddleName
        {
            get { return middleName; }
            set
            {
                middleName = value;
                OnPropertyChanged("MiddleName");
            }
        }

        private string tabNumber;
        public string TabNumber
        {
            get { return tabNumber; }
            set
            {
                tabNumber = value;
                OnPropertyChanged("TabNumber");
            }
        }

        private string department;
        public string Department
        {
            get { return department; }
            set
            {
                department = value;
                OnPropertyChanged("Department");
            }
        }

        private string position;
        public string Position
        {
            get { return position; }
            set
            {
                position = value;
                OnPropertyChanged("Position");
            }
        }

        public float Income
        {
            get { return Accrued.Where(p=>p.Name != "Paid").Sum(p => p.TotalAmount); }
        }

        private ObservableCollection<AccruedGroup> accrued = new ObservableCollection<AccruedGroup>();
        public ObservableCollection<AccruedGroup> Accrued
        {
            get { return accrued; }
            set
            {
                accrued = value;
                OnPropertyChanged("Accrued");
                OnPropertyChanged("Income");
            }
        }

        #endregion Properties

        #region Private methods

        private async Task  FillTestData()
        {
            if (avalibleMonth.Count == 0)
                for (int i = 1; i <= 12; i++)
                    avalibleMonth.Add(new DateTime(2019, i, 1));

            if (selectedMonth == DateTime.MinValue)
                return;

            if (IsBusy)
                return;

            IsBusy = true;
            await Task.Delay(3000);

            id = Guid.NewGuid();
            Organisation = "Daimler Chrysler";
            TabNumber = "00001";
            Department = "Logistic";
            Position = "Driver";

            Random random = new Random(0); 

            Accrued = new ObservableCollection<AccruedGroup>
            {
                new AccruedGroup("Accrued", new  List<Accrued>
                {
                new Accrued{ Type = "Salary", Period = new DateTime(2019, selectedMonth.Month, 1), PaidDays = 21, PaidHours = 168, WorkedOutDays=21, WorkedOutHours =168, Amount = random.Next(100000, 1000000)/100},
                new Accrued{ Type = "Bonus", Period = new DateTime(2019, selectedMonth.Month, 1), PaidDays = 21, PaidHours = 168, WorkedOutDays=0, WorkedOutHours =0, Amount = random.Next(100000, 1000000)/100},
                new Accrued{ Type = "Compensation", Period = new DateTime(2019, selectedMonth.Month, 1), PaidDays = 0, PaidHours = 0, WorkedOutDays=0, WorkedOutHours =0, Amount = random.Next(100000, 1000000)/100}
                }),
                new AccruedGroup("Natural Accrued", new List<Accrued>
                {
                    new Accrued{ Type = "Dinner", Period = new DateTime(2019, selectedMonth.Month, 12), PaidDays = 0, PaidHours = 0, WorkedOutDays=0, WorkedOutHours =0, Amount = random.Next(100000, 1000000)/100}
                }),
                new AccruedGroup("Deducted", new List<Accrued>
                {
                new Accrued{ Period = new DateTime(2019, selectedMonth.Month, 1), Type="Taxes", Amount=-random.Next(100000, 1000000)/100},
                new Accrued{ Period = new DateTime(2019, selectedMonth.Month, 1), Type="Corparate credit", Amount=-random.Next(100000, 1000000)/100}
                }),
                new AccruedGroup("Paid", new List<Accrued>
                {
                    new Accrued{ Period = new DateTime(2019, selectedMonth.Month, 1), Type="Paid", Amount= random.Next(100000, 1000000)/100}
                })
            };

            IsBusy = false;
        }

        private async Task LoadAvalibleMotns()
        {
            IsBusy = true;

            DateTime[] dates = await service.GetAvaliblePeriodsAsync();

            IsBusy = false;
        }

        private async Task ExecuteLoadDataCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            PaySlip paySlip = await service.GetPaySlipAsync(selectedMonth);

            id = paySlip.Id;
            Organisation = paySlip.Organisation;
            FirstName = paySlip.FirstName;
            LastName = paySlip.LastName;
            MiddleName = paySlip.MiddleName;
            TabNumber = paySlip.TabNumber;
            Department = paySlip.Department;
            Position = paySlip.Position;

            if (Accrued.Count > 0)
                Accrued.Clear();

            IsBusy = false;
        }

        private async Task ExecutePrint()
        {
            
        }

        #endregion Private methods
    }
}
