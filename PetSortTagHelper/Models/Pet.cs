using System;

namespace PetSortTagHelper.Models
{
    public abstract class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public DateTime Birthday { get; set; }
    }
}
