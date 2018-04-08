using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Weapon : Item
    {
        public Weapon(int iD, string name, string description, int minDamage = 0, int maxDamage = 0) : base(iD, name)
        {
            Description = description;
            MinimumDamage = (minDamage < maxDamage) ? minDamage : maxDamage;
            MaximumDamage = (minDamage < maxDamage) ? maxDamage : minDamage;
        }

        public string Description { get; set; }
        public int MinimumDamage { get; set; }
        public int MaximumDamage { get; set; }
    }
}
