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
    public partial class Pressure : ContentView
    {
        public Pressure()
        {
            InitializeComponent();
        }

        private void PaskalC(object sender, TextChangedEventArgs e)
        {
            if (Paskal.IsFocused)
            {
                try
                {
                    float p = float.Parse(Paskal.Text);
                    Bar.Text = (p / 100000).ToString();
                    Atmospfere.Text = (p / 101325).ToString();
                    Torr.Text = (p / 133.322F).ToString();
                    Error.Text = null;
                }
                catch (Exception ex)
                {
                    Error.Text = $"Исключение: {ex.Message}";
                }
            }
        }
        private void BarC(object sender, TextChangedEventArgs e)
        {
            if (Bar.IsFocused)
            {
                try
                {
                    float b = float.Parse(Bar.Text);
                    Paskal.Text = (b * 100000).ToString();
                    Atmospfere.Text = (b / 1.013F).ToString();
                    Torr.Text = (b * 750.062F).ToString();
                    Error.Text = null;
                }
                catch (Exception ex)
                {
                    Error.Text = $"Исключение: {ex.Message}";
                }
            }
        }
        private void AtmospfereC(object sender, TextChangedEventArgs e)
        {
            if (Atmospfere.IsFocused)
            {
                try
                {
                    float a = float.Parse(Atmospfere.Text);
                    Paskal.Text = (a * 101325).ToString();
                    Bar.Text = (a * 1.013F).ToString();
                    Torr.Text = (a * 760).ToString();
                    Error.Text = null;
                }
                catch (Exception ex)
                {
                    Error.Text = $"Исключение: {ex.Message}";
                }
            }
        }
        private void TorrC(object sender, TextChangedEventArgs e)
        {
            if (Torr.IsFocused)
            {
                try
                {
                    float t = float.Parse(Torr.Text);
                    Paskal.Text = (t * 133.322F).ToString();
                    Atmospfere.Text = (t / 760).ToString();
                    Bar.Text = (t / 750.062F).ToString();
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