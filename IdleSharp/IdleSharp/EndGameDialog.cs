using SharpAdventure;
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
    public partial class EndGameDialog : Form
    {
        private Main main = null;
        public EndGameDialog(string message, Main mainForm)
        {
            InitializeComponent();
            main = mainForm;
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            main.SpawnPlayer(true);
            this.Close();
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
