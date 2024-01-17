using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikacja_sklep
{
    internal class DBKoniecDnia : DBCreator
    {
        public List<DBKoniec> KoniecDnia {  get; set; }
    }

    internal class DBKoniec : DBKoniecDnia
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public float Kwota { get; set; }
    }
}
