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
    public partial class ResultForm : Form
    {
        public ResultForm()
        {
            InitializeComponent();
            EndGameLabelOnResultLabel.Parent = pictureBox1;
            elapsedTimeLabel.Parent = pictureBox3;
            MarkLabel.Parent = pictureBox3;
            ResultScoreLabel.Parent = pictureBox3;
        }
        public double scoreoonResultForm, numerOnResultForm, persent;
        public int gamemodenumber, elspasedTimeMinutes, elapsedTimeSeconds;

        private void ResultForm_Shown(object sender, EventArgs e)
        {
            persent = (scoreoonResultForm / numerOnResultForm) * 100;
            ResultScoreLabel.Text = "Вы ответили на " + Convert.ToString(persent) + "% правильно!";
            if (persent <= 20) MarkLabel.Text = "Ваш уровень знания устного счёта: Низкий";
            else if (persent > 20 && persent <= 40) MarkLabel.Text = "Ваш уровень знания устного счёта: Ниже среднего";
            else if (persent > 40 && persent <= 60) MarkLabel.Text = "Ваш уровень знания устного счёта: Средний";
            else if (persent > 60 && persent <= 80) MarkLabel.Text = "Ваш уровень знания устного счёта: Выше среднего";
            else if (persent > 80) MarkLabel.Text = "Ваш уровень знания устного счёта: Высокий";
            if (gamemodenumber == 1)
            {
                elapsedTimeLabel.Visible = true;
                elapsedTimeLabel.Text = "Затраченное время: " + elspasedTimeMinutes + " минут " + elapsedTimeSeconds + " секунд.";
            }

        }

        Point lastPoint;

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

        private void ExitIconOnResutForm_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ToMainMenuButtonOnResultForm_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Close();
        }


        private void ExitIconOnResutForm_MouseMove(object sender, MouseEventArgs e)
        {
            ExitIconOnResutForm.ForeColor = Color.Red;
        }

        private void ExitIconOnResutForm_MouseLeave(object sender, EventArgs e)
        {
            ExitIconOnResutForm.ForeColor = Color.Black;
        }
    }
}
