using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using System.Threading;
using System.Threading.Channels;
using Shop.Enums;

namespace Shop
{
    class Session
    {
        public int sessionId;
        public SessionStatus SessionStatus { get; private set; } = SessionStatus.active;
        Visitor visitor = new Visitor();


        public Session()
        {
            Random r = new Random(DateTime.Now.Millisecond);
            sessionId = r.Next(int.MaxValue);
            
        }
        
        //db actions
        private List<Action> actions = new List<Action>
        {
            new Action("Login", 1, true, "guest"),
            new Action("Logout", 2, false,"registeredUser", "administrator"),
            new Action("Show product list", 3, true, "guest", "registeredUser", "administrator"),
            new Action("Product search", 4, true, "guest", "registeredUser", "administrator"),
            new Action("Registration", 5, true, "guest"),
            new Action("New Order", 6, false, "registeredUser", "administrator"),
            new Action("Order History", 7, false, "registeredUser", "administrator"),
            new Action("Order status change", 8, false, "registeredUser", "administrator"),
            new Action("Update Profile", 9, false, "registeredUser", "administrator"),
            //new Action("Cancel order", 10, false,  "registeredUser", "administrator"),
            new Action("User profile change", 11, false, "administrator"),
            new Action("Product add", 12, false, "administrator"),
            new Action("Product data change", 13, false,  "administrator"),
            //new Action("Order status change", 14, false,  "administrator"), //
            new Action("Exit", 15, true, "guest", "registeredUser", "administrator")
        };

        //DB of products sample
        List<Product> productsList = new List<Product>()
        {
            new Product("Apple", Product.productCategoryType.Fruit, "Description of Apple", 100m),
            new Product("Plum", Product.productCategoryType.Fruit, "Description of Plum", 200m),
            new Product("Carrot", Product.productCategoryType.Vegetable, "Description of Carrot", 300m),
            new Product("Veal", Product.productCategoryType.Meat, "Description of Veal", 400m),
            new Product("Pork", Product.productCategoryType.Meat, "Description of Pork", 500m),
            new Product("Sword fish", Product.productCategoryType.Fish, "Description of Sword fish", 600m),
            new Product("Beer", Product.productCategoryType.Alcohol, "Description of Beer", 600m),
            new Product("Wine", Product.productCategoryType.Alcohol, "Description of Wine", 600m),
            new Product("Juice", Product.productCategoryType.nonAlcohol, "Description of Juice", 600m),
            new Product("Coca-Cola", Product.productCategoryType.nonAlcohol, "Description of Coca-Cola", 600m)
        };

        //DB of users sample
        List<User> userList = new List<User>()
        {
            new User("Ivan", "Ivan","Ivan1"),
            new User("Andrii", "Andrii","Andrii1"),
            new User("Sergii", "Sergii","Sergii1"),
            new User("Petro", "Petro","Petro1"),
            new User("Kirill", "Kirill","Kirill1", true)
        };


        public void Display(int button)
        {
            bool ifAvailableChoise = false;
            foreach (var item in actions)
            {
                if (item.button == button && item.ifEnabled)
                {
                    ifAvailableChoise = true;
                    break;
                }
            }

            if (!ifAvailableChoise)
            {
                Console.WriteLine("You made incorrect choice");
            }
            else
            {
                switch (button)
                {
                    case 15:
                        SessionStatus = SessionStatus.notActive;
                        break;

                    case 1:
                        Login();
                        break;

                    case 2:
                        visitor._visitorType = Visitor.VisitorType.guest;
                        ActionVisibilityChanger.ActionChanger(actions, visitor);
                        break;

                    case 3:
                        DisplayProducts();
                        break;

                    case 4:
                        DisplayProductSearch();
                        break;

                    case 5:
                        Registration();
                        break;

                    case 6:
                        Shopping();
                        break;

                    case 7:
                        SeeOrderHistory(); 
                        break;

                    case 8:
                        OrderStatusUpdate();
                        break;

                    case 9:
                        UserDataChangeByUser();
                        break;

                    //case 10:
                    //    OrderStatusUpdate();
                    //    break;

                    case 11:
                        UserDataChangeByAdmin();
                        break;

                    case 12:
                        ProductAdd();
                        break;

                    case 13:
                        ProductDataChange();
                        break;

                    default:
                        Console.WriteLine("How did you get here?");
                        break;

                }
            

           
            }
        }

