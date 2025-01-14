﻿using SeiyuuMoe.Contracts.SearchCriteria;
using SeiyuuMoe.Data.Model;
using SeiyuuMoe.Repositories.Utilities;
using System;
using System.Linq.Expressions;

namespace SeiyuuMoe.BusinessServices.SearchCriteria
{
	public class AnimeSearchCriteriaService : IAnimeSearchCriteriaService
	{
		public AnimeSearchCriteriaService()
		{
		}

		public Expression<Func<Anime, bool>> BuildExpression(AnimeSearchCriteria searchCriteria)
		{
			var predicate = PredicateBuilder.True<Anime>();
			return searchCriteria != null ? ExtendExpressionWithSearchCriteria(predicate, searchCriteria) : predicate;
		}

		private Expression<Func<Anime, bool>> ExtendExpressionWithSearchCriteria(Expression<Func<Anime, bool>> predicate, AnimeSearchCriteria searchCriteria)
		{
			return predicate
				.And(searchCriteria.MalId != null && searchCriteria.MalId.Count > 0, () => anime => searchCriteria.MalId.Contains(anime.MalId))
				.And(!string.IsNullOrWhiteSpace(searchCriteria.Title), () => anime =>
					anime.Title.Contains(searchCriteria.Title, StringComparison.InvariantCultureIgnoreCase) ||
					(!string.IsNullOrWhiteSpace(anime.JapaneseTitle) && anime.JapaneseTitle.Contains(searchCriteria.Title, StringComparison.InvariantCultureIgnoreCase)) ||
					(!string.IsNullOrWhiteSpace(anime.EnglishTitle) && anime.EnglishTitle.Contains(searchCriteria.Title, StringComparison.InvariantCultureIgnoreCase)) ||
					(!string.IsNullOrWhiteSpace(anime.TitleSynonyms) && anime.TitleSynonyms.Contains(searchCriteria.Title, StringComparison.InvariantCultureIgnoreCase)))
				.And(searchCriteria.SeasonId.HasValue, () => anime => searchCriteria.SeasonId.Equals(anime.SeasonId.Value))
				.And(searchCriteria.AnimeTypeId.HasValue && searchCriteria.AnimeTypeId.Value > 0, () => anime => searchCriteria.AnimeTypeId.Equals(anime.TypeId.Value));
		}
	}
}