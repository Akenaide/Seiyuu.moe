﻿using SeiyuuMoe.Contracts.SearchCriteria;
using SeiyuuMoe.Data.Model;
using SeiyuuMoe.Repositories.Utilities;
using System;
using System.Linq.Expressions;

namespace SeiyuuMoe.BusinessServices.SearchCriteria
{
	internal class SeasonSearchCriteriaService : ISeasonSearchCriteriaService
	{
		public SeasonSearchCriteriaService()
		{
		}

		public Expression<Func<Season, bool>> BuildExpression(SeasonSearchCriteria searchCriteria)
		{
			var predicate = PredicateBuilder.True<Season>();
			return searchCriteria != null ? ExtendExpressionWithSearchCriteria(predicate, searchCriteria) : predicate;
		}

		private Expression<Func<Season, bool>> ExtendExpressionWithSearchCriteria(Expression<Func<Season, bool>> predicate, SeasonSearchCriteria searchCriteria)
		{
			return predicate
				.And(!string.IsNullOrWhiteSpace(searchCriteria.Name), () => season => season.Name.Contains(searchCriteria.Name, StringComparison.InvariantCultureIgnoreCase))
				.And(searchCriteria.Year.HasValue, () => season => season.Year.Equals(searchCriteria.Year));
		}
	}
}