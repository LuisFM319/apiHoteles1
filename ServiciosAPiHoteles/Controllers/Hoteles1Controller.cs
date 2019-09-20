using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ServiciosWebDatos1.Modelo;

namespace ServiciosAPiHoteles.Controllers
{
    public class Hoteles1Controller : ApiController
    {
        private logisticaEntities db = new logisticaEntities();

        // GET: Todos los Hoteles
        public IQueryable<Hoteles> GetHoteles()
        {
            return db.Hoteles;
        }

        // GET: Hotel especifico
        [ResponseType(typeof(Hoteles))]
        public IHttpActionResult GetHoteles(int id)
        {
            Hoteles hoteles = db.Hoteles.Find(id);
            if (hoteles == null)
            {
                return NotFound();
            }

            return Ok(hoteles);
        }

        // PUT: Actualizar un Hotel
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHoteles(int id, Hoteles hoteles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hoteles.Id)
            {
                return BadRequest();
            }

            db.Entry(hoteles).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: Crear un Hotel
        [ResponseType(typeof(Hoteles))]
        public IHttpActionResult PostHoteles(Hoteles hoteles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Hoteles.Add(hoteles);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hoteles.Id }, hoteles);
        }

        // DELETE: Eliminar un Hotel
        [ResponseType(typeof(Hoteles))]
        public IHttpActionResult DeleteHoteles(int id)
        {
            Hoteles hoteles = db.Hoteles.Find(id);
            if (hoteles == null)
            {
                return NotFound();
            }

            db.Hoteles.Remove(hoteles);
            db.SaveChanges();

            return Ok(hoteles);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HotelesExists(int id)
        {
            return db.Hoteles.Count(e => e.Id == id) > 0;
        }
    }
}