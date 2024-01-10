using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikacja_sklep
{
    internal class Validator
    {
        public static int ValidateSwitch(string num) 
        {
            int wybor;
            
            try
            {
                Console.Clear();
                wybor = Convert.ToInt32(num);
                return wybor;
            }
            catch (System.FormatException ex)
            {
                Console.Clear();
                Console.WriteLine("================================================");
                Console.WriteLine("Nieprawidłowy wybor, prosze podać numer operacji");
                Console.WriteLine("================================================");
                return 0;
            }
        }

        public static int ValidateInt(string num) 
        {
            int wybor;

            try
            {
                wybor = Convert.ToInt32(num);
                return wybor;
            }
            catch (System.FormatException ex)
            {
             
                Console.WriteLine("========================================");
                Console.WriteLine("Nieprawidłowy wybor, prosze podać liczbe");
                Console.WriteLine("========================================");
                return 0;
            }
        }
    
        public static float ValidateFloat(string num)
        {
            float wybor;

            try
            {
                wybor = float.Parse(num, CultureInfo.InvariantCulture.NumberFormat);
                return wybor;
            }
            catch (System.FormatException ex)
            {

                Console.WriteLine("========================================");
                Console.WriteLine("Nieprawidłowy wybor, prosze podać liczbe");
                Console.WriteLine("========================================");
                return 0;
            }
        }
    }
}
