using AppMvvmProducts.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace AppMvvmProducts.Data
{
    public class DataLogic
    {
        private SQLiteConnection conn;
        private Contact contact;

        public DataLogic()
        {
            conn = DependencyService.Get<ISQLite>().GetConnection();
            conn.CreateTable<Contact>();
        }

        public bool SavetoDB(string name, string phone, string city)
        {
            contact = new Contact();
            contact.Name = name;
            contact.Phone = phone;
            contact.City = city;
            try
            {
                conn.Insert(contact);
                conn.Close();
                return true;
            }
            catch (SQLiteException) { }
            catch (Exception) { }
            return false;
        }

        public IEnumerable<Contact> ShowData()
        {
            var lstContact = from contact in conn.Table<Contact>() select contact;
            return lstContact;
        }
    }
}
