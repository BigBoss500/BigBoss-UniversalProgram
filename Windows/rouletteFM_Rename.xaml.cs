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

namespace OlibUpdater.Windows
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
        }

        private void RenameVoid()
        {
            Pages.ItemsS.Sourc = SelectItem.Text;
            Close();
        }

        private void Drag(object sender, MouseButtonEventArgs e) => DragMove();
        private void DoubleAnimation_Completed(object sender, EventArgs e) => RenameVoid();

        private void SelectItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) RenameVoid();
        }
    }
}
