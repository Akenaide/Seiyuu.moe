﻿using System;

namespace SeiyuuMoe.Contracts.Dtos
{
	public class SeiyuuCardDto
	{
		public string Name { get; set; }

		public string ImageUrl { get; set; }

		public long MalId { get; set; }

		public string JapaneseName { get; set; }

		public DateTime? Birthday { get; set; }

		public string About { get; set; }
	}
}