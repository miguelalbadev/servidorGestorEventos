using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GestorEventos.Models;
using GestorEventos.Repository;

namespace GestorEventos.Service {
    public class TipoEventosService : ITipoEventosService {
        private ITipoEventosRepository tipoEventosRepository;

        public TipoEventosService (ITipoEventosRepository tipoEventosRepository) {
            this.tipoEventosRepository = tipoEventosRepository;
        }

        public TipoEvento Create(TipoEvento tipoEvento) {
            return tipoEventosRepository.Create(tipoEvento);
        }

        public TipoEvento Delete(long id) {
            return tipoEventosRepository.Delete(id);
        }

        public TipoEvento Read(long id) {
            return tipoEventosRepository.Read(id);
        }

        public IQueryable<TipoEvento> ReadAll() {
            IQueryable<TipoEvento> tipoEvento;
            tipoEvento = tipoEventosRepository.ReadAll();
            return tipoEvento;
        }

        public void Update(long id, TipoEvento tipoEvento) {
            tipoEventosRepository.Update(id, tipoEvento);
        }
    }
}