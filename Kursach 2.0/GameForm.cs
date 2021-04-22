using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursach_2._0
{

    public partial class GameForm : Form
    {

        public int numer, lvl, gamemode;

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = Convert.ToString(numer);
            label2.Text = Convert.ToString(lvl);
            label3.Text = Convert.ToString(gamemode);
        }

        public GameForm()
        {
            InitializeComponent();
        }
    }
}
