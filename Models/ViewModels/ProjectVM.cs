using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Movizi_Portal.Models.ViewModels
{
	public class ProjectVM
	{
		[ValidateNever]
		public Project Project { get; set; }
		[ValidateNever]
		public ProjectService ProjectService { get; set; }
		[ValidateNever]
		public CarouselImage CarouselImage { get; set; }

		[ValidateNever]
		public List<int> SelectedServices { get; set; }
		[ValidateNever]
		public List<CarouselImage> CarouselImageList { get; set; }
		[ValidateNever]
		public IEnumerable<SelectListItem> IndustryList { get; set; }
		[ValidateNever]
		public IEnumerable<SelectListItem> ServiceList { get; set; }
	}
}
