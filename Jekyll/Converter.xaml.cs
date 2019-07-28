using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Controls;
using System.Xml.Linq;

namespace Jekyll
{
    public partial class Converter : Page
    {
        public Converter()
        {
            InitializeComponent();
            Currenty();
        }
        public XDocument doc;

        private void CelcionC(object sender, TextChangedEventArgs e)
        {
            if (Celcion.IsSelectionActive)
            {
                float c, f, k;
                try
                {
                    c = float.Parse(Celcion.Text);
                    f = (c * 9 / 5) + 32;
                    k = c + 273.15F;
                    Farengate.Text = f.ToString();
                    Kelvin.Text = k.ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = $"Исключение: {ex.Message}";
                }
            }
        }
        private void FarengateC(object sender, TextChangedEventArgs e)
        {
            if (Farengate.IsSelectionActive)
            {
                float c, f, k;
                try
                {
                    f = float.Parse(Farengate.Text);
                    c = (f - 32) * 5 / 9;
                    k = (f - 32) * 5 / 9 + 273.15F;
                    Celcion.Text = c.ToString();
                    Kelvin.Text = k.ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = $"Исключение: {ex.Message}";
                }
            }
        }
        private void KelvinC(object sender, TextChangedEventArgs e)
        {
            if (Kelvin.IsSelectionActive)
            {
                float c, f, k;
                try
                {
                    k = float.Parse(Kelvin.Text);
                    c = k - 273.15F;
                    f = (k - 273.15F) * 9 / 5 + 32;
                    Celcion.Text = c.ToString();
                    Farengate.Text = f.ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = $"Исключение: {ex.Message}";
                }
            }
        }

