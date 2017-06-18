using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;

namespace shop
{
    public class User
    {
        public int Cart_id;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public List<Order> Orders { get; set; }
        public object salt { get; set; }
    }
}