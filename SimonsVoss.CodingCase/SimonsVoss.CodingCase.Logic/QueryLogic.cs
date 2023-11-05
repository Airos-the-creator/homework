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

        public ItemDetails GetItemDetails(Guid itemId)
        {
            var item = this.dataRepository.GetById(itemId);
            if (item == null)
            {
                throw new ArgumentException($"The provided id {itemId} does not match any element in the repository");
            }
            var details = new ItemDetails();
            details.Properties = item.GetQueryableFieldsWithValues().Select(p => new ItemDetailProperty(p.Item1, p.Item2)).ToList();
            return details;
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

