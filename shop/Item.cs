using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;

namespace shop
{
    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Category_Id { get; set; }
        public string ImageSource { get; set; }
    }
}