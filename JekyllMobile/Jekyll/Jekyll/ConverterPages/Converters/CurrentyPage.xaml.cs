using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jekyll.ConverterPages.Converters
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CurrentyPage : ContentView
    {
        public CurrentyPage()
        {
            InitializeComponent();
            BindingContext = new CurrentyClass();
        }
        private void Change(object sender, EventArgs e) => Conv();
        private void EntryF_TextChanged(object sender, TextChangedEventArgs e) => Conv();
        
        private void Conv()
        {
            try
            {
                CurrentyClass currenty = new CurrentyClass();
                Result.Text = Convert.ToString(float.Parse(currenty.currentyText.ElementAt(Curr1.SelectedIndex).CurValue.ToString()) / float.Parse(currenty.currentyText.ElementAt(Curr2.SelectedIndex).CurValue.ToString()) * float.Parse(EntryF.Text) + " " + currenty.currentyText.ElementAt(Curr2.SelectedIndex).CurText);
                Error.Text = null;
            }
            catch(Exception ex)
            {
                Error.Text = $"Исключение: {ex.Message}";
            }
        }

    }

    class CurrentyClass
    {
        public List<CurrentyValues> currentyText { get; set; }

        public CurrentyClass()
        {
            var val = Currenty();
            if (val != null)
            {
                currentyText = val.ToList();
            }
        }
        public XDocument doc;
        public List<CurrentyValues> Currenty()
        {
            try
            {
                doc = XDocument.Load("https://www.cbr-xml-daily.ru/daily_utf8.xml");
                var USD = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01235"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var EUR = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01239"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var UAH = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01720"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var BYN = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01090B"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var AMD = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01060"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var AUD = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01010"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var AZN = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01020A"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var GBP = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01035"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var BGN = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01100"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var BRL = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01115"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var HUF = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01135"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var HKD = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01200"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var DKK = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01215"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var INR = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01270"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var KZT = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01335"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var CAD = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01350"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var KGS = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01370"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var CNY = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01375"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var MDL = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01500"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var NOK = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01535"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var PLN = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01565"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var RON = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01585F"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var XDR = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01589"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var SGD = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01625"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var TJS = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01670"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var TRY = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01700J"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var TMT = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01710A"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var UZS = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01717"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var CZK = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01760"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var SEK = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01770"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var CHF = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01775"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var ZAR = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01810"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var KRW = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01815"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var JPY = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01820"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var list = new List<CurrentyValues>()
                {
                    new CurrentyValues() { CurText = "Рубль", CurValue = 1},
                    new CurrentyValues() { CurText = USD.nam, CurValue = USD.val / USD.nom},
                    new CurrentyValues() { CurText = EUR.nam, CurValue = EUR.val / EUR.nom},
                    new CurrentyValues() { CurText = UAH.nam, CurValue = UAH.val / UAH.nom},
                    new CurrentyValues() { CurText = BYN.nam, CurValue = BYN.val / BYN.nom},
                    new CurrentyValues() { CurText = AMD.nam, CurValue = AMD.val / AMD.nom},
                    new CurrentyValues() { CurText = AUD.nam, CurValue = AUD.val / AUD.nom},
                    new CurrentyValues() { CurText = AZN.nam, CurValue = AZN.val / AZN.nom},
                    new CurrentyValues() { CurText = GBP.nam, CurValue = GBP.val / GBP.nom},
                    new CurrentyValues() { CurText = BGN.nam, CurValue = BGN.val / BGN.nom},
                    new CurrentyValues() { CurText = BRL.nam, CurValue = BRL.val / BRL.nom},
                    new CurrentyValues() { CurText = HUF.nam, CurValue = HUF.val / HUF.nom},
                    new CurrentyValues() { CurText = HKD.nam, CurValue = HKD.val / HKD.nom},
                    new CurrentyValues() { CurText = DKK.nam, CurValue = DKK.val / DKK.nom},
                    new CurrentyValues() { CurText = INR.nam, CurValue = INR.val / INR.nom},
                    new CurrentyValues() { CurText = KZT.nam, CurValue = KZT.val / KZT.nom},
                    new CurrentyValues() { CurText = CAD.nam, CurValue = CAD.val / CAD.nom},
                    new CurrentyValues() { CurText = KGS.nam, CurValue = KGS.val / KGS.nom},
                    new CurrentyValues() { CurText = CNY.nam, CurValue = CNY.val / CNY.nom},
                    new CurrentyValues() { CurText = MDL.nam, CurValue = MDL.val / MDL.nom},
                    new CurrentyValues() { CurText = NOK.nam, CurValue = NOK.val / NOK.nom},
                    new CurrentyValues() { CurText = PLN.nam, CurValue = PLN.val / PLN.nom},
                    new CurrentyValues() { CurText = RON.nam, CurValue = RON.val / RON.nom},
                    new CurrentyValues() { CurText = XDR.nam, CurValue = XDR.val / XDR.nom},
                    new CurrentyValues() { CurText = SGD.nam, CurValue = SGD.val / SGD.nom},
                    new CurrentyValues() { CurText = TJS.nam, CurValue = TJS.val / TJS.nom},
                    new CurrentyValues() { CurText = TRY.nam, CurValue = TRY.val / TRY.nom},
                    new CurrentyValues() { CurText = TMT.nam, CurValue = TMT.val / TMT.nom},
                    new CurrentyValues() { CurText = UZS.nam, CurValue = UZS.val / UZS.nom},
                    new CurrentyValues() { CurText = CZK.nam, CurValue = CZK.val / CZK.nom},
                    new CurrentyValues() { CurText = SEK.nam, CurValue = SEK.val / SEK.nom},
                    new CurrentyValues() { CurText = CHF.nam, CurValue = CHF.val / CHF.nom},
                    new CurrentyValues() { CurText = ZAR.nam, CurValue = ZAR.val / ZAR.nom},
                    new CurrentyValues() { CurText = KRW.nam, CurValue = KRW.val / KRW.nom},
                    new CurrentyValues() { CurText = JPY.nam, CurValue = JPY.val / JPY.nom}
                };
                return list;
            }
            catch
            {
                return null;
            }
        }
    }

    public class CurrentyValues
    {
        public string CurText { get; set; }
        public float CurValue { get; set; }
    }
}