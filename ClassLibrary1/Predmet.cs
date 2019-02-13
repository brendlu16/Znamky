using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class Predmet
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Nazev { get; set; }
    }
}
