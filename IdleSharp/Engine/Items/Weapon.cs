using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Weapon : Item
    {
        public Weapon(int iD, string name, string description, int minDamage = 0, int maxDamage = 0) : base(iD, name, description)
        {
            MinimumDamage = (minDamage < maxDamage) ? minDamage : maxDamage;
            MaximumDamage = (minDamage < maxDamage) ? maxDamage : minDamage;
        }

        public int MinimumDamage { get; set; }
        public int MaximumDamage { get; set; }

        public double AverageDamage()
        {
            return (MinimumDamage + MaximumDamage) / 2;
        }
    }
}
