using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace shop
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PasswordHash { get; set; }
        public List<Order> Orders { get; set; }


    }
}
