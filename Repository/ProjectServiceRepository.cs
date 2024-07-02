using Movizi_Portal.Data;
using Movizi_Portal.Models;
using Movizi_Portal.Repository.IRepository;

namespace Movizi_Portal.Repository
{
	public class ProjectServiceRepository : Repository<ProjectService>, IProjectServiceRepository
	{
		private readonly ApplicationDbContext _db;
		public ProjectServiceRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

		public void Update(ProjectService projectService)
		{
			_db.ProjectServices.Update(projectService);
		}
	}
}
