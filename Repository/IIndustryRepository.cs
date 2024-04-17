using Movizi_Portal.Models;

namespace Movizi_Portal.Repository
{
	public interface IIndustryRepository : IRepository<Industry>
	{
		void Update(Industry industry);
		void Save();
	}
}
