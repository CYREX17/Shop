using System;
using System.Collections.Generic;
using System.Text;

namespace Shop
{
    static class ActionVisibilityChanger
    {
        public static List<Action> ActionChanger(List<Action> list, Visitor visitor)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].actionOwner1 == visitor._visitorType.ToString() ||
                    list[i].actionOwner2 == visitor._visitorType.ToString() ||
                    list[i].actionOwner3 == visitor._visitorType.ToString())
                {
                    list[i].ifEnabled = true;
                }
                else
                {
                    list[i].ifEnabled = false;
                }
            }

            return list;
        }
    }
}
