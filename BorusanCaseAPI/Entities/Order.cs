using System.Text.Json.Serialization;

namespace Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public int StatusId { get; set; }
        public string CustomerOrderId { get; set; }
        public string OutputAddress { get; set; }
        public string ArrivalAddress { get; set; }
        public decimal? Quantity { get; set; }
        public byte? QuantityType { get; set; }
        public decimal? Weight { get; set; }
        public byte? WeightType { get; set; }
        public Guid ProductId { get; set; }
        public string? Note { get; set; }
        [JsonIgnore] public DateTime? CreatedDate { get; set; }
        [JsonIgnore] public DateTime? UpdatedDate { get; set; }
        public Product Product { get; set; }
    }
}
