using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class TableCreator
    {
        private SQLiteConnection db;
        DatabaseManager dbManager;
        public TableCreator(string path)
        {
            db = new SQLiteConnection(path);
            db.CreateTable<Znamka>();
            db.CreateTable<Predmet>();
            dbManager = new DatabaseManager(path);
        }
        public List<Predmet> NacistListPredmetu()
        {
            List<Predmet> predmety = dbManager.NacistPredmety().ToList();
            return predmety;
        }
        public List<List<Znamka>> VytvoritTabulku()
        {
            List<Predmet> predmety = dbManager.NacistPredmety().ToList();
            List<List<Znamka>> radky = new List<List<Znamka>>();
            for (int i = 0; i < predmety.Count; i++)
            {
                radky.Add(new List<Znamka>());
            }
            radky = VyplnitTabulku(radky, predmety);
            return radky;
        }
        private List<List<Znamka>> VyplnitTabulku(List<List<Znamka>> radky, List<Predmet> predmety)
        {
            List<Znamka> znamky = dbManager.NacistZnamky().ToList();
            foreach (Znamka item in znamky)
            {
                for (int i = 0; i < radky.Count; i++)
                {
                    if (predmety[i].ID == item.Predmet)
                    {
                        radky[i].Add(item);
                    }
                }
            }
            return radky;
        }
    }
}
