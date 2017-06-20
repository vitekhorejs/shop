using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;

namespace shop
{
    public class Category
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageSource { get; set; }
    }
}