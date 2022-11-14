using Eventor;
using System.Collections.Immutable;

namespace Eventor.Memory
{
    public class EventoRepository
    {
        IEnumerable<Evento> eventos; 
        public EventoRepository()
        {
            LinkedList<Participate> participates = new LinkedList<Participate>();
            participates.AddFirst(new Participate(1L, "Vanya"));
            participates.AddLast(new Participate(2L, "Petya"));
            participates.AddLast(new Participate(3L, "Anya"));

            LinkedList<Item> items = new LinkedList<Item>();
            items.AddFirst(new Item(1L, "Tent"));
            items.AddLast(new Item(2L, "Sleeping bag"));
            items.AddLast(new Item(3L, "Cookware"));
            items.AddLast(new Item(4L, "Lighther"));
            items.AddLast(new Item(5L, "Food"));

            Evento evento = new Evento(
                1,
                "Weekend Hiking with Team",
                "Manaraga National Park",
                startDate: new DateOnly(2023, 12, 02),
                finishDate: new DateOnly(2023, 12, 03),
                startTime: new TimeOnly(8, 00),
                finishTime: new TimeOnly(18, 00),
                3496m,
                participates,
                items
                );
            eventos = new Evento[]
            {
                evento
            };
        }
        public Evento GetById(long id)
            {
                return eventos.Single(e => e.Id == id);
            }
        }
    }