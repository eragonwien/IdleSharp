using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Location
    {
        public Location(int iD, string name, string description, Item requiredItem = null, Quest questAvailable = null, Monster monsterLiving = null)
        {
            ID = iD;
            Name = name;
            Description = description;
            ItemRequiredToEnter = requiredItem;
            QuestAvailable = questAvailable;
            MonsterLiving = monsterLiving;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Item ItemRequiredToEnter { get; set; }
        public Quest QuestAvailable { get; set; }
        public Monster MonsterLiving { get; set; }
        public Location NordLocation { get; set; }
        public Location WestLocation { get; set; }
        public Location SouthLocation { get; set; }
        public Location EastLocation { get; set; }

    }
}
