using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Aplikacja_sklep
{
    internal class KoniecDniaDodawanie
    {
        public static void KoniecDniaIstnieje(int ilosc,string typ, int kwota)
        {
            string path = "koniec.json";

            string koniecDerialized = File.ReadAllText(path);
            dynamic koniec = Newtonsoft.Json.JsonConvert.DeserializeObject(koniecDerialized);

            koniec["KoniecDnia"][0]["Quantity"] += ilosc;
            koniec["KoniecDnia"][0]["Kwota"] += kwota;

            for (int i = 0; i < koniec["KoniecDnia"].Count; i++)
            {
                if(koniec["KoniecDnia"][i]["Name"] == typ)
                {
                    koniec["KoniecDnia"][i]["Quantity"] += ilosc;
                    koniec["KoniecDnia"][i]["Kwota"] += kwota;
                }
            }

            string output = Newtonsoft.Json.JsonConvert.SerializeObject(koniec, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(path, output);
        }

        public static void KoniecDniaNowe(int ilosc, string name, int kwota)
        {
            string path = "koniec.json";
            //deserializacja
            string koniecDeserialized = File.ReadAllText(path);
            dynamic koniec = Newtonsoft.Json.JsonConvert.DeserializeObject(koniecDeserialized);

            koniec["KoniecDnia"][0]["Quantity"] += ilosc;
            koniec["KoniecDnia"][0]["Kwota"] += kwota;
            string koniecSerialized = JsonConvert.SerializeObject(koniec);
            File.WriteAllText(path, koniecSerialized);
            
            string koniecDeserialized1 = File.ReadAllText(path);
            DBKoniecDnia dBKoniec = JsonConvert.DeserializeObject<DBKoniecDnia>(koniecDeserialized1);

            //dodanie nowej pozycji do listy z napojami
            dBKoniec.KoniecDnia.Add(new DBKoniec() { Name =  name, Quantity= ilosc, Kwota=kwota});

            //serializacja danych oraz zapis do pliku
            string dbKoniecSerialized = JsonConvert.SerializeObject(dBKoniec);
            File.WriteAllText(path, dbKoniecSerialized);

            Console.Clear();
        }
    }
}
