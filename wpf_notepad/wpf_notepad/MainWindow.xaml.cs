using System;
using System.Collections.Generic;
using System.Drawing;
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
using MediaColor = System.Windows.Media.Color;

namespace wpf_notepad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int[] fontSizes = { 10, 12, 14, 16, 20, 22, 26, 30, 38 };
        System.Windows.Media.Color[] colors = new System.Windows.Media.Color[]
            {
                System.Windows.Media.Colors.Red,
                System.Windows.Media.Colors.Blue,
                System.Windows.Media.Colors.Green,
                System.Windows.Media.Colors.Yellow,
                System.Windows.Media.Colors.Orange
            };
        public MainWindow()
        {
            InitializeComponent();
            sizeComboBox.ItemsSource = fontSizes;
            sizeComboBox.SelectedIndex = 1;
            colorComboBox.ItemsSource = colors;

        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            TextBox.Text = string.Empty;
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ShowStatusBar()
        {
            int str, wrd, sym;
            str = TextBox.GetLineIndexFromCharacterIndex(TextBox.CaretIndex) + 1;
            numStrings.Content = $"String: {str}";
            wrd = TextBox.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Count();
            numWords.Content = $"Words: {wrd}";
            sym = TextBox.Text.Length;
            numSymbols.Content = $"Symbols: {sym}";
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ShowStatusBar();
        }

        private void ButtonBold_Click(object sender, RoutedEventArgs e)
        {
            TextBox.FontWeight= FontWeights.Bold;
        }

        private void ButtonUnderline_Click(object sender, RoutedEventArgs e)
        {
            TextBox.TextDecorations = TextDecorations.Underline;
        }

        private void ButtonItalic_Click(object sender, RoutedEventArgs e)
        {
            TextBox.FontStyle = FontStyles.Italic;
        }

        private void ButtonAlignLeft_Click(object sender, RoutedEventArgs e)
        {

            TextBox.TextAlignment = TextAlignment.Left;
        }

        private void ButtonAlignCenter_Click(object sender, RoutedEventArgs e)
        {
            TextBox.TextAlignment = TextAlignment.Center;
        }

        private void ButtonAlignRight_Click(object sender, RoutedEventArgs e)
        {
            TextBox.TextAlignment = TextAlignment.Right;
        }

        private void sizeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBox.FontSize = int.Parse(sizeComboBox.SelectedItem.ToString());
        }

        private void colorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBox.Text = colors[0].ToString();
        }
    }
}
