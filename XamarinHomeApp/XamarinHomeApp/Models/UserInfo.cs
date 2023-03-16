using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace XamarinHomeApp.Models
{
    public class UserInfo : INotifyPropertyChanged
    {
        private string _name;
        private string _email;

        public string Name 
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged("Email");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string prop = "") => 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
