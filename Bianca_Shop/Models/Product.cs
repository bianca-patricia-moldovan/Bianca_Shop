using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Bianca_Shop.Models
{
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string Image { get; set; }
    }
}
