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

        Core core = new Core(null, new Data.EFCore.EfRepository());

        // GET: MovieController
        public ActionResult Index()
        {
            return View(core.Repo.Query<Movie>().ToList());
        }

        // GET: MovieController/Details/5
        public ActionResult Details(int id)
        {
            return View(core.Repo.GetById<Movie>(id));
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
                core.Repo.Add(movie);
                core.Repo.Save();
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
            return View(core.Repo.GetById<Movie>(id));

        }

        // POST: MovieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Movie movie)
        {
            try
            {
                core.Repo.Update(movie);
                core.Repo.Save();
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
            return View(core.Repo.GetById<Movie>(id));

        }

        // POST: MovieController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                core.Repo.DeleteById<Movie>(id);
                core.Repo.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
