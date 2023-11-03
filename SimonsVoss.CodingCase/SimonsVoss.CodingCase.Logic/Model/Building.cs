using System;
namespace SimonsVoss.CodingCase.Logic.Model
{
    public class Building
    {
        public Guid Id { get; }
        public string ShortCut { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Building(Guid id, string shortCut, string name, string description)
        {
            this.Id = id;
            this.ShortCut = shortCut;
            this.Name = name;
            this.Description = description;
        }
    }
}

