using System;
using System.ComponentModel.DataAnnotations;

namespace MovieStoreWebApp.Models.Domain
{
	public class Director
	{
		public int Id { get; set; }

		[Required]
		public string DirectorName { get; set; }
	}
}

