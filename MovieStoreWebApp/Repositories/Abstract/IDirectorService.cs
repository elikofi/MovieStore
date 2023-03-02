using System;
using MovieStoreWebApp.Models.Domain;

namespace MovieStoreWebApp.Repositories.Abstract
{
	public interface IDirectorService
	{
		bool Add(Director model);

		bool Update(Director model);

		bool Delete(int id);

		Director FindById(int id);

		IEnumerable<Director> GetAll();
	}
}

