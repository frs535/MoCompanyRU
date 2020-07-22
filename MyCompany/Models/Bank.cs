using System.ComponentModel;

namespace MyCompany.Models
{
    public class Bank: INotifyPropertyChanged
    {
        private string bik = string.Empty;
        public string BIK
        {
            get { return bik; }
            set
            {
                bik = value;
                OnPropertyChanged("BIK");
            }
        }

        private string name = string.Empty;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private string corrAccount = string.Empty;
        public string CorrAccount
        {
            get { return corrAccount; }
            set
            {
                corrAccount = value;
                OnPropertyChanged("CorrAccount");
            }
        }

        private string account = string.Empty;
        public string Account
        {
            get { return account; }
            set
            {
                account = value;
                OnPropertyChanged("Account");
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
