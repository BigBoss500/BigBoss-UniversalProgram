using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Threading;

namespace Jekyll
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static object sync = new object();
        private void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            try
            {
                string pathToLog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");
                if (!Directory.Exists(pathToLog))
                    Directory.CreateDirectory(pathToLog); // Создаем директорию, если нужно
                string filename = Path.Combine(pathToLog, string.Format("{0}_{1:dd.MM.yyy}.log",
                AppDomain.CurrentDomain.FriendlyName, DateTime.Now));
                string fullText = string.Format("[{0:dd.MM.yyy HH:mm:ss.fff}] [{1}.{2}()] {3} \n Версия Windows: {4} \r\n",
                DateTime.Now, e.Exception.TargetSite.DeclaringType, e.Exception.TargetSite.Name, e.Exception, Environment.OSVersion.Version);
                lock (sync)
                {
                    File.AppendAllText(filename, fullText, Encoding.GetEncoding("Windows-1251"));
                }
            }
            catch
            {
                // Перехватываем все и ничего не делаем
            }
            MessageBox.Show(
                $"Исключение { e.Exception.GetType().ToString()} отключено. {System.Environment.NewLine} Причина: {e.Exception.Message} {System.Environment.NewLine} Подробности в лог-файле.", 
                "Ошибка", 
                MessageBoxButton.OK, 
                MessageBoxImage.Error);
            e.Handled = true;
        }
    }
}
