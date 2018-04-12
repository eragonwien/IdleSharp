using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Food : Item
    {
        public Food(int iD, string name, string description, int healAmount) : base(iD, name, description)
        {
            HealAmount = healAmount;
        }

        public int HealAmount { get; set; }
    }

}
