using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Player : Creatures
    {
        public Player(string name, int maximumHitPoint, int currentHitPoint, int maxExp, int gold = 0, int exp = 0, int level = 0) : base(name, maximumHitPoint, currentHitPoint)
        {
            Gold = gold;
            CurrentEXP = exp;
            MaximumEXP = maxExp;
            CurrentLevel = level;
            Inventory = new List<InventoryItem>();
            Quests = new List<PlayerQuest>();
        }

        public int Gold { get; set; }
        public int CurrentEXP { get; set; }
        public int MaximumEXP { get; set; }
        public int CurrentLevel { get; set; }
        public List<InventoryItem> Inventory { get; set; }
        public List<PlayerQuest> Quests { get; set; }
    }
}
