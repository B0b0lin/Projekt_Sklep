using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Aplikacja_sklep
{
    internal class MagazynModyfikacje
    {
        public static void NowyProduktNapoj(string name,int quantity,float cenaNetto)
        {
            //deserializacja
            string dbmagazynDeserialized = File.ReadAllText("magazyn.json");
            DBMagazyn dBMagazyn = JsonConvert.DeserializeObject<DBMagazyn>(dbmagazynDeserialized);
            
            //dodanie nowej pozycji do listy z napojami
            dBMagazyn.NapojeList.Add(new Napoje() { Name = name, Quantity = quantity, CenaNetto = cenaNetto });
            
            //serializacja danych oraz zapis do pliku
            string magazynSerialized = JsonConvert.SerializeObject(dBMagazyn);
            File.WriteAllText("magazyn.json", magazynSerialized);
            
            Console.WriteLine($"Produkt {name}, zostal pomyslnie dodany do magazynu");
            Thread.Sleep(2000);
            Console.Clear();
        }

        public static void NowyProduktAkcesoria(string name, int quantity, float cenaNetto)
        {
            //deserializacja
            string dbmagazynDeserialized = File.ReadAllText("magazyn.json");
            DBMagazyn dBMagazyn = JsonConvert.DeserializeObject<DBMagazyn>(dbmagazynDeserialized);

            //dodanie nowej pozycji do listy z napojami
            dBMagazyn.AkcesoriaList.Add(new Akcesoria() { Name = name, Quantity = quantity, CenaNetto = cenaNetto });

            //serializacja danych oraz zapis do pliku
            string magazynSerialized = JsonConvert.SerializeObject(dBMagazyn);
            File.WriteAllText("magazyn.json", magazynSerialized);

            Console.WriteLine($"Produkt {name}, zostal pomyslnie dodany do magazynu");
            Thread.Sleep(2000);
            Console.Clear();    
        }

        public static void UsunProduktNapoj(int num)
        {
            //deserializacja
            string dbmagazynDeserialized = File.ReadAllText("magazyn.json");
            DBMagazyn dBMagazyn = JsonConvert.DeserializeObject<DBMagazyn>(dbmagazynDeserialized);

            //dodanie nowej pozycji do listy z napojami
            dBMagazyn.NapojeList.RemoveAt(num);

            //serializacja danych oraz zapis do pliku
            string magazynSerialized = JsonConvert.SerializeObject(dBMagazyn);
            File.WriteAllText("magazyn.json", magazynSerialized);

            Console.WriteLine($"Produkt, zostal pomyslnie usunięty z magazynu");
            Thread.Sleep(2000);
            Console.Clear();
        }

        public static void UsunProduktAkcesoria(int num)
        {
            //deserializacja
            string dbmagazynDeserialized = File.ReadAllText("magazyn.json");
            DBMagazyn dBMagazyn = JsonConvert.DeserializeObject<DBMagazyn>(dbmagazynDeserialized);

            //dodanie nowej pozycji do listy z napojami
            dBMagazyn.AkcesoriaList.RemoveAt(num);

            //serializacja danych oraz zapis do pliku
            string magazynSerialized = JsonConvert.SerializeObject(dBMagazyn);
            File.WriteAllText("magazyn.json", magazynSerialized);

            Console.WriteLine($"Produkt, zostal pomyslnie usunięty z magazynu");
            Thread.Sleep(2000);
            Console.Clear();
        }

        public static void DodajProduktNapoj(int num, int ilosc)
        {
            string path = "magazyn.json";

            string magazynDerialized = File.ReadAllText(path);
            dynamic konto = Newtonsoft.Json.JsonConvert.DeserializeObject(magazynDerialized);
            konto["NapojeList"][num]["Quantity"] += ilosc;
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(konto, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(path, output);
            Console.WriteLine("Produkt zostal pomyslnie dodany!");
            Thread.Sleep(2000);
            Console.Clear();
        }

        public static void DodajProduktAkcesoria(int num, int ilosc)
        {
            string path = "magazyn.json";

            string magazynDerialized = File.ReadAllText(path);
            dynamic konto = Newtonsoft.Json.JsonConvert.DeserializeObject(magazynDerialized);
            konto["AkcesoriaList"][num]["Quantity"] += ilosc;
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(konto, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(path, output);
            Console.WriteLine("Produkt zostal pomyslnie dodany!");
            Thread.Sleep(2000);
            Console.Clear();
        }

        public static void SprzedajProduktNapoj(int num, int ilosc)
        {
            string path = "magazyn.json";

            string magazynDerialized = File.ReadAllText(path);
            dynamic konto = Newtonsoft.Json.JsonConvert.DeserializeObject(magazynDerialized);
            konto["NapojeList"][num]["Quantity"] -= ilosc;
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(konto, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(path, output);
        }

        public static void SprzedajProduktAkcesoria(int num, int ilosc)
        {
            string path = "magazyn.json";

            string magazynDerialized = File.ReadAllText(path);
            dynamic konto = Newtonsoft.Json.JsonConvert.DeserializeObject(magazynDerialized);
            konto["AkcesoriaList"][num]["Quantity"] -= ilosc;
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(konto, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(path, output);
        }
    }
}
