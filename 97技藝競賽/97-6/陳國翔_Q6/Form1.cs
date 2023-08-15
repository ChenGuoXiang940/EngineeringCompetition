using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 陳國翔_Q6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static int compare(char ch)
        {
            if (ch == 'x' || ch == '/') return 2;
            if (ch == '+' || ch == '-') return 1;
            return 0;
        }
        public static double figure(char ch,double a,double b)
        {
            if (ch == 'x') return b * a;
            if (ch == '/') return b / a;
            if (ch == '+') return b + a;
            return b - a;
        }
        public void Solove()
        {
            string text = $"{Label1.Text}";
            Stack<double> number = new Stack<double>();
            List<char> op = new List<char>();
            string data = "";
            for(int i = 0; i < text.Length; i++)
            {
                switch (text[i])
                {
                    case '+':
                    case '-':
                    case 'x':
                    case '/':
                        number.Push(double.Parse(data));
                        data = "";
                        while(op.Count >= 1 && text[i] <= op.Last())
                        {
                            number.Push(figure(op.Last(), number.Pop(), number.Pop()));
                            op.RemoveAt(op.Count - 1);
                        }
                        op.Add(text[i]);
                        break;
                    default:
                        data += text[i];
                        break;
                }
            }
            if (data != "") number.Push(double.Parse(data));
            while (number.Count != 1)
            {
                number.Push(figure(op.Last(), number.Pop(), number.Pop()));
                op.RemoveAt(op.Count - 1);
            }
            Label1.Text = $"{number.Peek()}";
        }
        private void Clicked(object sender, EventArgs e)
        {
            switch (((Button)sender).Text)
            {
                case "AC":
                    Label1.Text = "0";
                    break;
                case "Log":
                    Label1.Text = $"{Math.Log10(double.Parse(Label1.Text))}";
                    break;
                case "=":
                    Solove();                   
                    break;
                case "+/-":
                    label2.Text = (label2.Text) == "" ? "-" : "";
                    break;
                default:
                    if (Label1.Text.Length == 1 && Label1.Text == "0") Label1.Text = ((Button)sender).Text;
                    else Label1.Text += ((Button)sender).Text;
                    break;
            }
        }
    }
}
