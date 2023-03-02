using System;
using MovieStoreWebApp.Models.Domain;

namespace MovieStoreWebApp.Repositories.Abstract
{
	public interface IProductionService
	{
		bool Add(Production model);

		bool Update(Production model);

		bool Delete(int id);

		Production FindById(int id);

		IEnumerable<Production> GetAll();
	}
}

