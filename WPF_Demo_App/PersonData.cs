using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using WPF_Demo_App.Interface;

namespace WPF_Demo_App
{
    public class PersonData : IPersonData
    {
        #region Fields
        private string _name;
        private string _country;
        private string _address;
        private string _postalZip;
        private string _email;
        private string _phone;
        #endregion

        #region Properties        

        [Index(0)]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        [Index(1)]
        public string Country
        {
            get
            {
                return _country;
            }
            set
            {
                _country = value;
            }
        }

        [Index(2)]
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
            }
        }

        [Index(3)]
        public string PostalZip
        {
            get
            {
                return _postalZip;
            }
            set
            {
                _postalZip = value;
            }
        }

        [Index(4)]
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }

        [Index(5)]
        public string Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                _phone = value;
            }
        }

        #endregion
    }
}
