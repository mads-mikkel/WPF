using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace ItemsControls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Person> people = new()
        {
            new() { Name = "Lewis Hamilton", BirthDate = new(1982, 05, 04) },
            new() { Name = "Max Verstappen", BirthDate = new(1997, 11, 10) },
            new() { Name = "Kevin Magnussen", BirthDate = new(1992, 01, 12) }
        };

        public MainWindow()
        {            
            InitializeComponent();
            people = people.OrderBy(p => p.Name).ToList();
            listBoxPeople.ItemsSource = people;
        }

        private void AddPerson_Click(object sender, RoutedEventArgs e)
        {
            // Hent data fra brugerfladen:
            string name = textBoxName.Text;
            DateTime birthDate = datePickerBirthDate.SelectedDate.Value;

            // Lav et nyt Person objekt:
            Person p = new() { Name = name, BirthDate = birthDate };

            // Tilføje det nye Person objekt til listen af personer og sorter på ny:
            people.Add(p);
            people = people.OrderBy(p => p.Name).ToList();

            // Udskift itemssource på listboxen med den nu muterede liste af personer:
            listBoxPeople.ItemsSource = null;
            listBoxPeople.ItemsSource = people;
        }

        private void listBoxPeople_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBoxPeople.SelectedItem != null)
            {
                Person selectedPerson = (Person)listBoxPeople.SelectedItem;
                textBoxName.Text = selectedPerson.Name;
                datePickerBirthDate.SelectedDate = selectedPerson.BirthDate;
            }
        }
    }
}