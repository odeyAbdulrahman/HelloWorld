namespace HelloWorldAPI.Models
{
    public class Order
    {

        public int Id { get; set; }
        public string? Number { get; set; } = "OR-001";
        public string? Name { get; set; }
        public int? Qty { get; set; }
        public float? Price { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
    }
}
