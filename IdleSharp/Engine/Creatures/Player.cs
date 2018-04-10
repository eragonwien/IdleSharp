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
        public Location CurrentLocation { get; set; }

        public bool HasItem(Item itemRequiredToEnter)
        {
            if (itemRequiredToEnter == null)
            {
                return true;
            }
            foreach (InventoryItem item in Inventory)
            {
                if (item.Details.ID == itemRequiredToEnter.ID)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsQuestAccepted(Quest quest)
        {
            foreach (PlayerQuest playerQuest in Quests)
            {
                if (quest.ID == playerQuest.Details.ID)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsQuestCompleted(Quest quest)
        {
            foreach (PlayerQuest playerQuest in Quests)
            {
                if (quest.ID == playerQuest.Details.ID && playerQuest.IsCompleted)
                {
                    return true;
                }
            }
            return false;
        }

        public void AddQuest(Quest quest)
        {
            bool hasQuest = false;
            foreach (PlayerQuest playerQuest in Quests)
            {
                if (playerQuest.Details.ID == quest.ID)
                {
                    hasQuest = true;
                }
            }
            if (!hasQuest)
            {
                PlayerQuest newQuest = new PlayerQuest(quest);
                Quests.Add(newQuest);
            }
        }

        public bool IsQuestFulfilled(Quest quest)
        {
            List<QuestItem> requiredItems = quest.RequiredItems;
            foreach (QuestItem requiredItem in requiredItems)
            {
                bool hasRequiredItem = false;
                foreach (InventoryItem inventoryItem in Inventory)
                {
                    if (inventoryItem.Details.ID == requiredItem.Details.ID && inventoryItem.Quantity >= requiredItem.Quantity)
                    {
                        hasRequiredItem = true;
                    }
                }
                if (!hasRequiredItem)
                {
                    return false;
                }
            }
            return true;
        }

        public void Reward(Quest quest)
        {
            AddGold(quest.RewardGold);
            AddExp(quest.RewardExp);
            AddItem(quest.RewardItem);
        }

        private void AddItem(Item item)
        {
            foreach (InventoryItem inventoryItem in Inventory)
            {
                if (item.ID == inventoryItem.Details.ID)
                {
                    inventoryItem.Quantity++;
                    return;
                }
            }
            InventoryItem newItem = new InventoryItem(item, 1);
            Inventory.Add(newItem);
        }

        private void AddExp(int exp)
        {
            CurrentEXP += exp;
            if (CurrentEXP > MaximumEXP) // EXP overflow causes level up
            {
                int different = CurrentEXP - MaximumEXP;
                CurrentLevel++; // level up
                CurrentEXP = 0; // reset exp to zero
                CurrentEXP += different; // pass the EXP different to the new level
                MaximumEXP += (int)(MaximumEXP * World.MAX_EXP_MULTIPLIER); // raises the level up requirement
            }
        }

        private void AddGold(int gold)
        {
            Gold += gold;
        }

        public void CompleteQuest(Quest quest)
        {
            RemoveQuestItems(quest.RequiredItems);
            Reward(quest);

            // marks quest as completed
            foreach (PlayerQuest playerQuest in Quests)
            {
                if (quest.ID == playerQuest.Details.ID)
                {
                    playerQuest.IsCompleted = true;
                }
            }
        }

        public void RemoveQuestItems(List<QuestItem> questItems)
        {
            foreach (QuestItem questItem in questItems)
            {
                foreach (InventoryItem inventoryItem in Inventory)
                {
                    if (inventoryItem.Details.ID == questItem.Details.ID)
                    {
                        inventoryItem.Quantity = questItem.Quantity - inventoryItem.Quantity;
                        if (inventoryItem.Quantity <= 0)
                        {
                            Inventory.Remove(inventoryItem);
                        }
                    }
                }
            }
        }

        public void EnterLocation(Location location)
        {
            CurrentLocation = location;
        }

        public bool IsAtHome()
        {
            return (CurrentLocation.ID == World.LOCATION_HOME);
        }

        public void Heal(int hitPoint)
        {
            CurrentHitPoint += Math.Abs(hitPoint);
            CurrentHitPoint = (CurrentHitPoint < MaximumHitPoint) ? CurrentHitPoint : MaximumHitPoint;
        }
    }
}
