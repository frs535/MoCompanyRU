using System.Threading.Tasks;
using MyCompany.Views;
using Xamarin.Forms;

namespace MyCompany.Helpers
{
    public static class MVVMHelper
    {
        public static async Task DisplayAlert(string title, string message, string cancel = "Cancel")
        {
            await Application.Current.MainPage.DisplayAlert(title, message, cancel);
        }

        public static void LoginPage()
        {
            var page = new LoginView();
            if (Application.Current.MainPage == null)
                Application.Current.MainPage = new NavigationPage(page);
            else
                Application.Current.MainPage.Navigation.PushAsync(page);
        }

        public static async Task WorkspacePageAsync()
        {
            var page = new WorkspacePage();
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }

        public static async Task ForgotPageAsync()
        {
            var page = new ForgotPage();
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }

        public static async Task RegisterPageAsync()
        {
            var page = new RegisterPage();
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }

        public static async Task CompanyChoiseView()
        {
            var page = new CompanyChoiseView();
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }
    }
}
