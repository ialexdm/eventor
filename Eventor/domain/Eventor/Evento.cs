namespace Eventor
{
    public class Evento
    {
        private static long count;
        public static long Count { get; }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateOnly BeginDate { get; set; }
        public TimeOnly BeginTime { get; set; }
        public DateOnly EndDate { get; set; }
        public TimeOnly EndTime { get; set; }
        public decimal Cost { get; set; }
        public List<Participate> Participates { get; set; }
        public List<Item> Items { get; set; }

        public Evento(
            string name,
            string location,
            DateOnly startDate,
            TimeOnly startTime,
            DateOnly finishDate,
            TimeOnly finishTime,
            decimal cost,
            List<Participate> participates,
            List<Item> items)
        {
            Id = ++count;
            Name = name;
            Location = location;
            BeginDate = startDate;
            BeginTime = startTime;
            EndDate = finishDate;
            EndTime = finishTime;
            Cost = cost;
            Participates = participates;
            Items = items;
        }
    }
}