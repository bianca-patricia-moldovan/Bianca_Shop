using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Bianca_Shop.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
