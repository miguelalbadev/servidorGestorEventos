using GestorEventos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Service {
    public interface ITipoEventosService {

        TipoEvento Create(TipoEvento tipoEvento);
        TipoEvento Read(long id);
        IQueryable<TipoEvento> ReadAll();
        void Update(long id, TipoEvento tipoEvento);
        TipoEvento Delete(long id);
    }
}
