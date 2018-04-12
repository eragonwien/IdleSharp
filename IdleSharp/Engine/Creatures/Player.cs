using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Player : Creatures
    {
        public Player(string name, int maximumHitPoint, int currentHitPoint, int maxExp, int gold = 0, int exp = 0, int level = 0, bool isFighting = false) : base(name, maximumHitPoint, currentHitPoint)
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
        public bool IsFighting { get; set; }
        public List<InventoryItem> Inventory { get; set; }
        public List<PlayerQuest> Quests { get; set; }
        public Location CurrentLocation { get; set; }
        public Monster CurrentMonster { get; set; }

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
            AddItem(quest.RewardItem, 1);
        }

        public void AddItem(Item item, int quantity)
        {
            foreach (InventoryItem inventoryItem in Inventory)
            {
                if (item.ID == inventoryItem.Details.ID)
                {
                    inventoryItem.Quantity += quantity;
                    return;
                }
            }
            InventoryItem newItem = new InventoryItem(item, 1);
            Inventory.Add(newItem);
        }

        public int QuantityOfItem(Item item)
        {
            int result = 0;

            foreach (InventoryItem inventoryItem in Inventory)
            {
                if (item.ID == inventoryItem.Details.ID)
                {
                    return inventoryItem.Quantity;
                }
            }

            return result;
        }

        public bool AddExp(int exp) // return true if the exp causes leveling up
        {
            CurrentEXP += exp;
            if (CurrentEXP >= MaximumEXP) // EXP overflow causes level up
            {
                LevelUp();
                return true;
            }
            return false;
        }

        private void LevelUp()
        {

            // EXP
            int different = CurrentEXP - MaximumEXP;
            CurrentLevel++; // level up
            CurrentEXP = 0; // reset exp to zero
            CurrentEXP += different; // pass the EXP different to the new level
            MaximumEXP += (int)(MaximumEXP * World.MAX_EXP_MULTIPLIER); // raises the level up requirement

            // Hit Point
            MaximumHitPoint += (int)(MaximumHitPoint * World.MAX_HP_MULTIPLIER); // raise max hp
            CurrentHitPoint = MaximumHitPoint; // restores HP on level up
        }

        public void AddGold(int gold)
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
                RemoveItemFromInventory(questItem.Details, questItem.Quantity);
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

        public void ReduceHitPoint(int value)
        {
            CurrentHitPoint = (value < CurrentHitPoint) ? (CurrentHitPoint - value) : 0;
        }

        public Food Eat()
        {
            Food consumedFood = ConsumFood();
            if (consumedFood != null)
            {
                Heal(consumedFood.HealAmount);
            }

            return consumedFood;
        }

        private Food ConsumFood()
        {
            foreach (InventoryItem inventoryItem in Inventory)
            {
                Item details = inventoryItem.Details;
                if (details is Food food)
                {
                    InventoryItem removedItems = RemoveItemFromInventory(details, 1);
                    if (removedItems == null)
                    {
                        return null;
                    }
                    Food consumedFood = new Food(food.ID, food.Name, food.Description, food.HealAmount);
                    return consumedFood;
                }
            }
            return null;
        }

        private InventoryItem RemoveItemFromInventory(Item details, int quantity)
        {
            foreach (InventoryItem inventoryItem in Inventory)
            {
                if (details.ID == inventoryItem.Details.ID)
                {
                    int removeQuantity = (quantity < inventoryItem.Quantity) ? quantity : inventoryItem.Quantity;
                    InventoryItem removeItems = new InventoryItem(details, removeQuantity);
                    inventoryItem.Quantity -= removeQuantity;
                    if (inventoryItem.Quantity <= 0)
                    {
                        Inventory.Remove(inventoryItem);
                    }
                    return removeItems;
                }
            }
            return null;
        }

        public int Attack(Monster monster)
        {
            // gets the best weapon is stash
            int playerDamage = 0;
            Weapon weapon = BestWeapon();
            if (weapon != null)
            {
                playerDamage += Randomer.RandomInt(weapon.MinimumDamage, weapon.MaximumDamage);
            }
            
            // deals damage to monster
            monster.ReduceHitPoint(playerDamage);
            return playerDamage;
        }

        private Weapon BestWeapon()
        {
            Weapon bestWeapon = null;
            foreach (InventoryItem inventoryItem in Inventory)
            {
                if (inventoryItem.Details is Weapon weapon)
                {
                    if (bestWeapon == null)
                    {
                        bestWeapon = weapon;
                    }
                    else
                    {
                        bestWeapon = (weapon.AverageDamage() > bestWeapon.AverageDamage()) ? weapon : bestWeapon;
                    }
                }
            }
            return bestWeapon;
        }

        public bool IsAlive()
        {
            return (CurrentHitPoint > 0);
        }

        public List<InventoryItem> Loots(List<LootItem> loots)
        {
            List<InventoryItem> result = new List<InventoryItem>();

            foreach (LootItem lootItem in loots)
            {
                if (lootItem.IsDropped())
                {
                    AddItem(lootItem.Details, lootItem.Quantity);
                    result.Add(new InventoryItem(lootItem.Details, lootItem.Quantity));
                }
            }
            return result;
        }

        public void RemoveMonster()
        {
            CurrentMonster = null;
        }
    }
}
