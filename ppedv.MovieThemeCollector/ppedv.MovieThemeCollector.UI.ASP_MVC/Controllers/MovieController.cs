using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ppedv.MovieThemeCollector.Contracts;
using ppedv.MovieThemeCollector.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ppedv.MovieThemeCollector.UI.ASP_MVC.Controllers
{
    public class MovieController : Controller
    {

        Core core = new Core(null, new Data.EFCore.EfUnitOfWork());

        // GET: MovieController
        public ActionResult Index()
        {
            return View(core.UnitOfWork.GetRepo<Movie>().Query().ToList());
        }

        // GET: MovieController/Details/5
        public ActionResult Details(int id)
        {
            return View(core.UnitOfWork.GetRepo<Movie>().GetById(id));
        }

        // GET: MovieController/Create
        public ActionResult Create()
        {
            return View(new Movie() { Title = "NEU" });
        }

        // POST: MovieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            try
            {
                core.UnitOfWork.GetRepo<Movie>().Add(movie);
                core.UnitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MovieController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(core.UnitOfWork.GetRepo<Movie>().GetById(id));

        }

        // POST: MovieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Movie movie)
        {
            try
            {
                core.UnitOfWork.GetRepo<Movie>().Update(movie);
                core.UnitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MovieController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(core.UnitOfWork.GetRepo<Movie>().GetById(id));

        }

        // POST: MovieController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                core.UnitOfWork.GetRepo<Movie>().DeleteById(id);
                core.UnitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
