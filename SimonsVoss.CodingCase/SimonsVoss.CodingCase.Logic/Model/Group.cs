using System;
namespace SimonsVoss.CodingCase.Logic.Model
{
    public class Group
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Group(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}

