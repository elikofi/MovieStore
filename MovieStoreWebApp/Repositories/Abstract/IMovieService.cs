using System;
using MovieStoreWebApp.Models.Domain;

namespace MovieStoreWebApp.Repositories.Abstract
{
	public interface IMovieService
	{
		bool Add(Movie model);

		bool Update(Movie model);

		bool Delete(int id);

		Movie FindById(int id);

		IEnumerable<Movie> GetAll();
	}
}

