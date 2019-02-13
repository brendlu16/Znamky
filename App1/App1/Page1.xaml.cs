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
	public partial class Page1 : ContentPage
	{
		public Page1 ()
		{
			InitializeComponent ();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            path = Path.Combine(path, "test.db");
            TableCreator tableCreator = new TableCreator(path);
            var predmety = tableCreator.NacistListPredmetu();
            foreach (var item in predmety)
            {
                TestPicker.Items.Add(item.Nazev);
            }
        }
        public void PridatZnamku(object sender, EventArgs e)
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                path = Path.Combine(path, "test.db");
                TableCreator tableCreator = new TableCreator(path);
                DatabaseManager dbManager = new DatabaseManager(path);
                var predmety = tableCreator.NacistListPredmetu();
                var selectedPredmet = predmety[TestPicker.SelectedIndex];
                int znamka = int.Parse(ZnamkaEntry.Text);
                int vaha = int.Parse(VahaEntry.Text);
                Znamka novaZnamka = new Znamka { Predmet = selectedPredmet.ID, Hodnota = znamka, Vaha = vaha };
                dbManager.UlozitZnamku(novaZnamka);
                Navigation.PushAsync(new MainPage());
            }
            catch (Exception)
            {
                
            }
        }
    }
}