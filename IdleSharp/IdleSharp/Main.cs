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

namespace IdleSharp
{
    public partial class Main : Form
    {
        private Player player;
        public Main()
        {
            InitializeComponent();

            player = new Player("Player 1", 10, 10, 10);
            UpdatePlayer();
        }

        private void UpdatePlayer()
        {
            hpValue.Text = player.CurrentHitPoint.ToString();
            goldValue.Text = player.Gold.ToString();
            expValue.Text = player.CurrentEXP.ToString();
            levelValue.Text = player.CurrentLevel.ToString();
        }
    }
}
