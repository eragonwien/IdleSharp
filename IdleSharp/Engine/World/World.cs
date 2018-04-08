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
        public const int QUEST_KILL_THIEF_KING = 2;

        public const int LOCATION_HOME = 1;
        public const int LOCATION_VILLAGE = 2;
        public const int LOCATION_FARM = 3;
        public const int LOCATION_RIVER = 4;
        public const int LOCATION_THIEF_DEN = 5;

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
            Weapon sword = new Weapon(ITEM_DAGGER, "Sword", "Ordinary sword. Damage: 2 - 5", 2, 5);
            Weapon greatSword = new Weapon(ITEM_DAGGER, "Great Sword", "Great for boss fight. Can miss. Damage: 0 - 10", 10);

            Food bread = new Food(ITEM_BREAD, "Bread", 2);
            Food apple = new Food(ITEM_APPLE, "Apple", 3);

            Item thiefBag = new Item(ITEM_THIEF_BAG, "Thief's bag");
            Item thiefKnife = new Item(ITEM_THIEF_KNIFE, "Thief's broken knife");
            Item thiefCoin = new Item(ITEM_THIEF_COIN, "Thief's coin");
            Item thiefShoes = new Item(ITEM_THIEF_SHOES, "Thief's shoes");
            Item thiefCrown = new Item(THIEF_CROWN, "Crown of the thief's king");

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
            LootItem thiefLoot_1 = new LootItem(ItemById(ITEM_THIEF_BAG), 20);
            LootItem thiefLoot_2 = new LootItem(ItemById(ITEM_THIEF_COIN), 20);
            thief.Loots.Add(thiefLoot_1);
            thief.Loots.Add(thiefLoot_2); // CONTINE

            Monster masterThief = new Monster("Master thief", 7, 7, MONSTER_THIEF, 3, 4, 7, 7);
            Monster thiefKing = new Monster("King of thieves", 15, 15, MONSTER_THIEF, 4, 10, 15, 15);

            Monsters.Add(thief);
            Monsters.Add(masterThief);
            Monsters.Add(thiefKing);

        }

        private static void PopulateQuests()
        {

        }

        private static void PopulateLocations()
        {

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