        public void Login()
        {
            Console.Write("Please enter login:");
            string enteredLogin = Console.ReadLine();
            Console.Write("Please enter password:");
            string enteredPassword = Console.ReadLine();

            bool isAllowed = false;
            bool ifAdmin = false;

            foreach (var user in userList)
            {
                if (enteredLogin == user.userLogin && enteredPassword == user.userPassword)
                {
                    isAllowed = true;
                    if (user.ifAdmin) ifAdmin = true;
                    break;
                }
                
            }

            if (isAllowed)
            {
                if (ifAdmin)
                {
                    visitor._visitorType = Visitor.VisitorType.administrator;
                }
                else
                {
                    visitor._visitorType = Visitor.VisitorType.registeredUser;
                }

                visitor.login = enteredLogin;
                actions = ActionVisibilityChanger.ActionChanger(actions, visitor);
            }
            else
            {
                Console.WriteLine("Incorrect credentials");
            }
        }


        public void DisplayMenuBar()
        {
            foreach (var item in actions)
            {
                if (item.ifEnabled)
                {
                    Console.Write($" {item.button} - {item.name} |");
                }
            }
            Console.WriteLine();
        }

        void DisplayProducts()
        {
            for (int i = 0; i < productsList.Count; i++)
            {
                Console.WriteLine("==========================");
                Console.WriteLine($"Position {i + 1}");
                Console.WriteLine("Product Name>> " + productsList[i].ProductName);
                Console.WriteLine("Category    >> " + productsList[i].ProductCategory);
                Console.WriteLine("--------------------------");
                Console.WriteLine(productsList[i].ProductDescription);
                Console.WriteLine($"{productsList[i].ProductPrice} EURO");
                Console.WriteLine("==========================");
                Console.WriteLine();
            }

           
        }


        void DisplayProductSearch()
        {
            Console.WriteLine("What do you want to find?");
            string searchWord = Console.ReadLine().ToLower();

            for (int i = 0; i < productsList.Count; i++)
            {
                if (productsList[i].ProductName.ToLower().Contains(searchWord)) 
                { 
                    Console.WriteLine("==========================");
                    Console.WriteLine($"Position {i + 1}");
                    Console.WriteLine(">" + productsList[i].ProductName);
                    Console.WriteLine(">>" + productsList[i].ProductCategory);
                    Console.WriteLine("--------------------------");
                    Console.WriteLine(productsList[i].ProductDescription);
                    Console.WriteLine($"{productsList[i].ProductPrice} EURO");
                    Console.WriteLine("==========================");
                    Console.WriteLine();
                }
            }
        }

        void Registration()
        {
            Console.Write("Please enter your name:");
            string name = Console.ReadLine();

            Console.Write("Please enter your login:");
            string login = Console.ReadLine();

            Console.Write("Please enter your password:");
            string password = Console.ReadLine();

            //add usercheck later
            Console.WriteLine("Thank you for registration");
            userList.Add(new User(name, login, password));
        }

        void Shopping()
        {
            List<Product> shoppingList = new List<Product>();
            string str = "tba";
            while(str.ToLower().Trim() != "exit" || str.ToLower().Trim() != "pay")
            {
                DisplayProducts();
                if (shoppingList != null)
                {
                    Console.Write("Your basket: ");
                    foreach (var item in shoppingList)
                    {
                        Console.Write($"{item.ProductName}; ");
                    }
                }

                Console.WriteLine();
                Console.WriteLine("What do you wish to buy? Type product Position # or 'pay' for payment, or 'exit' for exit");
                str = Console.ReadLine();

                if (str.ToLower().Trim() == "exit")
                {
                    Console.WriteLine("See you next time");
                    break;
                }

                if (str.ToLower().Trim() == "pay")
                {
                    foreach (var user in userList)
                    {
                        if (user.userLogin == visitor.login)
                        {
                            Random r = new Random(DateTime.Now.Millisecond);
                            int orderNumber = r.Next(int.MaxValue);

                            user.OrderList.Add(shoppingList);
                            bool orderNumCheck = false;
                            while (!orderNumCheck)
                            {
                                orderNumCheck = user.OrderStatusList.TryAdd(orderNumber, OrderStatus.New);
                            }


                            Console.WriteLine("Payment completed...");
                            Console.WriteLine($"Order number is: {orderNumber}");
                            Console.WriteLine("Thank you for payment. You order is on the way");
                            break;
                        }
                    }
                    break;
                }
                bool ifProductExist = false;
                if (productsList[int.Parse(str)-1] != null)
                {
                    shoppingList.Add(productsList[int.Parse(str) - 1]);
                    ifProductExist = true;
                }
                
                if(!ifProductExist) Console.WriteLine("Invalid entry or Product is unavailable");
            }
        }

