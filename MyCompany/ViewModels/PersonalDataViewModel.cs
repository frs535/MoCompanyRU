using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MyCompany.Models;
using Xamarin.Forms;
using MyCompany.Services.PersonalsData;
using MyCompany.Views;
using MyCompany.Helpers;

namespace MyCompany.ViewModels
{
    public class PersonalDataViewModel: BaseViewModel
    {
        private bool _isFirstLoad = true;

        private IPersonalDataService service;

        public ICommand LogoutCommand => new Command(async () => await ExecuteLogoutCommand());
        public ICommand IncorrectDataCommand => new Command(async () => await ExecuteIncorrectDataCommand());
        public ICommand AppearingCommand => new Command(async () => await AppearingCommandExecute());

        #region Properties

        private string firstName = string.Empty;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        private string lastName = string.Empty;
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        private string middleName = string.Empty;
        public string MiddleName
        {
            get { return middleName; }
            set
            {
                middleName = value;
                OnPropertyChanged("MiddleName");
            }
        }

        private string urlPhoto = string.Empty;
        public string URLPhoto
        {
            get { return urlPhoto; }
            set
            {
                urlPhoto = value;
                OnPropertyChanged("URLPhoto");
            }
        }

        private DateTime birthDate = DateTime.Now;
        public DateTime BirthDate
        {
            get { return birthDate; }
            set
            {
                birthDate = value;
                OnPropertyChanged("BirthDate");
            }
        }

        private string inn = string.Empty;
        public string INN
        {
            get { return inn; }
            set
            {
                inn = value;
                OnPropertyChanged("INN");
            }
        }

        private string snils = string.Empty;
        public string SNILS
        {
            get { return snils; }
            set
            {
                snils = value;
                OnPropertyChanged("SNILS");
            }
        }

        private float inSalary;
        public float InSalary
        {
            get { return inSalary; }
            set
            {
                inSalary = value;
                OnPropertyChanged("InSalary");
            }
        }

        private float outSalary;
        public float OutSalary
        {
            get { return outSalary; }
            set
            {
                outSalary = value;
                OnPropertyChanged("OutSalary");
            }
        }

        private Document mainDocument = new Document();
        public Document MainDocument
        {
            get { return mainDocument; }
            set
            {
                mainDocument = value;
                OnPropertyChanged("MainDocument");
            }
        }

        private Adress legalAdres = new Adress();
        public Adress LegalAdres
        {
            get { return legalAdres; }
            set
            {
                legalAdres = value;
                OnPropertyChanged("Adress");
            }
        }

        private Adress postalAdress = new Adress();
        public Adress PostalAdress
        {
            get { return postalAdress; }
            set
            {
                postalAdress = value;
                OnPropertyChanged("PostalAdress");
            }
        }

        private Adress actualAdress = new Adress();
        public Adress ActualAdress
        {
            get { return actualAdress; }
            set
            {
                actualAdress = value;
                OnPropertyChanged("ActualAdress");
            }
        }

        #endregion Properties

        #region Private methods

        private async Task AppearingCommandExecute()
        {
            if (IsBusy) return;

            IsBusy = true;

            if(string.Empty == GlobalSetting.Instance.CurrentUserId)
            {
                await MVVMHelper.CompanyChoiseView();
                return;
            }

            if(_isFirstLoad)
            {
                await LoadPersonalData();
                _isFirstLoad = false;
            }

            IsBusy = false;
        }

        private async Task ExecuteLogoutCommand()
        {
            Application.Current.MainPage = new NavigationPage();
            await ((NavigationPage)Application.Current.MainPage).PushAsync(new LoginView());
        }

        private async Task ExecuteIncorrectDataCommand()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new IncorrectDataPage());
        }

        private async Task LoadPersonalData()
        {
            if (service == null)
                service = DependencyService.Get<IPersonalDataService>();

            var personalData = await service.GetPersonalDataAsync();
        }

        private void FillTestData()
        {
            FirstName = "Ivan";
            LastName = "Ivanov";
            MiddleName = "Ivanovich";
            BirthDate = new DateTime(1965, 7, 2);

            INN = "7736207543";
            SNILS = "023-345-228-444";

            InSalary = 90000F;
            OutSalary = 56342.33F;

            MainDocument = new Document
            {
                Series = "44 02",
                Number = "026355",
                Date = new DateTime(2019, 12, 23),
                Code = "123-532",
                Org = "FNS Russia",
                Type = "Passport"
            };

            LegalAdres = new Adress
            {
                City = "Moscow",
                ZIPCode = "123456",
                Street = "Yankovskaya str.",
                Hause = "123",
                Office = "367"
            };

            PostalAdress = new Adress
            {
                City = "Moscow",
                ZIPCode = "123456",
                Street = "Yankovskaya str.",
                Hause = "123",
                Office = "367"
            };

            ActualAdress = new Adress
            {
                City = "Moscow",
                ZIPCode = "123456",
                Street = "Yankovskaya str.",
                Hause = "123",
                Office = "367"
            };
        }

        #endregion Private methods
    }
}
