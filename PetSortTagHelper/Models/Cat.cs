namespace PetSortTagHelper.Models
{
    public class Cat : Pet
    {
        public int? PassportId { get; set; }
        public virtual Passport Passport { get; set; }
    }
}
