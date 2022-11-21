namespace Eventor
{
    public class Item
    {
        public long Id { get; set; }
        private long Count;
        public string Name { get; set; }

        public Item(string name)
        {
            Id = ++Count;
            Name = name;
        }   
    }
}