using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using MyCompany.Services.Identity;
using MyCompany.Validations;
using MyCompany.Helpers;

namespace MyCompany.ViewModels
{
    public class LoginViewModel:BaseViewModel
    {
        private readonly IIdentityService service;

        #region Commands

        public ICommand LoginCommand => new Command(async () => await LoginExecuteAsync());
        public ICommand ValidateUserNameCommand => new Command(() => ValidateUserName());
        public ICommand ValidatePasswordCommand => new Command(() => ValidatePassword());
        public ICommand RegisterCommand => new Command(async () => await RegisterAsync());
        public ICommand RestorePasswordCommand => new Command(async () => await ExecuteRestorePasswordAsync());

        #endregion Commands

        public LoginViewModel()
        {
            AddValidations();

            service = new IdentityService();

            Task.Run(async () => 
            {
                UserName.Value = await GlobalSetting.Instance.GetPropertyAsync("login", string.Empty);
#if DEBUG
                Password.Value = await GlobalSetting.Instance.GetPropertyAsync("pwd", string.Empty);
#endif
            });
        }

        #region Properties

        private ValidatableObject<string> userName = new ValidatableObject<string>();
        public ValidatableObject<string> UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }

        private ValidatableObject<string> password = new ValidatableObject<string>();
        public ValidatableObject<string> Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        private bool isValid;
        public bool IsValid
        {
            get { return isValid; }
            set
            {
                isValid = value;
                OnPropertyChanged("IsValid");
            }
        }

        private bool isLogin;
        public bool IsLogin
        {
            get { return isLogin; }
            set
            {
                isLogin = value;
                OnPropertyChanged("IsLogin");
            }
        }

        #endregion Properties

        #region Private methods

        private async Task LoginExecuteAsync()
        {
            if (!Validate())
                return;

            IsBusy = true;

            var result = await service.Login(UserName.Value, Password.Value);

            if (result != null)
            {
                await MVVMHelper.DisplayAlert("Сообщение", result.Message);
                IsBusy = false;
                return;
            }

            await GlobalSetting.Instance.SetPropertyAsync("login", userName.Value);
#if DEBUG
            await GlobalSetting.Instance.SetPropertyAsync("pwd", password.Value);
#endif
            await GlobalSetting.Instance.SaveSettingsAsync();

            
            var serviceResult = await service.GetUidAsync();
            if(!serviceResult.Contune)
            {
                await MVVMHelper.DisplayAlert("Ошибка", "При рабочче сервиса произошла ошибка. Попробуйте еще раз");
                IsValid = true;
                IsLogin = true;
                IsBusy = false;
                return;
            }

            GlobalSetting.Instance.ClientId = serviceResult.Data;

            await MVVMHelper.WorkspacePageAsync();

            IsValid = true;
            IsLogin = true;
            IsBusy = false;
        }

        private async Task ExecuteRestorePasswordAsync()
        {
            await MVVMHelper.ForgotPageAsync();
        }

        private async Task RegisterAsync()
        {
            await MVVMHelper.RegisterPageAsync();
        }

        private void AddValidations()
        {
            userName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "A email is required" });
            password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "A password is required" });
        }

        private bool ValidateUserName()
        {
            return userName.Validate();
        }

        private bool ValidatePassword()
        {
            return password.Validate();
        }

        private bool Validate()
        {
            bool isValidUser = ValidateUserName();
            bool isValidPassword = ValidatePassword();

            return isValidUser && isValidPassword;
        }

#endregion Private methods
    }
}
