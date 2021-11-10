using System;

namespace MentalStates.Models
{
    public class Item : ICloneable
    {
        public int ItemId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float Value { get; set; }
        public string Notes { get; set; }
        public ItemType Type { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        public Item Clone()
        {
            return (Item)this.MemberwiseClone();
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public enum ItemType
        {
            Slider,
            Note
        }
    }
}