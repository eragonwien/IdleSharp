using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Food : Item
    {
        public Food(int iD, string name, int healAmount) : base(iD, name)
        {
            HealAmount = healAmount;
        }

        public int HealAmount { get; set; }
    }

}
