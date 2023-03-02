using System;
using System.ComponentModel.DataAnnotations;

namespace MovieStoreWebApp.Models.Domain
{
	public class Genre
	{
		public int Id { get; set; }

		[Required]
		public string GenreName { get; set; }
	}
}

