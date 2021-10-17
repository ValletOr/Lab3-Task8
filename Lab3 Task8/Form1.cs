using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3_Task8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = Properties.Settings.Default.textBox1;
            textBox2.Text = Properties.Settings.Default.textBox2;
            operationBox.SelectedItem = Properties.Settings.Default.operationBox;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string check = InputChecker(textBox1.Text);
            if (check == "")
            {
                textBox1.BackColor = DefaultBackColor;
                textBox2.Enabled = true;
                operationBox.Enabled = true;
                Properties.Settings.Default.textBox1 = textBox1.Text;
                Properties.Settings.Default.Save();
                resultTextBox.Text = Calculate();
            }
            else
            {
                textBox1.BackColor = Color.Red;
                textBox2.Enabled = false;
                operationBox.Enabled = false;
                resultTextBox.Text = $"Ошибка в первом поле: {check}";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string check = InputChecker(textBox2.Text);
            if (check == "")
            {
                textBox2.BackColor = DefaultBackColor;
                textBox1.Enabled = true;
                operationBox.Enabled = true;
                Properties.Settings.Default.textBox2 = textBox2.Text;
                Properties.Settings.Default.Save();
                resultTextBox.Text = Calculate();
            }
            else
            {
                textBox2.BackColor = Color.Red;
                textBox1.Enabled = false;
                operationBox.Enabled = false;
                resultTextBox.Text = $"Ошибка во втором поле: {check}";
            }
        }

        private string Calculate()
        {
            MathSet firstSet = new MathSet(textBox1.Text);
            MathSet secondSet = new MathSet(textBox2.Text);
            MathSet resultSet;

            switch (operationBox.Text)
            {
                case "+":
                    resultSet = firstSet + secondSet;
                    break;
                case "*":
                    resultSet = firstSet * secondSet;
                    break;
                case "-":
                    resultSet = firstSet - secondSet;
                    break;
                default:
                    resultSet = new MathSet("");
                    break;
            }
            return resultSet.Verbose();
        }

        private string InputChecker(string input)
        {
            string outMessaage = "";
            try
            {
                int[] tempMass = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
                if(tempMass.Distinct().Count() != tempMass.Length)
                {
                    throw new Exception("В множестве есть повторяющиеся элементы");
                }
            }
            catch (Exception e)
            {
                outMessaage = e.Message;
                return outMessaage;
            }
            return outMessaage;
        }

        private void operationBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.operationBox = operationBox.Text;
            Properties.Settings.Default.Save();
            resultTextBox.Text = Calculate();
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Множество целых чисел. \n1)Объединение двух множеств(как сумма множеств)\n2)Пересечение двух множеств(как произведение множеств)\n3)Разность двух множеств\n4)Добавление элемента к множеству(как сумма с числом)\n5)Удаление элемента из множества(как разность с числом)");
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                operationBox.Focus();
                operationBox.DroppedDown = true;
            }
        }

        private void operationBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                textBox1.Focus();
            }
        }
    }
}
