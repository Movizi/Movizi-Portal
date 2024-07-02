using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movizi_Portal.Models
{
	public class Project
	{
		private DateTime _startDate = DateTime.Today;
		private DateTime _endDate = DateTime.Today;

		private void UpdateDuration()
		{
			ProjectDuration = (EndDate - StartDate).Days;
		}

		public int Id { get; set; }
		[Required]
		[MaxLength(20)]
		public string Title { get; set; }
		[Required]
		[MaxLength(50)]
		public string Subtitle { get; set; }
		public string? WebLink { get; set; }
		[Required]
		[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
		[DataType(DataType.Date)]
		public DateTime StartDate
		{
			get => _startDate;
			set
			{
				_startDate = value;
				UpdateDuration();
			}
		}
		[Required]
		[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
		[DataType(DataType.Date)]
		public DateTime EndDate
		{
			get => _endDate;
			set
			{
				_endDate = value;
				UpdateDuration();
			}
		}
		public int ProjectDuration { get; private set; }
		[Required]
		[MaxLength(200)]
		public string Description { get; set; }
		[ValidateNever]
		public string? ImageUrl { get; set; }
		[ValidateNever]
		public string? ColorsImageUrl { get; set; }
		[ValidateNever]
		public string? FontImageUrl { get; set; }

		[ValidateNever]
		public int IndustryId { get; set; }
		[ForeignKey("IndustryId")]
		[ValidateNever]
		public Industry Industry { get; set; }

		[ValidateNever]
		public List<CarouselImage> CarouselImages { get; set; }
		[ValidateNever]
		public List<ProjectService> ProjectServices { get; set; }
	}
}
