using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static class World
    {
        public static readonly List<Item> Items = new List<Item>();
        public static readonly List<Monster> Monsters = new List<Monster>();
        public static readonly List<Quest> Quests = new List<Quest>();
        public static readonly List<Location> Locations = new List<Location>();

        public const int ITEM_DAGGER = 1;
        public const int ITEM_SWORD = 2;
        public const int ITEM_GREAT_SWORD = 3;

        public const int ITEM_BREAD = 4;
        public const int ITEM_APPLE = 5;

        public const int ITEM_THIEF_BAG = 6;
        public const int ITEM_THIEF_KNIFE = 7;
        public const int ITEM_THIEF_COIN = 8;
        public const int ITEM_THIEF_SHOES = 9;
        public const int THIEF_CROWN = 10;

        public const int MONSTER_THIEF = 1;
        public const int MONSTER_MASTER_THIEF = 2;
        public const int MONSTER_THIEF_KING = 3;


        public const int QUEST_CATCH_THIEF = 1;
        public const int QUEST_DEFEAT_THE_MASTERS = 2;
        public const int QUEST_KILL_THIEF_KING = 3;

        public const int LOCATION_HOME = 1;
        public const int LOCATION_VILLAGE = 2;
        public const int LOCATION_FARM = 3;
        public const int LOCATION_RIVER = 4;
        public const int LOCATION_THIEF_DEN = 5;

        public const double MAX_EXP_MULTIPLIER = 0.2;
        public const double MAX_HP_MULTIPLIER = 0.2;
        public const string PLAYER_DATA_PATH = "player.xml";

        static World()
        {
            PopulateItems();
            PopulateMonsters();
            PopulateQuests();
            PopulateLocations();
        }

        private static void PopulateItems()
        {
            Weapon dagger = new Weapon(ITEM_DAGGER, "Dagger", "Short sharp blade. Damage: 1 - 3", 1, 3);
            Weapon sword = new Weapon(ITEM_SWORD, "Sword", "Ordinary sword. Damage: 2 - 5", 2, 5);
            Weapon greatSword = new Weapon(ITEM_GREAT_SWORD, "Great Sword", "Great for boss fight. Can miss. Damage: 0 - 10", 10);

            Food bread = new Food(ITEM_BREAD, "Bread", "Baked Bread", 2);
            Food apple = new Food(ITEM_APPLE, "Apple", "An Apple", 3);

            Item thiefBag = new Item(ITEM_THIEF_BAG, "Thief's bag", "A bag dropped by thief");
            Item thiefKnife = new Item(ITEM_THIEF_KNIFE, "Thief's broken knife", "Can be used to stab people.");
            Item thiefCoin = new Item(ITEM_THIEF_COIN, "Thief's coin", "Gold coin populated by the thieves's king.");
            Item thiefShoes = new Item(ITEM_THIEF_SHOES, "Thief's shoes", "Thieves use these shoes to move quietly.");
            Item thiefCrown = new Item(THIEF_CROWN, "Crown of the thief's king", "This crown was once belonged to the king.");

            Items.Add(dagger);
            Items.Add(sword);
            Items.Add(greatSword);

            Items.Add(bread);
            Items.Add(apple);

            Items.Add(thiefBag);
            Items.Add(thiefKnife);
            Items.Add(thiefCoin);
            Items.Add(thiefShoes);
            Items.Add(thiefCrown);
        }

        private static void PopulateMonsters ()
        {
            Monster thief = new Monster("Low key Thief", 3, 3, MONSTER_THIEF, 0, 2, 3, 3);
            LootItem thiefLoot_1 = new LootItem(ItemById(ITEM_THIEF_BAG), 1, 10);
            LootItem thiefLoot_2 = new LootItem(ItemById(ITEM_THIEF_COIN), 1, 10);
            LootItem thiefLoot_3 = new LootItem(ItemById(ITEM_BREAD), 2, 10);
            thief.Loots.Add(thiefLoot_1);
            thief.Loots.Add(thiefLoot_2);
            thief.Loots.Add(thiefLoot_3);

            Monster masterThief = new Monster("Master thief", 7, 7, MONSTER_MASTER_THIEF, 3, 4, 7, 7);
            LootItem masterThiefLoot_1 = new LootItem(ItemById(ITEM_THIEF_BAG), 1, 10);
            LootItem masterThiefLoot_2 = new LootItem(ItemById(ITEM_THIEF_COIN), 1, 10);
            LootItem masterThiefLoot_3 = new LootItem(ItemById(ITEM_THIEF_KNIFE), 1, 100);
            LootItem masterThiefLoot_4 = new LootItem(ItemById(ITEM_THIEF_SHOES), 1, 10);
            LootItem masterThiefLoot_5 = new LootItem(ItemById(ITEM_BREAD), 1, 10);
            LootItem masterThiefLoot_6 = new LootItem(ItemById(ITEM_APPLE), 1, 10);
            masterThief.Loots.Add(masterThiefLoot_1);
            masterThief.Loots.Add(masterThiefLoot_2);
            masterThief.Loots.Add(masterThiefLoot_3);
            masterThief.Loots.Add(masterThiefLoot_4);
            masterThief.Loots.Add(masterThiefLoot_5);
            masterThief.Loots.Add(masterThiefLoot_6);

            Monster thiefKing = new Monster("King of thieves", 15, 15, MONSTER_THIEF_KING, 4, 10, 15, 15);
            LootItem thiefKingLoot_1 = new LootItem(ItemById(THIEF_CROWN), 1, 100);
            thiefKing.Loots.Add(thiefKingLoot_1);

            Monsters.Add(thief);
            Monsters.Add(masterThief);
            Monsters.Add(thiefKing);

        }

        private static void PopulateQuests()
        {
            Quest catchTheThief = new Quest(QUEST_CATCH_THIEF, "Catch the thief", "Catch thiefs around town and brings back 3 coins and 1 bag", 10, 10);
            QuestItem catchTheThiefItems_1 = new QuestItem(ItemById(ITEM_THIEF_COIN), 3, catchTheThief);
            QuestItem catchTheThiefItems_2 = new QuestItem(ItemById(ITEM_THIEF_BAG), 1, catchTheThief);
            catchTheThief.RequiredItems.Add(catchTheThiefItems_1);
            catchTheThief.RequiredItems.Add(catchTheThiefItems_2);
            catchTheThief.RewardItem = ItemById(ITEM_SWORD);

            Quest defeatMasters = new Quest(QUEST_DEFEAT_THE_MASTERS, "Defeat the masters", "Take down 3 different master thieves and brings back 5 knives", 20, 20);
            QuestItem defeatMastersItems_1 = new QuestItem(ItemById(ITEM_THIEF_KNIFE), 3, defeatMasters);
            defeatMasters.RequiredItems.Add(defeatMastersItems_1);
            defeatMasters.RewardItem = ItemById(ITEM_GREAT_SWORD);

            Quest killTheKing = new Quest(QUEST_KILL_THIEF_KING, "King's Crown", "Assassinate the thieves's king and retrieves the crown", 100, 100);
            QuestItem killTheKingItems = new QuestItem(ItemById(THIEF_CROWN), 1, killTheKing);
            killTheKing.RequiredItems.Add(killTheKingItems);

            Quests.Add(catchTheThief);
            Quests.Add(defeatMasters);
            Quests.Add(killTheKing);
        }

        private static void PopulateLocations()
        {
            // creates locations
            Location home = new Location(LOCATION_HOME, "Home", "Home sweet home. All HP are restored on arrival.");
            Location village = new Location(LOCATION_VILLAGE, "Village", "Inside the village. People live here.");
            Location farm = new Location(LOCATION_FARM, "Farm house", "The farm house. A lot of thieves are lurking around here.");
            Location river = new Location(LOCATION_RIVER, "River", "Accross the river, dangerous thieves are waiting for merchants crossing the river.");
            Location den = new Location(LOCATION_THIEF_DEN, "Thieves's den", "In the thieves's den, the thief's king is sleeping on his treasures");

            river.ItemRequiredToEnter = ItemById(ITEM_SWORD);
            den.ItemRequiredToEnter = ItemById(ITEM_GREAT_SWORD);

            village.QuestAvailable = QuestById(QUEST_CATCH_THIEF);
            farm.QuestAvailable = QuestById(QUEST_DEFEAT_THE_MASTERS);
            river.QuestAvailable = QuestById(QUEST_KILL_THIEF_KING);

            farm.MonsterLiving = MonsterById(MONSTER_THIEF);
            river.MonsterLiving = MonsterById(MONSTER_MASTER_THIEF);
            den.MonsterLiving = MonsterById(MONSTER_THIEF_KING);

            // links them together
            home.NordLocation = village;

            village.NordLocation = farm;
            village.SouthLocation = home;

            farm.NordLocation = river;
            farm.SouthLocation = village;

            river.NordLocation = den;
            river.SouthLocation = farm;

            den.SouthLocation = river;

            // populates
            Locations.Add(home);
            Locations.Add(village);
            Locations.Add(farm);
            Locations.Add(river);
            Locations.Add(den);
        }

        public static Item ItemById(int id)
        {
            foreach (Item item in Items)
            {
                if (item.ID == id)
                {
                    return item;
                }
            }
            return null;
        }

        public static Monster MonsterById(int id)
        {
            foreach (Monster monster in Monsters)
            {
                if (monster.ID == id)
                {
                    return monster;
                }
            }
            return null;
        }

        public static Quest QuestById(int id)
        {
            foreach (Quest quest in Quests)
            {
                if (quest.ID == id)
                {
                    return quest;
                }
            }
            return null;
        }

        public static Location LocationById(int id)
        {
            foreach (Location location in Locations)
            {
                if (location.ID == id)
                {
                    return location;
                }
            }
            return null;
        }
    }
}
