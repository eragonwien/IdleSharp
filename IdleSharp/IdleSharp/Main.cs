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
        public Main()
        {
            InitializeComponent();
        }

        private void NordButton_Click(object sender, EventArgs e)
        {
            goldValue.Text = (String.IsNullOrEmpty(goldValue.Text)) ? "0" : "Nord";
        }
    }
}
