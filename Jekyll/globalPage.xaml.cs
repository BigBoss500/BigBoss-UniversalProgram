using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Jekyll
{
    public partial class globalPage : Page
    {
        public globalPage()
        {
            InitializeComponent();
            Text();
            EasterEgg.DisplayEgg(Text1);
            EasterEgg.DisplayImageEgg(ImageEgg);
        }
        private string l = Environment.NewLine;
        private void Open(object sender, RoutedEventArgs e) => _ = new Window1();

        private void Button_Click(object sender, RoutedEventArgs e) => _ = new AutoClicker();

        private void Page_Convert(object sender, RoutedEventArgs e) => NavigationService.Navigate(new Uri("Converter.xaml", UriKind.Relative));
        private void Page_Random(object sender, RoutedEventArgs e) => NavigationService.Navigate(new Uri("Random.xaml", UriKind.Relative));
        private void Page_News(object sender, RoutedEventArgs e) => NavigationService.Navigate(new Uri("News.xaml", UriKind.Relative));

        private async void Text()
        {
            string[] str =
            {
                "Совет:" + l+l + "Стремись ты к совершенству, в конце концов!",
                "Анекдот:" + l+l + "Он был настолько редкой тварью, что на ковчег пришел один.",
                "Анекдот:" + l+l + "Думаете, вы знаете, что такое стресс?" + l + "В моём детстве, если вы пропустили серию мультика на ТВ, то вы просто пропустили её. Навсегда.",
                "Совет:" + l+l + "Чем медленнее вы движетесь, тем быстрее умрете.",
                "Совет:" + l+l + "Изо всех ваших сил старайтесь не возненавидеть того, кого когда-то любили.",
                "Анекдот:" + l+l + "У врача:" +l+ "— Дружите с алкоголем?" +l+ "— А чего мне с ним ссориться?",
                "Анекдот:" + l+l + "Почему по арбузам можно стучать, чтобы проверить хороший он или нет, а по людям нельзя?",
                "Анекдот:" + l+l + "Если твой парень не афиширует ваши отношения в соцсетях, то этo не только твой парень.",
                "Анекдот:" + l+l + "Почему на улице гуляет столько маленьких детей с незаклеенными лицами? Сглаз работает только в инстраграмме и на авито?",
                "Анекдот:" + l+l + "Если вас пугает ваш возраст - попробуйте перевести его в доллары. Вы увидите как это чертовски мало.",
                "Анекдот:" + l+l + "- Ты правда глупый или это имидж?",
                "Анекдот:" + l+l + "С ним был не грех, а так, погрешность...",
                "Анекдот:" + l+l + "Некоторые из женщин предпочитают экологически чистый вид транспорта - метлу.",
                "Анекдот:" + l+l + "Загадка: с луком и с яйцами, но не пирожок и не Робин Гуд?" +l+ "Ответ: любой российский мужик после закона от 24 июля.",
                "Анекдот:" + l+l + "После разрешений на сбор валежника и охоты с луком стало понятно, что наш главный геополитический противник уже не США, а Зимбабве, Конго и Кения.",
                "Ребят, привет, теперь я ещё и смогу говорить, также, как и на сайте bigboss500.github.io!",
                "А знаете, здесь не плохо живется...",
                "Не забывайте предлагать идеи для программы!",
                "Поиграйте в нашу замечательную рулетку!",
                "Вы также можете поддержать автора, задонатив любую сумму, начиная от 1-го рубля!",
                "Каждый раз, попадая на главную страницу, текст меняется рандомно.",
                "Как думаете, программа наберет популярность?",
                "Добро пожаловать программу в Jekyll... что? Вы уже здесь были? Эм... ну ладно",
                "Автокликер, по сравнению с автокликером на Python, намного быстрее и стабильнее, также, как и VK User Info, да и вообще программа стала быстрее работать.",
                "Программа написана на языках программирования C# и XAML, автору нравятся эти языки, на них можно написать всё что угодно.",
                "Программа с открытым исходным кодом... просто напомнил.",
                "Название программы происхождена от острова Джекилл.",
                "Если увидели баг, сразу сообщите автору.",
                "Есть также секретная опция. Нажмите на меня и нажимайте любую клавишу на клавиатуре. Я бы мог подсказать, какая клавиша, но мне лень."
            };
            while (true)
            {
                string s = str[new System.Random().Next(0, str.Length)];
                RdmGlobal.Text = s;
                await Task.Delay(10000).ConfigureAwait(true);
            }
        }
        private void Page_TopSecret(object sender, RoutedEventArgs e) => NavigationService.Navigate(new Uri("TopSecret.xaml", UriKind.Relative));
        private void Page_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.M) TopSecret.Visibility = Visibility.Visible;
        }
        private void IdentifierIP_Window(object sender, RoutedEventArgs e) => _ = new IdentifierIP();
    }
}