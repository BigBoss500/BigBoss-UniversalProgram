using System;
using System.Windows;
using System.Windows.Controls;

namespace Olib.Pages
{
    /// <summary>
    /// Логика взаимодействия для mathematik.xaml
    /// </summary>
    public partial class mathematik : Page
    {
        private static readonly double p = Math.PI / 180;
        private double Cot(double x) => 1 / Math.Tan(x);

        public mathematik()
        {
            InitializeComponent();
            Core.Animations.AnimationText(Warning);
        }
        private void TextChangedQuadrat(object sender, TextChangedEventArgs e)
        {
            double a, b, c, d;
            try
            {
                a = double.Parse(TextA.Text);
                b = double.Parse(TextB.Text);
                c = double.Parse(TextC.Text);

                d = Math.Pow(b, 2) - 4 * a * c;
                Discriminant.Text = d.ToString();
                if (d < 0)
                {
                    Error.Content = (string)Application.Current.Resources["NoRealRoots"];
                }
                else
                {
                    ResultX1.Text = ((-b + Math.Sqrt(d)) / (2 * a)).ToString();
                    ResultX2.Text = ((-b - Math.Sqrt(d)) / (2 * a)).ToString();
                    Error.Content = null;
                }
            }
            catch (Exception ex)
            {
                Error.Content = ex.Message;
            }
        }

        private void IntersectionPoint(object sender, TextChangedEventArgs e)
        {
            double x1, y1, a1, x2, y2, a2;
            try
            {
                x1 = double.Parse(TBX1.Text);
                y1 = double.Parse(TBY1.Text);
                a1 = double.Parse(TBG1.Text);
                x2 = double.Parse(TBX2.Text);
                y2 = double.Parse(TBY2.Text);
                a2 = double.Parse(TBG2.Text);
                if (Math.Abs(a1 - a2) < 1) Error.Content = (string)Application.Current.Resources["Angles1"];
                else if ((((a1 < 0) && (a2 > 0)) || ((a1 > 0) && (a2 < 0))) && (Math.Abs(Math.Abs(Math.Abs(a1) - 180) - Math.Abs(a2)) < 1))
                    Error.Content = (string)Application.Current.Resources["Angles2"];
                else
                {
                    switch (Math.Round(a1))
                    {
                        case -180:
                        case 0:
                        case 180:
                            xres.Text = x1.ToString();
                            yres.Text = Math.Round(Cot(-a2 * p) * x1 - (x2 * Cot(-a2 * p) - y2)).ToString();
                            break;
                        case -90:
                        case 90:
                            yres.Text = y1.ToString();
                            xres.Text = Math.Round(Math.Round(x2 * Cot(-a2 * p) - y2 + y1) / Cot(-a2 * p)).ToString();
                            break;
                        default:
                            switch (Math.Round(a2))
                            {
                                case -180:
                                case 0:
                                case 180:
                                    xres.Text = x2.ToString();
                                    yres.Text = Math.Round(Cot(-a1 * p) * x2 - (x1 * Cot(-a1 * p) - y1)).ToString();
                                    break;
                                case -90:
                                case 90:
                                    yres.Text = y2.ToString();
                                    xres.Text = Math.Round((x1 * Cot(-a1 * p) - y1 + y2) / Cot(-a1 * p)).ToString();
                                    break;
                                default:
                                    xres.Text = Math.Round(((x1 * Cot(-a1 * p) - y1) - (x2 * Cot(-a2 * p) - y2)) / (Cot(-a1 * p) - Cot(-a2 * p))).ToString();
                                    yres.Text = Math.Round(Cot(-a1 * p) * double.Parse(xres.Text) - (x1 * Cot(-a1 * p) - y1)).ToString();
                                    break;
                            }
                            break;
                    }
                }
                Error.Content = null;
            }
            catch (Exception ex)
            {
                Error.Content = ex.Message;
            }
        }
    }
}