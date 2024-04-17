using System.ComponentModel.DataAnnotations;

namespace Movizi_Portal.Models
{
	public class Industry
	{
		public int Id { get; set; }
		[Required]
		[MaxLength(20)]
		public string Name { get; set; }
	}
}
