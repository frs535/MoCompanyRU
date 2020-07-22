using System;
using System.ComponentModel;

namespace MyCompany.Models
{
    public class Document: INotifyPropertyChanged
    {
        private string type = string.Empty;
        public string Type
        {
            get { return type; }
            set
            {
                type = value;
                OnPropertyChanged("Type");
            }
        }

        private string number = string.Empty;
        public string Number
        {
            get { return number; }
            set
            {
                number = value;
                OnPropertyChanged("Number");
            }
        }

        private string series = string.Empty;
        public string Series
        {
            get { return series; }
            set
            {
                series = value;
                OnPropertyChanged("Series");
            }
        }

        private string code = string.Empty;
        public string Code
        {
            get { return code; }
            set
            {
                code = value;
                OnPropertyChanged("Code");
            }
        }

        private string org = string.Empty;
        public string Org
        {
            get { return org; }
            set
            {
                org = value;
                OnPropertyChanged("Org");
            }
        }

        private DateTime date = new DateTime(1, 1, 1);
        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                OnPropertyChanged("Date");
            }
        }

        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(type))
                return "<>";

            return $"{Type}, {Number}, {Series}, {Org}, {Code}, {Date.ToString("dd.MM.yy")}";
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
