﻿using SeiyuuMoe.Data.Context;
using SeiyuuMoe.Data.Model;
using SeiyuuMoe.Repositories.Generic;

namespace SeiyuuMoe.Repositories.Repositories
{
	public class AnimeTypeRepository : CRUDEntityFrameworkRepository<AnimeType, ISeiyuuMoeContext, long>, IAnimeTypeRepository
	{
		public AnimeTypeRepository(ISeiyuuMoeContext dbContext) : base(dbContext, x => x.Id)
		{
		}
	}
}
