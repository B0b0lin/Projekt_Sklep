using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Aplikacja_sklep
{
    internal class DBCreator
    {
        public static void DBKasa(string path)
        {
            if (!File.Exists(path))
            {
                StreamWriter sw;
                sw = File.CreateText(path);
                sw.Close();

                var konto = new Konto()
                {
                    StanKasys = new List<DBStanKasy>()
                    {
                        new DBStanKasy()
                        {
                            Name = "Stan Konta (Suma Got i Kart)",
                            Value = 0
                        },
                        new DBStanKasy()
                        {
                            Name = "Gotowka",
                            Value = 0
                        },
                        new DBStanKasy()
                        {
                            Name = "Karta",
                            Value = 0
                        }
                    }
                };

                string kontoSerialized = JsonConvert.SerializeObject(konto);

                File.WriteAllText(path, kontoSerialized);
            }
        }
    
        public static void DBMagazyn(string path)
        {
            if (!File.Exists(path))
            {
                StreamWriter sw;
                sw = File.CreateText(path);
                sw.Close();

                var magazyn = new DBMagazyn()
                {
                    NapojeList = new List<Napoje>()
                    {
                        new Napoje()
                        {
                            Name = "Monster",
                            Quantity = 1,
                            CenaNetto = 4.99f
                        }
                    },

                    AkcesoriaList = new List<Akcesoria>()
                    {
                        new Akcesoria()
                        {
                            Name = "Myszka",
                            Quantity = 1,
                            CenaNetto = 59.99f
                        }
                    }
                };

                string magazynSerialized = JsonConvert.SerializeObject(magazyn);

                File.WriteAllText(path, magazynSerialized);
            }
        }

        public static void DBKoniec(string path)
        {
            if (!File.Exists(path))
            {
                StreamWriter sw;
                sw = File.CreateText(path);
                sw.Close();

                var koniec = new DBKoniecDnia()
                {
                    KoniecDnia = new List<DBKoniec>()
                    {
                        new DBKoniec()
                        {
                            Name = "Suma zarobiona na koniec dnia",
                            Quantity = 0,
                            Kwota = 0f
                        }
                    }

                };

                string koniecSerialized = JsonConvert.SerializeObject(koniec);

                File.WriteAllText(path, koniecSerialized);

            }
        }
    }
}
