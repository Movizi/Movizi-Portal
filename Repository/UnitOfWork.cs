using Movizi_Portal.Data;
using Movizi_Portal.Repository.IRepository;

namespace Movizi_Portal.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _db;

		public IProjectRepository Project { get; set; }
		public IIndustryRepository Industry { get; set; }
		public IServiceRepository Service { get; set; }
		public UnitOfWork(ApplicationDbContext db)
		{
			_db = db;
			Project = new ProjectRepository(db);
			Industry = new IndustryRepository(db);
			Service = new ServiceRepository(db);
		}

		public void Save()
		{
			_db.SaveChanges();
		}
	}
}
