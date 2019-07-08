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
using System.Text.RegularExpressions;

namespace Jekyll
{
    /// <summary>
    /// Логика взаимодействия для Convert.xaml
    /// </summary>
    public partial class Convert : Page
    {
        public Convert()
        {
            InitializeComponent();

        }
        private void CelcionC(object sender, RoutedEventArgs e)
        {
            float c, f, k;
            try
            {
                c = float.Parse(Celcion.Text);
                f = (c * 9 / 5) + 32;
                k = c + 273.15F;
                Farengate.Text = f.ToString();
                Kelvin.Text = k.ToString();
                Error.Content = "";
            }
            catch (Exception ex)
            {
                Error.Content = $"Исключение: {ex.Message}";
            }
        }
        private void FarengateC(object sender, RoutedEventArgs e)
        {
            float c, f, k;
            try
            {
                f = float.Parse(Farengate.Text);
                c = (f - 32) * 5 / 9;
                k = (f - 32) * 5 / 9 + 273.15F;
                Celcion.Text = c.ToString();
                Kelvin.Text = k.ToString();
                Error.Content = "";
            }
            catch (Exception ex)
            {
                Error.Content = $"Исключение: {ex.Message}";
            }
        }
        private void KelvinC(object sender, RoutedEventArgs e)
        {
            float c, f, k;
            try
            {
                k = float.Parse(Kelvin.Text);
                c = k - 273.15F;
                f = (k - 273.15F) * 9 / 5 + 32;
                Celcion.Text = c.ToString();
                Farengate.Text = f.ToString();
                Error.Content = "";
            }
            catch (Exception ex)
            {
                Error.Content = $"Исключение: {ex.Message}";
            }
        }
        private void MiligrammC(object sender, RoutedEventArgs e)
        {
            float m, g, k, t;
            try
            {
                m = float.Parse(Miligramm.Text);
                g = m / 1000;
                k = m / 1000000;
                t = m / 1000000000;
                Gramm.Text = g.ToString();
                Kilogramm.Text = k.ToString();
                Tonn.Text = t.ToString();
                Error.Content = "";
            }
            catch (Exception ex)
            {
                Error.Content = $"Исключение: {ex.Message}";
            }
        }
        private void GrammC(object sender, RoutedEventArgs e)
        {
            float g, m, k, t;
            try
            {
                g = float.Parse(Gramm.Text);
                m = g * 1000;
                k = g / 1000;
                t = g / 1000000;
                Miligramm.Text = m.ToString();
                Kilogramm.Text = k.ToString();
                Tonn.Text = t.ToString();
                Error.Content = "";
            }
            catch (Exception ex)
            {
                Error.Content = $"Исключение: {ex.Message}";
            }

        }
        private void KilogrammC(object sender, RoutedEventArgs e)
        {
            float k, m, g, t;
            try
            {
                k = float.Parse(Kilogramm.Text);
                m = k * 1000000;
                g = k * 1000;
                t = k / 1000;
                Miligramm.Text = m.ToString();
                Gramm.Text = g.ToString();
                Tonn.Text = t.ToString();
                Error.Content = "";
            }
            catch (Exception ex)
            {
                Error.Content = $"Исключение: {ex.Message}";
            }
        }
        private void TonnC(object sender, RoutedEventArgs e)
        {
            float t, m, g, k;
            try
            {
                t = float.Parse(Tonn.Text);
                m = t * 1000000000;
                g = t * 1000000;
                k = t * 1000;
                Miligramm.Text = m.ToString();
                Gramm.Text = g.ToString();
                Kilogramm.Text = k.ToString();
                Error.Content = "";
            }
            catch (Exception ex)
            {
                Error.Content = $"Исключение: {ex.Message}";
            }
        }

        private void MillimetrC(object sender, RoutedEventArgs e)
        {
            float mil, s, m, k;
            try
            {
                mil = float.Parse(Millimetr.Text);
                s = mil / 10;
                m = mil / 1000;
                k = mil / 1E+6F;
                Santimetr.Text = s.ToString();
                Metr.Text = m.ToString();
                Kilometr.Text = k.ToString();
                Error.Content = "";
            }
            catch (Exception ex)
            {
                Error.Content = $"Исключение: {ex.Message}";
            }
        }
        private void SantimetrC(object sender, RoutedEventArgs e)
        {
            float mil, s, m, k;
            try
            {
                s = float.Parse(Santimetr.Text);
                mil = s * 10;
                m = s / 100;
                k = s / 1E+5F;
                Millimetr.Text = mil.ToString();
                Metr.Text = m.ToString();
                Kilometr.Text = k.ToString();
                Error.Content = "";
            }
            catch (Exception ex)
            {
                Error.Content = $"Исключение: {ex.Message}";
            }
        }
        private void MetrC(object sender, RoutedEventArgs e)
        {
            float mil, s, m, k;
            try
            {
                m = float.Parse(Metr.Text);
                mil = m * 1000;
                s = m * 100;
                k = m / 1000;
                Millimetr.Text = mil.ToString();
                Santimetr.Text = s.ToString();
                Kilometr.Text = k.ToString();
                Error.Content = "";
            }
            catch (Exception ex)
            {
                Error.Content = $"Исключение: {ex.Message}";
            }
        }
        private void KilometrC(object sender, RoutedEventArgs e)
        {
            float mil, s, m, k;
            try
            {
                k = float.Parse(Kilometr.Text);
                mil = k * 1E+6F;
                s = k * 100000;
                m = k * 1000;
                Millimetr.Text = mil.ToString();
                Santimetr.Text = s.ToString();
                Metr.Text = m.ToString();
                Error.Content = "";
            }
            catch (Exception ex)
            {
                Error.Content = $"Исключение: {ex.Message}";
            }
        }

