using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movizi_Portal.Models
{
	public class Project
	{
		public int Id { get; set; }
		[Required]
		[MaxLength(20)]
		public string Title { get; set; }
		[Required]
		[MaxLength(50)]
		public string Subtitle { get; set; }
		public string? WebLink { get; set; }
		public int IndustryId { get; set; }
		[Required]
		[ForeignKey("IndustryId")]
		public Industry Industry { get; set; }
		public ICollection<ProjectService>? ProjectServices { get; set; }
		public TimeSpan? Duration { get; set; }
		[Required]
		[MaxLength(200)]
		public string Description { get; set; }
		[Required]
		public string ImageUrl { get; set; }
		public string? ColorsImageUrl { get; set; }
		public string? FontImageUrl { get; set; }
		public List<string>? SliderImages { get; set; }
	}
}
