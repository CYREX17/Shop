﻿using System;
using System.Collections.Generic;

namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Session s = new Session();
            Visitor visitor = new Visitor();

            while (s.SessionStatus == SessionStatus.active)
            {
                
                s.DisplayMenuBar();

                Console.WriteLine("Please make your choice");
                int button = int.Parse(Console.ReadLine());

                s.Display(button);
            }

            Console.WriteLine("Thank you for visiting our Store");

            Console.ReadLine();
            
        }
    }
}
