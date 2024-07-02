using System.ComponentModel.DataAnnotations;

namespace Movizi_Portal.Models
{
	public class CarouselImage
	{
		[Key]
		public Guid Id { get; set; }
		public int ProjectId { get; set; }
		public string ImageUrl { get; set; }

		public Project Project { get; set; }
	}
}
