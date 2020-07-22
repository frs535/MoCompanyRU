using System;

using Xamarin.Forms;

namespace MyCompany.Views
{
    public class PaySlip : ContentPage
    {
        public PaySlip()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

