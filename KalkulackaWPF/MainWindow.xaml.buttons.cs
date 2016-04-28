﻿using System.Windows;

namespace KalkulackaWPF
{
    public partial class MainWindow
    {
        public void updateDisplay(string task)
        {
            new Logger(3, "Code", string.Format("An updateDisplay call has appeared with task {0}", task));
            if (task == "clear")
            {
                directPad.Text = "";
                indirectPad.Text = "";
                new Logger(2, "Display", "Text pads were cleared");
                isResult = false;
                lastResult = 0;
                new Logger(2, "Vars", "Ans values were resetted");
            }
            else if (task == "del")
            {
                if (0 < directPad.Text.Length)
                {
                    directPad.Text = directPad.Text.Remove(directPad.Text.Length - 1, 1);
                    new Logger(2, "Display", "Erasing last caracter from directPad");
                }
                else
                {
                    new Logger(2, "Display", "Attempted to erase from directPad but source string is empty, aboarting");
                }
            }
            tasks.CheckBlocksInitiate(directPad.Text, indirectPad.Text);
        }
        public void updateDisplay(string task, string val)
        {
            if (task == "write")
            {
                if (val == ".")
                {
                    if (!tasks.dec && directPad.Text != "" && !isResult)
                    {
                        directPad.Text += ".";
                    }
                }
                else
                {
                    if (isResult)
                    {
                        directPad.Text = val;
                        indirectPad.Text = "";
                        isResult = false;
                    }
                    else
                    {
                        directPad.Text += val;
                    }
                }
            }
            else if (task == "moveUp")
            {
                string oper;
                switch (val)
                {
                    default:
                        oper = "";
                        break;
                    case "plus":
                        oper = "+";
                        break;
                    case "minus":
                        oper = "-";
                        break;
                    case "times":
                        oper = "*";
                        break;
                    case "divide":
                        oper = "/";
                        break;
                    case "equal":
                        oper = "=";
                        break;
                }
                indirectPad.Text += directPad.Text + oper;
                directPad.Text = processor.StepSolve();
            }
            tasks.CheckBlocksInitiate(directPad.Text, indirectPad.Text);
        }

        // numbers
        private void number1_Click(object sender, RoutedEventArgs e)
        {
            updateDisplay("write", "1");
        }
        private void number2_Click(object sender, RoutedEventArgs e)
        {
            updateDisplay("write", "2");
        }
        private void number3_Click(object sender, RoutedEventArgs e)
        {
            updateDisplay("write", "3");
        }
        private void number4_Click(object sender, RoutedEventArgs e)
        {
            updateDisplay("write", "4");
        }
        private void number5_Click(object sender, RoutedEventArgs e)
        {
            updateDisplay("write", "5");
        }
        private void number6_Click(object sender, RoutedEventArgs e)
        {
            updateDisplay("write", "6");
        }
        private void number7_Click(object sender, RoutedEventArgs e)
        {
            updateDisplay("write", "7");
        }
        private void number8_Click(object sender, RoutedEventArgs e)
        {
            updateDisplay("write", "8");
        }
        private void number9_Click(object sender, RoutedEventArgs e)
        {
            updateDisplay("write", "9");
        }
        private void number0_Click(object sender, RoutedEventArgs e)
        {
            updateDisplay("write", "0");
        }
        // clear
        private void del_Click(object sender, RoutedEventArgs e)
        {
            updateDisplay("del");
        }
        private void ac_Click(object sender, RoutedEventArgs e)
        {
            updateDisplay("clear");
        }
        // operators
        private void plus_Click(object sender, RoutedEventArgs e)
        {
            updateDisplay("moveUp", "plus");
        }
        private void minus_Click(object sender, RoutedEventArgs e)
        {
            updateDisplay("moveUp", "minus");
        }
        private void times_Click(object sender, RoutedEventArgs e)
        {
            updateDisplay("moveUp", "times");
        }
        private void divide_Click(object sender, RoutedEventArgs e)
        {
            updateDisplay("moveUp", "divide");
        }
        // func
        private void power2_Click(object sender, RoutedEventArgs e)
        {
            processor.CreateFormula("pow2");
        }
        private void power3_Click(object sender, RoutedEventArgs e)
        {
            processor.CreateFormula("pow3");
        }
        private void powerN_Click(object sender, RoutedEventArgs e)
        {
            processor.CreateFormula("powx");
        }
        private void root2_Click(object sender, RoutedEventArgs e)
        {
            processor.CreateFormula("root2");
        }
        private void root3_Click(object sender, RoutedEventArgs e)
        {
            processor.CreateFormula("root3");
        }
        private void rootN_Click(object sender, RoutedEventArgs e)
        {
            processor.CreateFormula("rootx");
        }
        private void sin_Click(object sender, RoutedEventArgs e)
        {
            processor.CreateFormula("sin");
        }
        private void cos_Click(object sender, RoutedEventArgs e)
        {
            processor.CreateFormula("cos");
        }
        private void tan_Click(object sender, RoutedEventArgs e)
        {
            processor.CreateFormula("tan");
        }
        private void log_Click(object sender, RoutedEventArgs e)
        {
            processor.CreateFormula("log10");
        }
        private void logn_Click(object sender, RoutedEventArgs e)
        {
            processor.CreateFormula("log");
        }
        private void ln_Click(object sender, RoutedEventArgs e)
        {
            processor.CreateFormula("ln");
        }
        // parts
        private void powerE_Click(object sender, RoutedEventArgs e)
        {
            processor.CreateFormula("eP");
        }
        private void exponential_Click(object sender, RoutedEventArgs e)
        {
            updateDisplay("write", "Ex");
        }
        private void ans_Click(object sender, RoutedEventArgs e)
        {
            updateDisplay("write", "Ans");
        }
        private void decButton_Click(object sender, RoutedEventArgs e)
        {
            updateDisplay("write", ".");
        }
        private void optionsOpen_Click(object sender, RoutedEventArgs e)
        {
            Window w = new Window();
            w.Content = new Options();
            w.Show();
        }
        private void bracketOpen_Click(object sender, RoutedEventArgs e)
        {
            updateDisplay("write", "(");
        }
        private void bracketClose_Click(object sender, RoutedEventArgs e)
        {
            updateDisplay("write", ")");
        }
        private void equal_Click(object sender, RoutedEventArgs e)
        {
            updateDisplay("moveUp", "equal");
            processor.Process();
        }
    }
}