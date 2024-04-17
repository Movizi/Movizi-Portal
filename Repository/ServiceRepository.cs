using Movizi_Portal.Data;
using Movizi_Portal.Models;
using Movizi_Portal.Repository.IRepository;

namespace Movizi_Portal.Repository
{
	public class ServiceRepository : Repository<Service>, IServiceRepository
	{
		private readonly ApplicationDbContext _db;
		public ServiceRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

		public void Update(Service service)
		{
			_db.Update(service);
		}
	}
}
