using System;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;

namespace Jekyll
{
    public partial class AutoClicker : Window, IComponentConnector
    {
        public const int MOUSEEVENTF_LEFTDOWN = 2;
        public const int MOUSEEVENTF_LEFTUP = 4;
        private HwndSource source;
        public bool click;
        public static int time;

        public AutoClicker()
        {
            InitializeComponent();
            IDtext.Text = Properties.Settings.Default.MillisValue.ToString();
        }

        [DllImport("user32.dll")]
        public static extern void mouse_event(
          int dwFlags,
          int dx,
          int dy,
          int dwData,
          int dwExtraInfo);

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            IntPtr handle = new WindowInteropHelper(this).Handle;
            source = HwndSource.FromHwnd(handle);
            source.AddHook(new HwndSourceHook(HwndHook));
            RegisterHotKey(handle, 9000, 0U, 113U);
        }

        private IntPtr HwndHook(
          IntPtr hwnd,
          int msg,
          IntPtr wParam,
          IntPtr lParam,
          ref bool handled)
        {
            if (msg == 786 && wParam.ToInt32() == 9000)
            {
                if (((int)lParam >> 16 & ushort.MaxValue) == 113)
                {
                    ClickLeftMouseButtonMouseEvent();
                }

                handled = true;
            }
            return IntPtr.Zero;
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.MillisValue = int.Parse(IDtext.Text);
            Properties.Settings.Default.Save();
            if (click)
            {
                click = !click;
            }
            Close();
        }

        private void Rollup(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;

        private void Drag(object sender, MouseButtonEventArgs e) =>DragMove();

        private void ClickLeftMouseButtonMouseEvent()
        {
            try
            {
                time = int.Parse(IDtext.Text);
                Error.Content = null;
            }
            catch (Exception ex)
            {
                Error.Content = "Исключение " + ex.Message;
                return;
            }
            click = !click;
            new Thread(new ThreadStart(Clicker), 26214400).Start();
        }

        private void Clicker()
        {
            while (click)
            {
                mouse_event(2, 0, 0, 0, 0);
                mouse_event(4, 0, 0, 0, 0);
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
}
