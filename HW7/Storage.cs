using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7
{
    public static class Storage
    {
        public static List<Merchandise> Merchandises { get; set; } = new List<Merchandise>();
        public static List<User> Users { get; set; } = new List<User>();
        public static List<Admin> Admins { get; set; } = new List<Admin>();
        public static List<Order> Orders { get; set; } = new List<Order>();
        public static List<Order> Pendorders { get; set; } = new List<Order> { };
        static Storage()
        {
            Merchandises.Add(new Merchandise("Laptop", 50) {Productid=1});
            Merchandises.Add(new Merchandise("S24 Ultra", 62) {Productid=2});
            Admins.Add(new Admin("r", "1") { Userid = 1,Name="Arash",Lastname="Rajabi" });
            Users?.Add(new User("A", "2") {Userid=2});
            Users?.Add(new User("KasraK21@gmail.com", "56789") {Userid=3});
        }
    }
}
