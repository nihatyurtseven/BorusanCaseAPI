using System.Text.Json.Serialization;

namespace Entities.Dtos
{
    public class OrderStatuDto
    {
        public string CustomerOrderId { get; set; } //Müşteri Sipariş No
        public int StatusId { get; set; } //Statü
        public DateTime? ChangeDate { get; set; } //Değişim Tarihi
    }
}