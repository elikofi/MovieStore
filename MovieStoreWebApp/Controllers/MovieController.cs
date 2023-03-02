using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieStoreWebApp.Models.Domain;
using MovieStoreWebApp.Repositories.Abstract;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieStoreWebApp.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService movieService;
        private readonly IDirectorService directorService;
        private readonly IGenreService genreService;
        private readonly IProductionService productionService;

        public MovieController(IMovieService movieService, IDirectorService directorService, IGenreService genreService, IProductionService productionService)
        {
            this.movieService = movieService;
            this.directorService = directorService;
            this.genreService = genreService;
            this.productionService = productionService;
        }

        // GET: /<controller>/
        public IActionResult Add()
        {
            var model = new Movie();
            model.DirectorList = directorService.GetAll().Select(a => new SelectListItem { Text=a.DirectorName,Value=a.Id.ToString()}).ToList();
            model.GenreList = genreService.GetAll().Select(a => new SelectListItem { Text = a.GenreName, Value = a.Id.ToString() }).ToList();
            model.ProductionList = productionService.GetAll().Select(a => new SelectListItem { Text = a.ProductionName, Value = a.Id.ToString() }).ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Movie model)
        {
            model.DirectorList = directorService.GetAll().Select(a => new SelectListItem { Text = a.DirectorName, Value = a.Id.ToString(),Selected=a.Id==model.DirectorId }).ToList();
            model.GenreList = genreService.GetAll().Select(a => new SelectListItem { Text = a.GenreName, Value = a.Id.ToString(),Selected=a.Id==model.GenreId }).ToList();
            model.ProductionList = productionService.GetAll().Select(a => new SelectListItem { Text = a.ProductionName, Value = a.Id.ToString(),Selected=a.Id==model.ProductionId }).ToList();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = movieService.Add(model);
            if (result)
            {
                TempData["msg"] = "New movie added Successfully";
                return RedirectToAction(nameof(Add));
            }
            TempData["msg"] = "Failed! Error has occured on server side.";
            return View(model);
        }

        //Update
        public IActionResult Update(int id)
        {
            var model = movieService.FindById(id);
            model.DirectorList = directorService.GetAll().Select(a => new SelectListItem { Text = a.DirectorName, Value = a.Id.ToString(), Selected = a.Id == model.DirectorId }).ToList();
            model.GenreList = genreService.GetAll().Select(a => new SelectListItem { Text = a.GenreName, Value = a.Id.ToString(), Selected = a.Id == model.GenreId }).ToList();
            model.ProductionList = productionService.GetAll().Select(a => new SelectListItem { Text = a.ProductionName, Value = a.Id.ToString(), Selected = a.Id == model.ProductionId }).ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(Movie model)
        {
            model.DirectorList = directorService.GetAll().Select(a => new SelectListItem { Text = a.DirectorName, Value = a.Id.ToString(), Selected = a.Id == model.DirectorId }).ToList();
            model.GenreList = genreService.GetAll().Select(a => new SelectListItem { Text = a.GenreName, Value = a.Id.ToString(), Selected = a.Id == model.GenreId }).ToList();
            model.ProductionList = productionService.GetAll().Select(a => new SelectListItem { Text = a.ProductionName, Value = a.Id.ToString(), Selected = a.Id == model.ProductionId }).ToList();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = movieService.Update(model);
            if (result)
            {
                TempData["msg"] = "Updated Successfully";
                return RedirectToAction(nameof(Add));
            }
            TempData["msg"] = "Failed to update. Error has occured on server side.";
            return View(model);
        }


        //delete

        public IActionResult Delete(int id)
        {
            var result = movieService.Delete(id);
            return RedirectToAction("GetAll");
        }

        //Get All method
        public IActionResult GetAll()
        {
            var data = movieService.GetAll();
            return View(data);
        }
    }
}

