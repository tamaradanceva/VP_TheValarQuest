using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace The_Valar_Quest
{
    public partial class ChooseCharacter : Form
    {
        public Game g;

        public ChooseCharacter()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Varda clicked
            string character= "Varda";
            g = new Game(character);
          //  Game g = new Game();
            g.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Manwe clicked
            string character = "Manwë";
            g = new Game(character);
            //  Game g = new Game();
            g.ShowDialog();
            this.Close();
        }
    }
}
