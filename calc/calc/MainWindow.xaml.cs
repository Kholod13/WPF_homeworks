using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace calc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        enum Operations 
        { 
            Add, 
            Minus, 
            Mult, 
            Div, 
            None = -1,
        }

        private string previousDigit = string.Empty;
        private string currentDigit = string.Empty;
        private int currentOperation = (int)Operations.None;
        private int lastOperation = (int)Operations.None;
        private string lastDigit = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
            TextBoxCurrent.Text = "0";
        }

        //methods
        public static bool auditZero(string val)
        {
            double n;
            return (double.TryParse(val, out n) && n != 0);
        }

        public static string DeleteLastDigit(string val)
        {
            StringBuilder builder = new StringBuilder(val);
            if (builder.Length > 1)
            {
                builder.Length--;  
            }
            else
            {
                builder[0] = '0';  
            }
            return builder.ToString();
        }

        //buttons
        private void ButtonCE_Click(object sender, RoutedEventArgs e)
        {
            currentDigit= string.Empty;
            TextBoxCurrent.Text = "0";
        }

        private void ButtonC_Click(object sender, RoutedEventArgs e)
        {
            currentDigit= string.Empty;
            previousDigit= string.Empty;
            TextBoxCurrent.Text = "0";
            TextBoxHistory.Text = string.Empty;
            currentOperation = (int)Operations.None;
        }

        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {
            if (auditZero(currentDigit))
            {
                currentDigit = DeleteLastDigit(currentDigit);
                TextBoxCurrent.Text = currentDigit;
            }
        }

        private void ButtonDivide_Click(object sender, RoutedEventArgs e)
        {
            if (previousDigit == string.Empty && currentDigit == string.Empty && currentOperation == (int)Operations.None)
                return;
            if (previousDigit != string.Empty && currentOperation != (int)Operations.None)
                ButtonEqual_Click_1(sender, e);
            else if (previousDigit == string.Empty)
                previousDigit = currentDigit;
            currentDigit = string.Empty;
            TextBoxHistory.Text = previousDigit + " / ";
            currentOperation = (int)Operations.Div;
        }

        private void ButtonD(object sender, RoutedEventArgs e)
        {
            currentDigit += (sender as Button).Content.ToString();
            TextBoxCurrent.Text = currentDigit;
        }

        private void ButtonEqual_Click_1(object sender, RoutedEventArgs e)
        {
            if (currentDigit == string.Empty && lastOperation != -1)
            {
                currentDigit = lastDigit;
                currentOperation = lastOperation;
                switch ((Operations)lastOperation)
                {
                    case Operations.Add:
                        TextBoxHistory.Text = $"{previousDigit} + ";
                        break;
                    case Operations.Minus:
                        TextBoxHistory.Text = $"{previousDigit} - ";
                        break;
                    case Operations.Mult:
                        TextBoxHistory.Text = $"{previousDigit} * ";
                        break;
                    case Operations.Div:
                        TextBoxHistory.Text = $"{previousDigit} / ";
                        break;
                    default:
                        break;
                }
            }
            if (currentOperation == -1 && lastOperation == -1)
                TextBoxHistory.Text = TextBoxCurrent.Text;
            else
            {
                switch ((Operations)currentOperation)
                {
                    case Operations.Add:
                        TextBoxCurrent.Text = (decimal.Parse(previousDigit) + decimal.Parse(currentDigit)).ToString();
                        break;
                    case Operations.Minus:
                        TextBoxCurrent.Text = (decimal.Parse(previousDigit) - decimal.Parse(currentDigit)).ToString();
                        break;
                    case Operations.Mult:
                        TextBoxCurrent.Text = (decimal.Parse(previousDigit) * decimal.Parse(currentDigit)).ToString();
                        break;
                    case Operations.Div:
                        if (previousDigit != string.Empty && currentDigit == "0")
                        {
                            previousDigit = string.Empty;
                            currentDigit = string.Empty;
                            currentOperation = (int)Operations.None;
                            TextBoxHistory.Text = string.Empty;
                            TextBoxCurrent.Text = "Cannot divide by zero";
                            return;
                        }
                        TextBoxCurrent.Text = (decimal.Parse(previousDigit) / decimal.Parse(currentDigit)).ToString();
                        break;
                    default:
                        break;
                }
                TextBoxHistory.Text += currentDigit;
                TextBoxHistory.Text += " = ";
                previousDigit = TextBoxCurrent.Text;
            }
            lastDigit = currentDigit;
            currentDigit = string.Empty;
            lastOperation = currentOperation;
            currentOperation = (int)Operations.None;
        }

        private void ButtonMultiply_Click(object sender, RoutedEventArgs e)
        {
            if (previousDigit == string.Empty && currentDigit == string.Empty && currentOperation == (int)Operations.None)
                return;

            if (previousDigit != string.Empty && currentOperation != (int)Operations.None)
                ButtonEqual_Click_1(sender, e);
            else if (previousDigit == string.Empty)
                previousDigit = currentDigit;
            currentDigit = string.Empty;
            TextBoxHistory.Text = previousDigit + " * ";
            currentOperation = (int)Operations.Mult;
        }

        private void ButtonMinus_Click(object sender, RoutedEventArgs e)
        {
            if (previousDigit == string.Empty && currentDigit == string.Empty && currentOperation == (int)Operations.None)
            {
                currentDigit = "-";
                TextBoxCurrent.Text = "-0";
                return;
            }
            if (previousDigit != string.Empty && currentOperation != (int)Operations.None)
                ButtonEqual_Click_1(sender, e);
            else if (previousDigit == string.Empty)
                previousDigit = currentDigit;
            currentDigit = string.Empty;
            TextBoxHistory.Text = previousDigit + " - ";
            currentOperation = (int)Operations.Minus;
        }

        private void ButtonPlus_Click(object sender, RoutedEventArgs e)
        {
            if (previousDigit == string.Empty && currentDigit == string.Empty && currentOperation == (int)Operations.None)
                return;
            if (previousDigit != string.Empty && currentOperation != (int)Operations.None)
                ButtonEqual_Click_1(sender, e);
            else if (previousDigit == string.Empty)
                previousDigit = currentDigit;
            currentDigit = string.Empty;
            TextBoxHistory.Text = previousDigit + " + ";
            currentOperation = (int)Operations.Add;
        }

        private void ButtonDot_Click(object sender, RoutedEventArgs e)
        {
            if (currentDigit.Contains(','))
                return;
            if (currentDigit != string.Empty && currentDigit == "-")
                currentDigit = "-0,";
            else if (currentDigit != string.Empty)
                currentDigit += ",";
            else
                currentDigit = "0,";
            TextBoxCurrent.Text = currentDigit;
        }
    }
}
