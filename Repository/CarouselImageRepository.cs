using Movizi_Portal.Data;
using Movizi_Portal.Models;
using Movizi_Portal.Repository.IRepository;

namespace Movizi_Portal.Repository
{
	public class CarouselImageRepository : Repository<CarouselImage>, ICarouselImageRepository
	{
		private readonly ApplicationDbContext _db;
		public CarouselImageRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

		public void Update(CarouselImage carouselImage)
		{
			_db.CarouselImages.Update(carouselImage);
		}
	}
}
