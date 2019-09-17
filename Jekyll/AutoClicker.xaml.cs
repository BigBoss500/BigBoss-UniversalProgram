using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;

namespace Jekyll
{
    public partial class AutoClicker : Window, IComponentConnector
    {
        private HwndSource source;
        private bool click;
        private static int time;

        public AutoClicker()
        {
            InitializeComponent();
            Clicked.Opacity = 0;
            Poss();
            IDtext.Text = Properties.Settings.Default.MillisValue.ToString();
        }
        private async void Rollup(object sender, RoutedEventArgs e)
        {
            App.Sound();
            for (double i = 1; i > 0; i -= 0.1)
            {
                Clicked.Opacity = i;
                await Task.Delay(1);
            }
            Clicked.Opacity = 1;
            WindowState = WindowState.Minimized;
        }

        private void Drag(object sender, MouseButtonEventArgs e) => DragMove();
        private async void Poss()
        {
            for (double i = 0; i < 1; i += 0.1)
            {
                Clicked.Opacity = i;
                await Task.Delay(1);
            }
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            IntPtr handle = new WindowInteropHelper(this).Handle;
            source = HwndSource.FromHwnd(handle);
            source.AddHook(new HwndSourceHook(HwndHook));
            NativeMethods.RegisterHotKey(handle, 9000, 0U, 113U);
        }

        private IntPtr HwndHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == 786 && wParam.ToInt32() == 9000)
            {
                if (((int)lParam >> 16 & ushort.MaxValue) == 113)
                    ClickLeftMouseButtonMouseEvent();
                handled = true;
            }
            return IntPtr.Zero;
        }

        private async void Close(object sender, RoutedEventArgs e)
        {
            App.Sound();
            Properties.Settings.Default.MillisValue = int.Parse(IDtext.Text);
            Properties.Settings.Default.Save();
            for (double i = 1; i > 0; i -= 0.1)
            {
                Clicked.Opacity = i;
                await Task.Delay(1);
            }
            if (click)
                click = !click;
            Close();
        }



        private void ClickLeftMouseButtonMouseEvent()
        {
            time = int.Parse(IDtext.Text);
            click = !click;
            new Thread(new ThreadStart(Clicker), 26214400).Start();
        }

        private void Clicker()
        {
            while (click)
            {
                Dispatcher.Invoke(() =>
                {
                    NativeMethods.mouse_event(2, 0, 0, 0, new WindowInteropHelper(this).Handle);
                    NativeMethods.mouse_event(4, 0, 0, 0, new WindowInteropHelper(this).Handle);
                });
                Thread.Sleep(time);
            }
        }

        private void IDtext_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (Regex.IsMatch(IDtext.Text, "[^0-9]"))
            {
                IDtext.Text = IDtext.Text.Remove(IDtext.Text.Length - 1);
                IDtext.SelectionStart = IDtext.Text.Length;
            }
        }
    }
    class NativeMethods
    {
        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, IntPtr dwExtraInfo);

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
    }
}
