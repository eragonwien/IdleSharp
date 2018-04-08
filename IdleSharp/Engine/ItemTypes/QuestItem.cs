using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class QuestItem : InventoryItem
    {
        public QuestItem(Item details, int quantity, Quest quest = null) : base(details, quantity)
        {
            RelatedQuest = quest;
        }

        public Quest RelatedQuest { get; set; }
    }
}
