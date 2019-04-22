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

namespace WpfDRAGDROP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void label1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.Move;
        }

        private void label1_Drop(object sender, DragEventArgs e)
        {
            Label lbl = (Label)sender;
            ((Label)sender).Content = (string)e.Data.GetData(DataFormats.Text);
            TextBox[] t = new TextBox[] { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6 };
            for (int i = 0; i <= 5; ++i)
            {
                if (t[i].IsFocused)
                {
                    ((Label)sender).FontWeight = t[i].FontWeight;
                    ((Label)sender).FontStyle = t[i].FontStyle;
                }
            }
        }

        private void textBox1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataObject data = new DataObject(typeof(TextBox), textBox1.Text);
            TextBox t = sender as TextBox;
            if (e.ChangedButton == MouseButton.Left)
                DragDrop.DoDragDrop(sender as TextBox, sender, DragDropEffects.Move);
        }

        private void Grid_PreviewDragEnter(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.Move;
        }

        private void Grid_Drop(object sender, DragEventArgs e)
        {
            var trg = e.Source as Label;
            if (trg == null)
                return;
            var src = e.Data.GetData(typeof(TextBox)) as TextBox;
            trg.Content = src.Text;
            src.Visibility = Visibility.Hidden;

        }

        private void exit1_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void bold1_Click(object sender, RoutedEventArgs e)
        {
            TextBox[] t = new TextBox[] { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6 };
            MenuItem mi = sender as MenuItem;
            for (int i = 0; i <= 5; ++i)
            {
                if (t[i].IsFocused)
                {
                    if (t[i].FontWeight == FontWeights.Normal)
                        t[i].FontWeight = FontWeights.Bold;
                    else
                        t[i].FontWeight = FontWeights.Normal;
                }
            }
        }

        private void italic1_Click(object sender, RoutedEventArgs e)
        {
            TextBox[] t = new TextBox[] { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6 };
            MenuItem mi = sender as MenuItem;
            for (int i = 0; i <= 5; ++i)
            {
                if (t[i].IsFocused)
                {
                    if (t[i].FontStyle == FontStyles.Normal)
                        t[i].FontStyle = FontStyles.Italic;
                    else
                        t[i].FontStyle = FontStyles.Normal;
                }
            }
        }
    }
}
