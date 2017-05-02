using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace shop
{
    public class User
    {
        public int Id;
        public string Name;
        public string Surname;
        public string Password;
        public string Mail;
        public List<Order> Orders;
    }
}