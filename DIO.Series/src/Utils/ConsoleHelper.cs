using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIO.Series.src.Utils
{
    public class ConsoleHelper
    {
        private static int result;

        public static int ReadInt(string prompt)
        {
            WriteLine(prompt);
            while (!int.TryParse(ReadLine(), out int result))
            {
                WriteLine("Entrada inválida. Por favor, insira um número inteiro.");
                Write(prompt);
            }
            return result;
        }
    }
}