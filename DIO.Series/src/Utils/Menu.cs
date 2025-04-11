using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using DIO.Series.src.Services;

namespace DIO.Series.src.Utils
{
    public class Menu
    {
        
        public static void Start()
        {
            var repository = new SerieRepository();
            var service = new SerieService(repository);

            string userOption = GetUserOption();

            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        service.ListSeries();
                        break;
                    case "2":
                        service.InsertSeries();
                        break;
                    case "3":
                        service.UpdateSeries();
                        break;
                    case "4":
                        service.DeleteSeries();
                        break;
                    case "5":
                        service.ViewSeries();
                        break;
                    case "C":
                        Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                userOption = GetUserOption();
            }
            
            WriteLine("Obrigado por utilizar nossos serviços.");
            ReadLine();
        }


        private static string GetUserOption()
        {
            WriteLine();
            WriteLine("DIO Séries a seu dispor!!!");
            WriteLine("Informe a opção desejada:");

            WriteLine("1- Listar séries");
            WriteLine("2- Inserir nova série");
            WriteLine("3- Atualizar série");
            WriteLine("4- Excluir série");
            WriteLine("5- Visualizar série");
            WriteLine("C- Limpar tela");
            WriteLine("X- Sair");

            string userOption = ReadLine().ToUpper();
            WriteLine();
            return userOption;
        }
    }
}
