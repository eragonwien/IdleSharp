﻿using Engine;
using Engine.Factory;
using IdleSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpAdventure
{
    public partial class Main : Form
    {
        private Player player;
        public Main()
        {
            InitializeComponent();
            SpawnPlayer(false);
        }

        public void SpawnPlayer(bool isNewGame)
        {
            PlayerFactory factory = new PlayerFactory();
            player = factory.SpawnPlayer(false);
            MovePlayerTo(player.CurrentLocation);
            UpdateUI();
        }

        private void UpdatePlayer()
        {
            UpdatePlayerHitPoint();
            UpdatePlayerGold();
            UpdatePlayerExp();
            UpdatePlayerLevel();
        }

        private void MovePlayerTo(Location destination)
        {
            
            if (!player.HasItem(destination.ItemRequiredToEnter))
            {
                AppendLog("You cannot enter this place.");
                AppendLog("Reason: " + destination.ItemRequiredToEnter.Name + " is required to enter this location.");
                return;
            }
            player.EnterLocation(destination);
            AppendLog("Player moves to " + destination.Name);
            
            CheckQuestIn(destination);
            DisableCombat();
            if (player.IsAtHome()) // ID of home
            {
                DisableHomeButton();
                player.Heal(player.MaximumHitPoint);
                AppendLog("Player's HP is restored to " + player.CurrentHitPoint + " at Home.");
            }

            if (!destination.HasAnyMonster())
            {
                DisableCombatButton();
            }
            UpdateUI();
            if (player.IsWinner())
            {
                //DisableAllControls();
                OpenEndGameDialog("Congrats. You win the game at level " + player.CurrentLevel);
            }
        }

        private void CheckQuestIn(Location location)
        {
            if (location.HasAnyQuest())
            {
                Quest locationQuest = location.QuestAvailable;

                if (player.IsQuestAccepted(locationQuest))
                {
                    if (!player.IsQuestCompleted(locationQuest) && player.IsQuestFulfilled(locationQuest))
                    {
                        player.CompleteQuest(locationQuest);
                        AppendLog("Quest " + locationQuest.Name + " completed.");
                    }
                }
                else
                {
                    AppendLog("New quest available.");
                    player.AddQuest(locationQuest);
                }
            }
        }

        private void EnableCombat()
        {
            player.InCombat = true;
            UpdateMovementControls(player.CurrentLocation);
            EnableCombatControls();
        }

        private void DisableCombat()
        {
            player.InCombat = false;
            UpdateMovementControls(player.CurrentLocation);
            DisableCombatControls();
        }

        /* UI update */
        private void OpenEndGameDialog(string message = "")
        {
            Form endGameDialog = new EndGameDialog(message, this);
            endGameDialog.StartPosition = FormStartPosition.CenterParent;
            endGameDialog.ShowDialog();
        }

        private void UpdateUI()
        {
            UpdateQuestLog();
            UpdateInventory();
            UpdatePlayer();
            UpdateMovementControls(player.CurrentLocation);
            UpdateLocationLog(player.CurrentLocation);
        }

        private void DisableAllControls()
        {
            SetMovementControls(false);
            SetActionControls(false);
        }

        // Player Stats

        private void UpdatePlayerHitPoint()
        {
            hpValue.Text = player.CurrentHitPoint + " / " + player.MaximumHitPoint.ToString();
        }

        private void UpdatePlayerExp()
        {
            expValue.Text = player.CurrentEXP.ToString() + " / " + player.MaximumEXP.ToString();
        }

        private void UpdatePlayerGold()
        {
            goldValue.Text = player.Gold.ToString();
        }

        private void UpdatePlayerLevel()
        {
            levelValue.Text = player.CurrentLevel.ToString();
        }

        // Inventory
        private void UpdateInventory()
        {
            InventoryBox.Rows.Clear();
            InventoryBox.Refresh();

            foreach (InventoryItem inventoryItem in player.Inventory)
            {
                Item details = inventoryItem.Details;

                String inventoryType = details.GetType().ToString();
                inventoryType = inventoryType.Replace("Engine.", ""); // removes the Engine prefix

                String itemEffect = "";
                if (details is Food food)
                {
                    itemEffect = "Heals " + food.HealAmount + " HP instantly.";
                }
                else if (details is Weapon weapon)
                {
                    itemEffect = weapon.MinimumDamage + "-" + weapon.MaximumDamage + " Damage."; 
                }

                InventoryBox.Rows.Add(inventoryItem.Quantity, details.Name, details.Description, itemEffect);
            }
        }

        // Log

        private void AppendLog(string text)
        {
            string locationPrefix = "[" + player.CurrentLocation.Name + "]";
            logBox.AppendText(locationPrefix + " " + text + '\n');
            logBox.SelectionStart = logBox.Text.Length;
            logBox.ScrollToCaret();
        }

        // Quest Log

        private void UpdateQuestLog()
        {
            QuestBox.Rows.Clear();
            QuestBox.Refresh();
            
            foreach (PlayerQuest playerQuest in player.Quests)
            {
                int index = QuestBox.Rows.Add();

                // quest name
                String questName = playerQuest.Details.Name;

                // gets required items
                List<QuestItem> requiredItems = playerQuest.Details.RequiredItems;
                String requiredItemsToString = "";
                if (!playerQuest.IsCompleted)
                {
                    foreach (QuestItem requiredItem in requiredItems)
                    {
                        int desiredQuantity = requiredItem.Quantity;
                        int currentQuantity = player.QuantityOfItem(requiredItem.Details);
                        requiredItemsToString += requiredItem.Details.Name + " " + currentQuantity + "/" + requiredItem.Quantity + Environment.NewLine;
                    }
                }

                // quest status
                String isCompleted = (playerQuest.IsCompleted) ? "Completed" : "Pending";

                QuestBox.Rows[index].Cells[0].Value = playerQuest.Details.Name;
                QuestBox.Rows[index].Cells[1].Value = requiredItemsToString;
                QuestBox.Rows[index].Cells[2].Value = isCompleted;
                QuestBox.Rows[index].Cells[2].Style.ForeColor = (playerQuest.IsCompleted) ? Color.Green : Color.Red;
            }
            QuestBox.PerformLayout();
        }

        // Movement Control

        private void SetMovementControls(bool isVisible)
        {
            NordButton.Visible = isVisible;
            WestButton.Visible = isVisible;
            EastButton.Visible = isVisible;
            SouthButton.Visible = isVisible;
        }

        private void UpdateMovementControls(Location location)
        {
            NordButton.Visible = (location.NordLocation != null) && (!player.InCombat);
            WestButton.Visible = (location.WestLocation != null) && (!player.InCombat);
            SouthButton.Visible = (location.SouthLocation != null) && (!player.InCombat);
            EastButton.Visible = (location.EastLocation != null) && (!player.InCombat);
        }

        // Actions Control

        private void SetActionControls(bool isVisible)
        {
            AttackButton.Visible = isVisible;
            FoodButton.Visible = isVisible;
            RunButton.Visible = isVisible;
            CombatButton.Visible = isVisible;
            SaveButton.Visible = isVisible;
            HomeButton.Visible = isVisible;
        }

        private void EnableCombatControls()
        {
            AttackButton.Visible = true;
            FoodButton.Visible = true;
            RunButton.Visible = true;
            CombatButton.Visible = false;
            HomeButton.Visible = false;
            SaveButton.Visible = false;
        }

        private void DisableCombatControls()
        {
            AttackButton.Visible = false;
            FoodButton.Visible = false;
            RunButton.Visible = false;
            CombatButton.Visible = true;
            HomeButton.Visible = true;
            SaveButton.Visible = true;
        }

        private void DisableHomeButton()
        {
            HomeButton.Visible = false;
        }

        private void DisableCombatButton()
        {
            CombatButton.Visible = false;
        }

        // Location Log

        private void UpdateLocationLog(Location location)
        {
            locationBox.Text = location.Name + '\n';
            locationBox.AppendText(location.Description + '\n');
            if (location.MonsterLiving != null)
            {
                locationBox.AppendText(location.MonsterLiving.Name + " can be found here." + '\n');
                locationBox.AppendText("Possible Loots: " + location.MonsterLiving.LootsToString());
            }
        }

        // Monster interaction

        private void SpawnMonster()
        {
            Monster locationMonster = player.CurrentLocation.MonsterLiving;
            Monster spawnedMonster = new Monster(locationMonster.Name, locationMonster.MaximumHitPoint, locationMonster.CurrentHitPoint, locationMonster.ID, locationMonster.MinimumDamage, locationMonster.MaximumDamage, locationMonster.RewardExp, locationMonster.RewardGold);

            foreach (LootItem lootItem in locationMonster.Loots)
            {
                spawnedMonster.Loots.Add(lootItem);
            }

            player.CurrentMonster = spawnedMonster;
            AppendLog("A wild " + player.CurrentMonster.Name + " appears");
        }


        /* Event handlers */

        private void NordButton_Click(object sender, EventArgs e)
        {
            MovePlayerTo(player.CurrentLocation.NordLocation);
        }

        private void WestButton_Click(object sender, EventArgs e)
        {
            MovePlayerTo(player.CurrentLocation.WestLocation);
        }

        private void SouthButton_Click(object sender, EventArgs e)
        {
            MovePlayerTo(player.CurrentLocation.SouthLocation);
        }

        private void EastButton_Click(object sender, EventArgs e)
        {
            MovePlayerTo(player.CurrentLocation.EastLocation);
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            MovePlayerTo(World.LocationById(World.LOCATION_HOME));
        }

        private void CombatButton_Click(object sender, EventArgs e)
        {
            EnableCombat();
            UpdateUI();
            SpawnMonster();
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            PerformRunning();
        }

        private void GameOver()
        {
            OpenEndGameDialog("Player dies at level " + player.CurrentLevel);
            SpawnPlayer(true);
        }

        private void AttackButton_Click(object sender, EventArgs e)
        {
            PerformAttack();
        }

        private void FoodButton_Click(object sender, EventArgs e)
        {
            PerformEating();
        }
        
        private void SaveButton_Click(object sender, EventArgs e)
        {
            SavePlayer();
        }

        private void PerformAttack()
        {
            int attackDamage = player.Attack(player.CurrentMonster);
            AppendLog("Player deals " + attackDamage + " damage to " + player.CurrentMonster.Name);
            AppendLog(player.CurrentMonster.Name + ": " + player.CurrentMonster.CurrentHitPoint + " HP.");
            if (player.CurrentMonster.IsAlive())
            {
                int monsterDamage = player.CurrentMonster.Attack(player);
                AppendLog(player.CurrentMonster.Name + " deals " + monsterDamage + " damage.");
                AppendLog(player.CurrentMonster.Name + ": " + player.CurrentMonster.CurrentHitPoint + " HP.");

                if (!player.IsAlive())
                {
                    GameOver();
                }
            }
            else
            {
                AppendLog(player.CurrentMonster.Name + " is defeated.");

                AppendLog(player.CurrentMonster.RewardExp + " EXP and " + player.CurrentMonster.RewardGold + " Gold earned.");
                player.AddGold(player.CurrentMonster.RewardGold);
                if (player.AddExp(player.CurrentMonster.RewardExp))
                {
                    AppendLog("Level up !");
                }

                List<InventoryItem> loots = player.Loots(player.CurrentMonster.Loots);
                if (loots != null)
                {
                    foreach (InventoryItem loot in loots)
                    {
                        AppendLog("Looted: " + loot.Quantity + " " + loot.Details.Name);
                    }
                }
                player.RemoveMonster();
                CheckQuestIn(player.CurrentLocation);
                SpawnMonster();
            }
            UpdateUI();
        }

        private void PerformEating()
        {
            Food consumedFood = player.Eat();
            if (consumedFood == null)
            {
                AppendLog("No food.");
                return;
            }
            AppendLog("Consuming " + consumedFood.Name + " heals " + consumedFood.HealAmount + " HP.");
            UpdateUI();
        }
        
        private void PerformRunning()
        {
            DisableCombat();
            player.CurrentMonster = null;
            player.ReduceHitPoint(player.CurrentLevel);
            AppendLog("HP is reduced because of fleeing to " + player.CurrentHitPoint);
            if (!player.IsAlive())
            {
                GameOver();
            }
            CheckQuestIn(player.CurrentLocation);
            UpdateUI();
        }

        private void SavePlayer()
        {
            string data = player.SaveXml();
            if (data != null)
            {
                File.WriteAllText(World.PLAYER_DATA_PATH, data);
                AppendLog("Saved.");
            }
            else
            {
                AppendLog("Error. Unable to save data.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenEndGameDialog();
        }
    }
}
