using System;
using SimonsVoss.CodingCase.Logic.Model;

namespace SimonsVoss.CodingCase.Logic
{
    public interface IDataRepository
    {
        public IQueryable<Lock> Locks{ get; set; }

    }
}
