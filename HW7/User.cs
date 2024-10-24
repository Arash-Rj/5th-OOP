using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7
{
    public class User
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public List<Merchandise> merchandises { get; set; } = new List<Merchandise>();
        public Shoppingcart cart { get; set; } = new Shoppingcart();
        public int Userid { get; set; }
        public User(string email,string password) 
        {
            Email = email;
            Password = password;
        }
        public User() { }
        public void UserIfno()
        {
            Console.WriteLine("=============");
            Console.WriteLine($"Username: {Name} {Lastname}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Password: {Password}");
            Console.WriteLine($"User ID: {Userid}");
        }
        public void ChangeEmail(string email)
        {
            Email=email;
            Console.WriteLine("Email successfully changed.");
        }
        public void ChangePassword(string password)
        {
            Password=password;
            Console.WriteLine("Password successfully changed.");
        }
        public void PurchaseHistory()
        {
           //merchandises.ForEach(merchandises => { merchandises.Info(); Console.WriteLine(merchandises.count + merchandises.Name); });
            foreach(ShoppingcartMerchandise merchandise in merchandises)
            {
                merchandise.Info();
                Console.WriteLine($"Count: {merchandise.count}");
            }
        }
    }
}
