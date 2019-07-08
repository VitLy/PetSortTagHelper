using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetSortTagHelper.Models
{
    public class Vaccine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Producer { get; set; }
        public string Country { get; set; }
        public decimal Price { get; set; }
        
        public virtual ICollection<Disease> Diseases {get;set;}

    }
}
