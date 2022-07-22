namespace GoshaDudarExampleShop.Data.Models
{
    public class Car
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ShortDesc { get; set; }

        public string LongDesc { get; set; }

        public string ImgPath { get; set; }

        public uint Price { get; set; }

        public bool IsFavourite { get; set; }

        public bool Available { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}