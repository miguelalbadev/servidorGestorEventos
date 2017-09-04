using GestorEventos.Models;
using GestorEventos.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestorEventos.Service
{
    public class EventosService : IEventosService {
        private IEventosRepository eventosRepository;

        public EventosService (IEventosRepository eventosRepository) {
            this.eventosRepository = eventosRepository;
        }

        public Evento Create(Evento evento) {
            return eventosRepository.Create(evento);
        }

        public Evento Delete(long id) {
            return eventosRepository.Delete(id);
        }

        public Evento Read(long id) {
            return eventosRepository.Read(id);
        }

        public IQueryable<Evento> ReadAll() {
            IQueryable<Evento> evento;
            evento = eventosRepository.ReadAll();
            return evento;
        }

        public void Update(long id, Evento evento) {
            eventosRepository.Update(id, evento);
        }
    }
}
