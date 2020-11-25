using Caliburn.Micro;
using SchoolDBUI.Library.Models.Contact;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SchoolDBUI.ViewModels.Components
{
    public class AddressAddControlViewModel : Screen
    {
        #region Addresses
        private string streetAddressTextbox;

        public string StreetAddressTextbox
        {
            get { return streetAddressTextbox; }
            set
            {
                streetAddressTextbox = value;
                NotifyOfPropertyChange(() => StreetAddressTextbox);
            }
        }

        private string postcodeTextbox;

        public string PostcodeTextbox
        {
            get { return postcodeTextbox; }
            set
            {
                postcodeTextbox = value;
                NotifyOfPropertyChange(() => PostcodeTextbox);
            }
        }

        private string suburbTextbox;

        public string SuburbTextbox
        {
            get { return suburbTextbox; }
            set
            {
                suburbTextbox = value;
                NotifyOfPropertyChange(() => SuburbTextbox);
            }
        }

        private string cityTextbox;

        public string CityTextbox
        {
            get { return cityTextbox; }
            set
            {
                cityTextbox = value;
                NotifyOfPropertyChange(() => CityTextbox);
            }
        }

        private string stateTextbox;

        public string StateTextbox
        {
            get { return stateTextbox; }
            set
            {
                stateTextbox = value;
                NotifyOfPropertyChange(() => StateTextbox);
            }
        }

        private bool primaryAddressBox;

        public bool PrimaryAddressBox
        {
            get { return primaryAddressBox; }
            set
            {
                primaryAddressBox = value;
                NotifyOfPropertyChange(() => PrimaryAddressBox);
            }
        }

        public Address SelectedAddress { get; set; }

        private BindingList<Address> addresses = new BindingList<Address>();

        public BindingList<Address> Addresses
        {
            get { return addresses; }
            set 
            {
                addresses = value;
                NotifyOfPropertyChange(() => Addresses);
            }
        }

        public void AddAddress()
        {
            var address = new Address
            {
                StreetAddress = StreetAddressTextbox,
                Suburb = SuburbTextbox,
                City = CityTextbox,
                State = StateTextbox,
                Postcode = PostcodeTextbox,
                IsPrimary = PrimaryAddressBox
            };

            Addresses.Add(address);
            ResetAddressTextFields();
        }

        public void RemoveAddress()
        {
            if (SelectedAddress != null)
            {
                Addresses.Remove(SelectedAddress);
            }
            ResetAddressTextFields();
        }

        private void ResetAddressTextFields()
        {
            StreetAddressTextbox = "";
            SuburbTextbox = "";
            CityTextbox = "";
            StateTextbox = "";
            PostcodeTextbox = "";
            PrimaryAddressBox = false;
        }

        #endregion
    }
}
