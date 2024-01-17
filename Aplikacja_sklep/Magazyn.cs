using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikacja_sklep
{
    internal class Magazyn : Program
    {
        public static void MagazynMain(string num)
        {
            bool dziala = true;

            if (Validator.ValidateSwitch(num) < 6)
            {
                switch (Validator.ValidateSwitch(num))
                {
                    //wyswietl stan magazynu ZROBIONE
                    case 1:
                        while (dziala)
                        {
                            string magazynSerialized = File.ReadAllText("magazyn.json");
                            dynamic magazyn = Newtonsoft.Json.JsonConvert.DeserializeObject(magazynSerialized);

                            Console.WriteLine("======= Napoje =======");
                            //loop NAPOJE
                            for (int i = 0; i < magazyn["NapojeList"].Count; i++)
                            {
                                Console.Write(magazyn["NapojeList"][i]["Name"] + " : ");
                                Console.Write(magazyn["NapojeList"][i]["Quantity"] + ", Cena netto: ");
                                Console.Write(magazyn["NapojeList"][i]["CenaNetto"]);
                                Console.WriteLine();
                            }

                            Console.WriteLine();    
                            Console.WriteLine("======= Akcesoria =======");
                            //loop AKCESORIA
                            for (int i = 0; i < magazyn["AkcesoriaList"].Count; i++)
                            {
                                Console.Write(magazyn["AkcesoriaList"][i]["Name"] + " : ");
                                Console.Write(magazyn["AkcesoriaList"][i]["Quantity"] + ", Cena netto: ");
                                Console.Write(magazyn["AkcesoriaList"][i]["CenaNetto"]);
                                Console.WriteLine();
                            }

                            Console.WriteLine();
                            Console.WriteLine("5. Zamknij");
                            Console.Write("Wybor: ");
                            int temp = Validator.ValidateSwitch(Convert.ToString(Console.ReadLine()));
                            if (temp == 5) { dziala = false; }
                            
                        }
                        break;

                    // dodaj stan magazynu ZROBIONE
                    case 2:
                        while (dziala)
                        {
                            Console.WriteLine("==== Dodaj Stan Istniejacego Produktu ====");
                            Console.WriteLine("1. Dodaj stan napojow");
                            Console.WriteLine("2. Dodaj stan akcesoriow");
                            Console.WriteLine("5. Powrot");
                            Console.Write("Wybor: ");
                            int temp = Validator.ValidateSwitch(Convert.ToString(Console.ReadLine()));
                            if (temp == 5) { dziala = false; }
                            else
                            {
                                switch (temp)
                                {
                                    //Dodawanie stanu istniejacego napoju
                                    case 1:
                                        //wyswietlenie numerowanej listy produktów 
                                        string magazynSerialized = File.ReadAllText("magazyn.json");
                                        dynamic magazyn = Newtonsoft.Json.JsonConvert.DeserializeObject(magazynSerialized);

                                        Console.WriteLine("======= Napoje =======");
                                        for (int i = 0; i < magazyn["NapojeList"].Count; i++)
                                        {
                                            Console.WriteLine($"{i + 1}. " + magazyn["NapojeList"][i]["Name"] + ", Stan: "+ magazyn["NapojeList"][i]["Quantity"]);
                                        }
                                        Console.WriteLine();

                                        //wybor pozycji do dodania stanu
                                        Console.WriteLine("0. Anuluj");
                                        Console.WriteLine("== Podaj numer produktu, do ktorego chcesz dodac stan ==");
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
                                            Console.Clear();
                                            Console.WriteLine("Podaj ilosc jaka chcesz dodac do wybranego produktu");
                                            Console.Write("Ilosc: ");
                                            int iloscN = Validator.ValidateInt(Convert.ToString(Console.ReadLine()));
                                            if (iloscN < 1) {Console.Clear(); Console.WriteLine("Wartosc musi byc wieksza od 0!"); }
                                            else
                                            {
                                                Console.Clear();
                                                MagazynModyfikacje.DodajProduktNapoj(wybor - 1, iloscN);
                                            }
                                            
                                        }
                                        break;

                                    //Dodawanie stanu istniejacego Akcesorium
                                    case 2:
                                        //wyswietlenie numerowanej listy produktów 
                                        string magazynSerialized1 = File.ReadAllText("magazyn.json");
                                        dynamic magazyn1 = Newtonsoft.Json.JsonConvert.DeserializeObject(magazynSerialized1);

                                        Console.WriteLine("======= Napoje =======");
                                        for (int i = 0; i < magazyn1["AkcesoriaList"].Count; i++)
                                        {
                                            Console.WriteLine($"{i + 1}. " + magazyn1["AkcesoriaList"][i]["Name"] + ", Stan: " + magazyn1["AkcesoriaList"][i]["Quantity"]);
                                        }
                                        Console.WriteLine();

                                        //wybor pozycji do dodania stanu
                                        Console.WriteLine("0. Anuluj");
                                        Console.WriteLine("== Podaj numer produktu, do ktorego chcesz dodac stan ==");
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
                                            Console.Clear();
                                            Console.WriteLine("Podaj ilosc jaka chcesz dodac do wybranego produktu");
                                            Console.Write("Ilosc: ");
                                            int iloscA = Validator.ValidateInt(Convert.ToString(Console.ReadLine()));
                                            if (iloscA < 1) { Console.Clear(); Console.WriteLine("Wartosc musi byc wieksza od 0!"); }
                                            else
                                            {
                                                Console.Clear();
                                                MagazynModyfikacje.DodajProduktAkcesoria(wybor1 - 1, iloscA);
                                            }
                                        }
                                        break;
                                }
                            }
                        }


                        break;

                    // Nowy produkt magazynu ZROBIONE
                    case 3:
                        while (dziala)
                        {
                            Console.WriteLine("==== Dodawanie nowego produktu ====");
                            Console.WriteLine("1. Dodaj napoj");
                            Console.WriteLine("2. Dodaj akcesoria");
                            Console.WriteLine("5. Powrot");
                            Console.Write("Wybor: ");
                            int temp = Validator.ValidateSwitch(Convert.ToString(Console.ReadLine()));
                            if (temp == 5) { dziala = false; }
                            else
                            {
                                switch (temp)
                                {
                                    //dodawanie napoju
                                    case 1:
                                        Console.Clear();
                                        Console.Write("Podaj nazwe nowego produktu: ");
                                        string nazwaN = Convert.ToString(Console.ReadLine());
                                        Console.Write("Podaj ilosc: ");
                                        int iloscN = Validator.ValidateInt(Convert.ToString(Console.ReadLine()));
                                        Console.Write("Podaj cene netto: ");
                                        float nettoN = Validator.ValidateFloat(Console.ReadLine());
                                        Console.WriteLine("Czy dodac produkt?");
                                        Console.WriteLine("1. Tak");
                                        Console.WriteLine("2. Nie");
                                        Console.Write("Wybor: ");
                                        int tempWybor = Validator.ValidateInt(Convert.ToString(Console.ReadLine()));
                                        if(tempWybor == 1) { MagazynModyfikacje.NowyProduktNapoj(nazwaN, iloscN, nettoN); }
                                        if(tempWybor == 2) { Console.Clear(); dziala = false; }
                                    break;
                                    
                                    //dodawanie akcesoriow
                                    case 2:
                                        Console.Clear();
                                        Console.Write("Podaj nazwe nowego produktu: ");
                                        string nazwaA = Convert.ToString(Console.ReadLine());
                                        Console.Write("Podaj ilosc: ");
                                        int iloscA = Validator.ValidateInt(Convert.ToString(Console.ReadLine()));
                                        Console.Write("Podaj cene netto: ");
                                        float nettoA = Validator.ValidateFloat(Console.ReadLine());
                                        Console.WriteLine("Czy dodac produkt?");
                                        Console.WriteLine("1. Tak");
                                        Console.WriteLine("2. Nie");
                                        Console.Write("Wybor: ");
                                        int tempWybor1 = Validator.ValidateInt(Convert.ToString(Console.ReadLine()));
                                        if (tempWybor1 == 1) { MagazynModyfikacje.NowyProduktAkcesoria(nazwaA, iloscA, nettoA); }
                                        if (tempWybor1 == 2) {Console.Clear(); dziala = false; }
                                        
                                    break;
                                }
                            }
                        }
                        break;

                    //Usuwanie produktów ZROBIONE
                    case 4:
                        while (dziala)
                        {
                            Console.WriteLine("==== Usuwanie produktu ====");
                            Console.WriteLine("1. Usun napoj");
                            Console.WriteLine("2. Usun akcesoria");
                            Console.WriteLine("5. Powrot");
                            Console.Write("Wybor: ");
                            int temp = Validator.ValidateSwitch(Convert.ToString(Console.ReadLine()));
                            if (temp == 5) { dziala = false; }
                            else
                            {
                                switch (temp)
                                {
                                    //usuwanie napoju
                                    case 1:
                                        //wyswietlenie numerowanej listy produktów 
                                        string magazynSerialized = File.ReadAllText("magazyn.json");
                                        dynamic magazyn = Newtonsoft.Json.JsonConvert.DeserializeObject(magazynSerialized);

                                        Console.WriteLine("======= Napoje =======");
                                        for (int i = 0; i < magazyn["NapojeList"].Count; i++)
                                        {
                                            Console.WriteLine($"{i+1}. "+magazyn["NapojeList"][i]["Name"]);
                                        }
                                        Console.WriteLine();

                                        //wybor pozycji do usuniecia
                                        Console.WriteLine("Podaj numer produktu do usuniecia");
                                        Console.WriteLine("0. Anuluj");
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
                                            Console.Clear();
                                            MagazynModyfikacje.UsunProduktNapoj(wybor - 1);
                                        }
                                    break;

                                    //usuwanie akcesoriow
                                    case 2:
                                        //wyswietlenie numerowanej listy produktów 
                                        string magazynSerialized1 = File.ReadAllText("magazyn.json");
                                        dynamic magazyn1 = Newtonsoft.Json.JsonConvert.DeserializeObject(magazynSerialized1);

                                        Console.WriteLine("======= Akcesoria =======");
                                        for (int i = 0; i < magazyn1["AkcesoriaList"].Count; i++)
                                        {
                                            Console.WriteLine($"{i + 1}. " + magazyn1["AkcesoriaList"][i]["Name"]);
                                        }
                                        Console.WriteLine();

                                        //wybor pozycji do usuniecia
                                        Console.WriteLine("Podaj numer produktu do usuniecia");
                                        Console.WriteLine("0. Anuluj");
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
                                            Console.Clear();
                                            MagazynModyfikacje.UsunProduktAkcesoria(wybor1 - 1);
                                        }
                                        break;
                                }
                            }
                        }
                        break;

                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("================================================");
                Console.WriteLine("Nieprawidłowy wybor, prosze podać numer operacji");
                Console.WriteLine("================================================");
            }
        }
    }
}
