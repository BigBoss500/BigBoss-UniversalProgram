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
            Var.Content = local.Localization.RandomStringOptions + a.Length;
        }

        private readonly string[] a =
            {
                "Повiсточка на бан",
                "Photoshop",
                "Тёрка за $6999",
                "Калыван",
                "Шанс на повтор рулетки",
                "Решётка",
                "Шанс найти в жизни девушку/парня",
                "Подарок ВК",
                "50 рублей",
                "Самый крутой смартфон",
                "Защита от DDoS-аттаки на телефон",
                "Удача в жизни",
                "Счастье в жизни",
                "DDoS телефона",
                "10 000 подписчиков на YouTube",
                "100 000 подписчиков на YouTube",
                "Алаеро",
                "Баги в программах и играх",
                "1 000 000 подписчиков на YouTube",
                "Критическая ошибка",
                "Инструкция \"Как поднять бабла\"",
                "Не учиться",
                "Орёл",
                "Ничего",
                "Очередная функция в программе Jekyll",
                "По ОГЭ/ЕГЭ на отлично",
                "Пинок",
                "Лицензия на Minecraft",
                "Котёнок",
                "Много денег",
                "Python, потому что почему-бы и нет",
                "С#, очень прикольный язык, кстати",
                "Повiстка в армию",
                "Face",
                "Windows 10",
                "Премиум аккаунт",
                "Мажорные предметы в играх",
                "Музыка",
                "PHP, теперь вы — домохозяйка",
                "Посмотреть сериал",
                "Canyon",
                "Gnome",
                "Посмотри сериал/фильм, шо ты сидишь на компе",
                "Мощный компьютер",
                "Lamborgini",
                "BMW",
                "Какая-нибудь игра",
                "Google",
                "Лицензия на какую-нибудь игру",
                "Красивые картинки в интернете",
                "Samsung Galaxy",
                "Пинболл",
                "Отряд",
                "Диспетчер задач",
                "Audi"
            };

        private void RdmClear(object sender, RoutedEventArgs e)
        {
            App.Sound();
            RdmGlobal.Text = local.Localization.RandomTextBoxRdmGlobal;
        }

        private void Free_Mode(object sender, RoutedEventArgs e)
        {
            App.Sound();
            NavigationService.Navigate(new Uri("RouletteFM.xaml", UriKind.Relative));
        }

        private void Rename(object sender, RoutedEventArgs e)
        {
            App.Sound();
            NameR();
        }

        private void NameR() => NameL.Content = local.Localization.RandomStringName2 + name.Text;

        private async void RandomObject(object sender, RoutedEventArgs e)
        {
            App.Sound();
            RdmGlobal.Text = local.Localization.RandomButtonTwistExpectation;
            await Task.Delay(1000).ConfigureAwait(true);
            string str = a[new System.Random().Next(0, a.Length)];
            RdmGlobal.Text = local.Localization.RandomButtonTwistOut + Environment.NewLine + str;
        }

        private void Name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                NameR();
        }
    }
}
