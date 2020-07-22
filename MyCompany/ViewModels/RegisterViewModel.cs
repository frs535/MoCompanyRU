using MyCompany.Models;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using MyCompany.Services.Identity;
using MyCompany.Views;
using MyCompany.Services.DaData;
using MyCompany.Models.DaData;
using System.Linq;
using MyCompany.Validations;
using MyCompany.Helpers;

namespace MyCompany.ViewModels
{
    public class RegisterViewModel :BaseViewModel
    {
        private IIdentityService service;
        private IDaDataService daDataService;

        public ICommand RegisterCommand => new Command(async () => await ExecuteRegisterCommand());
        public ICommand RegisterFinishedCommand => new Command(async () => await ExecuteRegisterFinishedCommand());
        public ICommand FillByINNCommand => new Command(async () => await ExecuteFillByINN());
        public ICommand CheckBankCommand => new Command(async () => await ExecuteCheckBank());


        public RegisterViewModel()
        {
            service = new IdentityService();
            daDataService = new DaDataService();

            bank.Validations.Add(new IsNotNullOrEmptyRule<Bank> { ValidationMessage = "Bank is not filled" });
        }

        #region Properties

        private bool notRegistred = true;
        public bool NotRegistred
        {
            get { return notRegistred; }
            set
            {
                notRegistred = value;
                OnPropertyChanged("NotRegistred");
            }
        }

        private bool isRegistrd;
        public bool Isregistred
        {
            get { return isRegistrd; }
            set
            {
                isRegistrd = value;
                OnPropertyChanged("Isregistred");
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

        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        private bool isCompany;
        public bool IsCompany
        {
            get { return isCompany; }
            set
            {
                isCompany = value;
                OnPropertyChanged("IsCompany");
            }
        }

        private string _INN = string.Empty;
        public string INN
        {
            get { return _INN; }
            set
            {
                _INN = value;
                OnPropertyChanged("INN");
            }
        }

        private string _KPP = string.Empty;
        public string KPP
        {
            get { return _KPP; }
            set
            {
                _KPP = value;
                OnPropertyChanged("KPP");
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private string fullName;
        public string FullName
        {
            get { return fullName; }
            set
            {
                fullName = value;
                OnPropertyChanged("FullName");
            }
        }

        private Adress legalAdres = new Adress();
        public Adress LegalAdress
        {
            get { return legalAdres; }
            set
            {
                legalAdres = value;
                OnPropertyChanged("LegalAdress");
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

        private ValidatableObject<Bank> bank = new ValidatableObject<Bank>();
        public ValidatableObject<Bank> Bank
        {
            get { return bank; }
            set
            {
                bank = value;
                OnPropertyChanged("Bank");
            }
        }

        #endregion Properties

        #region Private methods

        private RegistredData FiilRegistredData()
        {
            return new RegistredData()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password,
                IsCompany = isCompany,
                INN = INN,
                KPP = _KPP,
                Name = name,
                FullName = fullName,
                LegalAdres = legalAdres,
                ActualAdress = actualAdress,
                PostalAdress = postalAdress
            };
        }

        private async Task ExecuteRegisterCommand()
        {
            IsBusy = true;

            var result = await service.RegisterAsync(FiilRegistredData());
            if (result!=null)
            {
                await MVVMHelper.DisplayAlert("Сообщение", result.Message, "Отмена");
                return;
            }

            NotRegistred = false; ;

            IsBusy = false;

            NotRegistred = false;
            Isregistred = true;
        }

        private async Task ExecuteRegisterFinishedCommand()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new LoginView());
        }

        private async Task ExecuteFillByINN()
        {
            var query = new DataQuery
            {
                Query = INN,
                KPP = KPP
            };

            Organisation organisation = await daDataService.GetOrganisationAsync(query);
            var suggestions = organisation.Suggestions.FirstOrDefault();
            if (suggestions == null)
                return;

            Name = suggestions.Value;
            FullName = suggestions.UnrestrictedValue;

            var data = suggestions.Data;
            if (string.IsNullOrWhiteSpace(KPP))
                KPP = data.KPP;

            var adresses = await daDataService.GetAddressAsync(data.Address.UnrestrictedValue);

            var adress = adresses.FirstOrDefault();
            if (adress == null)
                return;

            LegalAdress = new Adress
            {
                ZIPCode = adress.PostalCode,
                City = adress.City,
                Street = adress.Street,
                Hause = adress.House,
                Office  = adress.Flat
            };

            ActualAdress = new Adress
            {
                ZIPCode = adress.PostalCode,
                City = adress.City,
                Street = adress.Street,
                Hause = adress.House,
                Office = adress.Flat
            };

            PostalAdress = new Adress
            {
                ZIPCode = adress.PostalCode,
                City = adress.City,
                Street = adress.Street,
                Hause = adress.House,
                Office = adress.Flat
            };
        }

        private async Task ExecuteCheckBank()
        {
            var query = new DataQuery
            {
                Query = Bank.Value.BIK
            };

            var bankResult = await daDataService.GetBankAsync(query);

            var sug = bankResult.Suggestions.FirstOrDefault();
            if (sug == null)
                return;

            Bank.Value.CorrAccount = sug.Data.CorrespondentAccount;
            Bank.Value.Name = sug.UnrestrictedValue;
        }

        #endregion Private methods
    }
}
