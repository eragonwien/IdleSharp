using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Engine
{
    public class Player : Creatures
    {
        public Player(string name, int maximumHitPoint, int currentHitPoint, int maxExp, int gold = 0, int exp = 0, int level = 0, bool inCombat = false) : base(name, maximumHitPoint, currentHitPoint)
        {
            Gold = gold;
            CurrentEXP = exp;
            MaximumEXP = maxExp;
            CurrentLevel = level;
            Inventory = new List<InventoryItem>();
            Quests = new List<PlayerQuest>();
            CurrentLocation = World.LocationById(World.LOCATION_HOME);
            InCombat = inCombat;
        }

        public int Gold { get; set; }
        public int CurrentEXP { get; set; }
        public int MaximumEXP { get; set; }
        public int CurrentLevel { get; set; }
        public bool InCombat { get; set; }
        public List<InventoryItem> Inventory { get; set; }
        public List<PlayerQuest> Quests { get; set; }
        public Location CurrentLocation { get; set; }
        public Monster CurrentMonster { get; set; }


        public void SuitUp()
        {
            AddItem(World.ItemById(World.ITEM_BREAD), 5);
            AddItem(World.ItemById(World.ITEM_DAGGER), 1);
        }

        public bool HasItem(Item item)
        {
            if (item == null)
            {
                return true;
            }
            return Inventory.Exists(inventoryItem => inventoryItem.Details.ID == item.ID);
        }

        public bool IsQuestAccepted(Quest quest)
        {
            return Quests.Exists(playerQuest => playerQuest.Details.ID == quest.ID);
        }

        public bool IsQuestCompleted(Quest quest)
        {
            return Quests.Exists(playerQuest => playerQuest.Details.ID == quest.ID && playerQuest.IsCompleted);
        }

        public void AddQuest(Quest quest)
        {
            bool hasQuest = Quests.Exists(playerQuest => playerQuest.Details.ID == quest.ID);
            if (!hasQuest)
            {
                PlayerQuest newQuest = new PlayerQuest(quest);
                Quests.Add(newQuest);
            }
        }

        public bool IsWinner()
        {
            return (IsQuestCompleted(World.QuestById(World.QUEST_KILL_THIEF_KING)));
        }

        public bool IsQuestFulfilled(Quest quest)
        {
            List<QuestItem> requiredItems = quest.RequiredItems;
            foreach (QuestItem requiredItem in requiredItems)
            {
                bool hasRequiredItem = Inventory.Exists(inventoryItem => inventoryItem.Details.ID == requiredItem.Details.ID && inventoryItem.Quantity >= requiredItem.Quantity);
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
            if (item == null)
            {
                return;
            }
            foreach (InventoryItem inventoryItem in Inventory)
            {
                if (item.ID == inventoryItem.Details.ID)
                {
                    inventoryItem.Quantity += quantity;
                    return;
                }
            }
            InventoryItem newItem = new InventoryItem(item, quantity);
            Inventory.Add(newItem);
        }

        public int QuantityOfItem(Item item)
        {
            int result = 0;
            if (item == null)
            {
                return result;
            }
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
            if (questItems == null)
            {
                return;
            }
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
            if (details == null)
            {
                return null;
            }
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
            if (loots == null)
            {
                return null;
            }
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

        public string SaveXml()
        {
            XmlDocument data = new XmlDocument();

            XmlNode playerData = data.CreateElement("Player");
            data.AppendChild(playerData);

            XmlNode stats = data.CreateElement("Stats");
            playerData.AppendChild(stats);

            XmlNode name = data.CreateElement("Name");
            name.AppendChild(data.CreateTextNode(Name));

            XmlNode currentHp = data.CreateElement("CurrentHitPoint");
            currentHp.AppendChild(data.CreateTextNode(CurrentHitPoint.ToString()));

            XmlNode gold = data.CreateElement("Gold");
            gold.AppendChild(data.CreateTextNode(Gold.ToString()));

            XmlNode currentExp = data.CreateElement("CurrentEXP");
            currentExp.AppendChild(data.CreateTextNode(CurrentEXP.ToString()));

            XmlNode currentLevel = data.CreateElement("CurrentLevel");
            currentLevel.AppendChild(data.CreateTextNode(CurrentLevel.ToString()));

            XmlNode maxHp = data.CreateElement("MaxHitPoint");
            maxHp.AppendChild(data.CreateTextNode(MaximumHitPoint.ToString()));

            XmlNode maxExp = data.CreateElement("MaxExp");
            maxExp.AppendChild(data.CreateTextNode(MaximumEXP.ToString()));

            XmlNode currentLocation = data.CreateElement("CurrentLocationId");
            currentLocation.AppendChild(data.CreateTextNode(CurrentLocation.ID.ToString()));

            XmlNode inventory = data.CreateElement("Inventory");
            playerData.AppendChild(inventory);

            foreach (InventoryItem inventoryItem in Inventory)
            {
                XmlNode xmlItem = inventoryItem.XmlNode(data);
                inventory.AppendChild(xmlItem);
            }


            XmlNode quests = data.CreateElement("Quests");
            playerData.AppendChild(quests);

            foreach (PlayerQuest playerQuest in Quests)
            {
                XmlNode xmlQuest = playerQuest.XmlNode(data);
                quests.AppendChild(xmlQuest);
            }

            stats.AppendChild(name);
            stats.AppendChild(currentHp);
            stats.AppendChild(gold);
            stats.AppendChild(currentExp);
            stats.AppendChild(currentLevel);
            stats.AppendChild(maxHp);
            stats.AppendChild(maxExp);
            stats.AppendChild(currentLocation);

            return data.InnerXml;
        }

        public Player LoadSaved(string xmlData)
        {
            try
            {
                XmlDocument playerData = new XmlDocument();
                playerData.LoadXml(xmlData);

                string name = playerData.SelectSingleNode("/Player/Stats/Name").InnerText;
                int currentHp = Convert.ToInt32(playerData.SelectSingleNode("/Player/Stats/CurrentHitPoint").InnerText);
                int currentExp = Convert.ToInt32(playerData.SelectSingleNode("/Player/Stats/CurrentEXP").InnerText);
                int gold = Convert.ToInt32(playerData.SelectSingleNode("/Player/Stats/Gold").InnerText);
                int currentLevel = Convert.ToInt32(playerData.SelectSingleNode("/Player/Stats/CurrentLevel").InnerText);
                int maxHp = Convert.ToInt32(playerData.SelectSingleNode("/Player/Stats/MaxHitPoint").InnerText);
                int maxExp = Convert.ToInt32(playerData.SelectSingleNode("/Player/Stats/MaxExp").InnerText);
                int currentLocationId = Convert.ToInt32(playerData.SelectSingleNode("/Player/Stats/CurrentLocationId").InnerText);

                Player player = new Player(name, maxHp, currentHp, maxExp, gold, currentExp, currentLevel);
                player.CurrentLocation = World.LocationById(currentLocationId);

                foreach (XmlNode node in playerData.SelectNodes("/Player/Inventory/Item"))
                {
                    int id = Convert.ToInt32(node.Attributes["ID"].Value);
                    int quantity = Convert.ToInt32(node.Attributes["Quantity"].Value);
                    Item itemDetails = World.ItemById(id);
                    player.AddItem(itemDetails, quantity);
                }

                foreach (XmlNode node in playerData.SelectNodes("/Player/Quests/Quest"))
                {
                    int id = Convert.ToInt32(node.Attributes["ID"].Value);
                    bool isCompleted = Convert.ToBoolean(node.Attributes["IsCompleted"].Value);

                    Quest questDetails = World.QuestById(id);
                    PlayerQuest quest = new PlayerQuest(questDetails, isCompleted);
                    player.Quests.Add(quest);
                }
                return player;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.GetType());
                Console.WriteLine(e.GetBaseException());

                return this;
            }
        }
    }
}
