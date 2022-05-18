using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Interfaces
{
    public class Driver
    {
        public Driver(string firstName, string lastName, string address, string phoneNumber)
        {
            _firstName = firstName;
            _lastName = lastName;
            _address = address;
            _phoneNumber = phoneNumber;
        }
        private Driver()
        {

        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {

                if (!String.IsNullOrEmpty(value))
                {
                    _firstName = value;
                }

            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {

                if (!String.IsNullOrEmpty(value))
                {
                    _lastName = value;
                }

            }
        }

        public string Address
        {
            get
            {
                return _address;
            }
            set
            {

                if (!String.IsNullOrEmpty(value))
                {
                    _address = value;
                }

            }
        }

        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {

                if (!String.IsNullOrEmpty(value))
                {
                    _phoneNumber = value;
                }

            }
        }


        private string _firstName;
        private string _lastName;
        private string _address;
        private string _phoneNumber;
        public override String ToString()
        {
            return "Driver " + _firstName + " " + _lastName;
        }

    }

}
