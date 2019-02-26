using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page3 : ContentPage
	{
		public Page3 (int predmetID)
		{
			InitializeComponent ();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            path = Path.Combine(path, "test.db");
            TableCreator tableCreator = new TableCreator(path);
            DatabaseManager dbManager = new DatabaseManager(path);
            var predmety = tableCreator.NacistListPredmetu();
            var radky = tableCreator.VytvoritTabulku();

            var radek = radky[predmetID];

            double soucet = 0;
            double soucetVah = 0;

            foreach (var item in radek)
            {
                soucet += item.Hodnota * item.Vaha;
                soucetVah += item.Vaha;
            }

            double prumer = soucet / soucetVah;
            prumer = Math.Round(prumer, 2);

            TextCell cell = new TextCell { Text = predmety[predmetID].Nazev+" (průměr: "+prumer+")" };
            TableZnamky.Add(cell);
            
            foreach (var item in radek)
            {
                TextCell cell2 = new TextCell { Text = item.Hodnota + " (váha: " + item.Vaha + ")", StyleId = item.ID.ToString() };
                cell2.Tapped += ViewCellTapped;
                TableZnamky.Add(cell2);
            }
        }
        public void ViewCellTapped(object sender, EventArgs e)
        {
            TextCell cell = (TextCell)sender;
            Navigation.PushAsync(new Page4(int.Parse(cell.StyleId)));

        }
    }
}