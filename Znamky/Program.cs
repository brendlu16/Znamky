using ClassLibrary1;
using System;
using System.IO;

namespace Znamky
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Brendlu16\source\repos\Znamky\" + "test.db";
            DatabaseManager dbManager = new DatabaseManager(path);
            TableCreator tableCreator = new TableCreator(path);

            //PridaniProTest();

            /*var znamky = dbManager.NacistZnamky();
            var predmety1 = dbManager.NacistPredmety().ToArray();
            foreach (var item in znamky)
            {
                Console.WriteLine(predmety1[item.Predmet].Nazev+", "+item.Hodnota+", "+item.Vaha+", "+item.ID);
            }*/

            var predmety = tableCreator.NacistListPredmetu();
            var radky = tableCreator.VytvoritTabulku();
            for (int i = 0; i < predmety.Count; i++)
            {
                Console.Write(predmety[i].Nazev+": ");
                foreach (var item in radky[i])
                {
                    Console.Write(item.Hodnota + "(vaha " + item.Vaha + "), ");
                }
                Console.WriteLine(" ");
            }

            Console.ReadKey();
        }
        public static void PridaniProTest()
        {
            string path = @"C:\Users\Brendlu16\source\repos\Znamky\" + "test.db";
            DatabaseManager dbManager = new DatabaseManager(path);
            
            Predmet predmet = new Predmet
            {
                Nazev = "Matematika"
            };
            Predmet predmet2 = new Predmet
            {
                Nazev = "Český jazyk"
            };
            Predmet predmet3 = new Predmet
            {
                Nazev = "Vývoj"
            };

            Znamka znamka = new Znamka
            {
                Predmet = 1,
                Hodnota = 1,
                Vaha = 20
            };
            Znamka znamka2 = new Znamka
            {
                Predmet = 1,
                Hodnota = 2,
                Vaha = 30
            };
            Znamka znamka3 = new Znamka
            {
                Predmet = 2,
                Hodnota = 3,
                Vaha = 80
            };
            Znamka znamka4 = new Znamka
            {
                Predmet = 2,
                Hodnota = 5,
                Vaha = 5
            };
            Znamka znamka5 = new Znamka
            {
                Predmet = 3,
                Hodnota = 2,
                Vaha = 15
            };

            dbManager.UlozitPredmet(predmet);
            dbManager.UlozitPredmet(predmet2);
            dbManager.UlozitPredmet(predmet3);
            dbManager.UlozitZnamku(znamka);
            dbManager.UlozitZnamku(znamka2);
            dbManager.UlozitZnamku(znamka3);
            dbManager.UlozitZnamku(znamka4);
            dbManager.UlozitZnamku(znamka5);
        }
    }
}
