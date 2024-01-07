using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Aplikacja_sklep
{
    internal class Konto
    {
        public List<StanKasy> StanKasys { get; set; }
    }
    
    internal class StanKasy
    {
        public string Name { get; set; }
        public int Value { get; set; }
    }


}


/*
Stan konta
1000 (suma kasy i karty)

Gotówka
500

Karta
500
 
 */