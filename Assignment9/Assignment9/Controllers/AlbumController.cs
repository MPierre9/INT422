using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment9.Controllers
{
    public class AlbumController : Controller
    {
        private Manager m = new Manager();

        // GET: Album
        public ActionResult Index()
        {   
            return View(m.AlbumGetAll());
        }

        // GET: Album/Details/5
        public ActionResult Details(int? id)
        {
            var o = m.AlbumGetOne(id.GetValueOrDefault());

            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                // Pass the object to the view
                return View(o);
            }
        }

        // GET: Album/Create
        [Authorize(Roles = "Admin,Coordinator")]
        public ActionResult Create()
        {
            var form = new AlbumAddForm();

            form.GenreList = new SelectList(m.GenreGetAll(), "Id", "Name");

            return View(form);
        }

        // POST: Album/Create
        [HttpPost]
        [Authorize(Roles = "Admin,Coordinator")]
        public ActionResult Create(AlbumAdd newItem)
        {
            // Validate the input
            if (!ModelState.IsValid)
            {
                return View(newItem);
            }

            // Process the input
            var addedItem = m.AlbumAdd(newItem);

            if (addedItem == null)
            {
                return View(newItem);
            }

            else
            {
                return RedirectToAction("details", new { id = addedItem.Id });
            }
        }

        // GET: Album/Edit/5
        [Authorize(Roles = "Admin,Coordinator")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Album/Edit/5
        [Authorize(Roles = "Admin,Coordinator")]
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Album/Delete/5
        [Authorize(Roles = "Admin,Coordinator")]
        public ActionResult Delete(int? id)
        {
            var itemToDelete = m.AlbumGetOne(id.GetValueOrDefault());

            if (itemToDelete == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(itemToDelete);
            }
        }

        // POST: Album/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin,Coordinator")]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            var result = m.AlbumDelete(id.GetValueOrDefault());

            return RedirectToAction("Index");
        }
    }
}
