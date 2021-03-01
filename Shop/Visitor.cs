using System;
using System.Collections.Generic;

namespace Shop
{
    public class Visitor
    {
        public VisitorType _visitorType;
        public List<Product> ShoppingList;
        public string login;

        public enum VisitorType
        {
            guest,
            registeredUser,
            administrator
        }

        public Visitor()
        {
            _visitorType = VisitorType.guest;
        }


        //--------------------------------------------------------------------
        public void UpdateActionList(List<Action> actions)
        {
            switch (_visitorType)
            {

            }
            foreach (var item in actions)
            {

            }
        }


        public void LoginAsUser()
        {
            Console.Write("Please enter login:");
            Console.Write("Please enter password:");

            if (true)
            {
                //    
                this._visitorType = VisitorType.registeredUser;
            }
            else
            {
                //dispay
            }
        }

        public void LoginAsAdmin()
        {
            Console.Write("Please enter login:");
            Console.Write("Please enter password:");

            if (true)
            {
                // 
                this._visitorType = VisitorType.administrator;
            }
            else
            {
                //dispay
            }
        }

        public void Logout()
        {
            this._visitorType = VisitorType.guest;
            //display
        }

        public void MakeYourChoice(int num)
        {
            int n = 1;
            this.MakeYourChoice(n);
            Console.WriteLine("What are you going to do?");
            //for guest
            Console.WriteLine("0 - Login as admin");
            Console.WriteLine("1 - Login as user");
            Console.WriteLine("2 - See Product List");
            Console.WriteLine("3 - Search by product name");
            Console.WriteLine("4 - Registration");


            //for registered user
            Console.WriteLine("5 - Logout");
            Console.WriteLine("6 - Update personal info");
            Console.WriteLine("2 - See Product List"); //
            Console.WriteLine("3 - Search by product name"); //
            Console.WriteLine("7 - My orders");

            //for admin
            Console.WriteLine("5 - Logout");
            Console.WriteLine("6 - Update users personal info");
            Console.WriteLine("2 - See Product List"); //
            Console.WriteLine("3 - Search by product name"); //
            Console.WriteLine("8 - See all orders");
        }
    }
}