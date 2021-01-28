using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using SQLite;

using Bianca_Shop.Models;

namespace Bianca_Shop.Models
{
    public class Return
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [ForeignKey(nameof(User))]
        public int userID { get; set; }

        [ForeignKey(nameof(Product))]
        public int productID { get; set; }

        public string userComment { get; set; }

        public string status { get; set; }


    }
}
