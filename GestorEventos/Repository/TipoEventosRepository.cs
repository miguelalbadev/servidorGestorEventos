using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GestorEventos.Models;
using GestorEventos.Excepciones;
using System.Data.Entity;

namespace GestorEventos.Repository {
    public class TipoEventosRepository : ITipoEventosRepository {

        public TipoEvento Create(TipoEvento tipoEvento) {
            return ApplicationDbContext.applicationDbContext.TipoEventoes.Add(tipoEvento);
        }

        public TipoEvento Delete(long id) {
            TipoEvento tipoEvento = ApplicationDbContext.applicationDbContext.TipoEventoes.Find(id);
            if (tipoEvento == null) {
                throw new NoEncontradoException("No se ha encontrado la entidad a eliminar");
            }
            ApplicationDbContext.applicationDbContext.TipoEventoes.Remove(tipoEvento);
            return tipoEvento;
        }

        public TipoEvento Read(long id) {
            return ApplicationDbContext.applicationDbContext.TipoEventoes.Find(id);
        }

        public IQueryable<TipoEvento> ReadAll() {
            IList<TipoEvento> tipoEventos = new List<TipoEvento>(ApplicationDbContext.applicationDbContext.TipoEventoes);
            return tipoEventos.AsQueryable();
        }

        public void Update(long id, TipoEvento tipoEvento) {
            if (ApplicationDbContext.applicationDbContext.TipoEventoes.Count(e => e.Id == tipoEvento.Id) == 0) {
                throw new NoEncontradoException("No se ha encontrado la entidad a actualizar");
            }
            ApplicationDbContext.applicationDbContext.Entry(tipoEvento).State = EntityState.Modified;
        }
    }
}