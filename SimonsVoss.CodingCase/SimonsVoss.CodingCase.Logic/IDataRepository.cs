using System;
using SimonsVoss.CodingCase.Logic.Model;

namespace SimonsVoss.CodingCase.Logic
{
    public interface IDataRepository
    {
        IQueryable<QueryableEntity> QueryableEntities { get; }
        QueryableEntity? GetById(Guid id);
    }
}
