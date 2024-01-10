using Newtonsoft.Json;
using System.Data;
using System.Diagnostics;


namespace Aplikacja_sklep
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //tworzenie bazy danych dla kasy,magazynu,końca dnia jezeli nie istnieje
            DBCreator.DBKasa("kasa.json");
            DBCreator.DBMagazyn("magazyn.json");
            DBCreator.DBKoniec("koniec.json");

            //start programu główna petla
            while (true)
            {
                bool dziala = true;

                Console.Clear();
                Console.WriteLine("== Klub Gamingowy ==");
                Console.WriteLine("1. Stan kasy");
                Console.WriteLine("2. Magazyn");
                Console.WriteLine("3. Sprzedarz");
                Console.WriteLine("4. Koniec Dnia");
                Console.WriteLine("5. Zamknij");
                Console.Write("Wybor: ");
                int temp1 = Validator.ValidateSwitch(Convert.ToString(Console.ReadLine()));
                if (temp1 < 6)
                {
                    switch (temp1)
                    {
                        // %  STAN KASY  %  ZROBIONE
                        case 1:
                            while (dziala)
                            {
                                string kontoSerialized = File.ReadAllText("kasa.json");
                                dynamic konto = Newtonsoft.Json.JsonConvert.DeserializeObject(kontoSerialized);

                                for (int i = 0; i < 3; i++)
                                {
                                    Console.Write(konto["StanKasys"][i]["Name"] + " : ");
                                    Console.Write(konto["StanKasys"][i]["Value"]);
                                    Console.WriteLine();
                                }

                                Console.WriteLine("5. Powrót ");
                                Console.Write("Wybor: ");
                                if (Validator.ValidateSwitch(Convert.ToString(Console.ReadLine())) == 5) { Console.Clear(); dziala = false; }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("================================================");
                                    Console.WriteLine("Nieprawidłowy wybor, prosze podać numer operacji");
                                    Console.WriteLine("================================================");
                                }
                            }
                            break;

                        // %  MAGAZYN  %  ZROBIONE
                        case 2:
                            Console.Clear();
                            while (dziala)
                            {
                                Console.WriteLine("===  Magazyn  ===");
                                Console.WriteLine("1. Wyswietl stan");
                                Console.WriteLine("2. Dodaj stan");
                                Console.WriteLine("3. Nowy produkt");
                                Console.WriteLine("4. Usun produkt");
                                Console.WriteLine("5. Zamknij");
                                Console.Write("Wybor: ");
                                string temp = Convert.ToString(Console.ReadLine());
                                if (temp == "5") { dziala = false; }
                                Magazyn.MagazynMain(temp);
                            }
                            break;

                        // % SPRZEDARZ  %  ZROBIONE
                        case 3:

                            Console.Clear(); 
                            while (dziala)
                            {
                                Console.WriteLine("== Sprzedarz ==");
                                Console.WriteLine("1. Wejscia gry");
                                Console.WriteLine("2. Napoje");
                                Console.WriteLine("3. Akcesoria");
                                Console.WriteLine("5. Zamknij");
                                Console.Write("Wybor: ");
                                string temp = Convert.ToString(Console.ReadLine());
                                if (temp == "5") { dziala = false; }
                                Sprzedaz.Sprzedawca(temp);
                            }
                            break;

                        // %  KONIEC DNIA  %  ZROBIONE
                        case 4:
                            Console.Clear();
                            while (dziala)
                            {
                                Console.WriteLine("===  Koniec Dnia  ===");
                                Console.WriteLine("1. Wyswietl utarg");
                                Console.WriteLine("2. Zakoncz dzien");
                                Console.WriteLine("5. Zamknij");
                                Console.Write("Wybor: ");
                                string temp = Convert.ToString(Console.ReadLine());
                                if (temp == "5") { dziala = false; }
                                KoniecDnia.KoniecMain(temp);
                                dziala = false;
                            }
                            break;

                        // %  EXIT  %  ZROBIONE
                        case 5:
                            System.Environment.Exit(0);
                            break;

                    }
                }
                else 
                {
                    Console.Clear();
                    Console.WriteLine("========================================");
                    Console.WriteLine("Nieprawidłowy wybor, prosze podać liczbe");
                    Console.WriteLine("========================================");
                }
            }
        }
    }
}
