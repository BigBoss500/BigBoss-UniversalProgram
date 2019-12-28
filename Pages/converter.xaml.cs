using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;

namespace Olib.Pages
{
    /// <summary>
    /// Логика взаимодействия для converter.xaml
    /// </summary>
    public partial class converter : Page
    {
        public converter()
        {
            InitializeComponent();
            Currenty();
            Core.Animations.AnimationText(Warning);
        }
        private XDocument doc;
        private void TemperatureC(object sender, TextChangedEventArgs e)
        {
            double c, f, k;
            try
            {
                if (Celcion.IsSelectionActive)
                {
                    c = double.Parse(Celcion.Text);
                    Farengate.Text = ((c * 9 / 5) + 32).ToString();
                    Kelvin.Text = (c + 273.15).ToString();
                }
                else if (Farengate.IsSelectionActive)
                {
                    f = double.Parse(Farengate.Text);
                    Celcion.Text = ((f - 32) * 5 / 9).ToString();
                    Kelvin.Text = ((f - 32) * 5 / 9 + 273.15).ToString();
                }
                else if (Kelvin.IsSelectionActive)
                {
                    k = double.Parse(Kelvin.Text);
                    Celcion.Text = (k - 273.15).ToString();
                    Farengate.Text = ((k - 273.15) * 9 / 5 + 32).ToString();
                }
                Error.Content = null;
            }
            catch (FormatException ex)
            {
                Error.Content = ex.Message;
            }
        }
        private void MassC(object sender, TextChangedEventArgs e)
        {
            double m, g, k, t;
            try
            {
                if (Miligramm.IsSelectionActive)
                {
                    m = double.Parse(Miligramm.Text);
                    Gramm.Text = (m / 1000).ToString();
                    Kilogramm.Text = (m / 1000000).ToString();
                    Tonn.Text = (m / 1000000000).ToString();
                }
                else if (Gramm.IsSelectionActive)
                {
                    g = double.Parse(Gramm.Text);
                    Miligramm.Text = (g * 1000).ToString();
                    Kilogramm.Text = (g / 1000).ToString();
                    Tonn.Text = (g / 1000000).ToString();
                }
                else if (Kilogramm.IsSelectionActive)
                {
                    k = double.Parse(Kilogramm.Text);
                    Miligramm.Text = (k * 1000000).ToString();
                    Gramm.Text = (k * 1000).ToString();
                    Tonn.Text = (k / 1000).ToString();
                }
                else if (Tonn.IsSelectionActive)
                {
                    t = double.Parse(Tonn.Text);
                    Miligramm.Text = (t * 1000000000).ToString();
                    Gramm.Text = (t * 1000000).ToString();
                    Kilogramm.Text = (t * 1000).ToString();
                }
                Error.Content = null;
            }
            catch (Exception ex)
            {
                Error.Content = ex.Message;
            }
        }
        private void LengthC(object sender, TextChangedEventArgs e)
        {
            double mil, s, m, k, st;
            try
            {
                if (Millimetr.IsSelectionActive)
                {
                    mil = double.Parse(Millimetr.Text);
                    Santimetr.Text = (mil / 10).ToString();
                    Metr.Text = (mil / 1000).ToString();
                    Kilometr.Text = (mil / 1E+6).ToString();
                    Step.Text = (mil / 800).ToString();
                }
                else if (Santimetr.IsSelectionActive)
                {
                    s = double.Parse(Santimetr.Text);
                    Millimetr.Text = (s * 10).ToString();
                    Metr.Text = (s / 100).ToString();
                    Kilometr.Text = (s / 1E+5).ToString();
                    Step.Text = (s / 80).ToString();
                }
                else if (Metr.IsSelectionActive)
                {
                    m = double.Parse(Metr.Text);
                    Millimetr.Text = (m * 1000).ToString();
                    Santimetr.Text = (m * 100).ToString();
                    Kilometr.Text = (m / 1000).ToString();
                    Step.Text = (m * 1.25).ToString();
                }
                else if (Kilometr.IsSelectionActive)
                {
                    k = double.Parse(Kilometr.Text);
                    Millimetr.Text = (k * 1E+6).ToString();
                    Santimetr.Text = (k * 100000).ToString();
                    Metr.Text = (k * 1000).ToString();
                    Step.Text = (k * 1250).ToString();
                }
                else if (Step.IsSelectionActive)
                {
                    st = double.Parse(Step.Text);
                    Millimetr.Text = (st * 800).ToString();
                    Santimetr.Text = (st * 80).ToString();
                    Metr.Text = (st / 1.25).ToString();
                    Kilometr.Text = (st / 1250).ToString();

                }
                Error.Content = null;
            }
            catch (Exception ex)
            {
                Error.Content = ex.Message;
            }
        }
        private void DataC(object sender, TextChangedEventArgs e)
        {
            double b, k, m, g, t, bit, ki, mi, gi, ti;
            try
            {
                if (Byte.IsSelectionActive)
                {
                    b = double.Parse(Byte.Text);
                    KiloByte.Text = (b / 1024).ToString();
                    MegaByte.Text = (b / 1048576).ToString();
                    GigaByte.Text = (b / 1073741824).ToString();
                    TeraByte.Text = (b / 1099511627776).ToString();
                    Bit.Text = (b * 8).ToString();
                    KiloBit.Text = (b / 125).ToString();
                    MegaBit.Text = (b / 125000).ToString();
                    GigaBit.Text = (b / 1.25e+8).ToString();
                    TeraBit.Text = (b / 1.25e+11).ToString();
                }
                else if (KiloByte.IsSelectionActive)
                {
                    k = double.Parse(KiloByte.Text);
                    Byte.Text = (k * 1024).ToString();
                    MegaByte.Text = (k / 1024).ToString();
                    GigaByte.Text = (k / 1048576).ToString();
                    TeraByte.Text = (k / 1073741824).ToString();
                    Bit.Text = (k * 8000).ToString();
                    KiloBit.Text = (k * 8).ToString();
                    MegaBit.Text = (k / 125).ToString();
                    GigaBit.Text = (k / 125000).ToString();
                    TeraBit.Text = (k / 1.25e+8).ToString();
                }
                else if (MegaByte.IsSelectionActive)
                {
                    m = double.Parse(MegaByte.Text);
                    Byte.Text = (m * 1048576).ToString();
                    KiloByte.Text = (m * 1024).ToString();
                    GigaByte.Text = (m / 1024).ToString();
                    TeraByte.Text = (m / 1048576).ToString();
                    Bit.Text = (m * 8e+6).ToString();
                    KiloBit.Text = (m * 8000).ToString();
                    MegaBit.Text = (m * 8).ToString();
                    GigaBit.Text = (m / 125).ToString();
                    TeraBit.Text = (m / 125000).ToString();
                }
                else if (GigaByte.IsSelectionActive)
                {
                    g = double.Parse(GigaByte.Text);
                    Byte.Text = (g * 1073741824).ToString();
                    KiloByte.Text = (g * 1048576).ToString();
                    MegaByte.Text = (g * 1024).ToString();
                    TeraByte.Text = (g / 1024).ToString();
                    Bit.Text = (g * 8e+9).ToString();
                    KiloBit.Text = (g * 8e+6).ToString();
                    MegaBit.Text = (g * 8000).ToString();
                    GigaBit.Text = (g * 8).ToString();
                    TeraBit.Text = (g / 125).ToString();
                }
                else if (TeraByte.IsSelectionActive)
                {
                    t = double.Parse(TeraByte.Text);
                    Byte.Text = (t * 1099511627776).ToString();
                    KiloByte.Text = (t * 1073741824).ToString();
                    MegaByte.Text = (t * 1048576).ToString();
                    GigaByte.Text = (t * 1024).ToString();
                    Bit.Text = (t * 8e+12).ToString();
                    KiloBit.Text = (t * 8e+9).ToString();
                    MegaBit.Text = (t * 8e+6).ToString();
                    GigaBit.Text = (t * 8000).ToString();
                    TeraBit.Text = (t * 8).ToString();
                }
                else if (Bit.IsSelectionActive)
                {
                    bit = double.Parse(Bit.Text);
                    Byte.Text = (bit / 8).ToString();
                    KiloByte.Text = (bit / 8000).ToString();
                    MegaByte.Text = (bit / 8000000).ToString();
                    GigaByte.Text = (bit / 8000000000).ToString();
                    TeraByte.Text = (bit / 8000000000000).ToString();
                    KiloBit.Text = (bit / 1000).ToString();
                    MegaBit.Text = (bit / 1000000).ToString();
                    GigaBit.Text = (bit / 1000000000).ToString();
                    TeraBit.Text = (bit / 1000000000000).ToString();
                }
                else if (KiloBit.IsSelectionActive)
                {
                    ki = double.Parse(KiloBit.Text);
                    Byte.Text = (ki * 125).ToString();
                    KiloByte.Text = (ki / 8).ToString();
                    MegaByte.Text = (ki / 8000).ToString();
                    GigaByte.Text = (ki / 8000000).ToString();
                    TeraByte.Text = (ki / 8000000000).ToString();
                    Bit.Text = (ki * 1000).ToString();
                    MegaBit.Text = (ki / 1000).ToString();
                    GigaBit.Text = (ki / 1000000).ToString();
                    TeraBit.Text = (ki / 1000000000).ToString();
                }
                else if (MegaBit.IsSelectionActive)
                {
                    mi = double.Parse(MegaBit.Text);
                    Byte.Text = (mi * 125000).ToString();
                    KiloByte.Text = (mi * 125).ToString();
                    MegaByte.Text = (mi / 8).ToString();
                    GigaByte.Text = (mi / 8000).ToString();
                    TeraByte.Text = (mi / 8000000).ToString();
                    Bit.Text = (mi * 1000000).ToString();
                    KiloBit.Text = (mi * 1000).ToString();
                    GigaBit.Text = (mi / 1000).ToString();
                    TeraBit.Text = (mi / 1000000).ToString();
                }
                else if (GigaBit.IsSelectionActive)
                {
                    gi = double.Parse(GigaBit.Text);
                    Byte.Text = (gi * 125000000).ToString();
                    KiloByte.Text = (gi * 125000).ToString();
                    MegaByte.Text = (gi * 125).ToString();
                    GigaByte.Text = (gi / 8).ToString();
                    TeraByte.Text = (gi / 8000).ToString();
                    Bit.Text = (gi * 1000000000).ToString();
                    KiloBit.Text = (gi * 1000000).ToString();
                    MegaBit.Text = (gi * 1000).ToString();
                    TeraBit.Text = (gi / 1000).ToString();
                }
                else if (TeraBit.IsSelectionActive)
                {
                    ti = double.Parse(TeraBit.Text);
                    Byte.Text = (ti * 125000000000).ToString();
                    KiloByte.Text = (ti * 125000000).ToString();
                    MegaByte.Text = (ti * 125000).ToString();
                    GigaByte.Text = (ti * 125).ToString();
                    TeraByte.Text = (ti / 8).ToString();
                    Bit.Text = (ti * 1000000000000).ToString();
                    KiloBit.Text = (ti * 1000000000).ToString();
                    MegaBit.Text = (ti * 1000000).ToString();
                    GigaBit.Text = (ti * 1000).ToString();

                }
                Error.Content = null;
            }
            catch (Exception ex)
            {
                Error.Content = ex.Message;
            }
        }
        private void PressureC(object sender, TextChangedEventArgs e)
        {
            double p, b, a, t;
            try
            {
                if (Paskal.IsSelectionActive)
                {
                    p = double.Parse(Paskal.Text);
                    Bar.Text = (p / 100000).ToString();
                    Atmospfere.Text = (p / 101325).ToString();
                    Torr.Text = (p / 133.322).ToString();
                }
                else if (Bar.IsSelectionActive)
                {
                    b = double.Parse(Bar.Text);
                    Paskal.Text = (b * 100000).ToString();
                    Atmospfere.Text = (b / 1.013).ToString();
                    Torr.Text = (b * 750.062).ToString();
                }
                else if (Atmospfere.IsSelectionActive)
                {
                    a = double.Parse(Atmospfere.Text);
                    Paskal.Text = (a * 101325).ToString();
                    Bar.Text = (a * 1.013).ToString();
                    Torr.Text = (a * 760).ToString();
                }
                else if (Torr.IsSelectionActive)
                {
                    t = double.Parse(Torr.Text);
                    Paskal.Text = (t * 133.322).ToString();
                    Atmospfere.Text = (t / 760).ToString();
                    Bar.Text = (t / 750.062).ToString();
                }
                Error.Content = null;
            }
            catch (Exception ex)
            {
                Error.Content = ex.Message;
            }
        }
        private void VolumeC(object sender, TextChangedEventArgs e)
        {
            double mi, l, m;
            try
            {
                if (MiliLitre.IsSelectionActive)
                {
                    mi = double.Parse(MiliLitre.Text);
                    Litre.Text = (mi / 1000).ToString();
                    MetrCube.Text = (mi / 1e+6).ToString();
                }
                else if (Litre.IsSelectionActive)
                {
                    l = double.Parse(Litre.Text);
                    MiliLitre.Text = (l * 1000).ToString();
                    MetrCube.Text = (l / 1000).ToString();
                }
                else if (MetrCube.IsSelectionActive)
                {
                    m = double.Parse(MetrCube.Text);
                    MiliLitre.Text = (m * 1e+6).ToString();
                    Litre.Text = (m * 1000).ToString();
                }
                Error.Content = null;
            }
            catch (Exception ex)
            {
                Error.Content = ex.Message;
            }
        }
        private void AreaC(object sender, TextChangedEventArgs e)
        {
            double s, ms, ks, hs, mis;
            try
            {
                if (SantimetrSquare.IsSelectionActive)
                {
                    s = double.Parse(SantimetrSquare.Text);
                    MetrSquare.Text = (s / 10000).ToString();
                    KilometrSquare.Text = (s / 1e+10).ToString();
                    HarSquare.Text = (s / 1e+8).ToString();
                    MileSquare.Text = (s / 2.59e+10).ToString();
                }
                else if (MetrSquare.IsSelectionActive)
                {
                    ms = double.Parse(MetrSquare.Text);
                    SantimetrSquare.Text = (ms * 10000).ToString();
                    KilometrSquare.Text = (ms / 1e+6).ToString();
                    HarSquare.Text = (ms / 10000).ToString();
                    MileSquare.Text = (ms / 2.59e+6).ToString();
                }
                else if (KilometrSquare.IsSelectionActive)
                {
                    ks = double.Parse(KilometrSquare.Text);
                    SantimetrSquare.Text = (ks * 1e+10).ToString();
                    MetrSquare.Text = (ks * 1e+6).ToString();
                    HarSquare.Text = (ks * 100).ToString();
                    MileSquare.Text = (ks / 2.59).ToString();
                }
                else if (HarSquare.IsSelectionActive)
                {
                    hs = double.Parse(HarSquare.Text);
                    SantimetrSquare.Text = (hs * 1e+8).ToString();
                    MetrSquare.Text = (hs * 10000).ToString();
                    KilometrSquare.Text = (hs / 100).ToString();
                    MileSquare.Text = (hs / 258.999).ToString();
                }
                else if (MileSquare.IsSelectionActive)
                {
                    mis = double.Parse(MileSquare.Text);
                    SantimetrSquare.Text = (mis * 2.59e+10).ToString();
                    MetrSquare.Text = (mis * 2.59e+6).ToString();
                    KilometrSquare.Text = (mis * 2.59).ToString();
                    HarSquare.Text = (mis * 258.999).ToString();
                }
                Error.Content = null;
            }
            catch (Exception ex)
            {
                Error.Content = ex.Message;
            }
        }
        private void BinaryC(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (Decimal.IsSelectionActive)
                {
                    Double.Text = Convert.ToString(int.Parse(Decimal.Text), 2);
                }
                else if (Double.IsSelectionActive)
                {
                    Decimal.Text = Convert.ToInt32(Double.Text, 2).ToString();
                }
                Error.Content = null;
            }
            catch (Exception ex)
            {
                Error.Content = ex.Message;
            }
        }


