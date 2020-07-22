using System.ComponentModel;

namespace MyCompany.Models
{
    public class Adress: INotifyPropertyChanged
    {
        private string city = string.Empty;
        public string City
        {
            get { return city; }
            set
            {
                city = value;
                OnPropertyChanged("City");
            }
        }

        private string zipCode = string.Empty;
        public string ZIPCode
        {
            get { return zipCode; }
            set
            {
                zipCode = value;
                OnPropertyChanged("ZIPCode");
            }
        }

        private string street = string.Empty;
        public string Street
        {
            get { return street; }
            set
            {
                street = value;
                OnPropertyChanged("Street");
            }
        }

        private string hause = string.Empty;
        public string Hause
        {
            get { return hause; }
            set
            {
                hause = value;
                OnPropertyChanged("Hause");
            }
        }

        private string office;
        public string Office
        {
            get { return office; }
            set
            {
                office = value;
                OnPropertyChanged("Office");
            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
