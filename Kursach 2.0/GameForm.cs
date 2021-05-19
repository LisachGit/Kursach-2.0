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
        public int numer, lvl, gamemode, point, score = 0, time, example, operation, timerstart = 0, m = 0, s = 0, timevalue; // timevalue: 1 - 30 секунд, 2 - 1 минута, 3 - 2 минуты, 4 - 5 минут
        public bool prost, timelimiter = true;

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
            if (gamemode == 1)
                GameProcesslvl1num10time();
            else if (gamemode == 2) GameProcesslvl1num10training();
        }

        private void AnswerBoxOnGameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                answerbox = AnswerBoxOnGameForm.Text;
                if (gamemode == 1)
                    GameProcesslvl1num10time();
                else if (gamemode == 2) GameProcesslvl1num10training();

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

        private void timer1_Tick(object sender, EventArgs e)
        {
            ResultForm resultFormOnGameForm = new ResultForm();
            if (s < 59)
            {
                s++;
                if (s < 10)
                {
                    TimeCountSecondsLabelOnGameForm.Text = "0" + s.ToString();
                }
                else TimeCountSecondsLabelOnGameForm.Text = s.ToString();
            }
            else
            {
                if (m < 59)
                {
                    m++;
                    if (m < 10)

                        TimeCountMinutesLabelOnGameForm.Text = "0" + m.ToString();
                    else TimeCountMinutesLabelOnGameForm.Text = m.ToString();
                    s = 0;
                    TimeCountSecondsLabelOnGameForm.Text = "00";
                }
                else
                {
                    m = 0;
                    TimeCountMinutesLabelOnGameForm.Text = "00";
                }
            }

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
            TimeCountMinutesLabelOnGameForm.Text = "00";
            TimeCountSecondsLabelOnGameForm.Text = "00";
            if (gamemode == 2)
            {
                conditionwritetrainingmode();
                ScoreNameLabelOnGameForm.Visible = true;
                ScoreCountLabelOnGameForm.Visible = true;
                schetchikOnGameForm.Visible = true;
                num1labelOnGameForm.Visible = true;
                num2labelOnGameForm.Visible = true;
                operationlabelOnGameForm.Visible = true;
                AnswerLabelNameOnGameForm.Visible = true;
                AnswerBoxOnGameForm.Visible = true;
                AnswerButtonOnGameForm.Visible = true;
                TimeCountMinutesLabelOnGameForm.Visible = false;
                TimeCountSecondsLabelOnGameForm.Visible = false;
                TimeLabelOnMainForm.Visible = false;
                StartTheActionButtonOnGameForm.Visible = false;
            } else if (gamemode == 1)
            {
                conditionwritetimemode();
                ScoreNameLabelOnGameForm.Visible = true;
                ScoreCountLabelOnGameForm.Visible = true;
                schetchikOnGameForm.Visible = true;
                num1labelOnGameForm.Visible = true;
                num2labelOnGameForm.Visible = true;
                operationlabelOnGameForm.Visible = true;
                AnswerLabelNameOnGameForm.Visible = true;
                AnswerBoxOnGameForm.Visible = true;
                AnswerButtonOnGameForm.Visible = true;
                TimeCountMinutesLabelOnGameForm.Visible = true;
                TimeCountSecondsLabelOnGameForm.Visible = true;
                TimeLabelOnMainForm.Visible = true;
                StartTheActionButtonOnGameForm.Visible = false;
            }
        }
        private void GoBackButtonOnGameForm_Click(object sender, EventArgs e)
        {
            MainForm mainFormOnGameForm = new MainForm();
            mainFormOnGameForm.Show();
            this.Close();
        }

        public int x, y, z, x1, y1, i = 0;

        public GameForm()
        {
            InitializeComponent();
            GameNameOnGameForm.Parent = pictureBox1;
            ScoreNameLabelOnGameForm.Parent = pictureBox3;
            ScoreCountLabelOnGameForm.Parent = pictureBox3;
            schetchikOnGameForm.Parent = pictureBox3;
            TimeLabelOnMainForm.Parent = pictureBox3;
            TimeCountMinutesLabelOnGameForm.Parent = pictureBox3;
            TimeCountSecondsLabelOnGameForm.Parent = pictureBox3;
            num1labelOnGameForm.Parent = pictureBox3;
            operationlabelOnGameForm.Parent = pictureBox3;
            num2labelOnGameForm.Parent = pictureBox3;
            AnswerLabelNameOnGameForm.Parent = pictureBox3;
        }



        public void Lvl1()
        {
            schetchikOnGameForm.Text = ("Номер примера - " + i);
            ScoreCountLabelOnGameForm.Text = Convert.ToString(score);
            x1 = rndongameform.Next(10, 20);
            y1 = rndongameform.Next(1, 10);
            operation = rndongameform.Next(2); // 1 это плюс, 0 это минус
            num1labelOnGameForm.Text = Convert.ToString(x1);
            num2labelOnGameForm.Text = Convert.ToString(y1);
            if (operation == 1) operationlabelOnGameForm.Text = "+"; else if (operation == 0) operationlabelOnGameForm.Text = "-";
        }

        public void Lvl2()
        {
            schetchikOnGameForm.Text = ("Номер примера - " + i);
            ScoreCountLabelOnGameForm.Text = Convert.ToString(score);
            operation = rndongameform.Next(3); // 1 это плюс, 0 это минус, 2 это умножить
            if (operation == 2)
            {
                x1 = rndongameform.Next(1, 10);
                y1 = rndongameform.Next(2, 10);
            }
            else if (operation == 1)
            {
                x1 = rndongameform.Next(5, 50);
                y1 = rndongameform.Next(5, 30);
            }
            else if (operation == 0)
            {
                x1 = rndongameform.Next(21, 50);
                y1 = rndongameform.Next(5, 20);
            }
            num1labelOnGameForm.Text = Convert.ToString(x1);
            num2labelOnGameForm.Text = Convert.ToString(y1);
            if (operation == 1) operationlabelOnGameForm.Text = "+"; else if (operation == 0) operationlabelOnGameForm.Text = "-"; else if (operation == 2) operationlabelOnGameForm.Text = "*";
        }

        public void Lvl3()
        {
            schetchikOnGameForm.Text = ("Номер примера - " + i);
            ScoreCountLabelOnGameForm.Text = Convert.ToString(score);
            operation = rndongameform.Next(4); // 1 это плюс, 0 это минус, 2 это умножить, 3 это деление
            if (operation == 2)
            {
                x1 = rndongameform.Next(2, 20);
                y1 = rndongameform.Next(5, 30);
            }
            else if (operation == 3)
            {
                del();
            }
            else if (operation == 1)
            {
                x1 = rndongameform.Next(50, 200);
                y1 = rndongameform.Next(30, 49);
            }
            else if (operation == 0)
            {
                x1 = rndongameform.Next(50, 200);
                y1 = rndongameform.Next(20, 49);
            }
            num1labelOnGameForm.Text = Convert.ToString(x1);
            num2labelOnGameForm.Text = Convert.ToString(y1);
            if (operation == 1) operationlabelOnGameForm.Text = "+"; else if (operation == 0) operationlabelOnGameForm.Text = "-"; else if (operation == 2) operationlabelOnGameForm.Text = "*"; else if (operation == 3) operationlabelOnGameForm.Text = "/";
        }

        public void del()
        {
            do
            {
                x1 = rndongameform.Next(10, 400);
                for (int i = 2; i <= x1 / 2; i++)
                {
                    if (x1 % i == 0)
                    {
                        prost = false;
                        break;
                    }
                }
            } while (prost);
            do
            {
                y1 = rndongameform.Next(2, 399);
            }
            while (x1 % y1 != 0 && x1 != y1);
            if (x1 == y1) del();
        }

        public void Plus()
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
        }

        public void Minus()
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
        }

        public void Power()
        {
            z = x1 * y1;
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
        }

        public void Divide()
        {
            z = x1 / y1;
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
        }

        public void conditionwritetrainingmode()
        {
            if (lvl == 1)
            {
                Lvl1();
            }
            else if (lvl == 2)
            {
                Lvl2();
            }
            else if (lvl == 3)
            {
                Lvl3();
            }
        }



        public void conditionwritetimemode()
        {
            timer1.Enabled = true;
            if (lvl == 1)
            {
                Lvl1();
            }
            else if (lvl == 2)
            {
                Lvl2();
            }
            else if (lvl == 3)
            {
                Lvl3();
            }
            if (timevalue == 1 && s >= 30) timelimiter = false;
            else if (timevalue == 2 && m >= 1) timelimiter = false;
            else if (timevalue == 3 && m >= 2) timelimiter = false;
            else if (timevalue == 4 && m >= 5) timelimiter = false;

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
                        Plus();
                        conditionwritetrainingmode();
                    }
                    else if (operation == 0)
                    {

                        Minus();
                        conditionwritetrainingmode();
                    }
                    else if (operation == 2)
                    {
                        Power();
                        conditionwritetrainingmode();
                    }
                    else if (operation == 3)
                    {
                        Divide();
                        conditionwritetrainingmode();
                    }
                }

            } while (i > numer);
            if (i == numer)
            {
                timer1.Enabled = false;
                MessageBox.Show("Игра окончена!");
                resultFormOnGameForm.elapsedTimeSeconds = s;
                resultFormOnGameForm.elspasedTimeMinutes = m;
                resultFormOnGameForm.scoreoonResultForm = score;
                resultFormOnGameForm.numerOnResultForm = numer;
                resultFormOnGameForm.gamemodenumber = gamemode;
                resultFormOnGameForm.Show();
                this.Close();

            }
        }

        public void GameProcesslvl1num10time()
        {
            ResultForm resultFormOnGameForm = new ResultForm();
            ScoreCountLabelOnGameForm.Text = Convert.ToString(score);
            

            do
            {
                


                    if (operation == 1)
                    {
                        Plus();
                        conditionwritetimemode();
                    }
                    else if (operation == 0)
                    {

                        Minus();
                        conditionwritetimemode();
                    }
                    else if (operation == 2)
                    {
                        Power();
                        conditionwritetimemode();
                    }
                    else if (operation == 3)
                    {
                        Divide();
                        conditionwritetimemode();
                    }
                if (timelimiter == false) break;

            } 
            while (timelimiter == false);
            
            if (timelimiter == false)
            {
                timer1.Enabled = false;
                MessageBox.Show("Время вышло!");
                resultFormOnGameForm.elapsedTimeSeconds = s;
                resultFormOnGameForm.elspasedTimeMinutes = m;
                resultFormOnGameForm.scoreoonResultForm = score;
                resultFormOnGameForm.numerOnResultForm = numer;
                resultFormOnGameForm.gamemodenumber = gamemode;
                resultFormOnGameForm.iongame = i;
                
                resultFormOnGameForm.Show();
                this.Close();

            }
        }
    }
}
