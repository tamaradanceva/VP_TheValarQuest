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
    public partial class MainMenu : Form
    {
        public ChooseCharacter cc;
        public MainMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Play clicked
            cc = new ChooseCharacter();
            cc.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // How to play clicked
            How_to_play htp = new How_to_play();
            htp.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
