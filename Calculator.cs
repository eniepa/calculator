using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace calculator
{
    public partial class Calculator : Form
    {
        char decimalSeparator;
        double numOne = 0;
        double numTwo = 0;
        string operation;
        Random rand = new Random();

        int red = 0;
        int green = 0;
        int blue = 0;

        bool operationInserted = false;
        string firstOperation;
        string secondOperation;
        string expression;
        int lengthOfNumOne = 0;
        bool scifiMode = false;
        const int widthSmall = 460;
        const int widthLarge = 800;
      

        public Calculator()
        {
            InitializeComponent();
            InitializeCalculator();
        }

        private void InitializeCalculator()
        {
           
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            backColor.Enabled = true;
            decimalSeparator = Convert.ToChar(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            Display.Text = "0";
            Display.TabStop = false;
            this.Width = widthSmall;
            
            string buttonName = null;
            Button button = null;
            for (int i = 0; i < 10; i++)
            {
                buttonName = "button" + i;
                button = (Button)this.Controls[buttonName];
                button.Text = i.ToString();
                // buttn.BackColor or Font = new Font ("Roboto", 22f)
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (Display.Text == "0")
            {
                Display.Text = button.Text;
            }
            else
            {
                Display.Text += button.Text;
            }
        }

        private void buttonDecimal_Click(object sender, EventArgs e)
        {

            if (!Display.Text.Contains(decimalSeparator))
            {
                if (Display.Text == string.Empty)
                {
                    Display.Text += "0" + decimalSeparator;
                }
                else
                {
                    Display.Text += decimalSeparator;
                }
            }
        }

        private void buttonBackspace_Click(object sender, EventArgs e)
        {
            string s = Display.Text;
            if (s.Length > 1)
            {
                if ((s.Contains("-")) && (s.Length == 2) || s.Substring(s.Length - 1, 1) == decimalSeparator.ToString())
                {
                    s = "0";
                    Display.Text = s;
                    return;
                }
                else
                {
                    s = "0";
                }
                Display.Text = s;
            }
        }

        private void buttonSign_Click(object sender, EventArgs e)
        {
            try
            {
                double number = Convert.ToDouble(Display.Text);
                number *= -1;
                Display.Text = number.ToString();
            }
            catch { }
        }

        private void Calculator_Load(object sender, EventArgs e)
        {

        }

        private void Operation_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            numOne = Convert.ToDouble(Display.Text);

            if (button.Text == "Sqrt")
            {
                Display.Text = Math.Sqrt(numOne).ToString();
                return;
            }

            Display.Text = string.Empty;
            operation = button.Text;
        }

        private void Result_Click(object sender, EventArgs e)
        {
            double result = 0;
            numTwo = Convert.ToDouble(Display.Text);
            if (operation == "+")
            {
                result = numOne + numTwo;
            }
            else if (operation == "-")
            {
                result = numOne - numTwo;
            }
            else if (operation == "*")
            {
                result = numOne * numTwo;
            }
            else if (operation == "/")
            {
                result = numOne / numTwo;
            }
            else if (operation == "^")
            {
                numOne = Math.Pow(numOne, numTwo);
            }

            Display.Text = result.ToString();
        }

        private void buttonSubstract_Click(object sender, EventArgs e)
        {
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Display.Text = "0";
        }

        private void backColor_Tick(object sender, EventArgs e)
        {
            red = rand.Next(0, 256);
            green = rand.Next(0, 256);
            blue = rand.Next(0, 256);
            this.BackColor = Color.FromArgb(red, green, blue);
            
        }

        private void buttonSciFi_Click(object sender, EventArgs e)
        {
            if (scifiMode)
            {
                this.Width = widthSmall;
            }
            else
            {
                this.Width = widthLarge;
            }
            scifiMode = !scifiMode;
        }
    }
    
}
