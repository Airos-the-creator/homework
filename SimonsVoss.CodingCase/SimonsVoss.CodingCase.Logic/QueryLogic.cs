using System;
using SimonsVoss.CodingCase.Contract.Dto;

namespace SimonsVoss.CodingCase.Logic
{
    public class QueryLogic : IQueryLogic
    {
        private readonly IDataRepository dataRepository;
        public QueryLogic(IDataRepository dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        public IList<QueryResult> QueryData(string searchString)
        {
            var locks = this.dataRepository.Locks.FirstOrDefault(l => l.Name.ToLower().Contains(searchString));
            return new List<QueryResult> { new QueryResult(locks.Name, locks.Id)};
        }
    }
}

