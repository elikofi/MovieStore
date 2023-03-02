using System;
using MovieStoreWebApp.Models.Domain;
using MovieStoreWebApp.Repositories.Abstract;

namespace MovieStoreWebApp.Repositories.Implementation
{
	public class ProductionService : IProductionService
	{
        private readonly DatabaseContext context;

        public ProductionService(DatabaseContext context)
		{
            this.context = context;
		}

        //Add method
        public bool Add(Production model)
        {
            try
            {
                context.Production.Add(model);
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

                context.Production.Remove(data);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Production FindById(int id)
        {
            return context.Production.Find(id);
        }

        public IEnumerable<Production> GetAll()
        {
            return context.Production.ToList();
        }

        public bool Update(Production model)
        {
            try
            {
                context.Production.Update(model);
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

