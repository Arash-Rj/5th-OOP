using HW7;
Userservice userService = new Userservice();
Storeservice storeservice = new Storeservice();
AdminService adminService = new AdminService();

int option = 0;
do
{
    Console.Clear();
    Console.WriteLine("**************************");
    Console.WriteLine("Welcome to the store.");
    Console.WriteLine("1.Log in.");
    Console.WriteLine("2.Sign up.");
    Console.WriteLine("3.Exit.");
    Console.WriteLine("**************************");

    option = int.Parse(Console.ReadLine());
    switch (option)
    {
        case 1:
            Console.Clear();
            Console.WriteLine("**************************");
            Console.WriteLine("1.Admin    2.Costumer");
            int ch = Convert.ToInt32(Console.ReadLine());
            if (ch == 2)
            {
                Console.Write("Please Enter your Email : ");
                string email = Console.ReadLine();
                Console.Write("Please Enter your Password : ");
                string password = Console.ReadLine();
                User U = userService.Login(email, password);
                if (U == null)
                {
                    Console.WriteLine("User not found!");
                    Console.ReadKey();
                }
                else if (U is not Admin)
                {
                    int op1 = 0;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("$==================$");
                        Console.WriteLine($"Welcome to the Store {U.Name}");
                        Console.WriteLine("1.User menu     2.Store products");
                        op1 = int.Parse(Console.ReadLine());
                        switch (op1)
                        {
                            case 1:
                                Usermenu(U);

                                break;
                            case 2:
                                Storeproducts(U);

                                break;
                        }
                    } while (op1 < 3);
                }
            }
            if(ch == 1)
            {
                Console.Write("Please Enter your Email : ");
                string email = Console.ReadLine();
                Console.Write("Please Enter your Password : ");
                string password = Console.ReadLine();
                Admin admin  = adminService.Login(email, password);
                if (admin == null)
                {
                    Console.WriteLine("User not found!");
                    Console.ReadKey();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("$==================$");
                    Console.WriteLine($"Welcome to the Store {admin.Name}");
                    AdminMenu(admin);
                }
            }
            //storeservice.ResetproductCount();
            break;
        case 2:
            Console.Clear();
            Console.WriteLine("**************************");
            Console.WriteLine("Please enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Please enter your lastname: ");
            string lastname = Console.ReadLine();
            Console.Write("Pls Enter The Email: ");
            string? mail = Console.ReadLine();
            Console.Write("Pls Enter The Password: ");
            string? Pass = Console.ReadLine();
            User? user1 = new User();
            userService.Register(mail, Pass,out user1);
            if (user1 != null)
            {
                user1.Name = name;
                user1.Lastname = lastname;
                Console.WriteLine("======Register successful======");
                Console.WriteLine();
                Console.WriteLine("Do you want to proceed?");
                Console.WriteLine("1.Yes     2.No");
                int opt = int.Parse(Console.ReadLine());
                switch (opt)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("$==================$");
                        Console.WriteLine($"Welcome to the Store {user1.Name}");
                        Console.WriteLine("1.User menu     2.Store products");
                        int op1 = int.Parse(Console.ReadLine());
                        switch (op1)
                        {
                            case 1:
                                Usermenu(user1);
                                break;
                            case 2:
                                Storeproducts(user1);
                                break;
                        }
                    break;
                    case 2:
                        Console.Clear();
                        break;
                }
            }
            else
            {
                Console.WriteLine("==Please try again.==");
            }
            //storeservice.ResetproductCount();
            Console.ReadKey();
            break;
    }
}
while (option < 3);
void Usermenu(User user)
{
    int option2 = 0;
    do
    {
        Console.Clear();
        Console.WriteLine("1.User information.");
        Console.WriteLine("2.Change email.");
        Console.WriteLine("3.Change password.");
        Console.WriteLine("4.Purchase history.");
        Console.WriteLine("5.Exit.");
        option2 = Convert.ToInt32(Console.ReadLine());
        switch (option2)
        {
            case 1:
                Console.Clear();
                user.UserIfno();
                Console.ReadKey();
                break;
            case 2: 
                Console.Clear();
                Console.WriteLine("Enter the new email: ");
                string em = Console.ReadLine();
                user.ChangeEmail(em);
                Console.WriteLine("Done!");
                Console.ReadKey();
                break;
            case 3:
                Console.Clear();
                Console.WriteLine("Enter the new password: ");
                string pass = Console.ReadLine();
                user.ChangePassword(pass);
                Console.WriteLine("Done!");
                Console.ReadKey();
                break;
            case 4:
                Console.Clear();
                if(user.merchandises.Count ==0)
                {
                    Console.WriteLine("You have not purchased anything yet.");
                    Console.ReadKey();
                    break ;
                }
                else
                {
                    user.PurchaseHistory();
                    Console.ReadKey (); 
                    break ;
                }
        }
    }
    while (option2 < 5);
    }
