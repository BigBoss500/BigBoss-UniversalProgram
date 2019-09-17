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
    public partial class Data : ContentView
    {
        public Data()
        {
            InitializeComponent();
        }

        private void ByteC(object sender, TextChangedEventArgs e)
        {
            if (Byte.IsFocused)
            {
                try
                {
                    float b = float.Parse(Byte.Text);
                    KiloByte.Text = (b / 1024).ToString();
                    MegaByte.Text = (b / 1048576).ToString();
                    GigaByte.Text = (b / 1073741824).ToString();
                    TeraByte.Text = (b / 1099511627776).ToString();
                    Bit.Text = (b * 8).ToString();
                    KiloBit.Text = (b / 125).ToString();
                    MegaBit.Text = (b / 125000).ToString();
                    GigaBit.Text = (b / 1.25e+8F).ToString();
                    TeraBit.Text = (b / 1.25e+11F).ToString();
                    Error.Text = null;
                }
                catch (Exception ex)
                {
                    Error.Text = $"Исключение: {ex.Message}";
                }
            }
        }
        private void KilobyteC(object sender, TextChangedEventArgs e)
        {
            if (KiloByte.IsFocused)
            {
                try
                {
                    float k = float.Parse(KiloByte.Text);
                    Byte.Text = (k * 1024).ToString();
                    MegaByte.Text = (k / 1024).ToString();
                    GigaByte.Text = (k / 1048576).ToString();
                    TeraByte.Text = (k / 1073741824).ToString();
                    Bit.Text = (k * 8000).ToString();
                    KiloBit.Text = (k * 8).ToString();
                    MegaBit.Text = (k / 125).ToString();
                    GigaBit.Text = (k / 125000).ToString();
                    TeraBit.Text = (k / 1.25e+8F).ToString();
                    Error.Text = null;
                }
                catch (Exception ex)
                {
                    Error.Text = $"Исключение: {ex.Message}";
                }
            }
        }
        private void MegabyteC(object sender, TextChangedEventArgs e)
        {
            if (MegaByte.IsFocused)
            {
                try
                {
                    float m = float.Parse(MegaByte.Text);
                    Byte.Text = (m * 1048576).ToString();
                    KiloByte.Text = (m * 1024).ToString();
                    GigaByte.Text = (m / 1024).ToString();
                    TeraByte.Text = (m / 1048576).ToString();
                    Bit.Text = (m * 8e+6F).ToString();
                    KiloBit.Text = (m * 8000).ToString();
                    MegaBit.Text = (m * 8).ToString();
                    GigaBit.Text = (m / 125).ToString();
                    TeraBit.Text = (m / 125000).ToString();
                    Error.Text = null;
                }
                catch (Exception ex)
                {
                    Error.Text = $"Исключение: {ex.Message}";
                }
            }
        }
        private void GigabyteC(object sender, TextChangedEventArgs e)
        {
            if (GigaByte.IsFocused)
            {
                try
                {
                    float g = float.Parse(GigaByte.Text);
                    Byte.Text = (g * 1073741824).ToString();
                    KiloByte.Text = (g * 1048576).ToString();
                    MegaByte.Text = (g * 1024).ToString();
                    TeraByte.Text = (g / 1024).ToString();
                    Bit.Text = (g * 8e+9F).ToString();
                    KiloBit.Text = (g * 8e+6F).ToString();
                    MegaBit.Text = (g * 8000).ToString();
                    GigaBit.Text = (g * 8).ToString();
                    TeraBit.Text = (g / 125).ToString();
                    Error.Text = null;
                }
                catch (Exception ex)
                {
                    Error.Text = $"Исключение: {ex.Message}";
                }
            }
        }
        private void TerabyteC(object sender, TextChangedEventArgs e)
        {
            if (TeraByte.IsFocused)
            {
                try
                {
                    float t = float.Parse(TeraByte.Text);
                    Byte.Text = (t * 1099511627776).ToString();
                    KiloByte.Text = (t * 1073741824).ToString();
                    MegaByte.Text = (t * 1048576).ToString();
                    GigaByte.Text = (t * 1024).ToString();
                    Bit.Text = (t * 8e+12F).ToString();
                    KiloBit.Text = (t * 8e+9F).ToString();
                    MegaBit.Text = (t * 8e+6F).ToString();
                    GigaBit.Text = (t * 8000).ToString();
                    TeraBit.Text = (t * 8).ToString();
                    Error.Text = null;
                }
                catch (Exception ex)
                {
                    Error.Text = $"Исключение: {ex.Message}";
                }
            }
        }
        private void BitC(object sender, TextChangedEventArgs e)
        {
            if (Bit.IsFocused)
            {
                try
                {
                    float bit = float.Parse(Bit.Text);
                    Byte.Text = (bit / 8).ToString();
                    KiloByte.Text = (bit / 8000).ToString();
                    MegaByte.Text = (bit / 8000000).ToString();
                    GigaByte.Text = (bit / 8000000000).ToString();
                    TeraByte.Text = (bit / 8000000000000).ToString();
                    KiloBit.Text = (bit / 1000).ToString();
                    MegaBit.Text = (bit / 1000000).ToString();
                    GigaBit.Text = (bit / 1000000000).ToString();
                    TeraBit.Text = (bit / 1000000000000).ToString();
                    Error.Text = null;
                }
                catch (Exception ex)
                {
                    Error.Text = "Исключение: " + ex.Message;
                }
            }
        }
        private void KilobitC(object sender, TextChangedEventArgs e)
        {
            if (KiloBit.IsFocused)
            {
                try
                {
                    float ki = float.Parse(KiloBit.Text);
                    Byte.Text = (ki * 125).ToString();
                    KiloByte.Text = (ki / 8).ToString();
                    MegaByte.Text = (ki / 8000).ToString();
                    GigaByte.Text = (ki / 8000000).ToString();
                    TeraByte.Text = (ki / 8000000000).ToString();
                    Bit.Text = (ki * 1000).ToString();
                    MegaBit.Text = (ki / 1000).ToString();
                    GigaBit.Text = (ki / 1000000).ToString();
                    TeraBit.Text = (ki / 1000000000).ToString();
                    Error.Text = null;
                }
                catch (Exception ex)
                {
                    Error.Text = "Исключение: " + ex.Message;
                }
            }
        }
        private void MegabitC(object sender, TextChangedEventArgs e)
        {
            if (MegaBit.IsFocused)
            {
                try
                {
                    float mi = float.Parse(MegaBit.Text);
                    Byte.Text = (mi * 125000).ToString();
                    KiloByte.Text = (mi * 125).ToString();
                    MegaByte.Text = (mi / 8).ToString();
                    GigaByte.Text = (mi / 8000).ToString();
                    TeraByte.Text = (mi / 8000000).ToString();
                    Bit.Text = (mi * 1000000).ToString();
                    KiloBit.Text = (mi * 1000).ToString();
                    GigaBit.Text = (mi / 1000).ToString();
                    TeraBit.Text = (mi / 1000000).ToString();
                    Error.Text = null;
                }
                catch (Exception ex)
                {
                    Error.Text = "Исключение: " + ex.Message;
                }
            }
        }
        private void GigabitC(object sender, TextChangedEventArgs e)
        {
            if (GigaBit.IsFocused)
            {
                try
                {
                    float gi = float.Parse(GigaBit.Text);
                    Byte.Text = (gi * 125000000).ToString();
                    KiloByte.Text = (gi * 125000).ToString();
                    MegaByte.Text = (gi * 125).ToString();
                    GigaByte.Text = (gi / 8).ToString();
                    TeraByte.Text = (gi / 8000).ToString();
                    Bit.Text = (gi * 1000000000).ToString();
                    KiloBit.Text = (gi * 1000000).ToString();
                    MegaBit.Text = (gi * 1000).ToString();
                    TeraBit.Text = (gi / 1000).ToString();
                    Error.Text = null;
                }
                catch (Exception ex)
                {
                    Error.Text = "Исключение: " + ex.Message;
                }
            }
        }
        private void TerabitC(object sender, TextChangedEventArgs e)
        {
            if (TeraBit.IsFocused)
            {
                try
                {
                    float ti = float.Parse(TeraBit.Text);
                    Byte.Text = (ti * 125000000000).ToString();
                    KiloByte.Text = (ti * 125000000).ToString();
                    MegaByte.Text = (ti * 125000).ToString();
                    GigaByte.Text = (ti * 125).ToString();
                    TeraByte.Text = (ti / 8).ToString();
                    Bit.Text = (ti * 1000000000000).ToString();
                    KiloBit.Text = (ti * 1000000000).ToString();
                    MegaBit.Text = (ti * 1000000).ToString();
                    GigaBit.Text = (ti * 1000).ToString();
                    Error.Text = null;
                }
                catch (Exception ex)
                {
                    Error.Text = "Исключение: " + ex.Message;
                }
            }
        }
    }
}