using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyCompany.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TextBox : ContentView
    {
        public TextBox()
        {
            InitializeComponent();

            entTextBox.TextChanged += EntTextBox_TextChanged;
            PropertyChanged += TextBox_PropertyChanged;

        }
 
        private void TextBox_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Label")
                lblTextBox.Text = Label;
            else if (e.PropertyName == "HasRequired")
                if (HasRequired)
                    lblRequaredField.IsVisible = true;
                else
                    lblRequaredField.IsVisible = false;
        }

        private void EntTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(entTextBox.Text))
                lblTextBox.IsVisible = true;
            else
                lblTextBox.IsVisible = false;

            Text = entTextBox.Text;
        }

        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(TextBox));
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set
            {
                SetValue(TextProperty, value);
                entTextBox.Text = value;
            }
        }

        public static readonly BindableProperty LabelProperty = BindableProperty.Create(nameof(Label), typeof(string), typeof(TextBox));
        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set
            {
                SetValue(LabelProperty, value);
                lblTextBox.Text = value;
            }
        }

        public static readonly BindableProperty HasRequiredProperty = BindableProperty.Create(nameof(HasRequired), typeof(bool), typeof(TextBox));
        public bool HasRequired
        {
            get { return (bool)GetValue(HasRequiredProperty); }
            set
            {
                SetValue(HasRequiredProperty, value);
            }
        }

        public static readonly BindableProperty IsValidProperty = BindableProperty.Create(nameof(IsValid), typeof(bool), typeof(TextBox));
        public bool IsValid
        {
            get { return (bool)GetValue(IsValidProperty); }
            set
            {
                SetValue(IsValidProperty, value);
            }
        }


    }
}
