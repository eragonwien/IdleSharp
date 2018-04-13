using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Engine.Factory
{
    public class PlayerFactory
    {
        public Player SpawnPlayer(bool isNewGame)
        {
            Player player = null;

            if (File.Exists(World.PLAYER_DATA_PATH) && !isNewGame)
            {
                player = LoadSavedPlayer(File.ReadAllText(World.PLAYER_DATA_PATH));
            }
            else
            {
                player = new Player("Player 1", 10, 10, 10);
                player.SuitUp();
            }
            return player;
        }

        private Player LoadSavedPlayer(string xmlData)
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
            catch (Exception e)
            {
                Console.WriteLine(e.GetType());
                Console.WriteLine(e.GetBaseException());

                return SpawnPlayer(true);
            }
        }
    }
}
