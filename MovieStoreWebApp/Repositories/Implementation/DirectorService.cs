using System;
using MovieStoreWebApp.Models.Domain;
using MovieStoreWebApp.Repositories.Abstract;

namespace MovieStoreWebApp.Repositories.Implementation
{
	public class DirectorService : IDirectorService
	{
        private readonly DatabaseContext context;

		public DirectorService(DatabaseContext context)
		{
            this.context = context;
		}

        public bool Add(Director model)
        {
            try
            {
                context.Director.Add(model);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var data = this.FindById(id);
                if (data == null)
                    return false;
                context.Director.Remove(data);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Director FindById(int id)
        {
            return context.Director.Find(id);
        }

        public IEnumerable<Director> GetAll()
        {
            return context.Director.ToList();
        }

        public bool Update(Director model)
        {
            try
            {
                context.Director.Update(model);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

