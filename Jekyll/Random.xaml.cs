using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Jekyll
{
    public partial class Random : Page
    {
        public Random()
        {
            InitializeComponent();
            Var.Content = "Всего вариантов выпадения: " + a.Length;
        }

        private string[] a = new string[55];

        private void RdmClear(object sender, RoutedEventArgs e) => RdmGlobal.Text = "Нажмите \"Крутить\", чтобы испытать удачу";
        private void Free_Mode(object sender, RoutedEventArgs e) => NavigationService.Navigate(new Uri("RandomFM.xaml", UriKind.Relative));
        private void Rename(object sender, RoutedEventArgs e) => NameR();

        void NameR() => NameL.Content = "Будем крутить для: " + name.Text;

        private async void RandomObject(object sender, RoutedEventArgs e)
        {
            RdmGlobal.Text = "Пожалуйста, подождите...";
            await Task.Delay(1000).ConfigureAwait(true);
            a[0] = "Повiсточка на бан";
            a[1] = "Photoshop";
            a[2] = "Тёрка за $6999";
            a[3] = "Калыван";
            a[4] = "Шанс на повтор рулетки";
            a[5] = "Решётка";
            a[6] = "Шанс найти в жизни девушку/парня";
            a[7] = "Подарок ВК";
            a[8] = "50 рублей";
            a[9] = "Самый крутой смартфон";
            a[10] = "Защита от DDoS-аттаки на телефон";
            a[11] = "Удача в жизни";
            a[12] = "Счастье в жизни";
            a[13] = "DDoS телефона";
            a[14] = "10 000 подписчиков на YouTube";
            a[15] = "100 000 подписчиков на YouTube";
            a[16] = "Алаеро";
            a[17] = "Баги в программах и играх";
            a[18] = "1 000 000 подписчиков на YouTube";
            a[19] = "Критическая ошибка";
            a[20] = "Инструкция \"Как поднять бабла\"";
            a[21] = "Не учиться";
            a[22] = "Орёл";
            a[23] = "Ничего";
            a[24] = "Очередная функция в программе Jekyll";
            a[25] = "По ОГЭ/ЕГЭ на отлично";
            a[26] = "Пинок";
            a[27] = "Лицензия на Minecraft";
            a[28] = "Котёнок";
            a[29] = "Много денег";
            a[30] = "Python, потому что почему-бы и нет";
            a[31] = "С#, очень прикольный язык, кстати";
            a[32] = "Повiстка в армию";
            a[33] = "Face";
            a[34] = "Windows 10";
            a[35] = "Премиум аккаунт";
            a[36] = "Мажорные предметы в играх";
            a[37] = "Музыка";
            a[38] = "PHP, теперь вы - домохозяйка";
            a[39] = "Посмотреть сериал";
            a[40] = "Canyon";
            a[41] = "Gnome";
            a[42] = "Посмотри сериал/фильм, шо ты сидишь на компе";
            a[43] = "Мощный компьютер";
            a[44] = "Lamborgini";
            a[45] = "BMW";
            a[46] = "Какая-нибудь игра";
            a[47] = "Google";
            a[48] = "Лицензия на какую-нибудь игру";
            a[49] = "Красивые картинки в интернете";
            a[50] = "Samsung Galaxy";
            a[51] = "Пинболл";
            a[52] = "Отряд";
            a[53] = "Диспетчер задач";
            a[54] = "Audi";

            string str = a[new System.Random().Next(0, a.Length)];
            RdmGlobal.Text = "Выпадает: " + Environment.NewLine + str;
        }

        private void Name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                NameR();
        }
    }
}
