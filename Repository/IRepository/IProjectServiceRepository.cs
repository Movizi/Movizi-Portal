using Movizi_Portal.Models;

namespace Movizi_Portal.Repository.IRepository
{
	public interface IProjectServiceRepository : IRepository<ProjectService>
	{
		void Update(ProjectService projectService);
	}
}
