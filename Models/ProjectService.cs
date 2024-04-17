using System.ComponentModel.DataAnnotations;

namespace Movizi_Portal.Models
{
	public class ProjectService
	{
		[Key]
		public int Id { get; set; }
		public int ProjectId { get; set; }
		public Project Project { get; set; }

		public int ServiceId { get; set; }
		public Service Service { get; set; }
	}
}
