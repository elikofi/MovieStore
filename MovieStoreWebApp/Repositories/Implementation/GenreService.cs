using System;
using MovieStoreWebApp.Models.Domain;
using MovieStoreWebApp.Repositories.Abstract;

namespace MovieStoreWebApp.Repositories.Implementation
{
    public class GenreService : IGenreService
    {
        private readonly DatabaseContext context;

        public GenreService(DatabaseContext context)
        {
            this.context = context;
        }

        //Add method
        public bool Add(Genre model)
        {
            try
            {
                context.Genre.Add(model);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Delete method
        public bool Delete(int id)
        {
            try
            {
                var data = this.FindById(id);
                if (data == null)
                    return false;

                context.Genre.Remove(data);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Find by method
        public Genre FindById(int id)
        {
            return context.Genre.Find(id);
        }


        //Get All method
        public IEnumerable<Genre> GetAll()
        {
            return context.Genre.ToList();
        }



        //Update method
        public bool Update(Genre model)
        {
            try
            {
                context.Genre.Update(model);
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

