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

namespace clw0206
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int numPeoples = 0;
        public MainWindow()
        {
            InitializeComponent();
            buttonOK.IsEnabled= false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string room = "";
            if (radioButtonEco.IsChecked == true)
            {
                room = radioButtonEco.Content.ToString();
            }
            else if (radioButtonStandart.IsChecked == true)
            {
                room = radioButtonStandart.Content.ToString();
            }
            else if (radioButtonLux.IsChecked == true)
            {
                room = radioButtonLux.Content.ToString();
            }
            List<DateTime> selectedDates = Calendar.SelectedDates.ToList();

            DateTime startDate = selectedDates.Min();
            DateTime endDate = selectedDates.Max();

            MessageBox.Show($"Info:\nName:{name.Text}\nContact info:{contact_info.Text}\nNum peoples: {num_peoples.Text}\nType room: {room}\nTime: {startDate} to {endDate}");
        }

        private void RepeatButton_Click(object sender, RoutedEventArgs e)
        {
            numPeoples++;
            if (numPeoples > 12)
            {
                numPeoples = 0;
            }
            num_peoples.Text = numPeoples.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            name.Text= string.Empty;
            contact_info.Text = string.Empty;
            num_peoples.Text = string.Empty;

            radioButtonEco.IsChecked = false;
            radioButtonStandart.IsChecked = false;
            radioButtonLux.IsChecked = false;

            Calendar.SelectedDates.Clear();
            checkBox.IsChecked = false;
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            if (checkBox.IsChecked == true)
            {
                buttonOK.IsEnabled = true;
            }
            if (checkBox.IsChecked == false)
            {
                buttonOK.IsEnabled = false;
            }
        }
    }
}
