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
	public partial class Page2 : ContentPage
	{
		public Page2 ()
		{
			InitializeComponent ();
		}
        public void PridatPredmet(object sender, EventArgs e)
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                path = Path.Combine(path, "test.db");
                DatabaseManager dbManager = new DatabaseManager(path);
                string nazev = PredmetEntry.Text;
                Predmet predmet = new Predmet { Nazev = nazev };
                dbManager.UlozitPredmet(predmet);
                Navigation.PushAsync(new MainPage());
            }
            catch (Exception)
            {

            }
        }
    }
}