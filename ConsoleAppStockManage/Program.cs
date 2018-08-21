using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleAppStockManage
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(Environment.NewLine + "  L: för att få Saldo." + Environment.NewLine);
            Console.WriteLine("  I + {nummer}: för att mata in en inleverans till lager. Ex: I5" + Environment.NewLine);
            Console.WriteLine("  S + {nummer}: för att mata in en försäljning. Ex: S4" + Environment.NewLine);
            Console.WriteLine("  Exit: för att sluta och stänga ner konsolen." + Environment.NewLine);

            Console.ForegroundColor = ConsoleColor.Green;

            Console.Write(">");

            string userInput = "";

            do
            {
                userInput = Console.ReadLine();

                var response = ProcessCommando(userInput);

                if (!response.Success)
                {
                    Console.Error.WriteLine(!string.IsNullOrEmpty(response.ErrorMessage) ?
                        response.ErrorMessage :
                        "Fel inmatning. Försök igen!");
                }
                else
                {
                    Console.WriteLine(response.Saldo.HasValue ? $"Saldo: {response.Saldo.Value}." : "Klart!");
                }

                Console.Write(">");

            } while (!userInput.ToLower().Equals("exit"));

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static ProcessCommandoResponse ProcessCommando(string commando)
        {
            if (string.IsNullOrEmpty(commando))
                return null;

            string value;

            switch (commando.ToLower()[0])
            {
                case 'l':
                    if (commando.Length > 1)
                        return new ProcessCommandoResponse(false);
                    try
                    {
                        return ServiceStockManage.GetSaldo();
                    }
                    catch (Exception ex)
                    {
                        return new ProcessCommandoResponse(false, ex.Message);
                    }

                case 's':
                    if (commando.Length == 1)
                        return new ProcessCommandoResponse(false);
                    value = commando.Substring(1);
                    if (!IsNumeric(value))
                        return new ProcessCommandoResponse(false);
                    try
                    {
                        return ServiceStockManage.InsertNewSaldoMovment(int.Parse(value) * -1);
                    }
                    catch (Exception ex)
                    {
                        return new ProcessCommandoResponse(false, ex.Message);
                    }

                case 'i':
                    if (commando.Length == 1)
                        return new ProcessCommandoResponse(false);
                    value = commando.Substring(1);
                    if (!IsNumeric(value))
                        return new ProcessCommandoResponse(false);
                    try
                    {
                        return ServiceStockManage.InsertNewSaldoMovment(int.Parse(value));
                    }
                    catch (Exception ex)
                    {
                        return new ProcessCommandoResponse(false, ex.Message);
                    }

                default:
                    return new ProcessCommandoResponse(false);
            }
        }

        private static bool IsNumeric(string stringNumber) => Regex.IsMatch(stringNumber, @"^\d+$");
    }
}
