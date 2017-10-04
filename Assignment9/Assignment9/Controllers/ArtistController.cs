using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment9.Controllers
{
    public class ArtistController : Controller
    {
        private Manager m = new Manager();

        // GET: Artist
        public ActionResult Index()
        {   
            return View(m.ArtistGetAll());
        }

        // GET: Artist/Details/5
        public ActionResult Details(int? id)
        {
            var o = m.ArtistGetById(id.GetValueOrDefault());

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

        // GET: Artist/Create
        [Authorize(Roles = "Admin,Executive")]
        public ActionResult Create()
        {
            var form = new ArtistAddForm();

            form.GenreList = new SelectList(m.GenreGetAll(), "Id", "Name");

            return View(form);

        }

        // POST: Artist/Create
        [Authorize(Roles = "Admin,Executive")]
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(ArtistAdd newItem)
        {
            // Validate the input
            if (!ModelState.IsValid)
            {
                return View(newItem);
            }

            // Process the input
            var addedItem = m.ArtistAdd(newItem);

            if (addedItem == null)
            {
                return View(newItem);
            }
            else
            {
                return RedirectToAction("details", new { id = addedItem.Id });
            }
        }


        [Authorize(Roles = "Admin,Coordinator")]
        [Route("Artist/{id}/AddAlbum")]
        public ActionResult AddAlbum(int? id)
        {
            var a = m.ArtistGetById(id.GetValueOrDefault());
            var b = m.AlbumGetOne(id.GetValueOrDefault());

            if (a == null)
            {
                return HttpNotFound();
            }
            else
            {
               
                var form = new AlbumAddForm();
                form.ArtistName = a.Name;
                form.GenreList = new SelectList(m.GenreGetAll(), "Id", "Name");
                return View(form);
            }
        }


        [Route("Artist/{id}/AddAlbum")]
        [Authorize(Roles = "Admin,Coordinator")]
        [HttpPost, ValidateInput(false)]
        public ActionResult AddAlbum(AlbumAdd newItem)
        {
            // Attempt to get the associated object
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
                // Attention - Must redirect to the Vehicles controller
                return RedirectToAction("Details", "Album", new { id = addedItem.Id });
            }
        }


        // GET: Artist/Edit/5
        [Authorize(Roles = "Admin,Executive")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Artist/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin,Executive")]
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

        // GET: Artist/Delete/5
        [Authorize(Roles = "Admin,Executive")]
        public ActionResult Delete(int? id)
        {
            var itemToDelete = m.ArtistGetById(id.GetValueOrDefault());

            if (itemToDelete == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(itemToDelete);
            }
        }

        // POST: Artist/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin,Executive")]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            var result = m.ArtistDelete(id.GetValueOrDefault());

            return RedirectToAction("Index");
        }
    }
}
