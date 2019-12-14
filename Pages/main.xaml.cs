using Microsoft.AppCenter.Analytics;
using Olib.Core;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Olib.Pages
{
    /// <summary>
    /// Логика взаимодействия для main.xaml
    /// </summary>
    public partial class main : Page
    {
        public main()
        {
            InitializeComponent();
            TopSecret.Visibility = EasterEggs.Image;
            EasterEggs.DisplayEgg(SecretText);
            Animations.AnimationText(Warning);
        }
        private void dataParser(object sender, RoutedEventArgs e)
        {
            _ = NavigationService.Navigate(new Uri("Pages/dataParser.xaml", UriKind.Relative));
            Analytics.TrackEvent("Активирована одна из функции в программе", new Dictionary<string, string> {
                { "Категория", "Функция" },
                { "Название", "DataParser"}
            });
        }

        private void Roulette(object sender, RoutedEventArgs e)
        {
            _ = NavigationService.Navigate(new Uri("Pages/roulette.xaml", UriKind.Relative));
            Analytics.TrackEvent("Активирована одна из функции в программе", new Dictionary<string, string> {
                { "Категория", "Функция" },
                { "Название", "Рулетка"}
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _ = NavigationService.Navigate(new Uri("Pages/converter.xaml", UriKind.Relative));
            Analytics.TrackEvent("Активирована одна из функции в программе", new Dictionary<string, string> {
                { "Категория", "Функция" },
                { "Название", "Конвертер"}
            });
        }

        private void Autoclicker(object sender, RoutedEventArgs e)
        {
            new Windows.autoclicker().Show();
            Analytics.TrackEvent("Активирована одна из функции в программе", new Dictionary<string, string> {
                { "Категория", "Функция" },
                { "Название", "Автокликер"}
            });
        }

        private void DarkChat(object sender, RoutedEventArgs e)
        {
            _ = NavigationService.Navigate(new Uri("Pages/darkChat.xaml", UriKind.Relative));
            Analytics.TrackEvent("Активирована одна из функции в программе", new Dictionary<string, string> {
                { "Категория", "Функция" },
                { "Название", "DarkChat"}
            });
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _ = NavigationService.Navigate(new Uri("Pages/neuro.xaml", UriKind.Relative));
            Analytics.TrackEvent("Активирована одна из функции в программе", new Dictionary<string, string> {
                { "Категория", "Функция" },
                { "Название", "Neuro"}
            });
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            _ = NavigationService.Navigate(new Uri("Pages/mathematik.xaml", UriKind.Relative));
            Analytics.TrackEvent("Активирована одна из функции в программе", new Dictionary<string, string> {
                { "Категория", "Функция" },
                { "Название", "Математика"}
            });
        }
    }
}
