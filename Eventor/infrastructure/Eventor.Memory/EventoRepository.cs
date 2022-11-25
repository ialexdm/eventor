using Eventor;
using System.Collections.Immutable;

namespace Eventor.Memory
{
    public class EventoRepository : IEventoRepository
    {
        private static long Count { get; set; }

        LinkedList<Evento> eventos;
        public EventoRepository()
        {
            eventos = new LinkedList<Evento>();

            List<Participate> participates = new List<Participate>();
            participates.Add(new Participate("Vanya"));
            participates.Add(new Participate("Petya"));
            participates.Add(new Participate("Anya"));

            List<Item> items = new List<Item>();
            items.Add(new Item("Tent"));
            items.Add(new Item("Sleeping bag"));
            items.Add(new Item("Cookware"));
            items.Add(new Item("Lighther"));
            items.Add(new Item("Food"));

            CreateEvento(
                "Weekend Hiking with Team",
                "Manaraga National Park",
                beginDate: new DateOnly(2023, 12, 02),
                beginTime: new TimeOnly(8, 00),
                endDate: new DateOnly(2023, 12, 03),
                endTime: new TimeOnly(18, 00),
                3496m,
                participates,
                items
                );
            CreateEvento(
                "Birthday party",
                "Papa Johnes",
                beginDate: new DateOnly(2023, 12, 02),
                beginTime: new TimeOnly(8, 00),
                endDate: new DateOnly(2023, 12, 03),
                endTime: new TimeOnly(18, 00),
                3496m,
                participates,
                items
                );
        }

        public void CreateEvento(Evento evento)
        {
            eventos.AddLast(evento);
        }

        public void CreateEvento(string name, string location, DateOnly beginDate, TimeOnly beginTime, DateOnly endDate, TimeOnly endTime, decimal cost, List<Participate> participates, List<Item> items)
        {
            eventos.AddLast(new Evento(++Count,
                name,
                location,
                beginDate,
                beginTime,
                endDate,
                endTime,
                cost,
                participates,
                items));
        }

        public Evento[]? GetAll()
        {
            return eventos.Where(evento => evento != null).ToArray();
        }

        public Evento GetById(long id)
        {
            return eventos.Single(e => e.Id == id);
        }
        public Evento GetByName(string name)
        {
            return eventos.Single(e => e.Name.Trim().ToLower() == name);
        }
    }
}