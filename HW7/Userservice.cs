using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7
{
    public class Userservice
    {
        public User? Login(string email, string password)
        {
            foreach(User user in Storage.Users)
            {
                if (user == null) { break; }
                if (user.Email == email && user.Password == password)
                {
                    return user;
                }
            }
            return null;
        }
        public void Register(string? email, string? password, out User? user)
        {
            user = null;
            if (email is "" || password is "")
            {
                Console.Clear();
                Console.WriteLine("******invalid password or email.******");
                //user = null;
                //Console.ReadKey();
            }
            else 
            {
                bool check = Duplicatedemailorpass(email, password);
                if (check == true)
                {
                    Console.Clear();
                    Console.WriteLine("*****User already exists.*****");
                    //user = null;
                    //Console.ReadKey();
                }
                else if (check == false)
                {
                    int id = 0;
                    id = SearchLastID();
                    user = new User(email, password) { Userid = id + 1 };
                    Storage.Users.Add(user);
                }
            }
        }
        public bool Duplicatedemailorpass(string email, string password)
        {
            foreach (User user in Storage.Users)
            {
                if (user == null) { return false; }
                if (user.Email.Equals(email) && user.Password == password)
                { return true; }
            }
            return false;
        }
        public int SearchLastID()
        {
            int id = 0;
            User user = Storage.Users.Last<User>();
            id= user.Userid;
            return id;
        }
        public User? GetUser(int id,out Order order1)
        {
            order1 = null;
            foreach(Order order in Storage.Pendorders )
            {
                if(order.User.Userid == id)
                {
                    order1 =order;
                    return order.User;
                }
            }
            return null;
        }
    }
}
