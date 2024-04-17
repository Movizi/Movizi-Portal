using Movizi_Portal.Data;
using Movizi_Portal.Models;

namespace Movizi_Portal.Repository
{
	public class IndustryRepository : Repository<Industry>, IIndustryRepository
	{
		private readonly ApplicationDbContext _db;
		public IndustryRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

		public void Update(Industry industry)
		{
			_db.Industries.Update(industry);
		}

		public void Save()
		{
			_db.SaveChanges();
		}
	}
}
