using System;
namespace SimonsVoss.CodingCase.Logic.Model
{
    public class Medium
    {
        public Guid Id { get; set; }
        public Guid GroupId { get; set; }
        public string Type { get; set; }
        public string Owner { get; set; }
        public string SerialNumber { get; set; }
        public string Description { get; set; }

        public Medium(Guid id, Guid groupId, string type, string owner, string serialNumber, string description)
        {
            Id = id;
            GroupId = groupId;
            Type = type;
            Owner = owner;
            SerialNumber = serialNumber;
            Description = description;
        }
    }
}

