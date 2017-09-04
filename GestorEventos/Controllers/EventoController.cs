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

namespace GestorEventos.Controllers
{
    public class EventoController : ApiController
    {
        private IEventosService eventosService;

        public EventoController(IEventosService eventosService) {
            this.eventosService = eventosService;
        }

        // GET: api/Evento
        public IQueryable<Evento> GetEventos()
        {
            return eventosService.ReadAll();
        }

        // GET: api/Evento/5
        [ResponseType(typeof(Evento))]
        public IHttpActionResult GetEvento(long id)
        {
            Evento evento = eventosService.Read(id);
            if (evento == null)
            {
                return NotFound();
            }

            return Ok(evento);
        }

        // PUT: api/Evento/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEvento(long id, Evento evento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != evento.Id)
            {
                return BadRequest();
            }

            try
            {
                eventosService.Update(id, evento);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();

            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Evento
        [ResponseType(typeof(Evento))]
        public IHttpActionResult PostEvento(Evento evento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            evento = eventosService.Create(evento);

            return CreatedAtRoute("DefaultApi", new { id = evento.Id }, evento);
        }

        // DELETE: api/Evento/5
        [ResponseType(typeof(Evento))]
        public IHttpActionResult DeleteEvento(long id)
        {
            Evento evento;
            try {
                evento = eventosService.Delete(id);
            }
            catch(NoEncontradoException e) {
                return NotFound();
            }
            return Ok(evento);
        }
    }
}
