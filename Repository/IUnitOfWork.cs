namespace Movizi_Portal.Repository
{
	public interface IUnitOfWork
	{
		IIndustryRepository Industry { get; }
		void Save();
	}
}
