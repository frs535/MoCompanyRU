using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyCompany.Services.Holidays;
using MyCompany.Services.Identity;
using MyCompany.Services.PaySlips;
using MyCompany.Services.PersonalsData;
using MyCompany.Services.Privilege;
using MyCompany.Services.Schedules;
using MyCompany.Services.DaData;
using MyCompany.Helpers;

namespace MyCompany
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<IdentityService>();
            DependencyService.Register<HolidaysService>();
            DependencyService.Register<PaySlipService>();
            DependencyService.Register<PersonalDataService>();
            DependencyService.Register<PrivilegesService>();
            DependencyService.Register<ScheduleService>();
            DependencyService.Register<DaDataService>();

            MVVMHelper.LoginPage();

            //            MessagingCenter.Unsubscribe<CatalogViewModel, CatalogItem>(this, MessageKeys.AddProduct);
            //            MessagingCenter.Subscribe<CatalogViewModel, CatalogItem>(this, MessageKeys.AddProduct, async (sender, arg) =>
            //           {
            //           }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
