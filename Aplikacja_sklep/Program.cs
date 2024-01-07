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
            string path = "kasa.json";
            string pathM = "magazyn.json";
            string pathK = "koniec.json";
           /* StreamWriter sw;
            sw = File.CreateText(pathM);
            sw.Close();
            sw = File.CreateText(pathK);
            sw.Close();*/
            if (!File.Exists(path))
            {
                StreamWriter sw;
                sw = File.CreateText(path);
                sw.Close();
                
                var konto = new Konto()
                {
                    StanKasys = new List<StanKasy>()
                    {
                        new StanKasy()
                        {
                            Name = "Stan Konta (Suma Got i Kart)",
                            Value = 0
                        },
                        new StanKasy()
                        {
                            Name = "Gotowka",
                            Value = 0
                        },
                        new StanKasy()
                        {
                            Name = "Karta",
                            Value = 0
                        }
                    }
                };

                string kontoSerialized = JsonConvert.SerializeObject(konto);

                File.WriteAllText(path, kontoSerialized);
            }
            if (!File.Exists(pathM)) 
            {
            
            }

            //start programu główna petla
            while (true)
            {
                bool dziala = true;

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
                                string kontoSerialized = File.ReadAllText(path);
                                dynamic konto = Newtonsoft.Json.JsonConvert.DeserializeObject(kontoSerialized);

                                for (int i = 0; i < 3; i++)
                                {
                                    Console.Write(konto["StanKasys"][i]["Name"] + " : ");
                                    Console.Write(konto["StanKasys"][i]["Value"]);
                                    Console.WriteLine();
                                }

                                Console.WriteLine("5. Powrót ");
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

                        // %  MAGAZYN  %  TODO: opcje na dodanie stanu magazynu (w tym nowy produkt lub produkt istniejący) 
                        // wyswietlenie stanu magazynu, oraz opcja voucher dodanie, wyswietlenie, usuniecie vouchera
                        // MOZLKIWE ZE VOUCHER USUNE
                        case 2:
                            Console.WriteLine("pokazanie stanów magazynowych");
                            break;

                        // % SPRZEDARZ  %  TODO: Napoje, Akcesoria, Voucher (może)
                        case 3:

                            Console.Clear();
                            while (dziala)
                            {
                                Console.WriteLine("== Sprzedarz ==");
                                Console.WriteLine("1. Wejscia gry");
                                Console.WriteLine("2. Napoje");
                                Console.WriteLine("3. Akcesoria");
                                Console.WriteLine("4. Voucher");
                                Console.WriteLine("5. Zamknij");
                                Console.Write("Wybor: ");
                                string temp = Convert.ToString(Console.ReadLine());
                                if (temp == "5") { dziala = false; }
                                Sprzedarz.Sprzedawca(temp);
                            }
                            break;

                        // %  KONIEC DNIA  %  TODO: Wyświetlenie wszystkiego co sie sprzedało przez czas od ostatniego zamkniecia
                        //temp json zapisujacy co i ile plus, liczy sume zarobku 

                        case 4:
                            Console.WriteLine("Koniec dnia");
                            break;

                        // %  EXIT  %  TODO:  przed wyjsciem zapyta czy chcemy wyjsc bez skonczenia dnia jak nie skonczymy dnia
                        // to plik "konca dnia" zostaje z poprzedniej sesjii aż go nie zakonczymy
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
