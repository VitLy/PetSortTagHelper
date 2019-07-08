using PetSortTagHelper.Data.Interfaces;
using PetSortTagHelper.Models;

namespace PetSortTagHelper.Data.Repository
{
    public class CatRepository: Repository<Cat>,ICatRepository
    {
        public CatRepository(PetContext context):base(context)
        {

        }
    }
}
