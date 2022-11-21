namespace Eventor
{
    public class Participate
    {
        public long Id { get; set; }
        public string Name { get; set; }
        private long count;

        public Participate(string name)
        {
            Id = ++count;
            Name = name;
        }
    }
}