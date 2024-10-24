using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7
{
    public class Merchandise
    {
        public string Name { get; set; }
        public int Price {  get; set; }
        public int Quantity { get; set; }
        public int Productid { get; set; }
        public string Size { get; set; }
        
        public Merchandise(string name,int price) 
        {
            Name = name;
            Price = price;
            Quantity = 100;
        }
        public Merchandise() { Quantity = 100; }
        public void Info()
        {
            Console.WriteLine("====================");
            Console.WriteLine($"Name: {Name} ");
            Console.WriteLine($"price: {Price}");
            Console.WriteLine($"Size: {Size}");
            Console.WriteLine($"Product ID: {Productid}");
            Console.WriteLine($"Number of {Name} available in storage: {Quantity}");
        }
    }
}
