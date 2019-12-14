using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Olib.Windows
{
    /// <summary>
    /// Логика взаимодействия для rouletteFM_Settings.xaml
    /// </summary>
    public partial class rouletteFM_Settings : Window
    {
        public rouletteFM_Settings()
        {
            InitializeComponent();
            Check1.IsChecked = Properties.Settings.Default.CheckBox1;
            Check2.IsChecked = Properties.Settings.Default.CheckBox2;
            Check3.IsChecked = Properties.Settings.Default.CheckBox3;
            SelectTime.Text = Properties.Settings.Default.SelectTime.ToString();
            NumberItems.Text = Properties.Settings.Default.NumberItems.ToString();
        }

        private void Drag(object sender, MouseButtonEventArgs e) => DragMove();

        private void DoubleAnimation_Completed(object sender, EventArgs e)
        {
            Properties.Settings.Default.CheckBox1 = (bool)Check1.IsChecked;
            Properties.Settings.Default.CheckBox2 = (bool)Check2.IsChecked;
            Properties.Settings.Default.CheckBox3 = (bool)Check3.IsChecked;
            Properties.Settings.Default.SelectTime = int.Parse(SelectTime.Text);
            Properties.Settings.Default.NumberItems = int.Parse(NumberItems.Text);
            Properties.Settings.Default.Save();
            Close();
        }

        private void NumberItems_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(NumberItems.Text, "[^0-9]"))
            {
                NumberItems.Text = NumberItems.Text.Remove(NumberItems.Text.Length - 1);
                NumberItems.SelectionStart = NumberItems.Text.Length;
            }
        }

        private void SelectTime_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(SelectTime.Text, "[^0-9]"))
            {
                SelectTime.Text = SelectTime.Text.Remove(SelectTime.Text.Length - 1);
                SelectTime.SelectionStart = SelectTime.Text.Length;
            }
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
            anim1.Completed += DoubleAnimation_Completed;

            Timeline.SetDesiredFrameRate(anim, 60);
            Timeline.SetDesiredFrameRate(anim1, 60);

            BeginAnimation(OpacityProperty, anim);
            ScaleWindow.BeginAnimation(ScaleTransform.ScaleXProperty, anim1);
            ScaleWindow.BeginAnimation(ScaleTransform.ScaleYProperty, anim1);
        }
    }
}
