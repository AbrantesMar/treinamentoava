using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using BomDiaBrasilTreinamento.Web.Models;
using Dominio;

namespace BomDiaBrasilTreinamento.Web.Controllers
{
    public class ComentariosApiController : ApiController
    {
        private BomDiaBrasilContext db = new BomDiaBrasilContext();

        // GET: api/ComentariosApi
        public IQueryable<Comentario> GetComentarios()
        {
            return db.Comentarios;
        }

        // GET: api/ComentariosApi/5
        [ResponseType(typeof(Comentario))]
        public IHttpActionResult GetComentario(int id)
        {
            Comentario comentario = db.Comentarios.Find(id);
            if (comentario == null)
            {
                return NotFound();
            }

            return Ok(comentario);
        }

        // PUT: api/ComentariosApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutComentario(int id, Comentario comentario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != comentario.Id)
            {
                return BadRequest();
            }

            db.Entry(comentario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComentarioExists(id))
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

        // POST: api/ComentariosApi
        [ResponseType(typeof(Comentario))]
        public IHttpActionResult PostComentario(Comentario comentario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Comentarios.Add(comentario);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = comentario.Id }, comentario);
        }

        // DELETE: api/ComentariosApi/5
        [ResponseType(typeof(Comentario))]
        public IHttpActionResult DeleteComentario(int id)
        {
            Comentario comentario = db.Comentarios.Find(id);
            if (comentario == null)
            {
                return NotFound();
            }

            db.Comentarios.Remove(comentario);
            db.SaveChanges();

            return Ok(comentario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ComentarioExists(int id)
        {
            return db.Comentarios.Count(e => e.Id == id) > 0;
        }
    }
}