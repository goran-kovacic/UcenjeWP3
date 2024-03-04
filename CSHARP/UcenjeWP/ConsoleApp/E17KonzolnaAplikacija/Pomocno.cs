using System.Globalization;

namespace ConsoleApp.E17KonzolnaAplikacija
{
    internal class Pomocno
    {
        public static bool dev;
        public static int ucitajBrojRaspon(string poruka, string greska, 
            int poc, int kraj)
        {
            int b;
            while (true)
            {
                Console.Write(poruka);
                try
                {
                    b = int.Parse(Console.ReadLine());
                    if(b>=poc && b<=kraj)
                    {
                        return b;
                    }
                    Console.WriteLine(greska);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(greska);
                }
            }
        }

        public static int ucitajBrojRaspon(string poruka, string greska,
            int poc, int kraj, string prekid)
        {
            int b;
            while (true)
            {
                Console.Write(poruka);
                
                try
                {
                    prekid = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(prekid))
                    {
                        return 0;
                    }

                    b = int.Parse(prekid);
                    //if (b == prekid)
                    //{
                    //    return b;
                    //}

                    if (b >= poc && b <= kraj)
                    {
                        return b;
                    }
                    Console.WriteLine(greska);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(greska);
                }
            }
        }

        internal static int ucitajCijeliBroj(string poruka, string greska)
        {
            int b;
            while (true)
            {
                Console.Write(poruka);
                try
                {
                    b = int.Parse(Console.ReadLine());
                    if (b > 0)
                    {
                        return b;
                    }
                    Console.WriteLine(greska);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(greska);
                }
            }
        }

        internal static int promijeniCijeliBroj(string poruka, string greska)
        {
            while(true)
            {
                Console.Write(poruka);
                string input = Console.ReadLine();
                try
                {
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        return 0;
                    }

                    if (int.TryParse(input, out int result) && result > 0)
                    {
                        return result;
                    }
                    else
                    {
                        Console.WriteLine(greska);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(greska);
                }
            }
        }

        internal static decimal ucitajDecimalniBroj(string poruka, string greska)
        {
            decimal b;
            while (true)
            {
                Console.Write(poruka);
                try
                {
                    b = decimal.Parse(Console.ReadLine());
                    if (b > 0)
                    {
                        return b;
                    }
                    Console.WriteLine(greska);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(greska);
                }
            }
        }

        internal static decimal promijeniDecimalniBroj(string poruka, string greska)
        {
            while (true)
            {
                Console.Write(poruka);
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    return 0;
                }
                if (decimal.TryParse(input, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal result) && result > 0)
                {
                    return result;
                }
                else
                {
                    Console.WriteLine(greska);
                }
            }
        }

        internal static bool ucitajBool(string poruka)
        {
            Console.Write(poruka);
            return Console.ReadLine().Trim().ToLower().Equals("da") ? true : false;
        }

        internal static string UcitajBoolAliString(string poruka, string izlaz)
        {
            while (true)
            {
                Console.Write(poruka);
                string input = Console.ReadLine().Trim().ToLower();

                if (string.IsNullOrWhiteSpace(input))
                {
                    return izlaz;
                }

                if (input.Equals("da") || input.Equals("ne"))
                {
                    return input;
                }
                //else if (input.Equals("ne"))
                //{
                //    return "false";
                //}
                else
                {
                    Console.WriteLine("Neispravan unos. Unesi 'da', 'ne', ili Enter za nastavak.");
                }
            }
        }

        internal static string UcitajString(string poruka, string greska)
        {
            string s = "";
            while (true)
            {
                Console.Write(poruka);
                s = Console.ReadLine();
                if (s != null && s.Trim().Length > 0)
                {
                    return s;
                }
                Console.WriteLine(greska);
            }
        }

        internal static string PromijeniString(string poruka, string greska)
        {
            while (true)
            {
                Console.Write(poruka);
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    return "";
                }
                if (input != null && input.Trim().Length > 0)
                {
                    return input;
                }
                Console.WriteLine(greska);
            }
        }

        internal static DateTime ucitajDatum(string v1, string v2)
        {
            while(true)
            {
                try
                {
                    Console.WriteLine(v1);
                    return DateTime.Parse(Console.ReadLine());
                }catch (Exception ex)
                {
                    Console.WriteLine(v2);
                }
            }
        }
    }
}
