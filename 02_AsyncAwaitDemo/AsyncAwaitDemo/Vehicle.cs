namespace TeslaInventoryVehicle
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Model { get; set; } // e.g., Model Y, Model 3
        public string Configuration { get; set; } // e.g., Long Range, Performance
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        
    }
}