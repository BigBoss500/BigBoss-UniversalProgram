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
        private void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            try
            {
                string path = @"Log\" + string.Format("{0}_{1:dd.MM.yyy}.log", AppDomain.CurrentDomain.FriendlyName, DateTime.Now);
                if (!Directory.Exists(@"Log\"))
                    Directory.CreateDirectory(@"Log\"); // Создаем директорию, если нужно
                using (StreamWriter stream = new StreamWriter(path, true))
                {
                    stream.WriteLine("[{0:dd.MM.yyy HH:mm:ss.fff}] [{1}.{2}()] {3} \n Операционная система: {4} \n Имеет 64-bit? — {6} \n Версия, используемой для программы, .NET Framework: {5} \r\n", 
                        DateTime.Now, 
                        e.Exception.TargetSite.DeclaringType, 
                        e.Exception.TargetSite.Name, 
                        e.Exception, 
                        Environment.OSVersion,
                        Environment.Version.ToString(),
                        Environment.Is64BitOperatingSystem ? "Да" : "Нет");
                }
            }
            catch{}
            MessageBox.Show(
                $"Исключение {e.Exception.GetType().ToString()} отключено. {Environment.NewLine}Причина: {e.Exception.Message} {Environment.NewLine}Подробности в лог-файле.", 
                "Ошибка", 
                MessageBoxButton.OK, 
                MessageBoxImage.Error);
            e.Handled = true;
        }
    }
}
