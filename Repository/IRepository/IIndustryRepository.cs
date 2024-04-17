using Movizi_Portal.Models;

namespace Movizi_Portal.Repository.IRepository
{
    public interface IIndustryRepository : IRepository<Industry>
    {
        void Update(Industry industry);
    }
}
