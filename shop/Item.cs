using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;

namespace shop
{
    public class Item
    {
        private int Category_Id;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
    }
}