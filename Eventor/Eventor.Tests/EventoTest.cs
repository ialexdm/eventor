namespace Eventor.Tests
{
    public class EventoTest
    {
        [Fact]
        public void Evento_WithEndTimeBeforeBeginTime_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Evento(1L,
                "default",
                "location",
                new DateOnly(2025, 1, 1),
                new TimeOnly(),
                new DateOnly(2023, 1, 1),
                new TimeOnly(),
                0m, new List<Participate>(),
                new List<Item>()));
        }
        [Fact]
        public void Evento_WithValid_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Evento(1L,
                "default",
                "location",
                new DateOnly(2025, 1, 1),
                new TimeOnly(),
                new DateOnly(2023, 1, 1),
                new TimeOnly(),
                0m, new List<Participate>(),
                new List<Item>()));
        }
        [Fact]
        public void Evento_WithEqualDatesAndEndTimeBeforeBeginTime_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Evento(1L,
                "default",
                "location",
                new DateOnly(2023, 1, 1),
                new TimeOnly(1,0,0),
                new DateOnly(2023, 1, 1),
                new TimeOnly(0,0,0),
                0m, new List<Participate>(),
                new List<Item>()));
        }
    }
}