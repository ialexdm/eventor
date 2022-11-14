namespace Eventor
{
    public class Item
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public Item(long id, string name)
        {
            Id = id;
            Name = name;
        }   
    }
}