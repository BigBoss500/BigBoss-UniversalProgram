using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Olib.Windows
{
    /// <summary>
    /// Логика взаимодействия для rouletteFM_Rename.xaml
    /// </summary>
    public partial class rouletteFM_Rename : Window
    {
        public rouletteFM_Rename()
        {
            InitializeComponent();
            SelectItem.Text = Pages.ItemsS.Sourc;
            SelectItem.Focus();
            SelectItem.SelectionStart = SelectItem.Text.Length;
        }

        private void RenameVoid()
        {
            Pages.ItemsS.Sourc = SelectItem.Text;
            Close();
        }
        private void CloseWindow(object sender, EventArgs e) => RenameVoid();

        private void Drag(object sender, MouseButtonEventArgs e) => DragMove();

        private void DoubleAnimation_Completed(object sender, EventArgs e) => RenameVoid();

        private void SelectItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) RenameVoid();
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
