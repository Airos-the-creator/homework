using System;
namespace SimonsVoss.CodingCase.Logic.Model
{
    public class Lock
    {
        public Guid Id { get; set; }
        public Guid BuildingId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public string Floor { get; set; }
        public string RoomNumber { get; set; }
        public string Description { get; set; }

        public Lock(Guid id, Guid buildingId, string type, string name, string serialNumber, string floor, string roomNumber, string description)
        {
            Id = id;
            BuildingId = buildingId;
            Type = type;
            Name = name;
            SerialNumber = serialNumber;
            Floor = floor;
            RoomNumber = roomNumber;
            Description = description;
        }
    }
}

