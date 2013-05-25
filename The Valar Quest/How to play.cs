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
    public partial class How_to_play : Form
    {
        public How_to_play()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // go back clicked
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // see map clicked
            Map m = new Map();
            m.ShowDialog();
        }
    }
}
