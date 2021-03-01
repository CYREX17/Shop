using System.Collections.Generic;
using Shop.Enums;

namespace Shop
{
  public  class User
    {
        public string userName;
        public string userLogin;
        public string userPassword;
        public bool ifAdmin;
        public List<List<Product>> OrderList;
        //public List<OrderStatus> OrderStatusList;
        public Dictionary<int, OrderStatus> OrderStatusList;

       
        
        public User(string name, string login, string password, bool ifAdmin = false)
        {
            userName = name;
            userLogin = login;
            userPassword = password;
            this.ifAdmin = ifAdmin;
            OrderList = new List<List<Product>>();
            OrderStatusList = new Dictionary<int, OrderStatus>();
        }

       
    }
}