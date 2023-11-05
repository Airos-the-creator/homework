using System;
using SimonsVoss.CodingCase.Contract.Dto;

namespace SimonsVoss.CodingCase.Logic
{
    public interface IQueryLogic
    {
        ItemDetails GetItemDetails(Guid itemId);
        IList<QueryResult> QueryData(string searchString);
    }
}