        private void MiligrammC(object sender, TextChangedEventArgs e)
        {
            if (Miligramm.IsSelectionActive)
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
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = $"Исключение: {ex.Message}";
                }
            }
        }
        private void GrammC(object sender, TextChangedEventArgs e)
        {
            if (Gramm.IsSelectionActive)
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
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = $"Исключение: {ex.Message}";
                }
            }
        }
        private void KilogrammC(object sender, TextChangedEventArgs e)
        {
            if (Kilogramm.IsSelectionActive)
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
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = $"Исключение: {ex.Message}";
                }
            }
        }
        private void TonnC(object sender, TextChangedEventArgs e)
        {
            if (Tonn.IsSelectionActive)
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
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = $"Исключение: {ex.Message}";
                }
            }
        }

        private void MillimetrC(object sender, TextChangedEventArgs e)
        {
            if (Millimetr.IsSelectionActive)
            {
                float mil, s, m, k, st;
                try
                {
                    mil = float.Parse(Millimetr.Text);
                    s = mil / 10;
                    m = mil / 1000;
                    k = mil / 1E+6F;
                    st = mil / 800;
                    Santimetr.Text = s.ToString();
                    Metr.Text = m.ToString();
                    Kilometr.Text = k.ToString();
                    Step.Text = st.ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = $"Исключение: {ex.Message}";
                }
            }
        }
        private void SantimetrC(object sender, TextChangedEventArgs e)
        {
            if (Santimetr.IsSelectionActive)
            {
                float mil, s, m, k, st;
                try
                {
                    s = float.Parse(Santimetr.Text);
                    mil = s * 10;
                    m = s / 100;
                    k = s / 1E+5F;
                    st = s / 80;
                    Millimetr.Text = mil.ToString();
                    Metr.Text = m.ToString();
                    Kilometr.Text = k.ToString();
                    Step.Text = st.ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = $"Исключение: {ex.Message}";
                }
            }
        }
        private void MetrC(object sender, TextChangedEventArgs e)
        {
            if (Metr.IsSelectionActive)
            {
                float mil, s, m, k, st;
                try
                {
                    m = float.Parse(Metr.Text);
                    mil = m * 1000;
                    s = m * 100;
                    k = m / 1000;
                    st = m * 1.25F;
                    Millimetr.Text = mil.ToString();
                    Santimetr.Text = s.ToString();
                    Kilometr.Text = k.ToString();
                    Step.Text = st.ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = $"Исключение: {ex.Message}";
                }
            }
        }
        private void KilometrC(object sender, TextChangedEventArgs e)
        {
            if (Kilometr.IsSelectionActive)
            {
                float mil, s, m, k, st;
                try
                {
                    k = float.Parse(Kilometr.Text);
                    mil = k * 1E+6F;
                    s = k * 100000;
                    m = k * 1000;
                    st = k * 1250;
                    Millimetr.Text = mil.ToString();
                    Santimetr.Text = s.ToString();
                    Metr.Text = m.ToString();
                    Step.Text = st.ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = $"Исключение: {ex.Message}";
                }
            }
        }
        private void StepC(object sender, TextChangedEventArgs e)
        {
            if (Step.IsSelectionActive)
            {
                float mil, s, m, k, st;
                try
                {
                    st = float.Parse(Step.Text);
                    mil = st * 800;
                    s = st * 80;
                    m = st / 1.25F;
                    k = st / 1250;
                    Millimetr.Text = mil.ToString();
                    Santimetr.Text = s.ToString();
                    Metr.Text = m.ToString();
                    Kilometr.Text = k.ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = $"Исключение: {ex.Message}";
                }
            }
        }

        private void ByteC(object sender, TextChangedEventArgs e)
        {
            if (Byte.IsSelectionActive)
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
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = $"Исключение: {ex.Message}";
                }
            }
        }
        private void KilobyteC(object sender, TextChangedEventArgs e)
        {
            if (KiloByte.IsSelectionActive)
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
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = $"Исключение: {ex.Message}";
                }
            }
        }
        private void MegabyteC(object sender, TextChangedEventArgs e)
        {
            if (MegaByte.IsSelectionActive)
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
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = $"Исключение: {ex.Message}";
                }
            }
        }
        private void GigabyteC(object sender, TextChangedEventArgs e)
        {
            if (GigaByte.IsSelectionActive)
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
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = $"Исключение: {ex.Message}";
                }
            }
        }
        private void TerabyteC(object sender, TextChangedEventArgs e)
        {
            if (TeraByte.IsSelectionActive)
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
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = $"Исключение: {ex.Message}";
                }
            }
        }
        private void BitC(object sender, TextChangedEventArgs e)
        {
            if (Bit.IsSelectionActive)
            {
                try
                {
                    double num1 = float.Parse(Bit.Text);
                    float num2 = (float)(num1 / 8.0);
                    float num3 = (float)(num1 / 8000.0);
                    float num4 = (float)(num1 / 8000000.0);
                    float num5 = (float)(num1 / 8000000000.0);
                    float num6 = (float)(num1 / 7999999967232.0);
                    float num7 = (float)(num1 / 1000.0);
                    float num8 = (float)(num1 / 1000000.0);
                    float num9 = (float)(num1 / 1000000000.0);
                    float num10 = (float)(num1 / 999999995904.0);
                    Byte.Text = num2.ToString();
                    KiloByte.Text = num3.ToString();
                    MegaByte.Text = num4.ToString();
                    GigaByte.Text = num5.ToString();
                    TeraByte.Text = num6.ToString();
                    KiloBit.Text = num7.ToString();
                    MegaBit.Text = num8.ToString();
                    GigaBit.Text = num9.ToString();
                    TeraBit.Text = num10.ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = "Исключение: " + ex.Message;
                }
            }
        }
        private void KilobitC(object sender, TextChangedEventArgs e)
        {
            if (KiloBit.IsSelectionActive)
            {
                try
                {
                    double num1 = float.Parse(KiloBit.Text);
                    float num2 = (float)(num1 * 125.0);
                    float num3 = (float)(num1 / 8.0);
                    float num4 = (float)(num1 / 8000.0);
                    float num5 = (float)(num1 / 8000000.0);
                    float num6 = (float)(num1 / 8000000000.0);
                    float num7 = (float)(num1 * 1000.0);
                    float num8 = (float)(num1 / 1000.0);
                    float num9 = (float)(num1 / 1000000.0);
                    float num10 = (float)(num1 / 1000000000.0);
                    Byte.Text = num2.ToString();
                    KiloByte.Text = num3.ToString();
                    MegaByte.Text = num4.ToString();
                    GigaByte.Text = num5.ToString();
                    TeraByte.Text = num6.ToString();
                    Bit.Text = num7.ToString();
                    MegaBit.Text = num8.ToString();
                    GigaBit.Text = num9.ToString();
                    TeraBit.Text = num10.ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = "Исключение: " + ex.Message;
                }
            }
        }
        private void MegabitC(object sender, TextChangedEventArgs e)
        {
            if (MegaBit.IsSelectionActive)
            {
                try
                {
                    double num1 = float.Parse(MegaBit.Text);
                    float num2 = (float)(num1 * 125000.0);
                    float num3 = (float)(num1 * 125.0);
                    float num4 = (float)(num1 / 8.0);
                    float num5 = (float)(num1 / 8000.0);
                    float num6 = (float)(num1 / 8000000.0);
                    float num7 = (float)(num1 * 1000000.0);
                    float num8 = (float)(num1 * 1000.0);
                    float num9 = (float)(num1 / 1000.0);
                    float num10 = (float)(num1 / 1000000.0);
                    Byte.Text = num2.ToString();
                    KiloByte.Text = num3.ToString();
                    MegaByte.Text = num4.ToString();
                    GigaByte.Text = num5.ToString();
                    TeraByte.Text = num6.ToString();
                    Bit.Text = num7.ToString();
                    KiloBit.Text = num8.ToString();
                    GigaBit.Text = num9.ToString();
                    TeraBit.Text = num10.ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = "Исключение: " + ex.Message;
                }
            }
        }
        private void GigabitC(object sender, TextChangedEventArgs e)
        {
            if (GigaBit.IsSelectionActive)
            {
                try
                {
                    double num1 = float.Parse(GigaBit.Text);
                    float num2 = (float)(num1 * 125000000.0);
                    float num3 = (float)(num1 * 125000.0);
                    float num4 = (float)(num1 * 125.0);
                    float num5 = (float)(num1 / 8.0);
                    float num6 = (float)(num1 / 8000.0);
                    float num7 = (float)(num1 * 1000000000.0);
                    float num8 = (float)(num1 * 1000000.0);
                    float num9 = (float)(num1 * 1000.0);
                    float num10 = (float)(num1 / 1000.0);
                    Byte.Text = num2.ToString();
                    KiloByte.Text = num3.ToString();
                    MegaByte.Text = num4.ToString();
                    GigaByte.Text = num5.ToString();
                    TeraByte.Text = num6.ToString();
                    Bit.Text = num7.ToString();
                    KiloBit.Text = num8.ToString();
                    MegaBit.Text = num9.ToString();
                    TeraBit.Text = num10.ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = "Исключение: " + ex.Message;
                }
            }
        }
        private void TerabitC(object sender, TextChangedEventArgs e)
        {
            if (TeraBit.IsSelectionActive)
            {
                try
                {
                    double num1 = float.Parse(TeraBit.Text);
                    float num2 = (float)(num1 * 124999999488.0);
                    float num3 = (float)(num1 * 125000000.0);
                    float num4 = (float)(num1 * 125000.0);
                    float num5 = (float)(num1 * 125.0);
                    float num6 = (float)(num1 / 8.0);
                    float num7 = (float)(num1 * 999999995904.0);
                    float num8 = (float)(num1 * 1000000000.0);
                    float num9 = (float)(num1 * 1000000.0);
                    float num10 = (float)(num1 * 1000.0);
                    Byte.Text = num2.ToString();
                    KiloByte.Text = num3.ToString();
                    MegaByte.Text = num4.ToString();
                    GigaByte.Text = num5.ToString();
                    TeraByte.Text = num6.ToString();
                    Bit.Text = num7.ToString();
                    KiloBit.Text = num8.ToString();
                    MegaBit.Text = num9.ToString();
                    GigaBit.Text = num10.ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = "Исключение: " + ex.Message;
                }
            }
        }

        private void Currenty()
        {
            try
            {
                doc = XDocument.Load("https://www.cbr-xml-daily.ru/daily.xml");
                var USD = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01235"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var EUR = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01239"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var UAH = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01720"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var BYN = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01090B"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var AMD = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01060"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var AUD = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01010"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var AZN = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01020A"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var GBP = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01035"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var BGN = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01100"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var BRL = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01115"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var HUF = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01135"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var HKD = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01200"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var DKK = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01215"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var INR = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01270"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var KZT = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01335"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var CAD = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01350"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var KGS = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01370"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var CNY = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01375"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var MDL = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01500"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var NOK = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01535"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var PLN = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01565"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var RON = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01585F"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var XDR = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01589"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var SGD = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01625"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var TJS = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01670"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var TRY = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01700J"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var TMT = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01710A"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var UZS = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01717"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var CZK = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01760"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var SEK = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01770"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var CHF = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01775"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var ZAR = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01810"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var KRW = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01815"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var JPY = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01820"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();

                Curr1.SelectedValuePath = "Key";
                Curr1.DisplayMemberPath = "Value";
                Curr2.SelectedValuePath = "Key";
                Curr2.DisplayMemberPath = "Value";
                KeyValuePair<float, string>[] items = new[]
                {
                    new KeyValuePair<float, string>(1, "Рубль"),
                    new KeyValuePair<float, string>(USD.val / USD.nom, USD.nam),
                    new KeyValuePair<float, string>(EUR.val / EUR.nom, EUR.nam),
                    new KeyValuePair<float, string>(UAH.val / UAH.nom, UAH.nam),
                    new KeyValuePair<float, string>(BYN.val / BYN.nom, BYN.nam),
                    new KeyValuePair<float, string>(AMD.val / AMD.nom, AMD.nam),
                    new KeyValuePair<float, string>(AUD.val / AUD.nom, AUD.nam),
                    new KeyValuePair<float, string>(AZN.val / AZN.nom, AZN.nam),
                    new KeyValuePair<float, string>(GBP.val / GBP.nom, GBP.nam),
                    new KeyValuePair<float, string>(BGN.val / BGN.nom, BGN.nam),
                    new KeyValuePair<float, string>(BRL.val / BRL.nom, BRL.nam),
                    new KeyValuePair<float, string>(HUF.val / HUF.nom, HUF.nam),
                    new KeyValuePair<float, string>(HKD.val / HKD.nom, HKD.nam),
                    new KeyValuePair<float, string>(DKK.val / DKK.nom, DKK.nam),
                    new KeyValuePair<float, string>(INR.val / INR.nom, INR.nam),
                    new KeyValuePair<float, string>(KZT.val / KZT.nom, KZT.nam),
                    new KeyValuePair<float, string>(CAD.val / CAD.nom, CAD.nam),
                    new KeyValuePair<float, string>(KGS.val / KGS.nom, KGS.nam),
                    new KeyValuePair<float, string>(CNY.val / CNY.nom, CNY.nam),
                    new KeyValuePair<float, string>(MDL.val / MDL.nom, MDL.nam),
                    new KeyValuePair<float, string>(NOK.val / NOK.nom, NOK.nam),
                    new KeyValuePair<float, string>(PLN.val / PLN.nom, PLN.nam),
                    new KeyValuePair<float, string>(RON.val / RON.nom, RON.nam),
                    new KeyValuePair<float, string>(XDR.val / XDR.nom, XDR.nam),
                    new KeyValuePair<float, string>(SGD.val / SGD.nom, SGD.nam),
                    new KeyValuePair<float, string>(TJS.val / TJS.nom, TJS.nam),
                    new KeyValuePair<float, string>(TRY.val / TRY.nom, TRY.nam),
                    new KeyValuePair<float, string>(TMT.val / TMT.nom, TMT.nam),
                    new KeyValuePair<float, string>(UZS.val / UZS.nom, UZS.nam),
                    new KeyValuePair<float, string>(CZK.val / CZK.nom, CZK.nam),
                    new KeyValuePair<float, string>(SEK.val / SEK.nom, SEK.nam),
                    new KeyValuePair<float, string>(CHF.val / CHF.nom, CHF.nam),
                    new KeyValuePair<float, string>(ZAR.val / ZAR.nom, ZAR.nam),
                    new KeyValuePair<float, string>(KRW.val / KRW.nom, KRW.nam),
                    new KeyValuePair<float, string>(JPY.val / JPY.nom, JPY.nam)
                };
                for (int x = 0; x < items.Length; x++)
                {
                    Curr1.Items.Add(items[x]);
                    Curr2.Items.Add(items[x]);
                }
                Error.Content = null;
            }
            catch (Exception ex)
            {
                Error.Content = $"Исключение: {ex.Message}";
            }
        }

        private void Number_TextChanged(object sender, TextChangedEventArgs e) => CurrConvert();

        private void CurrConvert()
        {
            try
            {
                float money1 = float.Parse(Curr1.SelectedValue.ToString());
                float money2 = float.Parse(Curr2.SelectedValue.ToString());
                float num = float.Parse(Number.Text);
                Res.Content = Convert.ToString(money1 / money2 * num + " " + Curr2.Text);
                Error.Content = null;
            }
            catch (Exception ex)
            {
                Error.Content = $"Исключение: {ex.Message}";
            }
        }

        private void Curr1_SelectionChanged(object sender, SelectionChangedEventArgs e) => CurrConvert();

        private void Curr2_SelectionChanged(object sender, SelectionChangedEventArgs e) => CurrConvert();

        private void DecimalC(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (Decimal.IsSelectionActive)
                {
                    Double.Text = Convert.ToString(int.Parse(Decimal.Text), 2);
                    Error.Content = null;
                }
            }
            catch (Exception ex)
            {
                Error.Content = $"Исключение: {ex.Message}";
            }
        }

        private void DoubleC(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (Double.IsSelectionActive)
                {
                    Decimal.Text = Convert.ToInt32(Double.Text, 2).ToString();
                    Error.Content = null;
                }
            }
            catch (Exception ex)
            {
                Error.Content = $"Исключение: {ex.Message}";
            }
        }
    }
}