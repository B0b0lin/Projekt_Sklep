using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikacja_sklep
{
    internal class KoniecDnia :Program
    {
        public static void KoniecMain(string num)
        {
            bool dziala = true;

            if (Validator.ValidateSwitch(num) < 3 || Validator.ValidateSwitch(num) ==5)
            {
                switch (Validator.ValidateSwitch(num))
                {
                    //wyswietl utarg
                    case 1:
                        while (dziala)
                        {
                            string koniecDniaSerialized = File.ReadAllText("koniec.json");
                            dynamic koniecDnia = Newtonsoft.Json.JsonConvert.DeserializeObject(koniecDniaSerialized);

                            Console.WriteLine("======= Utarg =======");
                            for (int i = 0; i < koniecDnia["KoniecDnia"].Count; i++)
                            {
                                Console.Write(koniecDnia["KoniecDnia"][i]["Name"] + " \nIlosc transakcji: ");
                                Console.Write(koniecDnia["KoniecDnia"][i]["Quantity"] + ", Suma zarobiona: ");
                                Console.Write(koniecDnia["KoniecDnia"][i]["Kwota"]);
                                Console.WriteLine(); Console.WriteLine();
                            }

                            Console.WriteLine();
                            Console.WriteLine("5. Zamknij");
                            Console.Write("Wybor: ");
                            int temp = Validator.ValidateSwitch(Convert.ToString(Console.ReadLine()));
                            if (temp == 5) { dziala = false; }
                            else
                            {
                                Console.WriteLine("================================================");
                                Console.WriteLine("Nieprawidłowy wybor, prosze podać numer operacji");
                                Console.WriteLine("================================================");
                            }
                        }
                        break;

                    //zakoncz dzien
                    case 2:
                        Console.WriteLine("=======  Koniec Dnia =======");
                        while (dziala)
                        {
                            string koniecDniaSerialized = File.ReadAllText("koniec.json");
                            dynamic koniecDnia = Newtonsoft.Json.JsonConvert.DeserializeObject(koniecDniaSerialized);

                            Console.WriteLine("Utarg Z Dnia");
                            Console.WriteLine();
                            for (int i = 0; i < koniecDnia["KoniecDnia"].Count; i++)
                            {
                                Console.Write(koniecDnia["KoniecDnia"][i]["Name"] + " \nIlosc transakcji: ");
                                Console.Write(koniecDnia["KoniecDnia"][i]["Quantity"] + ", Suma zarobiona: ");
                                Console.Write(koniecDnia["KoniecDnia"][i]["Kwota"]);
                                Console.WriteLine(); Console.WriteLine();
                            }

                            Console.WriteLine();
                            Console.WriteLine("Czy chcesz zakonczyc dzien?");
                            Console.WriteLine("1. Potwierdź");
                            Console.WriteLine("5. Anuluj");
                            Console.Write("Wybor: ");
                            int temp = Validator.ValidateSwitch(Convert.ToString(Console.ReadLine()));
                            if (temp == 1 && File.Exists("koniec.json")) 
                            {
                                Console.WriteLine("Drukowanie...");
                                Thread.Sleep(1000);
                                Console.Clear();
                                Console.WriteLine("Dzień zakończony");
                                Thread.Sleep(1000);
                                File.Delete("koniec.json");
                                DBCreator.DBKoniec("koniec.json");
                            }
                            if (temp == 5 || temp == 1) {Console.Clear(); dziala = false; }
                            else
                            {
                                Console.WriteLine("================================================");
                                Console.WriteLine("Nieprawidłowy wybor, prosze podać numer operacji");
                                Console.WriteLine("================================================");
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
