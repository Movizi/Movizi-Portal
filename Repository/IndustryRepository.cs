﻿using Movizi_Portal.Data;
using Movizi_Portal.Models;
using Movizi_Portal.Repository.IRepository;

namespace Movizi_Portal.Repository
{
	public class IndustryRepository : Repository<Industry>, IIndustryRepository
	{
		private readonly ApplicationDbContext _db;
		public IndustryRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

		public void Update(Industry industry)
		{
			_db.Industries.Update(industry);
		}
	}
}
