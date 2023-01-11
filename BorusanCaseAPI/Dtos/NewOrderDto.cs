using System.Text.Json.Serialization;

namespace Entities.Dtos
{
    public class NewOrderDto
    {
        public Guid? Id { get; set; }
        public string CustomerOrderId { get; set; }
        public string OutputAddress { get; set; }
        public string ArrivalAddress { get; set; }
        public decimal? Quantity { get; set; }
        public byte? QuantityType { get; set; }
        public decimal? Weight { get; set; }
        public byte? WeightType { get; set; }
        public string? ProductCode { get; set; }
        public string? ProductName { get; set; }
        public string? Note { get; set; }
    }
}