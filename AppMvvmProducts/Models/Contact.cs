using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppMvvmProducts.Models
{
    public class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Phone { get; set; }

        [MaxLength(100)]
        public string City { get; set; }

    }
}
