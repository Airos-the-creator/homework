using System;

namespace SimonsVoss.CodingCase.Logic.Model
{
    public class Group : QueryableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public override string DisplayName => Name;

        private readonly Dictionary<string, int> fieldToWeightMapping = new Dictionary<string, int>
        {
            { nameof(Group.Name), 9},
            { nameof(Group.Description), 5},
        };
        protected override Dictionary<string, int> FieldToWeightMapping => fieldToWeightMapping;

        public Group(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public override int GetScore(string searchString)
        {
            return this.GetScoreForOwnFields(searchString);
        }
    }
}

