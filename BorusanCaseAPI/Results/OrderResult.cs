namespace BorusanCaseAPI.Results
{
    public class OrderResult
    {
        public string CustomerOrderId { get; set; } // MusteriSiparisNo
        public Guid OrderId { get; set; } //SistemSiparisNo
        public byte Statu{ get; set; } // Statü
        public string Message { get; set; } // HataAciklama
    }
}
