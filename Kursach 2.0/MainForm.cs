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
            AboutLvlsLabel.Parent = pictureBox3;
            SelectTimeLabel.Parent = pictureBox3;
            panel4.Parent = pictureBox3;
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


        private void GoBackButtonOnMainForm_Click(object sender, EventArgs e)
        {
            this.Hide();
            WelcomeForm welcomeform = new WelcomeForm();
            welcomeform.Show();
        }

        private void StartButtonOnMainForm_Click(object sender, EventArgs e)
        {
            ResultForm resultForm = new ResultForm();
            if ((lvl1.Checked || lvl2.Checked || lvl3.Checked) && training_mode.Checked && (num10.Checked || num20.Checked || num30.Checked) || (lvl1.Checked || lvl2.Checked || lvl3.Checked) && time_mode.Checked && (sec30button.Checked || minute1button.Checked || minute2button.Checked || minute5button.Checked))
            {
                if (lvl1.Checked) gameFormonmain.lvl = 1; else if (lvl2.Checked) gameFormonmain.lvl = 2; else if (lvl3.Checked) gameFormonmain.lvl = 3;

                if (time_mode.Checked) gameFormonmain.gamemode = 1; else if (training_mode.Checked) gameFormonmain.gamemode = 2;

                if (num10.Checked) { gameFormonmain.numer = 10; resultForm.numerOnResultForm = 10; } else if (num20.Checked) { gameFormonmain.numer = 20; resultForm.numerOnResultForm = 20; } else if (num30.Checked) {gameFormonmain.numer = 30; resultForm.numerOnResultForm = 30; }

                if (sec30button.Checked) { gameFormonmain.timevalue = 1; } else if (minute1button.Checked) { gameFormonmain.timevalue = 2; } else if (minute2button.Checked) { gameFormonmain.timevalue = 3; } else if (minute5button.Checked) { gameFormonmain.timevalue = 4; }
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

        private void AboutLvlsLabel_MouseMove(object sender, MouseEventArgs e)
        {
            AboutLvlsLabel.ForeColor = Color.Cyan;
        }

        private void AboutLvlsLabel_MouseLeave(object sender, EventArgs e)
        {
            AboutLvlsLabel.ForeColor = Color.White;
        }

        private void AboutLvlsLabel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Сложность 1 - Базовая тренировка на сложение и вычитания \nСложность 2 - Средний уровень тренировки сложения, вычитания и умножения \nСложность 3 - Продвинутый уровень тренировки сложения, вычитания, умножения и деления");
        }

        private void time_mode_CheckedChanged(object sender, EventArgs e)
        {
            if (time_mode.Checked == true)
            {
                SelectTimeLabel.Visible = true;
                panel4.Visible = true;
                panel3.Visible = false;
                ChooseNumberOnMainForm.Visible = false;
            }
        }

        private void training_mode_CheckedChanged(object sender, EventArgs e)
        {
            if (training_mode.Checked == true)
            {
                SelectTimeLabel.Visible = false;
                panel4.Visible = false;
                panel3.Visible = true;
                ChooseNumberOnMainForm.Visible = true;
            }
        }
    }
}
