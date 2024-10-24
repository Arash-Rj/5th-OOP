using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7
{
    public class Storeservice
    {
        public void AddToCart(int id,User user)
        {
            bool check = false;  
            foreach(Merchandise merchandise in Storage.Merchandises)
            {
                foreach (ShoppingcartMerchandise merchandise1 in user.cart.Merchandises)
                {
                    if (merchandise.Productid == id && merchandise.Productid == merchandise1.Productid)
                    {
                        //merchandise.Quantity--;
                        merchandise1.count++;
                        check = true;
                        break;
                    }
                }
                if (merchandise.Productid == id && check==false)
                {
                        ShoppingcartMerchandise sh = new ShoppingcartMerchandise();
                        sh.Name = merchandise.Name;
                        sh.Price = merchandise.Price;
                        sh.Quantity = merchandise.Quantity;
                        sh.Productid = merchandise.Productid;
                        sh.Size = merchandise.Size;
                        sh.count++;
                        user.cart.Merchandises.Add(sh);
                        break;
                }
            }
          
        }
        public void ListOfProducts()
        {
            Storage.Merchandises.ForEach(merchandise => { merchandise.Info(); });
        }
        public void RemoveFromCart(User user,int id)
        {
            foreach(ShoppingcartMerchandise merchandise in user.cart.Merchandises)
            {
                if (merchandise.Productid == id)
                {
                    user.cart.Merchandises.Remove(merchandise);
                    //merchandise.Quantity += merchandise.count;
                    merchandise.count = 0;
                    Console.WriteLine("Removed.");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine("Product ID was wrong.");
                    Console.ReadKey();
                    break;
                }
            }
        }
        //public void ResetproductCount()
        //{
        //    foreach(Merchandise merchandise in Storage.Merchandises)
        //    {
        //        merchandise.count = 0;
        //    }
        //}

    }
}
