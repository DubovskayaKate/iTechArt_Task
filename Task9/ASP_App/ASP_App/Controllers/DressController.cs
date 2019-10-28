using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_App.Controllers
{
    [Route("api/[controller]")]
    public class DressController : Controller
    {
        private List<Dress> _dresses;

        public DressController()
        {
            _dresses = new List<Dress>
            {
                new Dress("blue", 1),
                new Dress("red", 2),
                new Dress("green", 3),
                new Dress("pink", 4),
                new Dress("white", 5),
            };
        }
        // GET: Dress
        public List<Dress> Index()
        {
            return _dresses;
        }
        [HttpGet("[action]")]
        // GET: Dress/Details/5
        public Dress Details(int id)
        {
            foreach (var dress in _dresses)
            {
                if (dress.Id == id)
                    return dress;
            }

            return _dresses[_dresses.Count - 1];
        }
        //[HttpGet("[action]")]
        //// GET: Dress/Create
        //public ActionResult Create()
        //{
        //    var dress = new Dress();
        //    return CreatedAtAction("Added", new { id = dress.Id }, dress);
        //}

        // POST: Dress/Create
        [HttpPost("[action]")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            var dress = new Dress();
            return CreatedAtAction("Added", new {id = dress.Id}, dress);
        }

        //// GET: Dress/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Dress/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Dress/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Dress/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        public class Dress
        {
            public Dress() { }
            public Dress(string description, int id)
            {
                this.Id = id;
                this.Description = description;
            }
            public string Description;
            public int Id;
        }
    }
}