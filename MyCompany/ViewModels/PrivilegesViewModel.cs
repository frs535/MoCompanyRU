using MyCompany.Services.Privilege;

namespace MyCompany.ViewModels
{
    public class PrivilegesViewModel : BaseViewModel
    {

        private IPrivilegesService service;

        public PrivilegesViewModel()
        {
            IsBusy = true;
        }
    }
}