        void OrderStatusUpdate()
        {
            if (visitor._visitorType == Visitor.VisitorType.registeredUser)
            {
                SeeOrderHistory();
                
                Console.WriteLine("Please enter order number you wish to update:");
                int orderToUpdate = int.Parse(Console.ReadLine());
                bool ifExist = false;

                foreach (var user in userList)
                {
                    foreach (var order in user.OrderStatusList)
                    {
                        if (orderToUpdate == order.Key && order.Value == OrderStatus.New)
                        {
                            Console.WriteLine($"Current order status is {order.Value}");

                            Console.Write($"Do you want to change it to 'Cancelled'? Y/N: ");
                            string answer = Console.ReadLine();
                            user.OrderStatusList[orderToUpdate] = answer?.ToLower() == "y"? OrderStatus.CancelledByUser : OrderStatus.New;

                            Console.WriteLine($"New status of order {orderToUpdate} is {user.OrderStatusList[orderToUpdate]}");

                            ifExist = true;
                            break;
                        }

                        if (!ifExist)
                        {
                            Console.WriteLine($"You can't update status of order {orderToUpdate} or order is not exist");
                        }
                    }
                }

            }

            if (visitor._visitorType == Visitor.VisitorType.administrator)
            {
                Console.WriteLine("Please enter order number you wish to update");
                int orderToUpdate = int.Parse(Console.ReadLine());
                bool ifExist = false;

                foreach (var user in userList)
                {
                    foreach (var order in user.OrderStatusList)
                    {
                        if (orderToUpdate == order.Key)
                        {
                            Console.WriteLine($"Current order status is {order.Value}");

                            Console.WriteLine($"Please choose new status from list below: ");
                            int i = 0;
                            foreach (OrderStatus status in Enum.GetValues(typeof(OrderStatus)))
                            {
                                Console.Write($" {i} - {status} |");
                                i++;
                            }

                            Console.WriteLine();
                            Console.Write("New Status: ");
                            var newStatus = (OrderStatus)int.Parse(Console.ReadLine());

                            user.OrderStatusList[orderToUpdate] = newStatus;

                            Console.WriteLine($"New status of order {orderToUpdate} is {newStatus}");

                            ifExist = true;
                            break;
                        }

                        if (!ifExist)
                        {
                            Console.WriteLine($"No order number {orderToUpdate} in DataBase");
                        }
                    }
                }
            }
        }

        void SeeOrderHistory()
        {
            Console.WriteLine("Your orders are:");
            foreach (var user in userList)
            {
                if (user.userLogin == visitor.login)
                {
                    int orderNum = 0;
                    foreach (var order in user.OrderStatusList)
                    {
                        Console.WriteLine($">>Order {orderNum+1}<<");
                        foreach (var item in user.OrderList[orderNum])
                        {
                            Console.Write($"{item.ProductName}; ");
                        }

                        Console.WriteLine();
                        Console.WriteLine($"Order number: {order.Key}, Order status: {order.Value}");
                        Console.WriteLine("========================");
                        Console.WriteLine();
                        orderNum++;
                    }
                }
            }
        }
        
        void ProductAdd()
        {
            Console.WriteLine("Enter data for new Product");
            Console.Write("Name: ");
            string name = Console.ReadLine();


            int i = 0;
            foreach (Product.productCategoryType cat in Enum.GetValues(typeof(Product.productCategoryType)))
            {
                Console.Write($" {i} - {cat} |");
                i++;
            }

            Console.WriteLine();
            Console.Write("Category: ");

            var category = (Product.productCategoryType)int.Parse(Console.ReadLine());
            
            Console.Write("Description: ");
            string description = Console.ReadLine();
            Console.Write("Price: ");
            decimal price = decimal.Parse(Console.ReadLine());
            

            productsList.Add(new Product(name, category, description, price));
        }

