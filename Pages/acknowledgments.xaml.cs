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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Olib.Pages
{
    /// <summary>
    /// Логика взаимодействия для acknowledgments.xaml
    /// </summary>
    public partial class acknowledgments : Page
    {
        public acknowledgments()
        {
            InitializeComponent();
            ClicksOlib.Content = $"{(string)Application.Current.Resources["ClickOlib"]} {Properties.Settings.Default.ClickOlib.ToString()}";
            Properties.Settings.Default.PropertyChanged += (s,e) => ClicksOlib.Content = $"{(string)Application.Current.Resources["ClickOlib"]} {Properties.Settings.Default.ClickOlib.ToString()}";
        }
    }
}
