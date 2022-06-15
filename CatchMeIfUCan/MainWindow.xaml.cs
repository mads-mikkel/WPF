using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace CatchMeIfUCan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DateTime start, stop;
        List<TimeSpan> times;
        public MainWindow()
        {
            InitializeComponent();
            start = DateTime.Now;
            times = new List<TimeSpan>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            stop = DateTime.Now;
            Background = PickBrush();
            button.Background = PickBrush();
            button.Foreground = PickBrush();
            button.BorderBrush = PickBrush();

            // Make a random number generator:
            Random generator = new Random();

            button.Height = generator.Next(35, 150);
            button.Width = generator.Next(35, 175);

            // Get the new dimensions
            double newHeight = generator.NextDouble() * (ActualHeight - button.ActualHeight);
            double newWidth = generator.NextDouble() * (ActualWidth - button.ActualWidth);

            // Load the new dimensions into the button
            button.Margin = new(newWidth, newHeight, 0.0, 0.0);

            TimeSpan time = stop - start;
            times.Add(time);
            times = times.OrderBy(e => e.Ticks).ToList();

            textBlockTime.Text = time.ToString(@"ss\.fff") + " s";
            if (times.Count > 0)
                textBlockHigh.Text = times.FirstOrDefault().ToString(@"ss\.fff") + " s";
            start = DateTime.Now;
        }

        private Brush PickBrush()
        {
            Brush result = Brushes.Transparent;

            Random rnd = new Random();

            Type brushesType = typeof(Brushes);

            PropertyInfo[] properties = brushesType.GetProperties();

            int random = rnd.Next(properties.Length);
            result = (Brush)properties[random].GetValue(null, null);

            return result;
        }
    }
}
