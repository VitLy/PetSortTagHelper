using System;
using System.Collections.Generic;

namespace PetSortTagHelper.Models
{
    public class Passport
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime GrantDate { get; set; }
        public string PetOwnerstName { get; set;}

        public virtual ICollection<Graft> Grafts { get; set; }
    }
}
