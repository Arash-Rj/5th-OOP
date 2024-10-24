using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7
{
    public class Admin : User
    {
        public Admin(string email, string password) : base(email, password)
        {
        }
        public Admin(): base() { }
        //public List<Order> Orders = new List<Order>();
    }
}
