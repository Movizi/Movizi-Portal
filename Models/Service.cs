using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movizi_Portal.Models
{
	public class Service
	{
		public int Id { get; set; }
		[Required]
		[MaxLength(20)]
		public string Name { get; set; }
		public ICollection<ProjectService>? ProjectServices { get; set; }
	}
}
