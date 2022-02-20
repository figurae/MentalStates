using System;

namespace MentalStates.Models
{
    public class Item
    {
        public int      ItemId { get; set; }
        public string   Title { get; set; } = string.Empty;
        public string?  Description { get; set; }
        public float    Value { get; set; }
        public string?  Notes { get; set; }
        public ItemType Type { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        public enum ItemType
        {
            Slider,
            Note,
            NoType
        }
    }
}