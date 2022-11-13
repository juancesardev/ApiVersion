namespace Version.DTO
{
    public class Product2
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public Rating rating { get; set; }

    }


    public class AddGuid
    {
        public Product2[]? data { get; set; }
        public string InternalId { get; set; } = Guid.NewGuid().ToString();


    }
}