        void ProductDataChange()
        {
            DisplayProducts();
            Console.WriteLine("Please type Position you wish to update");
            int positionToChange = int.Parse(Console.ReadLine())-1;
            Console.WriteLine($"It's {productsList[positionToChange].ProductName}");
            Console.Write($"Please type new Name iso {productsList[positionToChange].ProductName}: ");
            string newName = Console.ReadLine();

            Console.WriteLine($"Please choose Category from list below: ");
            int i = 0;
            foreach (Product.productCategoryType cat in Enum.GetValues(typeof(Product.productCategoryType)))
            {
                Console.Write($" {i} - {cat} |");
                i++;
            }

            Console.WriteLine();
            Console.Write("New category: ");
            var newCategory = (Product.productCategoryType)int.Parse(Console.ReadLine());

            Console.Write($"Please add description: ");
            string newDescription = Console.ReadLine();

            Console.Write($"Please add price: ");
            decimal newPrice = decimal.Parse(Console.ReadLine());

            productsList[positionToChange].ProductName = newName;
            productsList[positionToChange].ProductCategory = newCategory;
            productsList[positionToChange].ProductDescription = newDescription;
            productsList[positionToChange].ProductPrice = newPrice;

            Console.WriteLine("Updated");
            Console.ReadLine();
        }

        void UserDataChangeByUser()
        {
            Console.WriteLine("Do you wish to update you profile Y/N? ");
            bool ifUpdate = Console.ReadLine().ToLower() == "y";
            bool logout = false;

            if (ifUpdate)
            {
                
                string newName = "tba";
                string newLogin = "tba";
                string newPassword = "tba";

                foreach (var user in userList)
                {
                    if (user.userLogin == visitor.login)
                    {
                        newName = user.userName;
                        newLogin = user.userLogin;
                        newPassword = user.userPassword;
                        break;
                    }
                }


                ifUpdate = false;
                Console.WriteLine("Update name Y/N? ");
                ifUpdate = Console.ReadLine().ToLower() == "y";

                if (ifUpdate)
                {
                    Console.Write("Please enter new Name: ");
                    newName = Console.ReadLine();
                    Console.WriteLine("Name updated");
                }

                Console.WriteLine("Update login Y/N? ");
                ifUpdate = Console.ReadLine().ToLower() == "y";

                if (ifUpdate)
                {
                    Console.Write("Please enter new Login: ");
                    newLogin = Console.ReadLine();
                    logout = true;
                    Console.WriteLine("Login updated");
                }

                Console.WriteLine("Update password Y/N? ");
                ifUpdate = Console.ReadLine().ToLower() == "y";

                if (ifUpdate)
                {
                    Console.Write("Please enter new Password: ");
                    newPassword = Console.ReadLine();
                    logout = true;
                    Console.WriteLine("Password updated");
                }

                foreach (var user in userList)
                {
                    if (user.userLogin == visitor.login)
                    {
                        user.userName = newName;
                        user.userLogin = newLogin;
                        user.userPassword = newPassword;
                        break;
                    }
                }
            }

            if (logout)
            {
                Console.WriteLine("Please login again");
                visitor._visitorType = Visitor.VisitorType.guest;
                ActionVisibilityChanger.ActionChanger(actions, visitor);
            }

        }

        void UserDataChangeByAdmin()
        {
            Console.WriteLine("Please type 'login' of user you wish to update");
            string userLogin = Console.ReadLine();
            bool ifExist = false;
            string newName;
            string newPassword;
            string newLogin;

            foreach (var user in userList)
            {
                if (user.userLogin == userLogin)
                {
                    Console.Write($"Please type new Name for '{userLogin}': ");
                    newName = Console.ReadLine();
                    Console.Write($"Please type new Login for '{userLogin}': ");
                    newLogin = Console.ReadLine();
                    Console.Write($"Please type new Password for '{userLogin}': ");
                    newPassword = Console.ReadLine();
                    Console.Write($"Administrator Y/N: ");
                    string ifAdmin = Console.ReadLine();


                    user.userName = newName;
                    user.userPassword = newPassword;
                    user.userLogin = newLogin;
                    user.ifAdmin = ifAdmin.ToLower() == "y";
                    ifExist = true;

                    break;
                }
            }

            if(!ifExist) Console.WriteLine($"User with login '{userLogin}' is not exist");
            
        }

    }
}
