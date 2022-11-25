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
            long id,
            string name,
            string location,
            DateOnly beginDate,
            TimeOnly beginTime,
            DateOnly endDate,
            TimeOnly endTime,
            decimal cost,
            List<Participate> participates,
            List<Item> items)
        {
            Id = id;
            Name = name;
            Location = location;
            BeginDate = beginDate;
            BeginTime = beginTime;
            EndDate = endDate;
            EndTime = endTime;
            Cost = cost;
            Participates = participates;
            Items = items;
        }
    }
}