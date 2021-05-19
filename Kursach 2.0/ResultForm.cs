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
            persentage.Parent = pictureBox3;
        }
        public double scoreoonResultForm, numerOnResultForm, persent, iongame;
        public int gamemodenumber, elspasedTimeMinutes, elapsedTimeSeconds;
        public string based = "Ваш уровень знания устного счёта: ", low = "Низкий",middlelow = "Ниже среднего",middle = "Средний", highmiddle = "Выше среднего",high = "Высокий";

        private void ResultForm_Shown(object sender, EventArgs e)
        {
            if (gamemodenumber == 2)
            {
                persent = (scoreoonResultForm / numerOnResultForm) * 100;
                ResultScoreLabel.Text = "Вы ответили на " + string.Format("{0:0.00}", Convert.ToString(persent)) + "% правильно!";
                Analyze();
            }
            if (gamemodenumber == 1)
            {
                persentage.Visible = false;
                ResultScoreLabel.Text = "Количество решённых примеров: " + iongame;
                persentage.Text = "Из них верно отвеченных: " + scoreoonResultForm;
                persent = (scoreoonResultForm / iongame) * 100;
                Analyze();
                elapsedTimeLabel.Visible = true;
                elapsedTimeLabel.Text = "Затраченное время: " + elspasedTimeMinutes + " минут " + elapsedTimeSeconds + " секунд.";
            }

        }

        Point lastPoint;

        private void Analyze()
        {
            if (persent <= 20) MarkLabel.Text = based + low;
            else if (persent > 20 && persent <= 40) MarkLabel.Text = based + middlelow;
            else if (persent > 40 && persent <= 60) MarkLabel.Text = based + middle;
            else if (persent > 60 && persent <= 80) MarkLabel.Text = based + highmiddle;
            else if (persent > 80) MarkLabel.Text = based + high;
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
