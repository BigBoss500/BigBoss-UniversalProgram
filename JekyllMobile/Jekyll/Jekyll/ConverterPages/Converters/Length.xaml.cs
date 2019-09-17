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
    public partial class Length : ContentView
    {
        public Length()
        {
            InitializeComponent();
        }

        private void MillimetrC(object sender, TextChangedEventArgs e)
        {
            if (Millimetr.IsFocused)
            {
                try
                {
                    float mil = float.Parse(Millimetr.Text);
                    Santimetr.Text = (mil / 10).ToString();
                    Metr.Text = (mil / 1000).ToString();
                    Kilometr.Text = (mil / 1E+6F).ToString();
                    Step.Text = (mil / 800).ToString();
                    Error.Text = null;
                }
                catch (Exception ex)
                {
                    Error.Text = $"Исключение: {ex.Message}";
                }
            }
        }
        private void SantimetrC(object sender, TextChangedEventArgs e)
        {
            if (Santimetr.IsFocused)
            {
                try
                {
                    float s = float.Parse(Santimetr.Text);
                    Millimetr.Text = (s * 10).ToString();
                    Metr.Text = (s / 100).ToString();
                    Kilometr.Text = (s / 1E+5F).ToString();
                    Step.Text = (s / 80).ToString();
                    Error.Text = null;
                }
                catch (Exception ex)
                {
                    Error.Text = $"Исключение: {ex.Message}";
                }
            }
        }
        private void MetrC(object sender, TextChangedEventArgs e)
        {
            if (Metr.IsFocused)
            {
                try
                {
                    float m = float.Parse(Metr.Text);
                    Millimetr.Text = (m * 1000).ToString();
                    Santimetr.Text = (m * 100).ToString();
                    Kilometr.Text = (m / 1000).ToString();
                    Step.Text = (m * 1.25F).ToString();
                    Error.Text = null;
                }
                catch (Exception ex)
                {
                    Error.Text = $"Исключение: {ex.Message}";
                }
            }
        }
        private void KilometrC(object sender, TextChangedEventArgs e)
        {
            if (Kilometr.IsFocused)
            {
                try
                {
                    float k = float.Parse(Kilometr.Text);
                    Millimetr.Text = (k * 1E+6F).ToString();
                    Santimetr.Text = (k * 100000).ToString();
                    Metr.Text = (k * 1000).ToString();
                    Step.Text = (k * 1250).ToString();
                    Error.Text = null;
                }
                catch (Exception ex)
                {
                    Error.Text = $"Исключение: {ex.Message}";
                }
            }
        }
        private void StepC(object sender, TextChangedEventArgs e)
        {
            if (Step.IsFocused)
            {
                try
                {
                    float st = float.Parse(Step.Text);
                    Millimetr.Text = (st * 800).ToString();
                    Santimetr.Text = (st * 80).ToString();
                    Metr.Text = (st / 1.25F).ToString();
                    Kilometr.Text = (st / 1250).ToString();
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