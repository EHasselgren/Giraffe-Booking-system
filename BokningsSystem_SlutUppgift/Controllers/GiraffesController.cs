using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BokningsSystem_SlutUppgift.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BokningsSystem_SlutUppgift.Controllers
{
    public class GiraffesController : Controller
    {
        public IActionResult Index()
        {

            var giraffes = DbContext.Giraffes;

            return View(giraffes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(Giraffe giraffe)
        {
            giraffe.Id = Guid.NewGuid();
            giraffe.Name = giraffe.Name;
            giraffe.PicId = giraffe.PicId;
            DbContext.Giraffes.Add(giraffe);

            return Redirect("https://localhost:44338/Giraffes");

        }

        public IActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giraffe = DbContext.Giraffes.SingleOrDefault(g => g.Id == id);

            if (giraffe == null)
            {
                return NotFound();
            }

            return View(giraffe);
        }

        [HttpPost]
        public IActionResult Edit(Giraffe giraffe)
        {
            if (ModelState.IsValid)
            {
                var giraffeIndex = DbContext.Giraffes.FindIndex(g => g.Id == giraffe.Id);

                if (giraffeIndex == -1)
                {
                    return NotFound();
                }

                DbContext.Giraffes[giraffeIndex] = giraffe;

                return RedirectToAction(nameof(Index));
            }
            return View(giraffe);
        }

        public IActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giraffe = DbContext.Giraffes.FirstOrDefault(g => g.Id == id);

            if(giraffe == null)
            {
                return NotFound();
            }

            return View(giraffe);
        }

        [HttpPost]
        public IActionResult Delete(Giraffe giraffe)
        {
            var giraffeToDelete = DbContext.Giraffes.FirstOrDefault(g => g.Id == giraffe.Id);

            if (giraffeToDelete == null)
            {
                return NotFound();
            }

            DbContext.Giraffes.Remove(giraffeToDelete);

            return RedirectToAction("Index");
        }

        
    }

}
