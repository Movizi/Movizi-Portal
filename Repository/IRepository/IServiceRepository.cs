using Movizi_Portal.Models;

namespace Movizi_Portal.Repository.IRepository
{
	public interface IServiceRepository : IRepository<Service>
	{
		void Update(Service service);
	}
}
