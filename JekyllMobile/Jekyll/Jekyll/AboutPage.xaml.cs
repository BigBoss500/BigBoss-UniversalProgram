using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jekyll
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            CSharpClass.EasterEgg.DisplayNameEgg(AName);
            CSharpClass.EasterEgg.Version(Version);
        }

        private void DonatVK(object sender, EventArgs e) => Device.OpenUri(new Uri("https://vk.com/jekyll_app?w=app6471849_-182154976"));
        private void GroupVK(object sender, EventArgs e) => Device.OpenUri(new Uri("https://vk.com/jekyll_app"));
        private void GitHub(object sender, EventArgs e) => Device.OpenUri(new Uri("https://github.com/BigBoss500/Jekyll"));

    }
}