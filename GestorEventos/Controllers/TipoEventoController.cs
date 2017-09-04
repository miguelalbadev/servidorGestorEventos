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
using GestorEventos.Models;
using GestorEventos.Service;
using GestorEventos.Excepciones;
using System.Web.Http.Cors;

namespace GestorEventos.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TipoEventoController : ApiController
    {
        private ITipoEventosService tipoEventosService;

        public TipoEventoController(ITipoEventosService tipoEventosService) {
            this.tipoEventosService = tipoEventosService;
        }

        // GET: api/TipoEvento
        public IQueryable<TipoEvento> GetTipoEventos()
        {
            return tipoEventosService.ReadAll();
        }

        // GET: api/TipoEvento/5
        [ResponseType(typeof(TipoEvento))]
        public IHttpActionResult GetTipoEvento(long id)
        {
            TipoEvento tipoEvento = tipoEventosService.Read(id);
            if (tipoEvento == null)
            {
                return NotFound();
            }

            return Ok(tipoEvento);
        }

        // PUT: api/TipoEvento/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipoEvento(long id, TipoEvento tipoEvento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoEvento.Id)
            {
                return BadRequest();
            }
                       
            try
            {
                tipoEventosService.Update(id, tipoEvento);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
                
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/TipoEvento
        [ResponseType(typeof(TipoEvento))]
        public IHttpActionResult PostTipoEvento(TipoEvento tipoEvento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tipoEvento = tipoEventosService.Create(tipoEvento);

            return CreatedAtRoute("DefaultApi", new { id = tipoEvento.Id }, tipoEvento);
        }

        // DELETE: api/TipoEvento/5
        [ResponseType(typeof(TipoEvento))]
        public IHttpActionResult DeleteTipoEvento(long id)
        {
            TipoEvento tipoEvento;
            try {
                tipoEvento = tipoEventosService.Delete(id);
            }
            catch(NoEncontradoException e) {
                return NotFound();
            }
            return Ok(tipoEvento);
        }

        
    }
}