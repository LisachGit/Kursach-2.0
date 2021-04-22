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
        }
        public double scoreoonResultForm, numerOnResultForm, persent;

        private void ResultForm_Shown(object sender, EventArgs e)
        {
            persent = (scoreoonResultForm / numerOnResultForm) * 100;
            ResultScoreLabel.Text = "Вы ответили на " + Convert.ToString(persent) + "% правильно!";
            if (persent < 20) MarkLabel.Text = "Ваш уровень знания устного счёта: Низкий";
            else if (persent > 20 && persent < 50) MarkLabel.Text = "Ваш уровень знания устного счёта: Средний";
            else if (persent > 50 && persent < 80) MarkLabel.Text = "Ваш уровень знания устного счёта: Хороший";
            else if (persent > 80) MarkLabel.Text = "Ваш уровень знания устного счёта: Отличный";
        }

        private void ExitIconOnResutForm_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
