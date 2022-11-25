using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Eventor
{
    public interface IEventoRepository
    {
        Evento GetById(long id);
        Evento GetByName(string Name);

        void CreateEvento(string name,
            string location,
            DateOnly beginDate,
            TimeOnly beginTime,
            DateOnly endDate,
            TimeOnly endTime,
            decimal cost,
            List<Participate> participates,
            List<Item> items);
        Evento[]? GetAll();
    }
}
