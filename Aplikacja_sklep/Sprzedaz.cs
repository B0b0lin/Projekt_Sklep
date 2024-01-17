using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Aplikacja_sklep
{
    internal class Sprzedaz : Program
    {
       
        public static void Sprzedawca(string num)
        {
            bool dziala = true;

            if (Validator.ValidateSwitch(num) < 4 || Validator.ValidateSwitch(num)==5) 
            {
                switch (Validator.ValidateSwitch(num))
                {
                    //Sprzedarz uslugi gier   ZROBIONE
                    case 1:
                        while (dziala)
                        {
                            Console.WriteLine("== Wejscia gry ==");
                            Console.WriteLine("1. PC Gaming 19 zl");
                            Console.WriteLine("2. Sim Racing 60 zl");
                            Console.WriteLine("3. Vr spot 54 zl");
                            Console.WriteLine("5. Zamknij");
                            Console.Write("Wybor: ");
                            int temp = Validator.ValidateSwitch(Convert.ToString(Console.ReadLine()));
                            if (temp == 5) { dziala = false; }
                            WejsciaGry.Gry(temp);
                            dziala = false;
                        }
                        break;

                    // sprzedarz napojow    ZROBIONE
                    case 2:
                        //wyswietlenie numerowanej listy produktów z cenami
                        string magazynSerialized = File.ReadAllText("magazyn.json");
                        dynamic magazyn = Newtonsoft.Json.JsonConvert.DeserializeObject(magazynSerialized);

                        Console.WriteLine("======= Napoje Na Sprzedarz =======");
                        for (int i = 0; i < magazyn["NapojeList"].Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. " + magazyn["NapojeList"][i]["Name"] +", Stan: " + magazyn["NapojeList"][i]["Quantity"]);
                            Console.WriteLine($"   Cena Brutto: " + Convert.ToInt32(magazyn["NapojeList"][i]["CenaNetto"] +
                                (magazyn["NapojeList"][i]["CenaNetto"] * 60) / 100) + " zl");
                            Console.WriteLine();
                        }
                        Console.WriteLine();

                        Console.WriteLine("0. Anuluj");
                        Console.WriteLine("== Wybierz produkt do sprzedania ==");
                        Console.Write("Wybor: ");
                        int wybor = Validator.ValidateInt(Convert.ToString(Console.ReadLine()));
                        if (wybor > magazyn["NapojeList"].Count) { Console.WriteLine("Nie prawidlowy numer..."); }
                        if (wybor > magazyn["NapojeList"].Count || wybor == 0)
                        {
                            Console.WriteLine("Anulacja...");
                            Thread.Sleep(2000);
                            Console.Clear();
                        }
                        else
                        {
                            int cenaNapoj = Convert.ToInt32(magazyn["NapojeList"][wybor-1]["CenaNetto"] + (magazyn["NapojeList"][wybor-1]["CenaNetto"] * 60) / 100);

                            Console.Clear();
                            Console.WriteLine("Ile produktów chce kupic klient?");
                            Console.Write("Ilosc: ");
                            int iloscN = Validator.ValidateInt(Convert.ToString(Console.ReadLine()));
                            if (iloscN < 1) { Console.Clear(); Console.WriteLine("Wartosc musi byc wieksza od 0!"); }
                            if (iloscN > Convert.ToInt32(magazyn["NapojeList"][wybor - 1]["Quantity"])) { Console.WriteLine("Brak towaru"); }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("____________________________");
                                Console.WriteLine($"| Kwota do zapłaty: {cenaNapoj * iloscN} PLN |");
                                Console.WriteLine($"| {iloscN} X {magazyn["NapojeList"][wybor-1]["Name"]} |");
                                Console.WriteLine("____________________________");
                                Console.WriteLine($"== Platnosc ==");
                                Console.WriteLine("1. Karta");
                                Console.WriteLine("2. Gotówka");
                                Console.WriteLine("3. Anuluj i wroc");
                                string temp = Console.ReadLine();
                                if (temp == "1" || temp == "2") 
                                {
                                    PlatnoscClass.Platnosc(temp, cenaNapoj * iloscN);
                                    MagazynModyfikacje.SprzedajProduktNapoj(wybor - 1, iloscN);
                                    
                                    string requestDeserialized = File.ReadAllText("koniec.json");
                                    dynamic request = Newtonsoft.Json.JsonConvert.DeserializeObject(requestDeserialized);
                                    bool istnieje = false;

                                    string name = Convert.ToString(magazyn["NapojeList"][wybor - 1]["Name"]);
                                    for (int i = 0; i < request["KoniecDnia"].Count; i++)
                                    {
                                        if (request["KoniecDnia"][i]["Name"] == name) { istnieje = true; }
                                    }

                                    if (istnieje)
                                    { KoniecDniaDodawanie.KoniecDniaIstnieje(iloscN, Convert.ToString(magazyn["NapojeList"][wybor - 1]["Name"]), cenaNapoj * iloscN);break; }
                                    else
                                    { KoniecDniaDodawanie.KoniecDniaNowe(iloscN, Convert.ToString(magazyn["NapojeList"][wybor - 1]["Name"]), cenaNapoj * iloscN); break; }
                                }
                                else
                                {
                                    Console.WriteLine("Anulacja...");
                                    Thread.Sleep(2000);
                                    Console.Clear();
                                }
                                
                            }

                        }
                        break;

                    //sprzedarz akcesoriow   ZROBIONE
                    case 3: //wyswietlenie numerowanej listy produktów z cenami
                        string magazynSerialized1 = File.ReadAllText("magazyn.json");
                        dynamic magazyn1 = Newtonsoft.Json.JsonConvert.DeserializeObject(magazynSerialized1);

                        Console.WriteLine("======= Akcesoria Na Sprzedarz =======");
                        for (int i = 0; i < magazyn1["AkcesoriaList"].Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. " + magazyn1["AkcesoriaList"][i]["Name"] + ", Stan: " + magazyn1["AkcesoriaList"][i]["Quantity"]);
                            Console.WriteLine($"   Cena Brutto: " + Convert.ToInt32(magazyn1["AkcesoriaList"][i]["CenaNetto"] +
                                (magazyn1["AkcesoriaList"][i]["CenaNetto"] * 60) / 100) + " zl");
                            Console.WriteLine();
                        }
                        Console.WriteLine();

                        Console.WriteLine("0. Anuluj");
                        Console.WriteLine("== Wybierz produkt do sprzedania ==");
                        Console.Write("Wybor: ");
                        int wybor1 = Validator.ValidateInt(Convert.ToString(Console.ReadLine()));
                        if (wybor1 > magazyn1["AkcesoriaList"].Count) { Console.WriteLine("Nie prawidlowy numer..."); }
                        if (wybor1 > magazyn1["AkcesoriaList"].Count || wybor1 == 0)
                        {
                            Console.WriteLine("Anulacja...");
                            Thread.Sleep(2000);
                            Console.Clear();
                        }
                        else
                        {
                            int cenaAkces = Convert.ToInt32(magazyn1["AkcesoriaList"][wybor1 - 1]["CenaNetto"] + (magazyn1["AkcesoriaList"][wybor1 - 1]["CenaNetto"] * 60) / 100);

                            Console.Clear();
                            Console.WriteLine("Ile produktów chce kupic klient?");
                            Console.Write("Ilosc: ");
                            int iloscA = Validator.ValidateInt(Convert.ToString(Console.ReadLine()));
                            if (iloscA < 1) { Console.Clear(); Console.WriteLine("Wartosc musi byc wieksza od 0!"); }
                            if (iloscA > Convert.ToInt32(magazyn1["AkcesoriaList"][wybor1 - 1]["Quantity"])) { Console.WriteLine("Brak towaru"); }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("____________________________");
                                Console.WriteLine($"| Kwota do zapłaty: {cenaAkces * iloscA} PLN |");
                                Console.WriteLine($"| {iloscA} X {magazyn1["AkcesoriaList"][wybor1 - 1]["Name"]} |");
                                Console.WriteLine("____________________________");
                                Console.WriteLine($"== Platnosc ==");
                                Console.WriteLine("1. Karta");
                                Console.WriteLine("2. Gotówka");
                                Console.WriteLine("3. Anuluj i wroc");
                                string temp = Console.ReadLine();
                                if (temp == "1" || temp == "2")
                                {
                                    PlatnoscClass.Platnosc(temp, cenaAkces * iloscA);
                                    MagazynModyfikacje.SprzedajProduktAkcesoria(wybor1 - 1, iloscA);

                                    string requestDeserialized = File.ReadAllText("koniec.json");
                                    dynamic request = Newtonsoft.Json.JsonConvert.DeserializeObject(requestDeserialized);
                                    bool istnieje = false;

                                    string name = Convert.ToString(magazyn1["AkcesoriaList"][wybor1 - 1]["Name"]);
                                    for (int i = 0; i < request["KoniecDnia"].Count; i++)
                                    {
                                        if (request["KoniecDnia"][i]["Name"] == name) { istnieje = true; }
                                    }

                                    if (istnieje)
                                    { KoniecDniaDodawanie.KoniecDniaIstnieje(iloscA, Convert.ToString(magazyn1["AkcesoriaList"][wybor1 - 1]["Name"]), cenaAkces * iloscA); break; }
                                    else
                                    { KoniecDniaDodawanie.KoniecDniaNowe(iloscA, Convert.ToString(magazyn1["AkcesoriaList"][wybor1 - 1]["Name"]), cenaAkces * iloscA); break; }
                                }
                                else
                                {
                                    Console.WriteLine("Anulacja...");
                                    Thread.Sleep(2000);
                                    Console.Clear();
                                }

                            }

                        }
                        break;
                }   
            }else
            {
                Console.Clear();
                Console.WriteLine("================================================");
                Console.WriteLine("Nieprawidłowy wybor, prosze podać numer operacji");
                Console.WriteLine("================================================");
            }
        }
    }
}
