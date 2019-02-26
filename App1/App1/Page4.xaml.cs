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
	public partial class Page4 : ContentPage
	{
        int IDZnamky;
		public Page4 (int ZnamkaID)
		{
            IDZnamky = ZnamkaID;
			InitializeComponent ();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            path = Path.Combine(path, "test.db");
            DatabaseManager dbManager = new DatabaseManager(path);
            Znamka znamka = dbManager.NacistZnamku(ZnamkaID);
            ZnamkaLabel.Text = znamka.Hodnota.ToString() + " (váha: " + znamka.Vaha + ")";
        }
        private async void SmazatZnamku(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            path = Path.Combine(path, "test.db");
            DatabaseManager dbManager = new DatabaseManager(path);
            var answer = await DisplayAlert("Smazat?", "Známka bude trvale smazána", "Ano", "Ne");
            if (answer)
            {
                dbManager.SmazatZnamku(IDZnamky);
                await Navigation.PushAsync(new MainPage());
            }
        }
    }
}