        private async void Currenty()
        {
            try
            {
                await Task.Run(() => doc = XDocument.Load((string)Application.Current.Resources["SiteCur"]));
                Curr1.SelectedValuePath = "Key";
                Curr1.DisplayMemberPath = "Value";
                Curr2.SelectedValuePath = "Key";
                Curr2.DisplayMemberPath = "Value";
                var q = from x in doc.Element("ValCurs").Elements("Valute") select new { V = double.Parse(x.Element("Value").Value) / double.Parse(x.Element("Nominal").Value), Name = x.Element("Name").Value };
                var query = q.AsEnumerable().Select(i => new KeyValuePair<double, string>(i.V, i.Name)).ToList();
                query.Insert(0, new KeyValuePair<double, string>(1, (string)Application.Current.Resources["Ruble"]));
                foreach (var i in query)
                {
                    Curr1.Items.Add(i);
                    Curr2.Items.Add(i);
                }
                Error.Content = null;
            }
            catch (Exception ex)
            {
                Error.Content = ex.Message;
            }
        }
        private void CurrC(object sender, EventArgs e)
        {
            try
            {
                Res.Content = (double.Parse(Curr1.SelectedValue.ToString()) / double.Parse(Curr2.SelectedValue.ToString()) * double.Parse(Number.Text) + " " + Curr2.Text).ToString();
                Error.Content = null;
            }
            catch (Exception ex)
            {
                Error.Content = ex.Message;
            }
        }
    }
}