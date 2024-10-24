using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7
{
    public class AdminService
    {
        public Admin? Login(string email, string password)
        {
            foreach (Admin user in Storage.Admins)
            {
                if (user == null) { break; }
                if (user.Email == email && user.Password == password)
                {
                    return user;
                }
            }
            return null;
        }
        public void SubmitOrder(User user)
        {
            List<Merchandise> merchandises = new List<Merchandise>();
            merchandises.AddRange(user.cart.Merchandises);
            Order order = new Order(user,merchandises);
            //Admin admin = Storage.Admins.First<Admin>();
            Storage.Pendorders.Add(order);
        }
        public void ConfirmOrder(User user,Order order,Admin admin)
        {
            Storage.Orders.Add(order);
            user.merchandises.AddRange(user.cart.Merchandises);
            //user.cart.Merchandises.ForEach((merchandise) => { merchandise.Quantity -= merchandise.count;/* merchandise.count = 0;*/ });
            foreach(ShoppingcartMerchandise merchandise in user.cart.Merchandises)
            {
                foreach(Merchandise merchandise1 in Storage.Merchandises)
                {
                    if (merchandise.Productid == merchandise1.Productid )
                    {
                        merchandise1.Quantity -= merchandise.count;
                        merchandise.Quantity = merchandise1.Quantity;
                    }
                }
            }
            Storage.Pendorders.Remove(order);
            user.cart.Merchandises.Clear();
            //order.Merchandise.Add()
        }
        public void AddNewMerchandise(string name,int price,Merchandise merchandise )
        {
            int id = SearchLastPID();
            merchandise.Name = name;
            merchandise.Price = price;
            merchandise.Productid = id+1;
            Storage.Merchandises.Add(merchandise);
        }
        public void ChangeProductQuantity(int id,int quantity)
        {
            foreach(Merchandise merchandise in Storage.Merchandises)
            {
                if(merchandise.Productid == id)
                {
                    merchandise.Quantity = quantity;
                }
            }
        }
        public void RemoveMerchandise(int id)
        {
            foreach (Merchandise merchandise in Storage.Merchandises)
            {
                if (merchandise.Productid == id)
                {
                    Storage.Merchandises.Remove(merchandise);
                    break;
                }
            }
        }
        public int SearchLastPID()
        {
            int id = 0;
            Merchandise mer = Storage.Merchandises.Last<Merchandise>();
            id = mer.Productid;
            return id;
        }
    }
}
