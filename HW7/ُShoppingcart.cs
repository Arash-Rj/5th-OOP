using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7
{
    public class Shoppingcart
    {
        public int Id { get; set; }
        public List<ShoppingcartMerchandise> Merchandises { get; set; } = new List<ShoppingcartMerchandise>();

    }
}
