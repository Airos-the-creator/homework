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
            var data = this.dataRepository.QueryableEntities
                .Select(e => new QueryResult(e.DisplayName, e.Id, e.GetScore(searchString)))
                .Where(qr => qr.Score >= 0)
                .OrderByDescending(qr => qr.Score)
                .ToList();
            return data;
        }
    }
}

