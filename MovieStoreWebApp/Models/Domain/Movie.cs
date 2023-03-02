using System;
using System.ComponentModel.DataAnnotations;

namespace MovieStoreWebApp.Models.Domain
{
	public class Movie
	{
		public int Id { get; set; }

		[Required]
		public string Title { get; set; }

        [Required]
        public int TotalMinutes { get; set; }

        [Required]
        public int GenreId { get; set; }

        [Required]
        public int ProductionId { get; set; }

        [Required]
        public int DirectorId { get; set; }

	}
}

