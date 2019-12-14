using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

/// <summary>
/// Class that provides the Watermark attached property
/// </summary>
namespace Olib.Core
{
    public static class TextboxExtensions
    {
        public static readonly DependencyProperty PlaceholderProperty = DependencyProperty.RegisterAttached(
            "Placeholder", typeof(string), typeof(TextboxExtensions), new PropertyMetadata(default(string), propertyChangedCallback: PlaceholderChanged));

        private static void PlaceholderChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            TextBox tb = dependencyObject as TextBox;
            if (tb == null)
                return;

            tb.LostFocus -= OnLostFocus;
            tb.GotFocus -= OnGotFocus;
            tb.Initialized -= Tb_Initialized;

            if (args.NewValue != null)
            {
                tb.Initialized += Tb_Initialized;
                tb.GotFocus += OnGotFocus;
                tb.LostFocus += OnLostFocus;
            }
        }

        private static void Tb_Initialized(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (string.IsNullOrEmpty(tb.Text) || string.IsNullOrWhiteSpace(tb.Text))
            {
                tb.Foreground = CustomBrushes.PlaceholderColor;
                tb.Text = GetPlaceholder(tb);
            }
        }

        private static void OnLostFocus(object sender, RoutedEventArgs routedEventArgs)
        {
            TextBox tb = sender as TextBox;
            if (string.IsNullOrEmpty(tb.Text) || string.IsNullOrWhiteSpace(tb.Text))
            {
                tb.Foreground = CustomBrushes.PlaceholderColor;
                tb.Text = GetPlaceholder(tb);
            }
        }

        private static void OnGotFocus(object sender, RoutedEventArgs routedEventArgs)
        {
            TextBox tb = sender as TextBox;
            string ph = GetPlaceholder(tb);
            if (tb.Text == ph)
            {
                tb.Foreground = (SolidColorBrush)Application.Current.Resources["foregroundUPlaceholderText"];
                tb.Text = string.Empty;
            }
        }

        [AttachedPropertyBrowsableForType(typeof(TextBox))]
        public static void SetPlaceholder(DependencyObject element, string value) => element.SetValue(PlaceholderProperty, value);

        [AttachedPropertyBrowsableForType(typeof(TextBox))]
        public static string GetPlaceholder(DependencyObject element) => (string)element.GetValue(PlaceholderProperty);
    }
}
