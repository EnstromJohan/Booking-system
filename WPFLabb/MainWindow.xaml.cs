using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
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

using Microsoft.VisualBasic;
using WPFLabb;
using static Labb.MainWindow;
using static WPFLabb.Class.WPFClass;

namespace Labb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Restaurant>? reservations = new();

        string[] valbaraTider = { "17.00", "18:00", "19:00", "20:00", "21:00", "22:00" };
        string[] valbaraBord = { "Bord 1", "Bord 2", "Bord 3" };



        public MainWindow()
        {
            InitializeComponent();

            //MyListBox.ItemsSource = reservations;
            DisplayContent();
            ToListBox();

        }

        private void DisplayContent()
        {
            TimeComboBox.ItemsSource = valbaraTider;
            TableBox.ItemsSource = valbaraBord;

        }


        public void AddDateToList_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MyListBox.Items.Clear();
                if (MyListBox.Items.Contains(DatePicker.SelectedDate))
                {
                    MessageBox.Show("Datumet är redan bokat");
                }
                else
                    reservations.Add(new Restaurant((DateTime)DatePicker.SelectedDate, TimeComboBox.Text, NameTextBox.Text, TableBox.Text));
                ToListBox();
            }
            catch (Exception)
            {
                MessageBox.Show("Du saknar ett val! Försök igen", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        public void ToListBox()
        {
            //reservations.Add(new Restaurant { Date = "2022-10-11", Time = "18.00", Name = "Johan", Table = "Bord 1" });

            try
            {
                foreach (Restaurant input in reservations)
                {
                    MyListBox.Items.Add(input.Date + ", " + input.Time + ", " + input.Name + ", " + input.Table);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Du saknar ett val! Försök igen", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void RensaBokning_Click(object sender, RoutedEventArgs e)
        {
            MyListBox.Items.Remove(MyListBox.SelectedItem);


        }

        private void VisaBokning_Click(object sender, RoutedEventArgs e)
        {
            ToListBox();

        }
        private void Rensa_Click(object sender, RoutedEventArgs e)
        {
            MyListBox.Items.Clear();
        }


        private void Avsluta_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();

        }
    }
}