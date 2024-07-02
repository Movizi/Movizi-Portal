using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movizi_Portal.Models
{
	public class ProjectService
	{
		[Key]
		public Guid Id { get; set; }
		public int ProjectId { get; set; }
		[ValidateNever]
		public Project Project { get; set; }

		public int ServiceId { get; set; }
		[ValidateNever]
		public Service Service { get; set; }
	}
}
