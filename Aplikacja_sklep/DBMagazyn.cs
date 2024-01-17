using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikacja_sklep
{
    internal class DBMagazyn : DBCreator
    {
        public List<Napoje> NapojeList {  get; set; }
        public List<Akcesoria> AkcesoriaList { get; set; }
    }

    internal class Napoje : DBMagazyn
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public float CenaNetto { get; set; }
    }

    internal class Akcesoria : DBMagazyn
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public float CenaNetto { get; set; }
    }
}
