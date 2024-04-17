using Movizi_Portal.Data;
using Movizi_Portal.Models;
using Movizi_Portal.Repository.IRepository;

namespace Movizi_Portal.Repository
{
	public class ProjectRepository : Repository<Project>, IProjectRepository
	{
		private readonly ApplicationDbContext _db;
		public ProjectRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

		public void Update(Project project)
		{
			_db.Projects.Update(project);
		}
	}
}
