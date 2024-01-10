using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikacja_sklep
{
    internal class WejsciaGry
    {
        public static void Gry(int num)
        {
            bool dziala = true;

            switch (num)
            {
                //pc gaming
                case 1:
                    while (dziala)
                    {
                        Console.WriteLine("=== PC Gaming ===");
                        int ilosc;
                        int godziny;
                        do
                        {   
                            Console.Write("Podaj ilosc stanowisk: ");
                            ilosc = Validator.ValidateInt(Console.ReadLine());
                        } while (ilosc < 0);

                        do
                        {
                            Console.Write("Podaj ilosc godzin: ");
                            godziny = Validator.ValidateInt(Convert.ToString(Console.ReadLine()));
                        } while (godziny < 0);

                        Console.WriteLine( "____________________________");
                        Console.WriteLine($"| Kwota do zapłaty: {ilosc * godziny * 19} PLN |");
                        Console.WriteLine($"| {ilosc} PC Gaming na {godziny} godzin   |");
                        Console.WriteLine( "____________________________");
                        Console.WriteLine($"== Platnosc ==");
                        Console.WriteLine( "1. Karta");
                        Console.WriteLine( "2. Gotówka");
                        Console.WriteLine( "3. Anuluj i wroc");
                        string temp = Console.ReadLine();
                        if (temp == "3") {dziala = false; }
                        PlatnoscClass.Platnosc(temp, ilosc * godziny * 19);
                        
                        // dodawanie do bazy końca dnia 
                        string requestDeserialized = File.ReadAllText("koniec.json");
                        dynamic request = Newtonsoft.Json.JsonConvert.DeserializeObject(requestDeserialized);
                        bool istnieje = false;

                        string name = "PC Gaming";
                        for (int i = 0; i < request["KoniecDnia"].Count; i++)
                        {
                            if (request["KoniecDnia"][i]["Name"] == name) { istnieje = true; }
                        }

                        if (istnieje)
                        { KoniecDniaDodawanie.KoniecDniaIstnieje(ilosc, name, ilosc * godziny * 19);}
                        else
                        { KoniecDniaDodawanie.KoniecDniaNowe(ilosc, name, ilosc * godziny * 19);}
                        dziala = false;
                    }
                    break;
                
                //sim racing
                case 2:
                    while (dziala)
                    {
                        Console.WriteLine("=== Sim Racing ===");
                        int ilosc;
                        int godziny;
                        do
                        {
                            Console.Write("Podaj ilosc stanowisk: ");
                            ilosc = Validator.ValidateInt(Console.ReadLine());
                        } while (ilosc < 0);

                        do
                        {
                            Console.Write("Podaj ilosc godzin: ");
                            godziny = Validator.ValidateInt(Convert.ToString(Console.ReadLine()));
                        } while (godziny < 0);

                        
                        Console.WriteLine("____________________________");
                        Console.WriteLine($"| Kwota do zapłaty: {ilosc * godziny * 60} PLN |");
                        Console.WriteLine($"| {ilosc} Sim Racing na {godziny} godzin   |");
                        Console.WriteLine("____________________________");
                        Console.WriteLine($"== Platnosc ==");
                        Console.WriteLine("1. Karta");
                        Console.WriteLine("2. Gotówka");
                        Console.WriteLine("3. Anuluj i wroc");
                        string temp = Console.ReadLine();
                        if (temp == "3") { dziala = false; }
                        PlatnoscClass.Platnosc(temp, ilosc * godziny * 60);

                        // dodawanie do bazy końca dnia 
                        string requestDeserialized = File.ReadAllText("koniec.json");
                        dynamic request = Newtonsoft.Json.JsonConvert.DeserializeObject(requestDeserialized);
                        bool istnieje = false;

                        string name = "Sim Racing";
                        for (int i = 0; i < request["KoniecDnia"].Count; i++)
                        {
                            if (request["KoniecDnia"][i]["Name"] == name) { istnieje = true; }
                        }

                        if (istnieje)
                        { KoniecDniaDodawanie.KoniecDniaIstnieje(ilosc, name, ilosc * godziny * 60); }
                        else
                        { KoniecDniaDodawanie.KoniecDniaNowe(ilosc, name, ilosc * godziny * 60); }
                        dziala = false;
                    }
                    break;

                //vr spot
                case 3:
                    while (dziala)
                    {
                        Console.WriteLine("=== VR Spot ===");
                        int ilosc;
                        int godziny;
                        do
                        {
                            Console.Write("Podaj ilosc stanowisk: ");
                            ilosc = Validator.ValidateInt(Console.ReadLine());
                        } while (ilosc < 0);

                        do
                        {
                            Console.Write("Podaj ilosc godzin: ");
                            godziny = Validator.ValidateInt(Convert.ToString(Console.ReadLine()));
                        } while (godziny < 0);

                        //TO DO: dynamniczne zmienianie cen pobieranie z pliku z cenami
                        Console.WriteLine("____________________________");
                        Console.WriteLine($"| Kwota do zapłaty: {ilosc * godziny * 54} PLN |");
                        Console.WriteLine($"| {ilosc} VR Spot na {godziny} godzin   |");
                        Console.WriteLine("____________________________");
                        Console.WriteLine($"== Platnosc ==");
                        Console.WriteLine("1. Karta");
                        Console.WriteLine("2. Gotówka");
                        Console.WriteLine("3. Anuluj i wroc");
                        string temp = Console.ReadLine();
                        if (temp == "3") { dziala = false; }
                        PlatnoscClass.Platnosc(temp, ilosc * godziny * 54);

                        // dodawanie do bazy końca dnia 
                        string requestDeserialized = File.ReadAllText("koniec.json");
                        dynamic request = Newtonsoft.Json.JsonConvert.DeserializeObject(requestDeserialized);
                        bool istnieje = false;

                        string name = "VR Spot";
                        for (int i = 0; i < request["KoniecDnia"].Count; i++)
                        {
                            if (request["KoniecDnia"][i]["Name"] == name) { istnieje = true; }
                        }

                        if (istnieje)
                        { KoniecDniaDodawanie.KoniecDniaIstnieje(ilosc, name, ilosc * godziny * 54); }
                        else
                        { KoniecDniaDodawanie.KoniecDniaNowe(ilosc, name, ilosc * godziny * 54); }
                        dziala = false;
                    }
                    break;

            }
        }// klasa gry
    
    
    }//glowna petla
}
