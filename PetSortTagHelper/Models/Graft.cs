using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetSortTagHelper.Models
{
    public class Graft
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }

        public int? VaccineId { get; set; }
        public virtual Vaccine Vaccine { get; set; }
    }
}
