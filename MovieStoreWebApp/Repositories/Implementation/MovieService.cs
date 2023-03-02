using System;
using System.Diagnostics.Eventing.Reader;
using MovieStoreWebApp.Models.Domain;
using MovieStoreWebApp.Repositories.Abstract;

namespace MovieStoreWebApp.Repositories.Implementation
{
	public class MovieService : IMovieService
	{
        private readonly DatabaseContext context;

		public MovieService(DatabaseContext context)
		{
            this.context = context;
		}

        //Add method
        public bool Add(Movie model)
        {
            try
            {
                context.Movie.Add(model);
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
                if (data == null) return false;
                context.Movie.Remove(data);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Movie FindById(int id)
        {
            return context.Movie.Find(id);
        }

        public IEnumerable<Movie> GetAll()
        {
            var data = (from movie in context.Movie
                        join director in context.Director on movie.DirectorId equals director.Id
                        join genre in context.Genre on movie.GenreId equals genre.Id
                        join production in context.Production on movie.ProductionId equals production.Id
                        select new Movie
                        {
                            Id = movie.Id,
                            DirectorId = movie.DirectorId,
                            GenreId = movie.GenreId,
                            TotalMinutes = movie.TotalMinutes,
                            ProductionId = movie.ProductionId,
                            Title = movie.Title,
                            DirectorName = director.DirectorName,
                            GenreName = genre.GenreName,
                            ProductionName = production.ProductionName
                        }).ToList();
            return data;
        }

        public bool Update(Movie model)
        {
            try
            {
                context.Movie.Update(model);
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

