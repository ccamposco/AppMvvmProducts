using AppMvvmProducts.Data;
using AppMvvmProducts.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppMvvmProducts.ViewModels
{
   public class ContactVM : BaseViewModel
    {

        public Command _SaveCommand;
        public Command _ShowCommand;

        private string _nameProp;
        private string _phoneProp;
        private string _cityProp;
        
        ObservableCollection<Contact> contacts = new ObservableCollection<Contact>();

        public ObservableCollection<Contact> Contacts { get { return contacts; } }
        public ContactVM()
        {

        }

        public ICommand SaveCommand
        {
            get
            {
                if (_SaveCommand == null)
                {
                    _SaveCommand = new Command(SavetoDB);
                }
                return _SaveCommand;
            }
        }
        public ICommand ShowCommand
        {
            get
            {
                if (_ShowCommand == null)
                {
                    _ShowCommand = new Command(ShowData);
                }
                return _ShowCommand;
            }
        }
        public string NameProp
        {
            get => _nameProp;
            set
            {
                if (_nameProp != value) { _nameProp = value; }
                OnPropertyChanged();
            }
        }
        public string PhoneProp
        {
            get => _phoneProp;
            set
            {
                if (_phoneProp != value) { _phoneProp = value; }
                OnPropertyChanged();
            }
        }
        public string CityProp
        {
            get => _cityProp;
            set
            {
                if (_cityProp != value) { _cityProp = value; }
                OnPropertyChanged();
            }
        }
        private void SavetoDB()
        {
            var name = NameProp;
            var phone = PhoneProp;
            var city = CityProp;
            
            //Access DB Class
            DataLogic dl = new DataLogic();
            bool success = dl.SavetoDB(name, phone, city);
            if (success)
            {
                NameProp = string.Empty;
                PhoneProp = string.Empty;
                CityProp = string.Empty;
            }
        }
        private void ShowData()
        {
            DataLogic dataLogic = new DataLogic();
            var lstContact = dataLogic.ShowData();
            foreach (var contactDetails in lstContact)
            {
                Contact contact = new Contact
                {
                    Id = contactDetails.Id,
                    Name = contactDetails.Name,
                    Phone = contactDetails.Phone,
                    City = contactDetails.City
                };
                Contacts.Add(contact);
            }
        }
    }
}
