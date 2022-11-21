using Eventor;
using System.Collections.Immutable;

namespace Eventor.Memory
{
    public class EventoRepository : IEventoRepository
    {
        LinkedList<Evento> eventos;
        public EventoRepository()
        {
            List<Participate> participates = new List<Participate>();
            participates.Add(new Participate("Vanya"));
            participates.Add(new Participate("Petya"));
            participates.Add(new Participate("Anya"));

            List<Item> items = new List<Item>();
            items.Add(new Item ("Tent"));
            items.Add(new Item("Sleeping bag"));
            items.Add(new Item("Cookware"));
            items.Add(new Item("Lighther"));
            items.Add(new Item("Food"));

            Evento evento = new Evento(
                "Weekend Hiking with Team",
                "Manaraga National Park",
                startDate: new DateOnly(2023, 12, 02),
                startTime: new TimeOnly(8, 00),
                finishDate: new DateOnly(2023, 12, 03),
                finishTime: new TimeOnly(18, 00),
                3496m,
                participates,
                items
                );
            Evento evento1 = new Evento(
                "Birthday party",
                "Papa Johnes",
                startDate: new DateOnly(2023, 12, 02),
                startTime: new TimeOnly(8, 00),
                finishDate: new DateOnly(2023, 12, 03),
                finishTime: new TimeOnly(18, 00),
                3496m,
                participates,
                items
                );

            eventos = new LinkedList<Evento>();
            eventos.AddLast(evento);
            eventos.AddLast(evento1);
        }

        public void AddEvento(Evento evento)
        {
            eventos.AddLast(evento);
        }

        public Evento[]? GetAll()
        {
            return eventos.Where(evento => evento != null).ToArray();
        }

        public Evento GetById(long id)
        {
            return eventos.Single(e => e.Id == id);
        }
    }
}