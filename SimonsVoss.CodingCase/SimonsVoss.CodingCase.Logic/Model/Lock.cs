using System;
using SimonsVoss.CodingCase.Logic.Model;

namespace SimonsVoss.CodingCase.Logic.Model
{
    public class Lock : QueryableEntity
    {
        public Guid BuildingId { get; set; }
        public Building? BuildingOfLock { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public string Floor { get; set; }
        public string RoomNumber { get; set; }
        public string Description { get; set; }

        public override string DisplayName => Name;

        private readonly Dictionary<string, int> fieldToWeightMapping = new Dictionary<string, int>
        {
            { nameof(Lock.Type), 3},
            { nameof(Lock.Name), 10},
            { nameof(Lock.SerialNumber), 8},
            { nameof(Lock.Floor), 6},
            { nameof(Lock.RoomNumber), 6},
            { nameof(Lock.Description), 6},
        };
        protected override Dictionary<string, int> FieldToWeightMapping => fieldToWeightMapping;

        private readonly Dictionary<string, int> buildingFieldsToWeightMapping = new Dictionary<string, int>
        {
            { nameof(Building.Name), 6},
            { nameof(Building.ShortCut), 5},
            { nameof(Building.Description), 0}
        };

        public Lock(Guid id, Guid buildingId, string type, string name, string serialNumber, string floor, string roomNumber, string description) : base(id)
        {
            BuildingId = buildingId;
            Type = type;
            Name = name;
            SerialNumber = serialNumber;
            Floor = floor;
            RoomNumber = roomNumber;
            Description = description;
        }

        public override int GetScore(string searchString)
        {
            var ownFieldScore = this.GetScoreForOwnFields(searchString);
            var buildingFieldScore = BuildingOfLock?.GetScoreForFields(searchString, buildingFieldsToWeightMapping) ?? -1;

            var hasScore = ownFieldScore >= 0 || buildingFieldScore >= 0;
            if (!hasScore)
            {
                return -1;
            }

            return Math.Max(0, ownFieldScore) + Math.Max(0, buildingFieldScore);
        }
    }
}

