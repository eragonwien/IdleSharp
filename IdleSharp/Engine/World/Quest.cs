using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Quest
    {
        public Quest(int iD, string name, string description, int rewardExp, int rewardGold, Item rewardItem = null)
        {
            ID = iD;
            Name = name;
            Description = description;
            RewardExp = rewardExp;
            RewardGold = rewardGold;
            RewardItem = rewardItem;
            RequiredItems = new List<QuestItem>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int RewardExp { get; set; }
        public int RewardGold { get; set; }
        public Item RewardItem { get; set; }
        public List<QuestItem> RequiredItems { get; set; }
    }
}
