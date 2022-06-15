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
using System.Windows.Shapes;

namespace SplashLogin
{
    /// <summary>
    /// Interaction logic for SplashWindow.xaml
    /// </summary>
    public partial class SplashWindow : Window
    {
        public SplashWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateCredentials())
            {
                MainWindow mainWindow = new();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show(
                    "De indtastede oplysninger giver ikke adgang til systemet.",
                    "Login fejl",
                    MessageBoxButton.OK,
                    MessageBoxImage.Exclamation);
                passwordBox.Password = String.Empty;
            }
        }

        private bool ValidateCredentials()
        {
            string username = textBoxUsername.Text;
            string password = passwordBox.Password;
            return Valididate(username, password);
        }

        private bool Valididate(string username, string password)
        {
            List<(string, string)> credentials = new()
            {
                ("MARA", "1234"),
                ("DEGR", "1234"),
                ("LOAL", "1234")
            };
            return credentials.Contains((username, password));
        }

        private void TextBoxUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBoxUsername != null)
            {
                string input = textBoxUsername?.Text;
                if (input != null && input.Length > 4)
                {
                    textBoxUsername.Text = input.Substring(0, 4);
                }
                if (input.Length > 0)
                {
                    if (!Char.IsLetter(input.Last()))
                    {
                        textBoxUsername.Text = input.Substring(0, input.Length - 1);
                    }
                    else
                    {
                        textBoxUsername.Text = input.ToUpperInvariant();
                    }
                }
            }
        }
    }
}
