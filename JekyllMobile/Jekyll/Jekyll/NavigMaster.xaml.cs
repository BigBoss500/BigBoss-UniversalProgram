using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jekyll
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavigMaster : ContentPage
    {
        public ListView ListView;

        public NavigMaster()
        {
            InitializeComponent();

            BindingContext = new NavigMasterViewModel();
            ListView = MenuItemsListView;
        }

        class NavigMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<NavigMasterMenuItem> MenuItems { get; set; }

            public NavigMasterViewModel()
            {
                MenuItems = new ObservableCollection<NavigMasterMenuItem>(new[]
                {
                    new NavigMasterMenuItem { Title = "Главная", TargetType = typeof(MainPage), Image = "glob.png" },
                    new NavigMasterMenuItem { Title = "Конвертер", TargetType = typeof(ConverterPages.ConverterTabbed), Image = "convert.png" },
                    new NavigMasterMenuItem { Title = "Рулетка", TargetType = typeof(Views.Roulette), Image = "random.png" },
                    new NavigMasterMenuItem { Title = "VK User Info", TargetType = typeof(Views.VKUserInfo), Image = "vkuserinfo.png" },
                    new NavigMasterMenuItem { Title = "Identifier IP", TargetType = typeof(Views.IdentifierIP), Image = "ip.png" },
                    new NavigMasterMenuItem { Title = "О программе", TargetType = typeof(AboutPage), Image = "inf.png" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}