using System;

namespace SimonsVoss.CodingCase.Logic.Model
{
    public class Building : QueryableEntity
    {
        public string ShortCut { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public override string DisplayName => Name;

        private readonly Dictionary<string, int> fieldToWeightMapping = new Dictionary<string, int>
        {
            { nameof(Building.Name), 9},
            { nameof(Building.ShortCut), 7},
            { nameof(Building.Description), 5}
        };
        protected override Dictionary<string, int> FieldToWeightMapping => fieldToWeightMapping;

        public Building(Guid id, string shortCut, string name, string description) : base(id)
        {
            this.ShortCut = shortCut;
            this.Name = name;
            this.Description = description;
        }

        public override int GetScore(string searchString)
        {
            return this.GetScoreForOwnFields(searchString);
        }
    }
}

