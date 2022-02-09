using CrudNetCore5.Data;
using CrudNetCore5.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudNetCore5.Controllers
{
    public class PeliculasController : Controller
    {

        private readonly ApplicationDbContext _context;

        public PeliculasController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Peliculas> listLibros = _context.Peliculas;

            return View(listLibros);
        }

        //http Get Create 
        public IActionResult Create()
        {
            return View();
        }

        //http Post Create 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Peliculas Peliculas)
        {
            if (ModelState.IsValid)
            {
                _context.Peliculas.Add(Peliculas);
                _context.SaveChanges();

                TempData["mensaje"] = "se guardo correctamente";
                return RedirectToAction("Index");
            }

            return View();
        }

        //http Get Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //obtener el libro 
            var libro = _context.Peliculas.Find(id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }


        //http Post Edit 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Peliculas Peliculas)
        {
            if (ModelState.IsValid)
            {
                _context.Peliculas.Update(Peliculas);
                _context.SaveChanges();

                TempData["mensaje"] = "se ha actualizado correctamente";
                return RedirectToAction("Index");
            }

            return View();
        }

        //http Get Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //obtener el libro 
            var libro = _context.Peliculas.Find(id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }
        //http Post Delete 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteLibro(int? id)
        {
            var libro = _context.Peliculas.Find(id);
            if (libro == null)
            {
                return NotFound();
            }
             _context.Peliculas.Remove(libro);
             _context.SaveChanges();

             TempData["mensaje"] = "La pelicula se elimino correctamente";
             return RedirectToAction("Index");
        }
    }

}
