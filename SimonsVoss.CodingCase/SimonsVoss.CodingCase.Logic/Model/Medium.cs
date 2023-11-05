using System;

namespace SimonsVoss.CodingCase.Logic.Model
{
    public class Medium : QueryableEntity
    {
        public Guid GroupId { get; set; }
        public Group? GroupOfMedium { get; set; }
        public string Type { get; set; }
        public string Owner { get; set; }
        public string SerialNumber { get; set; }
        public string Description { get; set; }

        public override string DisplayName => $"{Type} of {Owner}";

        private readonly Dictionary<string, int> fieldToWeightMapping = new Dictionary<string, int>
        {
            { nameof(Medium.Type), 3},
            { nameof(Medium.Owner), 10},
            { nameof(Medium.SerialNumber), 8},
            { nameof(Medium.Description), 6},
        };
        protected override Dictionary<string, int> FieldToWeightMapping => fieldToWeightMapping;

        private readonly Dictionary<string, int> groupFieldToWeightMapping = new Dictionary<string, int>
        {
            { nameof(Group.Name), 8},
            { nameof(Group.Description), 0},
        };

        public Medium(Guid id, Guid groupId, string type, string owner, string serialNumber, string description) : base(id)
        {
            GroupId = groupId;
            Type = type;
            Owner = owner;
            SerialNumber = serialNumber;
            Description = description;
        }

        public override int GetScore(string searchString)
        {
            var ownScore = this.GetScoreForOwnFields(searchString);
            var groupScore = this.GroupOfMedium?.GetScoreForFields(searchString, groupFieldToWeightMapping) ?? -1;

            var hasScore = ownScore >= 0 || groupScore >= 0;
            if (!hasScore)
            {
                return -1;
            }

            return Math.Max(0, ownScore) + Math.Max(0, groupScore);
        }

        public override IList<Tuple<string, string?>> GetQueryableFieldsWithValues()
        {
            var propertiesWithValues = base.GetQueryableFieldsWithValues();
            propertiesWithValues.Add(new Tuple<string, string?>("Group", this.GroupOfMedium?.DisplayName));
            return propertiesWithValues;
        }
    }
}

