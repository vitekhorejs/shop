using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace shop
{
    public class Order
    {
        public int Id;
        public string Name;
        public int User_id;
        public List<Item> Items;

        public void Price()
        {
            throw new System.NotImplementedException();
        }
    }
}