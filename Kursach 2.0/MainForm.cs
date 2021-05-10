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
    public partial class MainForm : Form
    {

        Point lastPoint;
        GameForm gameFormonmain = new GameForm();
        AboutForm aboutFormOnMain = new AboutForm();
        public MainForm()
        {
            InitializeComponent();
            WelcomeLabelOnMainForm.Parent = pictureBox1;
            ChooseDifficultyLevelOnMainForm.Parent = pictureBox3;
            ChooseNumberOnMainForm.Parent = pictureBox3;
            ChooseTypeOnMainForm.Parent = pictureBox3;
            panel1.Parent = pictureBox3;
            panel2.Parent = pictureBox3;
            panel3.Parent = pictureBox3;
        }

        private void ExitIconOnMainForm_MouseMove(object sender, MouseEventArgs e)
        {
            ExitIconOnMainForm.ForeColor = Color.Red;
        }

        private void ExitIconOnMainForm_MouseLeave(object sender, EventArgs e)
        {
            ExitIconOnMainForm.ForeColor = Color.Black;
        }

        private void ExitIconOnMainForm_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ChooseDifficultyLevelOnMainForm_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(ChooseDifficultyLevelOnMainForm, "Тут написать про классы");
        }

        private void GoBackButtonOnMainForm_Click(object sender, EventArgs e)
        {
            this.Hide();
            WelcomeForm welcomeform = new WelcomeForm();
            welcomeform.Show();
        }

        private void StartButtonOnMainForm_Click(object sender, EventArgs e)
        {
            ResultForm resultForm = new ResultForm();
            if ((lvl1.Checked || lvl2.Checked || lvl3.Checked) && (time_mode.Checked || training_mode.Checked) && (num10.Checked || num20.Checked || num30.Checked))
            {
                if (lvl1.Checked) gameFormonmain.lvl = 1; else if (lvl2.Checked) gameFormonmain.lvl = 2; else if (lvl3.Checked) gameFormonmain.lvl = 3;

                if (time_mode.Checked) gameFormonmain.gamemode = 1; else if (training_mode.Checked) gameFormonmain.gamemode = 2;

                if (num10.Checked) { gameFormonmain.numer = 10; resultForm.numerOnResultForm = 10; } else if (num20.Checked) { gameFormonmain.numer = 20; resultForm.numerOnResultForm = 20; } else if (num30.Checked) {gameFormonmain.numer = 30; resultForm.numerOnResultForm = 30; }
                this.Hide();
                gameFormonmain.Show();
            }
            else
            { MessageBox.Show("Не выбрана сложность или режим игры или количество вопросов", "Ошибка!"); }
        }

        private void AboutIconOnMainForm_MouseMove(object sender, MouseEventArgs e)
        {
            AboutIconOnMainForm.ForeColor = Color.Cyan;
            toolTip2.SetToolTip(AboutIconOnMainForm, "О программе");
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

        private void AboutIconOnMainForm_MouseLeave(object sender, EventArgs e)
        {
            AboutIconOnMainForm.ForeColor = Color.Black;
        }

        private void AboutIconOnMainForm_Click(object sender, EventArgs e)
        {
            aboutFormOnMain.Show();
        }
    }
}
