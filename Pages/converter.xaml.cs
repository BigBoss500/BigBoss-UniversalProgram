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
        #region Temperature
        private void CelcionC(object sender, TextChangedEventArgs e)
        {
            if (Celcion.IsSelectionActive)
            {
                try
                {
                    double c = double.Parse(Celcion.Text);
                    Farengate.Text = ((c * 9 / 5) + 32).ToString();
                    Kelvin.Text = (c + 273.15).ToString();
                    Error.Content = null;
                }
                catch (FormatException ex)
                {
                    Error.Content = ex.Message;
                }
            }
        }
        private void FarengateC(object sender, TextChangedEventArgs e)
        {
            if (Farengate.IsSelectionActive)
            {
                try
                {
                    double f = double.Parse(Farengate.Text);
                    Celcion.Text = ((f - 32) * 5 / 9).ToString();
                    Kelvin.Text = ((f - 32) * 5 / 9 + 273.15).ToString();
                    Error.Content = null;
                }
                catch (FormatException ex)
                {
                    Error.Content = ex.Message;
                }
            }
        }
        private void KelvinC(object sender, TextChangedEventArgs e)
        {
            if (Kelvin.IsSelectionActive)
            {
                try
                {
                    double k = double.Parse(Kelvin.Text);
                    Celcion.Text = (k - 273.15).ToString();
                    Farengate.Text = ((k - 273.15) * 9 / 5 + 32).ToString();
                    Error.Content = null;
                }
                catch (FormatException ex)
                {
                    Error.Content = ex.Message;
                }
            }
        }
        #endregion
        #region Mass
        private void MiligrammC(object sender, TextChangedEventArgs e)
        {
            if (Miligramm.IsSelectionActive)
            {
                try
                {
                    double m = double.Parse(Miligramm.Text);
                    Gramm.Text = (m / 1000).ToString();
                    Kilogramm.Text = (m / 1000000).ToString();
                    Tonn.Text = (m / 1000000000).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = ex.Message;
                }
            }
        }
        private void GrammC(object sender, TextChangedEventArgs e)
        {
            if (Gramm.IsSelectionActive)
            {
                try
                {
                    double g = double.Parse(Gramm.Text);
                    Miligramm.Text = (g * 1000).ToString();
                    Kilogramm.Text = (g / 1000).ToString();
                    Tonn.Text = (g / 1000000).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = ex.Message;
                }
            }
        }
        private void KilogrammC(object sender, TextChangedEventArgs e)
        {
            if (Kilogramm.IsSelectionActive)
            {
                try
                {
                    double k = double.Parse(Kilogramm.Text);
                    Miligramm.Text = (k * 1000000).ToString();
                    Gramm.Text = (k * 1000).ToString();
                    Tonn.Text = (k / 1000).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = ex.Message;
                }
            }
        }
        private void TonnC(object sender, TextChangedEventArgs e)
        {
            if (Tonn.IsSelectionActive)
            {
                try
                {
                    double t = double.Parse(Tonn.Text);
                    Miligramm.Text = (t * 1000000000).ToString();
                    Gramm.Text = (t * 1000000).ToString();
                    Kilogramm.Text = (t * 1000).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = ex.Message;
                }
            }
        }
        #endregion
        #region Length
        private void MillimetrC(object sender, TextChangedEventArgs e)
        {
            if (Millimetr.IsSelectionActive)
            {
                try
                {
                    double mil = double.Parse(Millimetr.Text);
                    Santimetr.Text = (mil / 10).ToString();
                    Metr.Text = (mil / 1000).ToString();
                    Kilometr.Text = (mil / 1E+6).ToString();
                    Step.Text = (mil / 800).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = ex.Message;
                }
            }
        }
        private void SantimetrC(object sender, TextChangedEventArgs e)
        {
            if (Santimetr.IsSelectionActive)
            {
                try
                {
                    double s = double.Parse(Santimetr.Text);
                    Millimetr.Text = (s * 10).ToString();
                    Metr.Text = (s / 100).ToString();
                    Kilometr.Text = (s / 1E+5).ToString();
                    Step.Text = (s / 80).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = ex.Message;
                }
            }
        }
        private void MetrC(object sender, TextChangedEventArgs e)
        {
            if (Metr.IsSelectionActive)
            {
                try
                {
                    double m = double.Parse(Metr.Text);
                    Millimetr.Text = (m * 1000).ToString();
                    Santimetr.Text = (m * 100).ToString();
                    Kilometr.Text = (m / 1000).ToString();
                    Step.Text = (m * 1.25).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = ex.Message;
                }
            }
        }
        private void KilometrC(object sender, TextChangedEventArgs e)
        {
            if (Kilometr.IsSelectionActive)
            {
                try
                {
                    double k = double.Parse(Kilometr.Text);
                    Millimetr.Text = (k * 1E+6).ToString();
                    Santimetr.Text = (k * 100000).ToString();
                    Metr.Text = (k * 1000).ToString();
                    Step.Text = (k * 1250).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = ex.Message;
                }
            }
        }
        private void StepC(object sender, TextChangedEventArgs e)
        {
            if (Step.IsSelectionActive)
            {
                try
                {
                    double st = double.Parse(Step.Text);
                    Millimetr.Text = (st * 800).ToString();
                    Santimetr.Text = (st * 80).ToString();
                    Metr.Text = (st / 1.25).ToString();
                    Kilometr.Text = (st / 1250).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = ex.Message;
                }
            }
        }
        #endregion
        #region Data
        private void ByteC(object sender, TextChangedEventArgs e)
        {
            if (Byte.IsSelectionActive)
            {
                try
                {
                    double b = double.Parse(Byte.Text);
                    KiloByte.Text = (b / 1024).ToString();
                    MegaByte.Text = (b / 1048576).ToString();
                    GigaByte.Text = (b / 1073741824).ToString();
                    TeraByte.Text = (b / 1099511627776).ToString();
                    Bit.Text = (b * 8).ToString();
                    KiloBit.Text = (b / 125).ToString();
                    MegaBit.Text = (b / 125000).ToString();
                    GigaBit.Text = (b / 1.25e+8).ToString();
                    TeraBit.Text = (b / 1.25e+11).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = ex.Message;
                }
            }
        }
        private void KilobyteC(object sender, TextChangedEventArgs e)
        {
            if (KiloByte.IsSelectionActive)
            {
                try
                {
                    double k = double.Parse(KiloByte.Text);
                    Byte.Text = (k * 1024).ToString();
                    MegaByte.Text = (k / 1024).ToString();
                    GigaByte.Text = (k / 1048576).ToString();
                    TeraByte.Text = (k / 1073741824).ToString();
                    Bit.Text = (k * 8000).ToString();
                    KiloBit.Text = (k * 8).ToString();
                    MegaBit.Text = (k / 125).ToString();
                    GigaBit.Text = (k / 125000).ToString();
                    TeraBit.Text = (k / 1.25e+8).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = ex.Message;
                }
            }
        }
        private void MegabyteC(object sender, TextChangedEventArgs e)
        {
            if (MegaByte.IsSelectionActive)
            {
                try
                {
                    double m = double.Parse(MegaByte.Text);
                    Byte.Text = (m * 1048576).ToString();
                    KiloByte.Text = (m * 1024).ToString();
                    GigaByte.Text = (m / 1024).ToString();
                    TeraByte.Text = (m / 1048576).ToString();
                    Bit.Text = (m * 8e+6).ToString();
                    KiloBit.Text = (m * 8000).ToString();
                    MegaBit.Text = (m * 8).ToString();
                    GigaBit.Text = (m / 125).ToString();
                    TeraBit.Text = (m / 125000).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = ex.Message;
                }
            }
        }
        private void GigabyteC(object sender, TextChangedEventArgs e)
        {
            if (GigaByte.IsSelectionActive)
            {
                try
                {
                    double g = double.Parse(GigaByte.Text);
                    Byte.Text = (g * 1073741824).ToString();
                    KiloByte.Text = (g * 1048576).ToString();
                    MegaByte.Text = (g * 1024).ToString();
                    TeraByte.Text = (g / 1024).ToString();
                    Bit.Text = (g * 8e+9).ToString();
                    KiloBit.Text = (g * 8e+6).ToString();
                    MegaBit.Text = (g * 8000).ToString();
                    GigaBit.Text = (g * 8).ToString();
                    TeraBit.Text = (g / 125).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = ex.Message;
                }
            }
        }
        private void TerabyteC(object sender, TextChangedEventArgs e)
        {
            if (TeraByte.IsSelectionActive)
            {
                try
                {
                    double t = double.Parse(TeraByte.Text);
                    Byte.Text = (t * 1099511627776).ToString();
                    KiloByte.Text = (t * 1073741824).ToString();
                    MegaByte.Text = (t * 1048576).ToString();
                    GigaByte.Text = (t * 1024).ToString();
                    Bit.Text = (t * 8e+12).ToString();
                    KiloBit.Text = (t * 8e+9).ToString();
                    MegaBit.Text = (t * 8e+6).ToString();
                    GigaBit.Text = (t * 8000).ToString();
                    TeraBit.Text = (t * 8).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = ex.Message;
                }
            }
        }
        private void BitC(object sender, TextChangedEventArgs e)
        {
            if (Bit.IsSelectionActive)
            {
                try
                {
                    double bit = double.Parse(Bit.Text);
                    Byte.Text = (bit / 8).ToString();
                    KiloByte.Text = (bit / 8000).ToString();
                    MegaByte.Text = (bit / 8000000).ToString();
                    GigaByte.Text = (bit / 8000000000).ToString();
                    TeraByte.Text = (bit / 8000000000000).ToString();
                    KiloBit.Text = (bit / 1000).ToString();
                    MegaBit.Text = (bit / 1000000).ToString();
                    GigaBit.Text = (bit / 1000000000).ToString();
                    TeraBit.Text = (bit / 1000000000000).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = ex.Message;
                }
            }
        }
        private void KilobitC(object sender, TextChangedEventArgs e)
        {
            if (KiloBit.IsSelectionActive)
            {
                try
                {
                    double ki = double.Parse(KiloBit.Text);
                    Byte.Text = (ki * 125).ToString();
                    KiloByte.Text = (ki / 8).ToString();
                    MegaByte.Text = (ki / 8000).ToString();
                    GigaByte.Text = (ki / 8000000).ToString();
                    TeraByte.Text = (ki / 8000000000).ToString();
                    Bit.Text = (ki * 1000).ToString();
                    MegaBit.Text = (ki / 1000).ToString();
                    GigaBit.Text = (ki / 1000000).ToString();
                    TeraBit.Text = (ki / 1000000000).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = ex.Message;
                }
            }
        }
        private void MegabitC(object sender, TextChangedEventArgs e)
        {
            if (MegaBit.IsSelectionActive)
            {
                try
                {
                    double mi = double.Parse(MegaBit.Text);
                    Byte.Text = (mi * 125000).ToString();
                    KiloByte.Text = (mi * 125).ToString();
                    MegaByte.Text = (mi / 8).ToString();
                    GigaByte.Text = (mi / 8000).ToString();
                    TeraByte.Text = (mi / 8000000).ToString();
                    Bit.Text = (mi * 1000000).ToString();
                    KiloBit.Text = (mi * 1000).ToString();
                    GigaBit.Text = (mi / 1000).ToString();
                    TeraBit.Text = (mi / 1000000).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = ex.Message;
                }
            }
        }
        private void GigabitC(object sender, TextChangedEventArgs e)
        {
            if (GigaBit.IsSelectionActive)
            {
                try
                {
                    double gi = double.Parse(GigaBit.Text);
                    Byte.Text = (gi * 125000000).ToString();
                    KiloByte.Text = (gi * 125000).ToString();
                    MegaByte.Text = (gi * 125).ToString();
                    GigaByte.Text = (gi / 8).ToString();
                    TeraByte.Text = (gi / 8000).ToString();
                    Bit.Text = (gi * 1000000000).ToString();
                    KiloBit.Text = (gi * 1000000).ToString();
                    MegaBit.Text = (gi * 1000).ToString();
                    TeraBit.Text = (gi / 1000).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = ex.Message;
                }
            }
        }
        private void TerabitC(object sender, TextChangedEventArgs e)
        {
            if (TeraBit.IsSelectionActive)
            {
                try
                {
                    double ti = double.Parse(TeraBit.Text);
                    Byte.Text = (ti * 125000000000).ToString();
                    KiloByte.Text = (ti * 125000000).ToString();
                    MegaByte.Text = (ti * 125000).ToString();
                    GigaByte.Text = (ti * 125).ToString();
                    TeraByte.Text = (ti / 8).ToString();
                    Bit.Text = (ti * 1000000000000).ToString();
                    KiloBit.Text = (ti * 1000000000).ToString();
                    MegaBit.Text = (ti * 1000000).ToString();
                    GigaBit.Text = (ti * 1000).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = ex.Message;
                }
            }
        }
        #endregion
        #region Pressure
        private void PaskalC(object sender, TextChangedEventArgs e)
        {
            if (Paskal.IsSelectionActive)
            {
                try
                {
                    double p = double.Parse(Paskal.Text);
                    Bar.Text = (p / 100000).ToString();
                    Atmospfere.Text = (p / 101325).ToString();
                    Torr.Text = (p / 133.322).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = ex.Message;
                }
            }
        }
        private void BarC(object sender, TextChangedEventArgs e)
        {
            if (Bar.IsSelectionActive)
            {
                try
                {
                    double b = double.Parse(Bar.Text);
                    Paskal.Text = (b * 100000).ToString();
                    Atmospfere.Text = (b / 1.013).ToString();
                    Torr.Text = (b * 750.062).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = ex.Message;
                }
            }
        }
        private void AtmospfereC(object sender, TextChangedEventArgs e)
        {
            if (Atmospfere.IsSelectionActive)
            {
                try
                {
                    double a = double.Parse(Atmospfere.Text);
                    Paskal.Text = (a * 101325).ToString();
                    Bar.Text = (a * 1.013).ToString();
                    Torr.Text = (a * 760).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = ex.Message;
                }
            }
        }
        private void TorrC(object sender, TextChangedEventArgs e)
        {
            if (Torr.IsSelectionActive)
            {
                try
                {
                    double t = double.Parse(Torr.Text);
                    Paskal.Text = (t * 133.322).ToString();
                    Atmospfere.Text = (t / 760).ToString();
                    Bar.Text = (t / 750.062).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = ex.Message;
                }
            }
        }
        #endregion
        #region Volume
        private void MililitreC(object sender, TextChangedEventArgs e)
        {
            if (MiliLitre.IsSelectionActive)
            {
                try
                {
                    double m = double.Parse(MiliLitre.Text);
                    Litre.Text = (m / 1000).ToString();
                    MetrCube.Text = (m / 1e+6).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = ex.Message;
                }
            }
        }
        private void LitreC(object sender, TextChangedEventArgs e)
        {
            if (Litre.IsSelectionActive)
            {
                try
                {
                    double l = double.Parse(Litre.Text);
                    MiliLitre.Text = (l * 1000).ToString();
                    MetrCube.Text = (l / 1000).ToString();
                    Error.Content = null;

                }
                catch (Exception ex)
                {
                    Error.Content = ex.Message;
                }
            }
        }
        private void MetrCubeC(object sender, TextChangedEventArgs e)
        {
            if (MetrCube.IsSelectionActive)
            {
                try
                {
                    double m = double.Parse(MetrCube.Text);
                    MiliLitre.Text = (m * 1e+6).ToString();
                    Litre.Text = (m * 1000).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = ex.Message;
                }
            }
        }
        #endregion
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

        private void CurrConvert()
        {
            try
            {
                Res.Content = Convert.ToString(double.Parse(Curr1.SelectedValue.ToString()) / double.Parse(Curr2.SelectedValue.ToString()) * double.Parse(Number.Text) + " " + Curr2.Text);
                Error.Content = null;
            }
            catch (Exception ex)
            {
                Error.Content = ex.Message;
            }
        }

        private void Number_TextChanged(object sender, TextChangedEventArgs e) => CurrConvert();
        private void Curr1_SelectionChanged(object sender, SelectionChangedEventArgs e) => CurrConvert();
        private void Curr2_SelectionChanged(object sender, SelectionChangedEventArgs e) => CurrConvert();
        #region Area
        private void SantimetrSquareC(object sender, TextChangedEventArgs e)
        {
            if (SantimetrSquare.IsSelectionActive)
            {
                try
                {
                    double s = double.Parse(SantimetrSquare.Text);
                    MetrSquare.Text = (s / 10000).ToString();
                    KilometrSquare.Text = (s / 1e+10).ToString();
                    HarSquare.Text = (s / 1e+8).ToString();
                    MileSquare.Text = (s / 2.59e+10).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = ex.Message;
                }
            }
        }
        private void MetrSquareC(object sender, TextChangedEventArgs e)
        {
            if (MetrSquare.IsSelectionActive)
            {
                try
                {
                    double s = double.Parse(MetrSquare.Text);
                    SantimetrSquare.Text = (s * 10000).ToString();
                    KilometrSquare.Text = (s / 1e+6).ToString();
                    HarSquare.Text = (s / 10000).ToString();
                    MileSquare.Text = (s / 2.59e+6).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = ex.Message;
                }
            }
        }
        private void KilometrSquareC(object sender, TextChangedEventArgs e)
        {
            if (KilometrSquare.IsSelectionActive)
            {
                try
                {
                    double s = double.Parse(KilometrSquare.Text);
                    SantimetrSquare.Text = (s * 1e+10).ToString();
                    MetrSquare.Text = (s * 1e+6).ToString();
                    HarSquare.Text = (s * 100).ToString();
                    MileSquare.Text = (s / 2.59).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = ex.Message;
                }
            }
        }
        private void HarSquareC(object sender, TextChangedEventArgs e)
        {
            if (HarSquare.IsSelectionActive)
            {
                try
                {
                    double s = double.Parse(HarSquare.Text);
                    SantimetrSquare.Text = (s * 1e+8).ToString();
                    MetrSquare.Text = (s * 10000).ToString();
                    KilometrSquare.Text = (s / 100).ToString();
                    MileSquare.Text = (s / 258.999).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = ex.Message;
                }
            }
        }
        private void MileSquareC(object sender, TextChangedEventArgs e)
        {
            if (MileSquare.IsSelectionActive)
            {
                try
                {
                    double s = double.Parse(MileSquare.Text);
                    SantimetrSquare.Text = (s * 2.59e+10).ToString();
                    MetrSquare.Text = (s * 2.59e+6).ToString();
                    KilometrSquare.Text = (s * 2.59).ToString();
                    HarSquare.Text = (s * 258.999).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = ex.Message;
                }
            }
        }
        #endregion

        private void DecimalC(object sender, TextChangedEventArgs e)
        {
            if (Decimal.IsSelectionActive)
            {
                try
                {

                    Double.Text = Convert.ToString(int.Parse(Decimal.Text), 2);
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = ex.Message;
                }
            }
        }
        private void DoubleC(object sender, TextChangedEventArgs e)
        {
            if (Double.IsSelectionActive)
            {
                try
                {
                    Decimal.Text = Convert.ToInt32(Double.Text, 2).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = ex.Message;
                }
            }
        }

    }
}