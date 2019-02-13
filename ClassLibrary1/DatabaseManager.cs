using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ClassLibrary1
{
    public class DatabaseManager
    {
        private SQLiteConnection db;
        public DatabaseManager (string path)
        {
            db = new SQLiteConnection(path);
            db.CreateTable<Znamka>();
            db.CreateTable<Predmet>();
        }
        public void UlozitZnamku(Znamka znamka)
        {
            db.Insert(znamka);
        }
        public TableQuery<Znamka> NacistZnamky()
        {
            var Znamky = db.Table<Znamka>();
            return Znamky;
        }
        public void UlozitPredmet(Predmet predmet)
        {
            db.Insert(predmet);
        }
        public TableQuery<Predmet> NacistPredmety()
        {
            var Predmety = db.Table<Predmet>();
            return Predmety;
        }
    }
}
