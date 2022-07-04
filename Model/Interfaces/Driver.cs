using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Model.Interfaces
{
    [Serializable]
    public class Driver: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Constructor
        public Driver(string firstName, string lastName, string address, string phoneNumber)
        {
            _firstName = firstName;
            LastName = lastName;
            Address = address;
            PhoneNumber = phoneNumber;
        }
        private Driver()
        {}
        #endregion

        #region Fields
        private string _firstName;
        private string _lastName;
        private string _address;
        private string _phoneNumber;
        #endregion

        #region Getters&Setters
        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }
        public string Address
        {
            get => _address;
            set
            {
                _address = value;
                OnPropertyChanged("Address");
            }
        }
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }
        #endregion

        #region Operattors overload
        public override String ToString() => $"Driver {_firstName} {LastName}";
        #endregion

    }

}
