using GestorEventos.Excepciones;
using GestorEventos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GestorEventos.Repository
{
    public class EventosRepository : IEventosRepository {

        public Evento Create(Evento evento) {
            return ApplicationDbContext.applicationDbContext.Eventos.Add(evento);
        }

        public Evento Delete(long id) {
            Evento evento = ApplicationDbContext.applicationDbContext.Eventos.Find(id);
            if (evento == null) {
                throw new NoEncontradoException("No se ha encontrado la entidad a eliminar");
            }
            ApplicationDbContext.applicationDbContext.Eventos.Remove(evento);
            return evento;
        }

        public Evento Read(long id) {
            return ApplicationDbContext.applicationDbContext.Eventos.Find(id);
        }

        public IQueryable<Evento> ReadAll() {
            IList<Evento> eventos = new List<Evento>(ApplicationDbContext.applicationDbContext.Eventos);
            return eventos.AsQueryable();
        }

        public void Update(long id, Evento evento) {
            if (ApplicationDbContext.applicationDbContext.Eventos.Count(e => e.Id == evento.Id) == 0) {
                throw new NoEncontradoException("No se ha encontrado la entidad a actualizar");
            }
            ApplicationDbContext.applicationDbContext.Entry(evento).State = EntityState.Modified;
        }
    }
}
