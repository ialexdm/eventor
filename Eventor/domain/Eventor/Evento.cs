namespace Eventor
{
    public class Evento
    {
        public static long Count { get; }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateOnly BeginDate { get; set; }
        public TimeOnly BeginTime { get; set; }
        private DateOnly _endDate;
        public DateOnly EndDate
        {
            get => _endDate;
            set
            {
                ThrowInvalidEndDate(BeginDate, value);
                _endDate = value;
            }
        }
        private TimeOnly _endTime;
        public TimeOnly EndTime {
            get => _endTime;
            set 
            {
                ThrowInvalidEndTime(BeginDate, BeginTime, EndDate, value);
                _endTime = value;
            }
        }
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

        private static void ThrowInvalidEndTime(DateOnly beginDate, TimeOnly beginTime, DateOnly endDate, TimeOnly endTime)
        {
            if (beginDate == endDate && beginTime > endTime)
            {
                throw new ArgumentException($"{nameof(endTime)} must to be after {nameof(beginTime)}.");
            }
        }

        private static void ThrowInvalidEndDate(DateOnly beginDate, DateOnly endDate)
        {
            if (beginDate > endDate)
            {
                throw new ArgumentException($"{nameof(endDate)} must to be after {nameof(beginDate)}.");
            }
        }
    }
}