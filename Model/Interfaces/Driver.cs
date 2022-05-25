using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Interfaces
{
    [Serializable]
    public class Driver
    {
        #region Constructor
        public Driver(string firstName, string lastName, string address, string phoneNumber)
        {
            _firstName = firstName;
            LastName = lastName;
            Address = address;
            PhoneNumber = phoneNumber;
        }
        private Driver()
        {

        }
        #endregion

        #region Fields
        private string _firstName;
        private string _lastName;
        private string _address;
        private string _phoneNumber;
        #endregion

        #region Getters&Setters
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public string Address { get => _address; set => _address = value; }
        public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
        #endregion

        #region Operattors overload
        public override String ToString() => $"Driver {_firstName} {LastName}";
        #endregion

    }

}
