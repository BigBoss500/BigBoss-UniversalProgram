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
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OlibUpdater.Pages
{
    /// <summary>
    /// Логика взаимодействия для main.xaml
    /// </summary>
    public partial class main : Page
    {
        public main()
        {
            InitializeComponent();
            TopSecret.Visibility = Core.EasterEggs.Image;
            Core.EasterEggs.DisplayEgg(SecretText);
            AnimationText(this, null);
        }
        private void AnimationText1(object sender, EventArgs e)
        {
            var anim = new DoubleAnimation
            {
                Duration = TimeSpan.FromSeconds(1),
                To = 0
            };
            anim.Completed += AnimationText;
            Warning.BeginAnimation(DropShadowEffect.BlurRadiusProperty, anim);
        }
        private void AnimationText(object sender, EventArgs e)
        {
            var anim = new DoubleAnimation
            {
                Duration = TimeSpan.FromSeconds(1),
                To = 10
            };
            anim.Completed += AnimationText1;
            Warning.BeginAnimation(DropShadowEffect.BlurRadiusProperty, anim);
        }
        private void dataParser(object sender, RoutedEventArgs e) => NavigationService.Navigate(new Uri("Pages/dataParser.xaml", UriKind.Relative));
        private void Roulette(object sender, RoutedEventArgs e) => NavigationService.Navigate(new Uri("Pages/roulette.xaml", UriKind.Relative));
        private void Button_Click(object sender, RoutedEventArgs e) => NavigationService.Navigate(new Uri("Pages/converter.xaml", UriKind.Relative));
        private void Autoclicker(object sender, RoutedEventArgs e) => new Windows.autoclicker().Show();
    }
}
