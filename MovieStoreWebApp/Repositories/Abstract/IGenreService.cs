using System;
using MovieStoreWebApp.Models.Domain;

namespace MovieStoreWebApp.Repositories.Abstract
{
	public interface IGenreService
	{
		bool Add(Genre model);

        bool Update(Genre model);

        bool Delete(int id);

        Genre FindById(int id);

        IEnumerable<Genre> GetAll();
    }
}

