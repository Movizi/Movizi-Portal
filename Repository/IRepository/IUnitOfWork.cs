﻿namespace Movizi_Portal.Repository.IRepository
{
	public interface IUnitOfWork
	{
		IProjectRepository Project { get; }
		IIndustryRepository Industry { get; }
		IServiceRepository Service { get; }
		void Save();
	}
}
