using System;
namespace SimonsVoss.CodingCase.Logic.Model
{
    public abstract class QueryableEntity
    {
        public abstract string DisplayName { get; }

        public Guid Id { get; set; }

        public QueryableEntity(Guid id)
        {
            this.Id = id;
        }

        protected abstract Dictionary<string, int> FieldToWeightMapping { get; }

        public abstract int GetScore(string searchString);

        protected int GetScoreForOwnFields(string searchString)
        {
            return this.GetScoreForFields(searchString, this.FieldToWeightMapping);
        }

        public int GetScoreForFields(string searchString, Dictionary<string, int> fieldToWeightMapping)
        {
            var score = -1;
            foreach (var prop in this.GetType().GetProperties())
            {
                if (fieldToWeightMapping.TryGetValue(prop.Name, out int weight))
                {
                    if (this.TryGetScoreForStringField(prop.GetValue(this)?.ToString(), searchString, weight, out int fieldScore))
                    {
                        score = score != -1 ? score + fieldScore : fieldScore;
                    }
                }
            }
            return score;
        }

        protected bool TryGetScoreForStringField(string? fieldValue, string searchString, int weight, out int score)
        {
            if (fieldValue == null || !fieldValue.Contains(searchString, StringComparison.InvariantCultureIgnoreCase))
            {
                score = 0;
                return false;
            }

            if (string.Equals(fieldValue, searchString, StringComparison.InvariantCultureIgnoreCase))
            {
                score = weight * 10;
            } else
            {
                score = weight;
            }
            return true;
        }
    }
}

