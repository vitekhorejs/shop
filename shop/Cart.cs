using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;

namespace shop
{
    public class Cart
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int Price
        {
            get => throw new System.NotImplementedException();
        }
    }
}