using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikacja_sklep
{
    internal class PlatnoscClass
    {
        public static void Platnosc(string num, int kwota)
        {
            string path = "kasa.json";
            switch (Validator.ValidateSwitch(num))
            {
                //platnosc karta
                case 1:
                    //komunikacja z terminalem validacja karty kredytowej

                    //zapis do pliku JSON (kasa.json)
                    string kontoSerialized = File.ReadAllText(path);
                    dynamic konto = Newtonsoft.Json.JsonConvert.DeserializeObject(kontoSerialized);
                    konto["StanKasys"][2]["Value"] += kwota ;
                    konto["StanKasys"][0]["Value"] += kwota ;
                    string output = Newtonsoft.Json.JsonConvert.SerializeObject(konto, Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText(path, output);

                    Console.WriteLine("%Komunikacja z terminalem%");
                    Thread.Sleep(1000);
                    Console.WriteLine("Akceptacja, Dziekuje");
                    Thread.Sleep(2000);
                    Console.Clear();
                    break;

                //platnosc gotowka
                case 2:
                    int temp;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine($"Prosze zaplacic {kwota} PLN");
                        Console.Write("Podaj ile pieniedzy dal klient: ");
                        temp = Validator.ValidateInt(Convert.ToString(Console.ReadLine()));
                    } while (temp < kwota);

                    //zapis do pliku JSON (kasa.json) 
                    string kontoSerialized1 = File.ReadAllText(path);
                    dynamic konto1 = Newtonsoft.Json.JsonConvert.DeserializeObject(kontoSerialized1);
                    konto1["StanKasys"][1]["Value"] += kwota;
                    konto1["StanKasys"][0]["Value"] += kwota;
                    string output1 = Newtonsoft.Json.JsonConvert.SerializeObject(konto1, Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText(path, output1);


                    Console.WriteLine($"Reszta: {temp - kwota}");
                    Console.WriteLine("Akceptacja, Dziekuje");
                    Thread.Sleep(3000);
                    Console.Clear();
                    break;

            }
        }
    }
}
