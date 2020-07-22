using MyCompany.Services.PersonalsData;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Windows.Input;
using MyCompany.Views;

namespace MyCompany.ViewModels
{
    public class IncorrectDataViewModel : BaseViewModel
    {
        private IPersonalDataService service;

        public ICommand SendCommand => new Command(async () => await ExecuteSendCommand());

        public IncorrectDataViewModel()
        {
            service = new PersonalDataService();
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

        private async Task ExecuteSendCommand()
        {
            //await service.SendMessageAsync(message);

            await Application.Current.MainPage.Navigation.PushAsync(new WorkspacePage());
        }
    }
}
