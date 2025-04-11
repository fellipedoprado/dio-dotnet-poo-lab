using DIO.Series.Interfaces;

namespace DIO.Series
{
    public class SerieRepository : IRepository<Serie>
    {
        private List<Serie> series = new List<Serie>();
        public void Delete(int id)
        {
            series[id].Delete();
        }

        public void Insert(Serie entity)
        {
            series.Add(entity);
        }

        public List<Serie> List()
        {
            return series;
        }

        public int NextId()
        {
            return series.Count;
        }

        public Serie ReturnById(int id)
        {
            if (id < 0 || id >= series.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "ID inválido.");
            }
            return series[id];
        }

        public void Update(int id, Serie entity)
        {
            series[id] = entity;
        }

    }
}