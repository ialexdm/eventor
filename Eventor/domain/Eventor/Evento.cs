namespace Eventor
{
    public class Evento
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly FinishDate { get; set; }

        public TimeOnly StartTime { get; set; }
        public TimeOnly FinishTime { get; set; }
        public decimal Cost { get; set; }
        public LinkedList<Participate> Participates { get; set; }
        public LinkedList<Item> Items { get; set; }

        public Evento(
            long id,
            string name,
            string location,
            DateOnly startDate,
            DateOnly finishDate,
            TimeOnly startTime, 
            TimeOnly finishTime,
            decimal cost,
            LinkedList<Participate> participates,
            LinkedList<Item> items)
        {
            Id = id;
            Name = name;
            Location = location;
            StartDate = startDate;
            FinishDate = finishDate;
            StartTime = startTime;
            FinishTime = finishTime;
            Cost = cost;
            Participates = participates;
            Items = items;
        }
    }
}