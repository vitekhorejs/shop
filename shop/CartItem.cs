using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace shop
{
    public class CartItem
    {
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }
        public int ID_Cart { get; set; }
        public int ID_Item { get; set; }
    }
}
