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
    public partial class Temperature : ContentView
    {
        public Temperature()
        {
            InitializeComponent();
        }

        private void CelcionC(object sender, TextChangedEventArgs e)
        {
            if (Celcion.IsFocused)
            {
                try
                {
                    float c = float.Parse(Celcion.Text);
                    Farengate.Text = ((c * 9 / 5) + 32).ToString();
                    Kelvin.Text = (c + 273.15F).ToString();
                    Error.Text = null;
                }
                catch (Exception ex)
                {
                    Error.Text = $"Исключение: {ex.Message}";
                }
            }
        }

        private void FarengateC(object sender, TextChangedEventArgs e)
        {
            if (Farengate.IsFocused)
            {
                try
                {
                    float f = float.Parse(Farengate.Text);
                    Celcion.Text = ((f - 32) * 5 / 9).ToString();
                    Kelvin.Text = ((f - 32) * 5 / 9 + 273.15F).ToString();
                    Error.Text = null;
                }
                catch (Exception ex)
                {
                    Error.Text = $"Исключение: {ex.Message}";
                }
            }
        }

        private void KelvinC(object sender, TextChangedEventArgs e)
        {
            if (Kelvin.IsFocused)
            {
                try
                {
                    float k = float.Parse(Kelvin.Text);
                    Celcion.Text = (k - 273.15F).ToString();
                    Farengate.Text = ((k - 273.15F) * 9 / 5 + 32).ToString();
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