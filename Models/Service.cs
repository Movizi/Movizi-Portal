using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Movizi_Portal.Models
{
	public class Service
	{
		public int Id { get; set; }
		[Required]
		[MaxLength(20)]
		public string Name { get; set; }
		[ValidateNever]
		public List<ProjectService> ProjectServices { get; set; }
	}
}
