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
    public partial class Mass : ContentView
    {
        public Mass()
        {
            InitializeComponent();
        }

        private void MiligrammC(object sender, TextChangedEventArgs e)
        {
            if (Miligram.IsFocused)
            {
                try
                {
                    float m = float.Parse(Miligram.Text);
                    Gram.Text = (m / 1000).ToString();
                    Kilogram.Text = (m / 1000000).ToString();
                    Tonn.Text = (m / 1000000000).ToString();
                    Error.Text = null;
                }
                catch (Exception ex)
                {
                    Error.Text = $"Исключение: {ex.Message}";
                }
            }
        }
        private void GrammC(object sender, TextChangedEventArgs e)
        {
            if (Gram.IsFocused)
            {
                try
                {
                    float g = float.Parse(Gram.Text);
                    Miligram.Text = (g * 1000).ToString();
                    Kilogram.Text = (g / 1000).ToString();
                    Tonn.Text = (g / 1000000).ToString();
                    Error.Text = null;
                }
                catch (Exception ex)
                {
                    Error.Text = $"Исключение: {ex.Message}";
                }
            }
        }
        private void KilogrammC(object sender, TextChangedEventArgs e)
        {
            if (Kilogram.IsFocused)
            {
                try
                {
                    float k = float.Parse(Kilogram.Text);
                    Miligram.Text = (k * 1000000).ToString();
                    Gram.Text = (k * 1000).ToString();
                    Tonn.Text = (k / 1000).ToString();
                    Error.Text = null;
                }
                catch (Exception ex)
                {
                    Error.Text = $"Исключение: {ex.Message}";
                }
            }
        }
        private void TonnC(object sender, TextChangedEventArgs e)
        {
            if (Tonn.IsFocused)
            {
                try
                {
                    float t = float.Parse(Tonn.Text);
                    Miligram.Text = (t * 1000000000).ToString();
                    Gram.Text = (t * 1000000).ToString();
                    Kilogram.Text = (t * 1000).ToString();
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