void Storeproducts(User user)
{
    int option3 = 0;
    do
    {
        Console.Clear();
        Console.WriteLine("1.Products list.");
        Console.WriteLine("2.Shopping cart.");
        //Console.WriteLine("3.Order List.");
        Console.WriteLine("3.Exit.");
        option3 = Convert.ToInt32(Console.ReadLine());
        switch (option3)
        {
            case 1:
                Console.Clear();
                Console.WriteLine("=======Products=======");
                storeservice.ListOfProducts();
                Console.WriteLine("======================");
                Console.Write("Enter the id of product you want: ");
                int id = Convert.ToInt32(Console.ReadLine());
                storeservice.AddToCart(id, user);
                Console.WriteLine("Added to cart.");
                Console.ReadKey();
                break;
            case 2:
                int an = 0;
                do
                {
                    Console.Clear();
                    Console.WriteLine("*****Shopping cart*****");
                    if (user.cart.Merchandises.Count == 0)
                    {
                        Console.WriteLine("Nothing in the shopping cart.");
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        user.cart.Merchandises.ForEach(x => { x.Info(); Console.WriteLine($"Count:{x.count}"); });
                        Console.WriteLine("=======================");
                        Console.WriteLine("1.Submit order.");
                        Console.WriteLine("2.Remove from cart.");
                        Console.WriteLine("3.Exit.");
                        an = Convert.ToInt32(Console.ReadLine());
                        switch (an)
                        {
                            case 1:
                                Console.Clear();
                                adminService.SubmitOrder(user);
                                Console.WriteLine("******Successful,Order prnding.******");
                                Console.ReadKey();
                                break;
                            case 2:
                                Console.Write("Enter the Id of product: ");
                                int ip = Convert.ToInt32(Console.ReadLine());
                                storeservice.RemoveFromCart(user, ip);
                                break;
                        }
                    }
                } while (an < 3);
                break;
                //case 3:
                //Console.Clear();
                //break;
        }
    }
    while (option3 < 3);
    }
void AdminMenu(Admin admin)
{
    int option4 = 0;
    do
    {
        Console.Clear();
        Console.WriteLine("1.Confirm order.");
        Console.WriteLine("2.Add new merchandise.");
        Console.WriteLine("3.Change quantity of merchandises.");
        Console.WriteLine("4.Remove merchandises.");
        Console.WriteLine("5.All orders.");
        Console.WriteLine("6.Exit.");
        option4 = Convert.ToInt32(Console.ReadLine());
        switch (option4)
        {
            case 1:
                Console.Clear();
                Console.WriteLine("*****Pending Orders*****");
                Storage.Pendorders.ForEach(order => { order.OrderInfo(); });
                Console.WriteLine("Which user's order do you want to confirm? (Enter user id)");
                int id = Convert.ToInt32(Console.ReadLine());
                Order order = new Order();
                User user = userService.GetUser(id,out order);
                adminService.ConfirmOrder(user, order,admin);
                Console.WriteLine("Done!");
                Console.ReadKey();
                break;
            case 2:
                Console.Clear();
                Merchandise merchandise = new Merchandise();
                Console.WriteLine("Enter the name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Price: ");
                int price = Convert.ToInt32(Console.ReadLine());
                adminService.AddNewMerchandise(name, price, merchandise);
                Console.WriteLine("Done!");
                Console.ReadKey();
                break;
            case 3:
                Console.Clear();
                storeservice.ListOfProducts();
                Console.WriteLine("Which product's quantity do you want to change? (Enter product id)");
                int idp = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the new quantity: ");
                int quantity = Convert.ToInt32(Console.ReadLine());
                adminService.ChangeProductQuantity(idp, quantity);
                Console.WriteLine("Done!");
                Console.ReadKey();
                break;
            case 4:
                Console.Clear();
                storeservice.ListOfProducts();
                Console.WriteLine("Which product do you want to remove? (Enter product id)");
                int idp2 = Convert.ToInt32(Console.ReadLine());
                adminService.RemoveMerchandise(idp2);
                Console.WriteLine("Done!");
                Console.ReadKey();
                break;
            case 5:
                Console.Clear();
                Console.WriteLine("Order's history: ");
                Storage.Orders.ForEach(o => { o.OrderInfo(); });
                Console.WriteLine("==================");
                Console.WriteLine("Pending orders: ");
                Storage.Pendorders.ForEach(o => { o.OrderInfo(); });
                Console.ReadKey();
                break;
        }
    } while (option4 < 6);
}