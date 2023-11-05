using System;
namespace SimonsVoss.CodingCase.Contract.Dto
{
    public class ItemDetails
    {
        public IList<ItemDetailProperty> Properties { get; set; } = new List<ItemDetailProperty>();
        public ItemDetails()
        {
        }
    }
}

