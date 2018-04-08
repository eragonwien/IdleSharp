using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Monster : Creatures
    {
        public Monster(string name, int maximumHitPoint, int currentHitPoint, int iD, int minimumDamage, int maximumDamage, int rewardExp, int rewardGold) : base(name, maximumHitPoint, currentHitPoint)
        {
            ID = iD;
            MinimumDamage = minimumDamage;
            MaximumDamage = maximumDamage;
            RewardExp = rewardExp;
            RewardGold = rewardGold;
            Loots = new List<LootItem>();
        }

        public int ID { get; set; }
        public int MinimumDamage { get; set; }
        public int MaximumDamage { get; set; }
        public int RewardExp { get; set; }
        public int RewardGold { get; set; }
        public List<LootItem> Loots { get; set; }
    }
}
