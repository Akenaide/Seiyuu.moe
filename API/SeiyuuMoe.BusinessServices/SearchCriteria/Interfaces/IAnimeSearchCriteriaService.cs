﻿using SeiyuuMoe.Contracts.SearchCriteria;
using SeiyuuMoe.Data.Model;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SeiyuuMoe.BusinessServices.SearchCriteria
{
	public interface IAnimeSearchCriteriaService
	{
		Expression<Func<Anime, bool>> BuildExpression(AnimeSearchCriteria searchCriteria);
	}
}