using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Service
{
    public interface IEventosService
    {
        Evento Create(Evento evento);
        Evento Read(long id);
        IQueryable<Evento> ReadAll();
        void Update(long id, Evento evento);
        Evento Delete(long id);
    }
}
