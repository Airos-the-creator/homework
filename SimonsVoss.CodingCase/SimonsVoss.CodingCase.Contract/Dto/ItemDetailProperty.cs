using System;
namespace SimonsVoss.CodingCase.Contract.Dto
{
    public class ItemDetailProperty
    {
        public string Name { get; set; }
        public string? Value { get; set; }

        public ItemDetailProperty(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}

