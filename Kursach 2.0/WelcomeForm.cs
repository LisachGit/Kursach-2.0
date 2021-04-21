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
    public partial class WelcomeForm : Form
    {

        AboutForm aboutFormOnWelcomeForm = new AboutForm();
        MainForm mainFormOnWelcomeForm = new MainForm();
        Point lastPoint;
        public WelcomeForm()
        {
            InitializeComponent();
        }

        private void ExitIcon_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ExitIcon_MouseMove(object sender, MouseEventArgs e)
        {
            ExitIcon.ForeColor = Color.Red;
        }

        private void ExitIcon_MouseLeave(object sender, EventArgs e)
        {
            ExitIcon.ForeColor = Color.Black;
        }

        private void StartMainMenuButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainFormOnWelcomeForm.Show();
        }

        private void AboutOnWelcomeForm_MouseMove(object sender, MouseEventArgs e)
        {
            AboutOnWelcomeForm.ForeColor = Color.Cyan;
            toolTip1.SetToolTip(AboutOnWelcomeForm, "О программе");
        }

        private void AboutOnWelcomeForm_MouseLeave(object sender, EventArgs e)
        {
            AboutOnWelcomeForm.ForeColor = Color.Black;
        }

        private void AboutOnWelcomeForm_Click(object sender, EventArgs e)
        {
            aboutFormOnWelcomeForm.Show();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
    }
}
