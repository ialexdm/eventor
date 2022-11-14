namespace Eventor
{
    public class Participate
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public Participate(long id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}