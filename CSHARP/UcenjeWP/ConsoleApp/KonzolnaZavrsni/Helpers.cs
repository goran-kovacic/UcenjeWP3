using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.KonzolnaZavrsni
{
    internal class Helpers
    {
        public static bool Dev;
        public static int NumberRange(string message, string error,
            int start, int end)
        {
            int b;
            while (true)
            {
                Console.Write(message);
                try
                {
                    b = int.Parse(Console.ReadLine());
                    if (b >= start && b <= end)
                    {
                        return b;
                    }
                    Console.WriteLine(error);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(error);
                }
            }
        }
        public static int NumberRange(string message, string error,
            int start, int end, string cancel)
        {
            int b;
            while (true)
            {
                Console.Write(message);

                try
                {
                    cancel = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(cancel))
                    {
                        return 0;
                    }

                    b = int.Parse(cancel);
                    //if (b == prekid)
                    //{
                    //    return b;
                    //}

                    if (b >= start && b <= end)
                    {
                        return b;
                    }
                    Console.WriteLine(error);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(error);
                }
            }
        }
        internal static int InputInt(string message, string error)
        {
            int b;
            while (true)
            {
                Console.Write(message);
                try
                {
                    b = int.Parse(Console.ReadLine());
                    if (b > 0)
                    {
                        return b;
                    }
                    Console.WriteLine(error);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(error);
                }
            }
        }
        internal static int EditInt(string message, string error, string input)
        {
            while (true)
            {
                Console.Write(message);
                input = Console.ReadLine();
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
                        Console.WriteLine(error);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(error);
                }
            }
        }
        internal static decimal InputDecimal(string message, string error)
        {
            decimal b;
            while (true)
            {
                Console.Write(message);
                try
                {
                    b = decimal.Parse(Console.ReadLine());
                    if (b > 0)
                    {
                        return b;
                    }
                    Console.WriteLine(error);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(error);
                }
            }
        }
        internal static decimal EditDecimal(string message, string error)
        {
            while (true)
            {
                Console.Write(message);
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
                    Console.WriteLine(error);
                }
            }
        }
        internal static bool InputBool(string message)
        {
            Console.Write(message);
            return Console.ReadLine().Trim().ToLower().Equals("yes") ? true : false;
        }
        internal static string InputBoolAsString(string mesasge, string error, string cancel)
        {
            //string error = "Invalid input. Type 'yes', 'no', or Enter to continue.";
            while (true)
            {
                Console.Write(mesasge);
                string input = Console.ReadLine().Trim().ToLower();

                if (string.IsNullOrWhiteSpace(input))
                {
                    return cancel;
                }

                if (input.Equals("yes") || input.Equals("no"))
                {
                    return input;
                }
                //else if (input.Equals("ne"))
                //{
                //    return "false";
                //}
                else
                {
                    Console.WriteLine(error);
                }
            }
        }
        internal static string InputString(string message, string error)
        {
            string s = "";
            while (true)
            {
                Console.Write(message);
                s = Console.ReadLine();
                if (s != null && s.Trim().Length > 0)
                {
                    return s;
                }
                Console.WriteLine(error);
            }
        }
        internal static string EditString(string message, string error)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    return "";
                }
                if (input != null && input.Trim().Length > 0)
                {
                    return input;
                }
                Console.WriteLine(error);
            }
        }
        internal static DateTime? InputDate(string message, string error)
        {
            while (true)
            {
                Console.WriteLine(message);
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    return null;
                }

                string format = "dd-MM-yyyy";
                if(DateTime.TryParse(input, out DateTime date)) 
                {
                    return date;
                }
                else
                {
                    Console.WriteLine(error);
                    return InputDate(message, error);
                }


                //try
                //{
                //    Console.WriteLine(message);
                //    return DateTime.Parse(Console.ReadLine());
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine(error);
                //}
            }
        }
    }
}
