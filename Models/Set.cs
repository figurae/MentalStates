using System;
using System.Collections;
using System.Collections.Generic;

namespace MentalStates.Models
{
    public class Set
    {
        public int          SetId { get; set; }
        public List<Item>   Items { get; set; } = new List<Item>();
        public string?      Name { get; set; }
        public string?      Description { get; set; }
        public DateTime     Created { get; set; }
        public DateTime     Updated { get; set; }
    }
}