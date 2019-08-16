﻿using System;
using System.Globalization;
using System.Windows.Controls;

namespace Jekyll
{
    /// <summary>
    /// Логика взаимодействия для TopSecret.xaml
    /// </summary>
    public partial class TopSecret : Page
    {
        public TopSecret() => InitializeComponent();

        private static double p = Math.PI / 180;
        double Cot(double x)
        {
            return 1 / Math.Tan(x);
        }
        private void getPortalCoords(int x1, int z1, float a1, int x2, int z2, float a2)
        {
            if (Math.Abs(a1 - a2) < 1) Error.Content = "Углы не могут быть равны!";
            else if ((((a1 < 0) && (a2 > 0)) || ((a1 > 0) && (a2 < 0))) && (Math.Abs(Math.Abs(Math.Abs(a1) - 180) - Math.Abs(a2)) < 1))
                Error.Content = "Углы не могут быть противоположны!";
            else
            {
                switch (Math.Round(a1))
                {
                    case -180:
                    case 0:
                    case 180:
                        xres.Text = x1.ToString(new CultureInfo("en-US"));
                        zres.Text = Math.Round(Cot(-a2 * p) * x1 - (x2 * Cot(-a2 * p) - z2)).ToString(new CultureInfo("en-US"));
                        Error.Content = null;
                        break;
                    case -90:
                    case 90:
                        zres.Text = z1.ToString(new CultureInfo("en-US"));
                        xres.Text = Math.Round(Math.Round(x2 * Cot(-a2 * p) - z2 + z1) / Cot(-a2 * p)).ToString(new CultureInfo("en-US"));
                        Error.Content = null;
                        break;
                    default:
                        switch (Math.Round(a2))
                        {
                            case -180:
                            case 0:
                            case 180:
                                xres.Text = x2.ToString(new CultureInfo("en-US"));
                                zres.Text = Math.Round(Cot(-a1 * p) * x2 - (x1 * Cot(-a1 * p) - z1)).ToString(new CultureInfo("en-US"));
                                break;
                            case -90:
                            case 90:
                                zres.Text = z2.ToString(new CultureInfo("en-US"));
                                xres.Text = Math.Round((x1 * Cot(-a1 * p) - z1 + z2) / Cot(-a1 * p)).ToString(new CultureInfo("en-US"));
                                break;
                            default:
                                xres.Text = Math.Round(((x1 * Cot(-a1 * p) - z1) - (x2 * Cot(-a2 * p) - z2)) / (Cot(-a1 * p) - Cot(-a2 * p))).ToString(new CultureInfo("en-US"));
                                zres.Text = Math.Round(Cot(-a1 * p) * double.Parse(xres.Text, new CultureInfo("en-US")) - (x1 * Cot(-a1 * p) - z1)).ToString(new CultureInfo("en-US"));
                                break;
                        }
                        Error.Content = null;
                        break;
                }
            }
        }
        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                getPortalCoords(int.Parse(x1inp.Text, new CultureInfo("en-US")), int.Parse(z1inp.Text, new CultureInfo("en-US")), float.Parse(a1inp.Text, new CultureInfo("en-US")), int.Parse(x2inp.Text, new CultureInfo("en-US")), int.Parse(z2inp.Text, new CultureInfo("en-US")), float.Parse(a2inp.Text, new CultureInfo("en-US")));
            }
            catch (FormatException ex)
            {
                Error.Content = $"Исключение: {ex.Message}";
            }
            catch (OverflowException ex)
            {
                Error.Content = $"Исключение: {ex.Message}";
            }
        }

    }
}

