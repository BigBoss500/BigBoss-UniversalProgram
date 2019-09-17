using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

namespace Jekyll.CSharpClass
{
    public static class EasterEgg
    {
        static string data = DateTime.Now.ToString("dd.MM");
        private static readonly Random r = new Random();

        public static void DisplayEgg(Label label)
        {
            if ("19.02" == data)
                label.Text = "У автора сегодня день рождения!";
            if ("15.04" == data)
                label.Text = "Потерян такой великий собор...";
            if ("26.03" == data)
                label.Text = "В этот день появилась программа";
            if ("01.09" == data)
                label.Text = "Всех с днём знании!";
            if ("01.01" == data)
                label.Text = "Всех с новым годом!";
            if ("20.07" == data)
                label.Text = "Именно в этот день программа вышла в релиз";
            if (r.Next(1000) < 1)
                label.Text = "Ого! Удача на вашей стороне!";
        }
        public static void DisplayNameEgg(Span span)
        {
            span.Text = r.Next(10) < 1 ? "Автор: Дмитрий Мирзоян" : "Автор: Дмитрий Жутков";
        }
        public static void DisplayImageEgg(Image image)
        {
            if ("02.09" == data)
                image.IsVisible = true;
        }
        public static void Version(Label label)
        {
            label.Text = "Версия от 20 августа 2019 года";
        }
    }
}
