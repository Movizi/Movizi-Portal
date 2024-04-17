using Movizi_Portal.Data;

namespace Movizi_Portal.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _db;

		public IIndustryRepository Industry { get; set; }
		public UnitOfWork(ApplicationDbContext db)
		{
			_db = db;
			Industry = new IndustryRepository(db);
		}

		public void Save()
		{
			_db.SaveChanges();
		}
	}
}
