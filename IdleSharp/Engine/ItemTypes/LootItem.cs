using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class LootItem : InventoryItem
    {
        public LootItem(Item details, int quantity, int dropchance = 0) : base(details, quantity)
        {
            DropChance = dropchance;
        }

        public int DropChance { get; set; }
    }
}
