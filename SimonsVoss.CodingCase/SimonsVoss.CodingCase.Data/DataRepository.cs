using System;
using Newtonsoft.Json;
using SimonsVoss.CodingCase.Logic;
using SimonsVoss.CodingCase.Logic.Model;

namespace SimonsVoss.CodingCase.Data
{
    public class DataRepository : IDataRepository
    {
        public IQueryable<Building> Buildings { get; set; } = new List<Building>().AsQueryable();
        public IQueryable<Lock> Locks { get; set; } = new List<Lock>().AsQueryable();
        public IQueryable<Medium> Media { get; set; } = new List<Medium>().AsQueryable();
        public IQueryable<Group> Groups { get; set; } = new List<Group>().AsQueryable();

        public DataRepository()
        {
        }
    }
}

