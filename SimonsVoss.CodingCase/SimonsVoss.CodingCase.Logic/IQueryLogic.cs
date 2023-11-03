using System;
using SimonsVoss.CodingCase.Contract.Dto;

namespace SimonsVoss.CodingCase.Logic
{
    public interface IQueryLogic
    {
        IList<QueryResult> QueryData(string searchString);
    }
}

