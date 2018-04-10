using Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

            player = new Player("Player 1", 10, 10, 10);
            MovePlayerTo(World.LocationById(World.LOCATION_HOME));
            UpdatePlayer();
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
                AppendLog(destination.ItemRequiredToEnter.Name + " is required to enter this location.");
                return;
            }
            player.EnterLocation(destination);
            AppendLog("Player moves to " + destination.Name);
            if (destination.HasAnyQuest())
            {
                Quest locationQuest = destination.QuestAvailable;

                if (player.IsQuestAccepted(locationQuest))
                {
                    if (!player.IsQuestCompleted(locationQuest) && player.IsQuestFulfilled(locationQuest))
                    {
                        player.CompleteQuest(locationQuest);
                    }
                }
                else
                {
                    AppendLog("New quest available.");
                    player.AddQuest(locationQuest);
                }
            }
            if (player.IsAtHome()) // ID of home
            {
                player.Heal(player.MaximumHitPoint);
                AppendLog("Player's HP is restored to " + player.CurrentHitPoint);
            }

            UpdateQuestLog();
            UpdateMovementControls(destination);
            UpdateLocationLog(destination);
        }

        /* UI update */

        // Player Stats

        private void UpdatePlayerLevel()
        {
            hpValue.Text = player.CurrentHitPoint.ToString() + " / " + player.MaximumHitPoint.ToString();
        }

        private void UpdatePlayerExp()
        {
            expValue.Text = player.CurrentEXP.ToString();
        }

        private void UpdatePlayerGold()
        {
            goldValue.Text = player.Gold.ToString();
        }

        private void UpdatePlayerHitPoint()
        {
            levelValue.Text = player.CurrentLevel.ToString();
        }

        // Inventory

        // Log

        private void AppendLog(string text)
        {
            logBox.AppendText(text + '\n');
            logBox.SelectionStart = logBox.Text.Length;
            logBox.ScrollToCaret();
        }

        // Quest Log

        private void UpdateQuestLog()
        {
            QuestBox.Rows.Clear();
            QuestBox.Refresh();
            QuestBox.ColumnCount = 3;
            QuestBox.Columns[0].HeaderText = "Objective";
            QuestBox.Columns[1].HeaderText = "Progress";
            QuestBox.Columns[2].HeaderText = "Completed";
            foreach (PlayerQuest playerQuest in player.Quests)
            {
                int index = QuestBox.Rows.Add();
                String questName = playerQuest.Details.Name;
                List<QuestItem> requiredItems = playerQuest.Details.RequiredItems;
                String requiredItemsToString = "";
                foreach (QuestItem requiredItem in requiredItems)
                {
                    requiredItemsToString += requiredItem.Details.Name + '\n';// Continue here
                }
                QuestBox.Rows[index].Cells[0].Value = playerQuest.Details.Name;
                QuestBox.Rows[index].Cells[1].Value = requiredItemsToString;
                QuestBox.Rows[index].Cells[2].Value = playerQuest.Details.Name;
            }
            
        }

        // Movement Control
        private void UpdateMovementControls(Location location)
        {
            NordButton.Visible = (location.NordLocation != null);
            WestButton.Visible = (location.WestLocation != null);
            SouthButton.Visible = (location.SouthLocation != null);
            EastButton.Visible = (location.EastLocation != null);
        }

        // Actions Control

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
    }
}
