using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class Znamka
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int Predmet { get; set; }
        public int Hodnota { get; set; }
        public int Vaha { get; set; }
    }
}
