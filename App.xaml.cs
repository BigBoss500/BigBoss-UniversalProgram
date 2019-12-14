using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Media;
using System.Windows;
using System.Windows.Threading;

namespace Olib
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static List<CultureInfo> Languages { get; } = new List<CultureInfo>();
        public App()
        {
            Languages.Clear();
            Languages.Add(new CultureInfo("en-US")); //Neutral
            Languages.Add(new CultureInfo("ru-RU"));
            Languages.Add(new CultureInfo("uk-UA"));
            Languages.Add(new CultureInfo("de-DE"));
            Languages.Add(new CultureInfo("hy-AM"));
            LanguageChanged += App_LanguageChanged;
        }

        private void App_LanguageChanged(object sender, EventArgs e)
        {
            Olib.Properties.Settings.Default.DefaultLanguage = Language;
            Olib.Properties.Settings.Default.Save();
        }

        private void Sound(object sender, RoutedEventArgs e)
        {
            using (SoundPlayer sound = new SoundPlayer(Olib.Properties.Resources.sound_click))
            {
                sound.Play();
            }
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Resources.MergedDictionaries[0].Source = new Uri($"/Themes/{Olib.Properties.Settings.Default.NameTheme}.xaml", UriKind.Relative);

            Language = Olib.Properties.Settings.Default.DefaultLanguage;
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            string countryCode = RegionInfo.CurrentRegion.TwoLetterISORegionName;
            AppCenter.SetCountryCode(countryCode);
            Analytics.SetEnabledAsync(true);
            Crashes.SetEnabledAsync(true);
            AppCenter.Start("9a1cf24d-fb85-4707-be9e-44899806bde2",
                   typeof(Analytics), typeof(Crashes));
        }

        private void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            Crashes.TrackError(e.Exception);
            MessageBox.Show((string)Current.Resources["ErrorMsg"], (string)Current.Resources["ErrorMsgT"], MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static event EventHandler LanguageChanged;
        public static CultureInfo Language
        {
            get => System.Threading.Thread.CurrentThread.CurrentUICulture;
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                if (value == System.Threading.Thread.CurrentThread.CurrentUICulture) return;

                //1. Меняем язык приложения:
                System.Threading.Thread.CurrentThread.CurrentUICulture = value;

                //2. Создаём ResourceDictionary для новой культуры
                ResourceDictionary dict = new ResourceDictionary();
                if (Olib.Properties.Settings.Default.FirstLanguage)
                {
                    try
                    {
                        dict.Source = new Uri(string.Format("Local/lang.{0}.xaml", CultureInfo.CurrentCulture.ToString()), UriKind.Relative);
                    }
                    catch
                    {
                        dict.Source = new Uri("Local/lang.xaml", UriKind.Relative);
                    }
                    Olib.Properties.Settings.Default.FirstLanguage = false;
                }
                else
                {
                    try
                    {
                        dict.Source = new Uri(string.Format("Local/lang.{0}.xaml", value.Name), UriKind.Relative);
                    }
                    catch
                    {
                        dict.Source = new Uri("Local/lang.xaml", UriKind.Relative);
                    }
                }

                //3. Находим старую ResourceDictionary и удаляем его и добавляем новую ResourceDictionary
                ResourceDictionary oldDict = (from d in Current.Resources.MergedDictionaries
                                              where d.Source != null && d.Source.OriginalString.StartsWith("Local/lang.")
                                              select d).FirstOrDefault();
                if (oldDict != null)
                {
                    int ind = Current.Resources.MergedDictionaries.IndexOf(oldDict);
                    Current.Resources.MergedDictionaries.Remove(oldDict);
                    Current.Resources.MergedDictionaries.Insert(ind, dict);
                }
                else
                {
                    Current.Resources.MergedDictionaries.Add(dict);
                }

                //4. Вызываем евент для оповещения всех окон.
                LanguageChanged(Current, new EventArgs());
            }
        }
    }
}
