namespace Abstractions
{
    public class Order
    {
        public string? OrderId { get; set; }
        public string? CustomerName { get; set; }
        public List<int>? Items { get; set; }

    }
}