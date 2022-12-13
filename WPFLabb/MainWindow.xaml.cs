using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.Arm;
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
        string[] valbaraBord = { "Bord 1", "Bord 2", "Bord 3", "Bord 4", "Bord 5", "Bord 6" };

        public MainWindow()
        {

            InitializeComponent();
            DisplayContent();
            ToListBox();
            Calendar();

        }

        private void DisplayContent()
        {
            
            TidComboBox.ItemsSource = valbaraTider;
            BordBox.ItemsSource = valbaraBord;
            
        }

        private void Calendar()
        {
            Kalender.BlackoutDates.AddDatesInPast();
            Kalender.BlackoutDates.Add(new CalendarDateRange(DateTime.Now.AddDays(-1)));
        }
        public void AddDateToList_Click(object sender, RoutedEventArgs e)
        {

            if (Kalender.SelectedDate != null && TidComboBox.SelectedItem != null && !(string.IsNullOrEmpty(NamnTextBox.Text) && BordBox.SelectedItem != null))
            {
                MyListView.Items.Clear();
                reservations.Add(new Restaurant((DateTime)Kalender.SelectedDate, TidComboBox.Text, NamnTextBox.Text, BordBox.Text));

                ToListBox();
                TidComboBox.Text = String.Empty;
                NamnTextBox.Text = String.Empty;
                BordBox.Text = String.Empty;
            }

            else
            {
                MessageBox.Show("Du saknar ett val! Försök igen", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }
        public void TaBortBokningBtn_Click(object sender, RoutedEventArgs e)
        {
            
            RemoveListBox();
            
        }
        public void ToListBox()
        {
            MyListView.Items.Clear();
            foreach (Restaurant input in reservations)
            {
                
                MyListView.Items.Add(input.Date + ", " + input.Time + ", " + input.Name + ", " + input.Table);


            }

        }

        public void RemoveListBox()
        {
            if (MyListView.SelectedItems.Count != 0)
            {
                while (MyListView.SelectedIndex != -1)
                {
                    MyListView.Items.RemoveAt(MyListView.SelectedIndex);
                }
            }
        }
        private void VisaBokningBtn_Click(object sender, RoutedEventArgs e)

        {          
            ToListBox();


        }
        private void RensaBtn_Click(object sender, RoutedEventArgs e)
        {
            MyListView.Items.Clear();
        }

        private void AvslutaBtn_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();

        }
    }
}