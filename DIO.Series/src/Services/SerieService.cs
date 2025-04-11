using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIO.Series.src.Utils;

namespace DIO.Series.src.Services
{
    public class SerieService
    {
        private readonly SerieRepository _repository;

        public SerieService(SerieRepository repository)
        {
            _repository = repository;
        }

        public void InsertSeries()
        {
            WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
            }
            int entryGenre = ConsoleHelper.ReadInt("Digite o gênero entre as opções acima: ");
            Write("Digite o Título da Série: ");
            string entryTitle = ReadLine();
            int entryYear = ConsoleHelper.ReadInt("Digite o Ano de Início da Série: ");
            Write("Digite a Descrição da Série: ");
            string entryDescription = ReadLine();

            Serie newSerie = new Serie(id: _repository.NextId(),
                                        genre: (Genre)entryGenre,
                                        title: entryTitle,
                                        description: entryDescription,
                                        year: entryYear);

            _repository.Insert(newSerie);
            WriteLine("Série inserida com sucesso!");
        }

        public void DeleteSeries()
        {
            try
            {
                Write("Digite o id da série: ");
                int indexSerie = int.Parse(ReadLine());
                _repository.Delete(indexSerie);
                WriteLine("Série excluída com sucesso!");
            }
            catch (FormatException)
            {
                WriteLine("Formato inválido. Por favor, insira um número inteiro.");
            }
            catch (ArgumentOutOfRangeException)
            {
                WriteLine("Série não encontrada. Verifique o id e tente novamente.");
            }
            catch (Exception ex)
            {
                WriteLine($"Erro inesperado: {ex.Message}");
            }
        }
        public void ViewSeries()
        {
            Write("Digite o id da série: ");
            int indexSerie = int.Parse(ReadLine());
            var serie = _repository.ReturnById(indexSerie);
            WriteLine(serie);
        }
        public void UpdateSeries()
        {
            try
            {
                int indexSerie = ConsoleHelper.ReadInt("Digite o id da série: ");
                Serie updatedSerie = GetSerieFromUserInput(indexSerie);
                _repository.Update(indexSerie, updatedSerie);
                WriteLine("Série atualizada com sucesso!");
            }
            catch (Exception ex)
            {
                WriteLine($"Erro ao atualizar série: {ex.Message}");
            }

        }
        public void ListSeries()
        {
            WriteLine("Listar séries");

            var list = _repository.List();

            if (list.Count == 0)
            {
                WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in list)
            {
                var excluded = serie.GetIsDeleted();
                WriteLine("#ID {0}: - {1} {2}", serie.GetId(), serie.GetTitle(), (excluded ? "*Excluído*" : ""));
            }
        }

        private static Serie GetSerieFromUserInput(int id)
        {
            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
            }
            int entryGenre = ConsoleHelper.ReadInt("Digite o gênero entre as opções acima: ");
            Write("Digite o Título da Série: ");
            string entryTitle = ReadLine();
            int entryYear = ConsoleHelper.ReadInt("Digite o Ano de Início da Série: ");
            Write("Digite a Descrição da Série: ");
            string entryDescription = ReadLine();

            return new Serie(id: id, genre: (Genre)entryGenre, title: entryTitle, description: entryDescription, year: entryYear);
        }
    }
}