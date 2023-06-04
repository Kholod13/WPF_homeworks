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


    }
}
