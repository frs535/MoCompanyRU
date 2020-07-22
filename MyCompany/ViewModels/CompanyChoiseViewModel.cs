using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyCompany.Services.PersonalsData;
using Xamarin.Forms;

namespace MyCompany.ViewModels
{
    public class CompanyChoiseViewModel :BaseViewModel
    {
        public CompanyChoiseViewModel()
        {
            var service = DependencyService.Get<IPersonalDataService>();

            Task.Run(async () =>
            {
                IsBusy = true;
                var serviceResult = await service.GetUserEmployees();
                if(serviceResult.Contune)
                {
                    employees = serviceResult.Data;
                    OnPropertyChanged("Employees");
                }
                IsBusy = false;
            });
        }

        private Dictionary<string, string> employees = new Dictionary<string, string>();
        public Dictionary<string, string> Employees
        {
            get => employees;
            set
            {
                employees = value;
                OnPropertyChanged("Employees");
            }
        }

        private KeyValuePair<string, string> selectedItem = new KeyValuePair<string, string>();
        public KeyValuePair<string, string> SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;

                //GlobalSetting.Instance.CurrentUserId = value.Key;

                OnPropertyChanged("SelectedItem");
                
            }
        }
    }
}
