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

        
        Random rndongameform = new Random();
        Point lastPoint;
        public string answer, answerbox;
        public int numer, lvl, gamemode, point, score = 0, time, example, operation;

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

        private void AnswerButtonOnGameForm_Click(object sender, EventArgs e)
        {
            answerbox = AnswerBoxOnGameForm.Text;
            GameProcesslvl1num10training();
        }

        private void AnswerBoxOnGameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                answerbox = AnswerBoxOnGameForm.Text;
                GameProcesslvl1num10training();

            }
        }

        private void ExitIcon_MouseMove(object sender, MouseEventArgs e)
        {
            ExitIconOnGameForm.ForeColor = Color.Red;
        }

        private void ExitIcon_MouseLeave(object sender, EventArgs e)
        {
            ExitIconOnGameForm.ForeColor = Color.Black;
        }

        private void ExitIconOnGameForm_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void StartTheActionButtonOnGameForm_Click(object sender, EventArgs e)
        {
            conditionwrite();
            ScoreNameLabelOnGameForm.Visible = true;
            ScoreCountLabelOnGameForm.Visible = true;
            schetchikOnGameForm.Visible = true;
            num1labelOnGameForm.Visible = true;
            num2labelOnGameForm.Visible = true;
            operationlabelOnGameForm.Visible = true;
            AnswerLabelNameOnGameForm.Visible = true;
            AnswerBoxOnGameForm.Visible = true;
            AnswerButtonOnGameForm.Visible = true;
            TimeCountLabelOnGameForm.Visible = true;
            TimeLabelOnMainForm.Visible = true;
            StartTheActionButtonOnGameForm.Visible = false;
        }
        private void GoBackButtonOnGameForm_Click(object sender, EventArgs e)
        {
            MainForm mainFormOnGameForm = new MainForm();
            mainFormOnGameForm.Show();
        }

        public int x, y, z, x1, y1, i = 0;

        public GameForm()
        {
            InitializeComponent();
        }
        

        public void conditionwrite()
        {
            schetchikOnGameForm.Text = ("Номер примера - " + i);
            ScoreCountLabelOnGameForm.Text = Convert.ToString(score);
            x1 = rndongameform.Next(10, 20);
            y1 = rndongameform.Next(10);
            operation = rndongameform.Next(2); // 1 это плюс, 0 это минус
            num1labelOnGameForm.Text = Convert.ToString(x1);
            num2labelOnGameForm.Text = Convert.ToString(y1);
            if (operation == 1) operationlabelOnGameForm.Text = "+"; else if (operation == 0) operationlabelOnGameForm.Text = "-";
        }

        public void GameProcesslvl1num10training()
        {
            ResultForm resultFormOnGameForm = new ResultForm();
            ScoreCountLabelOnGameForm.Text = Convert.ToString(score);

            do
            {
                {


                    if (operation == 1)
                    {
                        z = x1 + y1;
                        answer = Convert.ToString(z);

                        if (answerbox == answer)
                        {
                            point = 1;
                        }
                        else point = 0;
                        score = score + point;
                        ScoreCountLabelOnGameForm.Text = Convert.ToString(score);
                        AnswerBoxOnGameForm.Text = "";
                        i++;

                        schetchikOnGameForm.Text = ("Номер примера - " + i);
                        conditionwrite();
                    }
                    else if (operation == 0)
                    {

                        z = x1 - y1;
                        answer = Convert.ToString(z);

                        if (answerbox == answer)
                        {
                            point = 1;
                        }
                        else point = 0;
                        score = score + point;
                        ScoreCountLabelOnGameForm.Text = Convert.ToString(score);
                        AnswerBoxOnGameForm.Text = "";
                        i++;

                        schetchikOnGameForm.Text = ("Номер примера - " + i);
                        conditionwrite();
                    }
                }

            } while (i > numer);
            if (i == numer)
            {
                MessageBox.Show("Игра окончена!");
                resultFormOnGameForm.scoreoonResultForm = score;
                resultFormOnGameForm.numerOnResultForm = numer;
                resultFormOnGameForm.Show();
                this.Close();

            }
        }
    }
}
