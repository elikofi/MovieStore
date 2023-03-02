using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

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


        [NotMapped]
        public string ? DirectorName { get; set; }
        [NotMapped]
        public string ? GenreName { get; set; }
        [NotMapped]
        public string ? ProductionName { get; set; }


        [NotMapped]
        public List<SelectListItem> ? DirectorList { get; set; }

        [NotMapped]
        public List<SelectListItem> ? GenreList { get; set; }

        [NotMapped]
        public List<SelectListItem> ? ProductionList { get; set; }
    }
}

