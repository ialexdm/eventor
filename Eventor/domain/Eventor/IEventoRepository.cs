using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventor
{
    public interface IEventoRepository
    {
        Evento GetById(long id);
        void AddEvento(Evento evento);
        Evento[]? GetAll();
    }
}
