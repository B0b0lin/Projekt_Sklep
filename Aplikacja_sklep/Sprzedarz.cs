using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikacja_sklep
{
    internal class Sprzedarz
    {
       
        public static void Sprzedawca(string num)
        {
            bool dziala = true;

            if (Validator.ValidateSwitch(num) < 6) 
            {
                switch (Validator.ValidateSwitch(num))
                {
                    case 1:
                        while (dziala)
                        {
                            Console.WriteLine("== Wejscia gry ==");
                            Console.WriteLine("1. PC Gaming");
                            Console.WriteLine("2. Sim Racing");
                            Console.WriteLine("3. Vr spot");
                            Console.WriteLine("5. Zamknij");
                            Console.Write("Wybor: ");
                            int temp = Validator.ValidateSwitch(Convert.ToString(Console.ReadLine()));
                            if (temp == 5) { dziala = false; }
                            WejsciaGry.Gry(temp);
                            dziala = false;
                        }
                        break;


                    case 2: Console.WriteLine("Napoje");
                        break;


                    case 3: Console.WriteLine("Akcesoria");
                        break;


                    case 4: Console.WriteLine("Voucher");
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
