using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7
{
    public class ShoppingcartMerchandise: Merchandise
    {
        public ShoppingcartMerchandise(string name, int price) : base(name, price)
        {
            count = 0;
        }

        public ShoppingcartMerchandise() { count = 0; }

        public int count { get; set; }
    }
}
