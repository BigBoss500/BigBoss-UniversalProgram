using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jekyll.ConverterPages.Converters
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DoublePage : ContentView
    {
        public DoublePage()
        {
            InitializeComponent();
        }

        private void DecimalC(object sender, TextChangedEventArgs e)
        {
            if (Decimal.IsFocused)
            {
                try
                {
                    Double.Text = Convert.ToString(int.Parse(Decimal.Text), 2);
                    Error.Text = null;
                }
                catch (Exception ex)
                {
                    Error.Text = $"Исключение: {ex.Message}";
                }
            }
        }
        private void DoubleC(object sender, TextChangedEventArgs e)
        {
            if (Double.IsFocused)
            {
                try
                {
                    Decimal.Text = Convert.ToInt32(Double.Text, 2).ToString();
                    Error.Text = null;
                }
                catch (Exception ex)
                {
                    Error.Text = $"Исключение: {ex.Message}";
                }
            }
        }
    }
}