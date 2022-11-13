using Eventually;
using System.Collections.Immutable;

namespace Eventually.Memory
{
    public class EventRepository
    {
        IEnumerable<Event> events;

        public EventRepository()
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

            Event evento = new Event(
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
            events = new Event[]
            {
                evento
            };
        }
        public Event GetById(long id)
            {
                return events.Single(e => e.Id == id);
            }
        }
    }