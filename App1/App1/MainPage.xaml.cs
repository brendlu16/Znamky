using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            path = Path.Combine(path, "test.db");

            VypsatZnamky(path);
        }
        public void VypsatZnamky(string path)
        {
            TableZnamky.Clear();
            DatabaseManager dbManager = new DatabaseManager(path);
            TableCreator tableCreator = new TableCreator(path);
            var predmety = tableCreator.NacistListPredmetu();
            var radky = tableCreator.VytvoritTabulku();
            for (int i = 0; i < predmety.Count; i++)
            {
                StackLayout radek = new StackLayout { Orientation = StackOrientation.Horizontal };
                Label label = new Label { Text = predmety[i].Nazev, WidthRequest = 100 };
                radek.Children.Add(label);
                foreach (var item in radky[i])
                {
                    Label label2 = new Label { Text = item.Hodnota.ToString(), WidthRequest = 20 };
                    radek.Children.Add(label2);
                }
                ViewCell cell = new ViewCell { View = radek};
                TableZnamky.Add(cell);
            }
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page1());
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page2());
        }
    }
}
