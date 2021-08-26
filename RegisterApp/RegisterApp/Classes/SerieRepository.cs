using System;
using System.Collections.Generic;
using System.Text;
using RegisterApp.Interfaces;

namespace RegisterApp
{
    public class SerieRepository : IRepository<Series>
    {
        private List<Series> serieList = new List<Series>();
        public void Update(int id, Series entity)
        {
            serieList[id] = entity;
        }

        public void Exclude(int id)
        {
            serieList[id].Exclude();
        }
        public void Insert(Series entity)
        {
            serieList.Add(entity);
        }

        public List<Series> List()
        {
            return serieList;
        }

        public int NextId()
        {
            return serieList.Count;
        }

        public Series ReturnById(int id)
        {
            return serieList[id];
        }

        
      
    }
}
