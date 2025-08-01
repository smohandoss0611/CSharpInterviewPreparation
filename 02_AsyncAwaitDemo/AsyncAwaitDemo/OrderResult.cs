namespace TeslaInventoryVehicle
{
    public class OrderResult
    {
        public int OrderId { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public decimal Discount { get; set; }
    }
}