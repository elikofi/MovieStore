using System;
using System.ComponentModel.DataAnnotations;

namespace MovieStoreWebApp.Models.Domain
{
	public class Production
	{
		public int Id { get; set; }

		[Required]
		public string ProductionName { get; set; }
	}
}

