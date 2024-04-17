using Movizi_Portal.Models;

namespace Movizi_Portal.Repository.IRepository
{
	public interface IProjectRepository : IRepository<Project>
	{
		void Update(Project project);
	}
}
