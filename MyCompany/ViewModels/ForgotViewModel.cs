using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MyCompany.Services.Identity;
using Xamarin.Forms;

namespace MyCompany.ViewModels
{
    public class ForgotViewModel : BaseViewModel
    {
        private readonly IIdentityService service;

        #region Commands

        public ICommand RestoreCommand => new Command(async () => await RestorePassword());

        #endregion Commands

        public ForgotViewModel()
        {
            service = new IdentityService();
        }

        #region Properties

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

        private string message;
        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                OnPropertyChanged("Message");
            }
        }

        #endregion Properties

        #region Private methods

        private async Task RestorePassword()
        {

            //bool result = await service.RestorePassswordAsync(email);
            //if (result)
            //    Message = "We send you email whith new password.";
            //else
            //    Message = "Something went wrong.";
        }

        #endregion Private methods
    }
}
