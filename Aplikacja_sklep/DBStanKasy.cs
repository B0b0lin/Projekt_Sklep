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
        public List<DBStanKasy> StanKasys { get; set; }
    }
    
    internal class DBStanKasy
    {
        public string Name { get; set; }
        public float Value { get; set; }
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