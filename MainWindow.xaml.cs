using Microsoft.AppCenter.Analytics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;

namespace Olib
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();

        private bool OpenSideBar = false;
        private bool mRestoreForDragMove;
        private bool IsRestart = false;
        private bool IsLangRestart = false;
        private void Drag(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (ResizeMode != ResizeMode.CanResize &&
                    ResizeMode != ResizeMode.CanResizeWithGrip)
                {
                    return;
                }
                if (WindowState == WindowState.Maximized) 
                {
                    MaxHeight = double.PositiveInfinity;
                    MaxWidth = double.PositiveInfinity;
                    WindowGrid.Margin = new Thickness(0);
                    WindowState = WindowState.Normal;
                }
                else
                {
                    MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
                    MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
                    WindowGrid.Margin = new Thickness(5);
                    WindowState = WindowState.Maximized;
                }
            }
            else
            {
                MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
                MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
                mRestoreForDragMove = WindowState == WindowState.Maximized;
                
                DragMove();
            }
        }
        private void mainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (WindowState != WindowState.Normal)
            {
                WindowGrid.Margin = new Thickness(5);
            }
        }
        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (mRestoreForDragMove)
            {
                mRestoreForDragMove = false;

                Point point = PointToScreen(e.MouseDevice.GetPosition(this));

                Left = point.X * 0.5;
                Top = point.Y - 15;

                MaxHeight = double.PositiveInfinity;
                MaxWidth = double.PositiveInfinity;
                WindowGrid.Margin = new Thickness(0);
                WindowState = WindowState.Normal;
                try
                {
                    DragMove();
                }
                catch { };
            }
        }
        private void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e) => mRestoreForDragMove = false;

        private void Full(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                FullMenu.Header = Application.Current.Resources["Expand"];
                MaxHeight = double.PositiveInfinity;
                MaxWidth = double.PositiveInfinity;
                WindowGrid.Margin = new Thickness(0);
                WindowState = WindowState.Normal;
            }
            else
            {
                FullMenu.Header = Application.Current.Resources["Restore"];
                MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
                MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
                WindowGrid.Margin = new Thickness(5);
                WindowState = WindowState.Maximized;
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            if (frame.NavigationService.CanGoBack)
                frame.NavigationService.GoBack();
        }

        private void Navigated(object sender, NavigationEventArgs e)
        {
            textHeader.Content = ((Page)e.Content).Title;
            DoubleAnimation anim = new DoubleAnimation
            {
                Duration = TimeSpan.FromSeconds(0.5),
                DecelerationRatio = 1,
                From = 0,
                To = 1,
            };
            DoubleAnimation anim1 = new DoubleAnimation
            {
                Duration = TimeSpan.FromSeconds(0.5),
                DecelerationRatio = 1,
                From = 0.8,
                To = 1,
            };

            Timeline.SetDesiredFrameRate(anim, 60);
            Timeline.SetDesiredFrameRate(anim1, 60);

            frame.BeginAnimation(OpacityProperty, anim);
            frameScale.BeginAnimation(ScaleTransform.ScaleXProperty, anim1);
            frameScale.BeginAnimation(ScaleTransform.ScaleYProperty, anim1);
        }
        private void Close(object sender, EventArgs e) => Application.Current.Shutdown();

        private void Hide(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;

        private void SideBar(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.ClickOlib += 1;
            Properties.Settings.Default.Save();
            HidenSideBar();
        }

        private void HidenSideBar()
        {
            GlobalButton.IsEnabled = false;
            DoubleAnimation anim = new DoubleAnimation();
            DoubleAnimation anim1 = new DoubleAnimation();
            anim.Duration = TimeSpan.FromSeconds(0.5);
            anim1.Duration = TimeSpan.FromSeconds(0.5);
            anim.DecelerationRatio = 1;
            anim1.DecelerationRatio = 1;
            if (!OpenSideBar)
            {
                anim.To = 260;
                anim1.To = 0.5;
                anim1.Completed += (s, e) => GlobalButton.IsEnabled = true;
                borderHide.Visibility = Visibility.Visible;
                sideBar.Visibility = Visibility.Visible;
                borderHide.IsEnabled = true;
                Author.Text = Core.EasterEggs.Author;
            }
            else
            {
                anim.To = 0;
                anim1.To = 0;
                anim1.Completed += (s, e) =>
                {
                    borderHide.Visibility = Visibility.Collapsed;
                    sideBar.Visibility = Visibility.Collapsed;
                    GlobalButton.IsEnabled = true;
                };
                borderHide.IsEnabled = false;
            }
            Timeline.SetDesiredFrameRate(anim, 60);
            Timeline.SetDesiredFrameRate(anim1, 60);
            sideBar.BeginAnimation(WidthProperty, anim);
            borderHide.BeginAnimation(OpacityProperty, anim1);
            OpenSideBar = !OpenSideBar;
        }
        private void ClickHideBorder(object sender, MouseButtonEventArgs e) => HidenSideBar();

        private void Autoclicker(object sender, RoutedEventArgs e)
        {
            new Windows.autoclicker().Show();
            HidenSideBar();
            Analytics.TrackEvent("Активирована одна из функции в программе", new Dictionary<string, string> {
                { "Категория", "Функция" },
                { "Название", "Autoclicker"}
            });
        }

        private void MainPage(object sender, RoutedEventArgs e)
        {
            _ = frame.NavigationService.Navigate(new Uri("Pages/main.xaml", UriKind.Relative));
            HidenSideBar();
            Analytics.TrackEvent("Осуществлён переход на главную страницу", new Dictionary<string, string> {
                { "Категория", "Функция" },
                { "Название", "Главная страница"}
            });
        }

        private void DataParser(object sender, RoutedEventArgs e)
        {
            _ = frame.NavigationService.Navigate(new Uri("Pages/dataParser.xaml", UriKind.Relative));
            HidenSideBar();
            Analytics.TrackEvent("Активирована одна из функции в программе", new Dictionary<string, string> {
                { "Категория", "Функция" },
                { "Название", "DataParser"}
            });
        }

        private void Roulette(object sender, RoutedEventArgs e)
        {
            _ = frame.NavigationService.Navigate(new Uri("Pages/roulette.xaml", UriKind.Relative));
            HidenSideBar();
            Analytics.TrackEvent("Активирована одна из функции в программе", new Dictionary<string, string> {
                { "Категория", "Функция" },
                { "Название", "Рулетка"}
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _ = frame.NavigationService.Navigate(new Uri("Pages/converter.xaml", UriKind.Relative));
            HidenSideBar();
            Analytics.TrackEvent("Активирована одна из функции в программе", new Dictionary<string, string> {
                { "Категория", "Функция" },
                { "Название", "Конвертер"}
            });
        }

        private async void mainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            cbThemes.SelectedValuePath = "Key";
            cbThemes.DisplayMemberPath = "Value";
            KeyValuePair<string, string>[] valuePair = new[]
            {
                new KeyValuePair<string, string>("Light", (string)Application.Current.Resources["Light"]),
                new KeyValuePair<string, string>("Dark", (string)Application.Current.Resources["Dark"]),
                new KeyValuePair<string, string>("SeaFoam", (string)Application.Current.Resources["SeaFoam"]),
                new KeyValuePair<string, string>("Bloody", (string)Application.Current.Resources["Bloody"]),
                new KeyValuePair<string, string>("Aurora", (string)Application.Current.Resources["Aurora"]),
                new KeyValuePair<string, string>("Legacy", (string)Application.Current.Resources["Legacy"])
            };
            foreach (KeyValuePair<string, string> i in valuePair)
            {
                cbThemes.Items.Add(i);
            }
            cbThemes.SelectedIndex = valuePair.ToList().FindIndex(i => i.Key == Properties.Settings.Default.NameTheme);

            cbLang.SelectedValuePath = "Key";
            cbLang.DisplayMemberPath = "Value";
            KeyValuePair<string, string>[] valuePair1 = new[]
            {
                new KeyValuePair<string, string>("en-US", "English"),
                new KeyValuePair<string, string>("ru-RU", "Русский"),
                new KeyValuePair<string, string>("uk-UA", "Український"),
                new KeyValuePair<string, string>("de-DE", "Deutsch"),
                new KeyValuePair<string, string>("fr-FR", "Français"),
                new KeyValuePair<string, string>("hy-AM", "Հայերեն")
            };
            foreach (KeyValuePair<string, string> i in valuePair1)
            {
                cbLang.Items.Add(i);
            }
            cbLang.SelectedIndex = valuePair1.ToList().FindIndex(i => i.Key == Properties.Settings.Default.DefaultLanguage.Name);

            Version.Text += " " + Assembly.GetEntryAssembly().GetName().Version.ToString();
            await Core.Update.CheckUpdate(ButtUpdate);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation anim = new DoubleAnimation
            {
                Duration = TimeSpan.FromSeconds(0.2),
                From = 1,
                To = 0,
            };
            DoubleAnimation anim1 = new DoubleAnimation
            {
                Duration = TimeSpan.FromSeconds(0.2),
                DecelerationRatio = 1,
                From = 1,
                To = 0.8,
            };
            anim1.Completed += Close;

            Timeline.SetDesiredFrameRate(anim, 60);
            Timeline.SetDesiredFrameRate(anim1, 60);

            BeginAnimation(OpacityProperty, anim);
            ScaleWindow.BeginAnimation(ScaleTransform.ScaleXProperty, anim1);
            ScaleWindow.BeginAnimation(ScaleTransform.ScaleYProperty, anim1);

        }

        private void DarkChat(object sender, RoutedEventArgs e)
        {
            _ = frame.NavigationService.Navigate(new Uri("Pages/darkChat.xaml", UriKind.Relative));
            HidenSideBar();
            Analytics.TrackEvent("Активирована одна из функции в программе", new Dictionary<string, string> {
                { "Категория", "Функция" },
                { "Название", "DarkChat"}
            });
        }

        private void mainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (textHeader.Content.ToString() == "Dark Chat")
            {
                _ = frame.NavigationService.Navigate(new Uri("Pages/main.xaml", UriKind.Relative));
            }
        }

        private void LinkVK(object sender, RoutedEventArgs e) => Process.Start("https://vk.com/olib_app");

        private void LinkGitHub(object sender, RoutedEventArgs e) => Process.Start("https://github.com/BigBoss500/Olib");

        private void cbThemes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Properties.Settings.Default.NameTheme = cbThemes.SelectedValue.ToString();
            Properties.Settings.Default.Save();
            Application.Current.Resources.MergedDictionaries[0].Source = new Uri($"/Themes/{Properties.Settings.Default.NameTheme}.xaml", UriKind.Relative);
            Analytics.TrackEvent($"Изменение темы на: {cbThemes.SelectedValue.ToString()}", new Dictionary<string, string> {
                { "Категория", "Остальное" },
                { "Название", "Тема оформления"}
            });
            if (IsRestart)
            {
                if (MessageBox.Show((string)Application.Current.Resources["Message"], (string)Application.Current.Resources["TitleMessage"], MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    Process.Start(Application.ResourceAssembly.Location);
                    Application.Current.Shutdown();
                }
            }
            IsRestart = true;
        }

        private void cbLang_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IsLangRestart)
            {
                Properties.Settings.Default.DefaultLanguage = new CultureInfo(cbLang.SelectedValue.ToString());
                Properties.Settings.Default.Save();

                Process.Start(Application.ResourceAssembly.Location);
                Application.Current.Shutdown();
            }
            IsLangRestart = true;
        }

        private void Mathematik(object sender, RoutedEventArgs e)
        {
            _ = frame.NavigationService.Navigate(new Uri("Pages/mathematik.xaml", UriKind.Relative));
            HidenSideBar();
            Analytics.TrackEvent("Активирована одна из функции в программе", new Dictionary<string, string> {
                { "Категория", "Функция" },
                { "Название", "Математика"}
            });
        }

        private void Acknowledgments(object sender, RoutedEventArgs e)
        {
            _ = frame.NavigationService.Navigate(new Uri("Pages/acknowledgments.xaml", UriKind.Relative));
            HidenSideBar();
        }
    }
}
