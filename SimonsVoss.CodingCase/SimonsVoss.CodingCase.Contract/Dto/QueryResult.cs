using System;
namespace SimonsVoss.CodingCase.Contract.Dto
{
    public class QueryResult
    {
        public string DisplayName { get; set; }
        public Guid ItemId { get; set; }
        public int Score { get; set; }

        public QueryResult(string displayName, Guid itemId, int score)
        {
            DisplayName = displayName;
            ItemId = itemId;
            Score = score;
        }
    }
}

