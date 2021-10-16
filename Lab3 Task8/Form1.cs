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
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string check = InputChecker(textBox1.Text);
            if (check == "")
            {
                textBox1.BackColor = DefaultBackColor;
                resultTextBox.Text = Calculate();
            }
            else
            {
                textBox1.BackColor = Color.Red;
                resultTextBox.Text = $"Исключение в первом поле. Код исключения: {check}";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string check = InputChecker(textBox2.Text);
            if (check == "")
            {
                textBox2.BackColor = DefaultBackColor;
                resultTextBox.Text = Calculate();
            }
            else
            {
                textBox2.BackColor = Color.Red;
                resultTextBox.Text = $"Исключение во втором поле. Код исключения: {check}";
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
            }
            catch (Exception e)
            {
                outMessaage = e.Message;
                return outMessaage;
            }
            return outMessaage;
        }
    }
}
