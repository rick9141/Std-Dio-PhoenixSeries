using System.Collections.Generic;
using Phoenix.Series.Interfaces;

namespace Phoenix.Series.Classes
{
    public class SeriesRepository : IRepository<Serie>
    {
        private readonly List<Serie> listSerie = new();

        public List<Serie> List()
        {
           return listSerie;
        }

        public void Insert(Serie serie)
        {
            listSerie.Add(serie);
        }

        public void Update(int id, Serie serie)
        {
            listSerie[id] = serie;
        }

        public void Delete(int id)
        {
            listSerie[id].Delet();
        }

        public int NextId()
        {
            return listSerie.Count;
        }

        public Serie ReturnById(int id)
        {
            return listSerie[id];
        }
    }
}