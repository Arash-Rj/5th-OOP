using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7
{
    public class Order
    {
        public User User { get; set; } = new User();
        public List<Merchandise> Merchandise { get; set; } = new List<Merchandise>();
        public Order(User user,List<Merchandise> merchandise) 
        { 
            User = user;
            Merchandise = merchandise;
        }
        public Order() { }
        public void OrderInfo()
        {
            Console.WriteLine("======================");
            Console.WriteLine($"Costumer: {User.Username}");
            Console.WriteLine($"User ID: {User.Userid}");   
            Console.WriteLine($"Order: ");
            foreach (ShoppingcartMerchandise merchandise in Merchandise)
            {
                merchandise.Info();
                Console.WriteLine($"Count: {merchandise.count}");
            }

        }
    }
}
