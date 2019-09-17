using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Jekyll.windows
{
    /// <summary>
    /// Логика взаимодействия для License.xaml
    /// </summary>
    public partial class License : Window
    {
        public License()
        {
            InitializeComponent();
            if (Properties.Settings.Default.LicenseAgreement == true)
            {
                MainWindow window = new MainWindow();
                window.Show();
                Close();
            }
            Licens.Opacity = 0;
            System.Random r = new System.Random();
            Chance = r.Next(1, 6);
            if (Chance == 1)
            {
                Text.Text += local.Localization.LicenseChance1;
            }
            else if (Chance == 2)
            {
                Text.Text += local.Localization.LicenseChance2;
            }
            else if (Chance == 3)
            {
                Text.Text += local.Localization.LicenseChance3;
            }
            else if (Chance == 4)
            {
                Text.Text += local.Localization.LicenseChance4;
            }
            else if (Chance == 5)
            {
                Text.Text += local.Localization.LicenseChance5;
            }
            else if (Chance == 6)
            {
                Text.Text += local.Localization.LicenseChance6;
            }
            Poss();
        }
        private async void Poss()
        {
            for (double i = 0; i < 1; i += 0.1)
            {
                Licens.Opacity = i;
                await Task.Delay(1);
            }
        }
        private async void Unposs()
        {
            for (double i = 1; i > 0; i -= 0.1)
            {
                Licens.Opacity = i;
                await Task.Delay(1);
            }
        }
        private int Attemps { get; set; }
        private int Chance;
        private void CloseButton_MouseEnter(object sender, MouseButtonEventArgs a)
        {
            if (Chance == 1)
            {
                if (a.ChangedButton == MouseButton.Middle)
                {
                    Properties.Settings.Default.LicenseAgreement = true;
                    Properties.Settings.Default.Save();
                    MainWindow window = new MainWindow();
                    window.Show();
                    Unposs();
                    Close();
                }
            }
            else if (Chance == 2)
            {
                if (a.ChangedButton == MouseButton.Right)
                {
                    Properties.Settings.Default.LicenseAgreement = true;
                    Properties.Settings.Default.Save();
                    MainWindow window = new MainWindow();
                    window.Show();
                    Unposs();
                    Close();
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.Sound();
            Attemps++;
            if (Attemps == 1)
            {
                MessageBox.Show(local.Localization.LicenseMessage1, local.Localization.LicenseMessage, MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (Attemps == 2)
            {
                MessageBox.Show(local.Localization.LicenseMessage2, local.Localization.LicenseMessage, MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (Attemps == 3)
            {
                MessageBox.Show(local.Localization.LicenseMessage3, local.Localization.LicenseMessage, MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (Attemps == 4)
            {
                MessageBox.Show($"{local.Localization.LicenseMessage4} {Attemps}", local.Localization.LicenseMessage, MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (Attemps > 4)
            {
                MessageBox.Show($"{local.Localization.LicenseMessage5} {Attemps}", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            App.Sound();
            Application.Current.Shutdown();
        }

        private void Button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Chance == 3)
            {
                if (e.ChangedButton == MouseButton.Middle)
                {
                    Properties.Settings.Default.LicenseAgreement = true;
                    Properties.Settings.Default.Save();
                    MainWindow window = new MainWindow();
                    window.Show();
                    Unposs();
                    Close();
                }
            }
            else if (Chance == 4)
            {
                if (e.ChangedButton == MouseButton.Right)
                {
                    Properties.Settings.Default.LicenseAgreement = true;
                    Properties.Settings.Default.Save();
                    MainWindow window = new MainWindow();
                    window.Show();
                    Unposs();
                    Close();
                }
            }
        }

        private void Button_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (Chance == 5)
            {
                if (e.ChangedButton == MouseButton.Middle)
                {
                    Properties.Settings.Default.LicenseAgreement = true;
                    Properties.Settings.Default.Save();
                    MainWindow window = new MainWindow();
                    window.Show();
                    Unposs();
                    Close();
                }
            }
            else if (Chance == 6)
            {
                if (e.ChangedButton == MouseButton.Right)
                {
                    Properties.Settings.Default.LicenseAgreement = true;
                    Properties.Settings.Default.Save();
                    MainWindow window = new MainWindow();
                    window.Show();
                    Unposs();
                    Close();
                }
            }
        }
    }
}
