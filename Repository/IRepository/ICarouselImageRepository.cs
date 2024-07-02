using Movizi_Portal.Models;

namespace Movizi_Portal.Repository.IRepository
{
	public interface ICarouselImageRepository : IRepository<CarouselImage>
	{
		void Update(CarouselImage carouselImage);
	}
}
