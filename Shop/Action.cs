using System;
using System.Collections.Generic;
using System.Text;

namespace Shop
{
    public class Action
    {
        public string name;
        public Action<IConsoleProvider> action;
        public int button;
        public bool ifEnabled;
        public int visibility; //0 guest,  1 registered, 2 admin
        public string actionOwner1;
        public string actionOwner2;
        public string actionOwner3;

        public Action(string name, Action<IConsoleProvider> method, int button, bool ifEnabled, string actionOwner1)
        {
            this.name = name;
            this.action = method;
            this.button = button;
            this.ifEnabled = ifEnabled;
            this.actionOwner1 = actionOwner1;
            this.actionOwner2 = "n/a";
            this.actionOwner3 = "n/a";
        }

        public Action(string name, Action<IConsoleProvider> method, int button, bool ifEnabled, string actionOwner1, string actionOwner2)
        {
            this.name = name;
            this.action = method;
            this.button = button;
            this.ifEnabled = ifEnabled;
            this.actionOwner1 = actionOwner1;
            this.actionOwner2 = actionOwner2;
            this.actionOwner3 = "n/a";
        }

        public Action(string name, Action<IConsoleProvider> method, int button, bool ifEnabled, string actionOwner1, string actionOwner2, string actionOwner3)
        {
            this.name = name;
            this.action = method;
            this.button = button;
            this.ifEnabled = ifEnabled;
            this.actionOwner1 = actionOwner1;
            this.actionOwner2 = actionOwner2;
            this.actionOwner3 = actionOwner3;
        }

        public virtual void Do() { }
    }
}