        private void ByteC(object sender, RoutedEventArgs e)
        {
            float b, k, m, g, t, bi, ki, mi, gi, ti;
            try
            {
                b = float.Parse(Byte.Text);
                k = b / 1024;
                m = b / 1048576;
                g = b / 1073741824;
                t = b / 1099511627776;
                bi = b * 8;
                ki = b / 125;
                mi = b / 125000;
                gi = b / 1.25e+8F;
                ti = b / 1.25e+11F;
                KiloByte.Text = k.ToString();
                MegaByte.Text = m.ToString();
                GigaByte.Text = g.ToString();
                TeraByte.Text = t.ToString();
                Bit.Text = bi.ToString();
                KiloBit.Text = ki.ToString();
                MegaBit.Text = mi.ToString();
                GigaBit.Text = g.ToString();
                TeraBit.Text = ti.ToString();
                Error.Content = "";
            }
            catch (Exception ex)
            {
                Error.Content = $"Исключение: {ex.Message}";
            }

        }
        private void KilobyteC(object sender, RoutedEventArgs e)
        {
            float b, k, m, g, t, bi, ki, mi, gi, ti;
            try
            {
                k = float.Parse(KiloByte.Text);
                b = k * 1024;
                m = k / 1024;
                g = k / 1048576;
                t = k / 1073741824;
                bi = k * 8000;
                ki = k * 8;
                mi = k / 125;
                gi = k / 125000;
                ti = k / 1.25e+8F;
                Byte.Text = b.ToString();
                MegaByte.Text = m.ToString();
                GigaByte.Text = g.ToString();
                TeraByte.Text = t.ToString();
                Bit.Text = bi.ToString();
                KiloBit.Text = ki.ToString();
                MegaBit.Text = mi.ToString();
                GigaBit.Text = gi.ToString();
                TeraBit.Text = ti.ToString();
                Error.Content = "";
            }
            catch (Exception ex)
            {
                Error.Content = $"Исключение: {ex.Message}";
            }

        }
        private void MegabyteC(object sender, RoutedEventArgs e)
        {
            float b, k, m, g, t, bi, ki, mi, gi, ti;
            try
            {
                m = float.Parse(MegaByte.Text);
                b = m * 1048576;
                k = m * 1024;
                g = m / 1024;
                t = m / 1048576;
                bi = m * 8e+6F;
                ki = m * 8000;
                mi = m * 8;
                gi = m / 125;
                ti = m / 125000;
                Byte.Text = b.ToString();
                KiloByte.Text = k.ToString();
                GigaByte.Text = g.ToString();
                TeraByte.Text = t.ToString();
                Bit.Text = bi.ToString();
                KiloBit.Text = ki.ToString();
                MegaBit.Text = mi.ToString();
                TeraBit.Text = ti.ToString();
                Error.Content = "";
            }
            catch (Exception ex)
            {
                Error.Content = $"Исключение: {ex.Message}";
            }
        }
        private void GigabyteC(object sender, RoutedEventArgs e)
        {
            float b, k, m, g, t, bi, ki, mi, gi, ti;
            try
            {
                g = float.Parse(GigaByte.Text);
                b = g * 1073741824;
                k = g * 1048576;
                m = g * 1024;
                t = g / 1024;
                bi = g * 8e+9F;
                ki = g * 8e+6F;
                mi = g * 8000;
                gi = g * 8;
                ti = g / 125;
                Byte.Text = b.ToString();
                KiloByte.Text = k.ToString();
                MegaByte.Text = m.ToString();
                TeraByte.Text = t.ToString();
                Bit.Text = bi.ToString();
                KiloBit.Text = ki.ToString();
                MegaBit.Text = mi.ToString();
                GigaBit.Text = gi.ToString();
                TeraBit.Text = ti.ToString();
                Error.Content = "";
            }
            catch (Exception ex)
            {
                Error.Content = $"Исключение: {ex.Message}";
            }
        }
        private void TerabyteC(object sender, RoutedEventArgs e)
        {
            float b, k, m, g, t, bi, ki, mi, gi, ti;
            try
            {
                t = float.Parse(TeraByte.Text);
                b = t * 1099511627776;
                k = t * 1073741824;
                m = t * 1048576;
                g = t * 1024;
                bi = t * 8e+12F;
                ki = t * 8e+9F;
                mi = t * 8e+6F;
                gi = t * 8000;
                ti = t * 8;
                Byte.Text = b.ToString();
                KiloByte.Text = k.ToString();
                MegaByte.Text = m.ToString();
                GigaByte.Text = g.ToString();
                Bit.Text = bi.ToString();
                KiloBit.Text = ki.ToString();
                MegaBit.Text = mi.ToString();
                GigaBit.Text = gi.ToString();
                TeraBit.Text = ti.ToString();
                Error.Content = "";
            }
            catch (Exception ex)
            {
                Error.Content = $"Исключение: {ex.Message}";
            }
        }
    }
}
