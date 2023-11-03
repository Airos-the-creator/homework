using System;
using SimonsVoss.CodingCase.Contract.Dto;

namespace SimonsVoss.CodingCase.Logic
{
    public class QueryLogic : IQueryLogic
    {
        public QueryLogic()
        {
        }

        public IList<QueryResult> QueryData(string searchString)
        {
            return new List<QueryResult>();
        }
    }
}

