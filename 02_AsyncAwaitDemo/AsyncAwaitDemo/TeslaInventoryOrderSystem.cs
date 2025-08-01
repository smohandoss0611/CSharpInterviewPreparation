using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TeslaInventoryVehicle
{

    public class TeslaInventoryOrderSystem
    {
        private readonly ConcurrentDictionary<int, TeslaInventoryOrderSystem> _inventory;
        public TeslaInventoryOrderSystem()
        {
            // Initialize Tesla vehicle inventory (simulated)
            _inventory = new ConcurrentDictionary<int, Vehicle>(
                new List<Vehicle>
                {
                new Vehicle { Id = 1, Model = "Model Y", Configuration = "Long Range", Quantity = 20, Price = 52990 },
                new Vehicle { Id = 2, Model = "Model 3", Configuration = "Performance", Quantity = 15, Price = 56990 },
                new Vehicle { Id = 3, Model = "Model S", Configuration = "Plaid", Quantity = 5, Price = 134990 }
                }.ToDictionary(v => v.Id));
        }

        public async Task<OrderResult> ProcessOrderAsync(TeslaOrder order)
        {
            try
            {
                bool isAvailable = await CheckInventoryAsync(order.VehicleId, order.Quantity);
                if (!isAvailable)
                {
                    return new OrderResult
                    {
                        OrderId = order.OrderId,
                        Success = false,
                        Message = $"Insufficient inventory for vehicle ID {order.VehicleId}."

                    };
                }
                // Step 2: Process payment
                await ProcessPaymentAsync(order);
                // Step 3: Update inventory
                bool updated = await UpdateInventoryAsync(order.VehicleId, order.Quantity);
                if (!updated)
                {
                    return new OrderResult
                    {
                        OrderId = order.OrderId,
                        Success = false,
                        Message = "Failed to update inventory."
                    };
                }
                // Step 4: Send confirmation email
                await SendConfirmationEmailAsync(order);

                return new OrderResult
                {
                    OrderId = order.OrderId,
                    Success = true,
                    Message = $"Order {order.OrderId} for {order.Quantity} vehicle(s) processed successfully."
                };


            }
            catch (Exception ex)
            {
                return new OrderResult
                {
                    OrderId = order.OrderId,
                    Success = false,
                    Message = $"Order {order.OrderId} failed: {ex.Message}"
                };
            }
        }

        private async Task<bool> CheckInventoryAsync(int vehicleId, int quantity)
        {
            // Simulate database query to check inventory
            await Task.Delay(500); // 500ms to mimic DB/network latency
            return _inventory.TryGetValue(vehicleId, out var vehicle) && vehicle.Quantity >= quantity;
        }
        private async Task ProcessPaymentAsync(TeslaOrder order)
        {
            // Simulate payment gateway API call (e.g., Tesla's payment system)
            Console.WriteLine($"Processing payment for order {order.OrderId}...");
            await Task.Delay(1000); // 1s to mimic payment processing
                                    // In a real system, integrate with Stripe, PayPal, or Tesla's payment API
        }

        private async Task<bool> UpdateInventoryAsync(int vehicleId, int quantity)
        {
            // Simulate thread-safe inventory update
            Console.WriteLine($"Updating inventory for vehicle {vehicleId}...");
            await Task.Delay(300); // 300ms to mimic DB update
            return _inventory.AddOrUpdate(
                vehicleId,
                _ => null, // Should not happen
                (id, vehicle) =>
                {
                    if (vehicle.Quantity < quantity) return vehicle;
                    vehicle.Quantity -= quantity;
                    return vehicle;
                })?.Quantity >= 0;
        }
        private async Task SendConfirmationEmailAsync(TeslaOrder order)
        {
            // Simulate sending confirmation email
            Console.WriteLine($"Sending confirmation email for order {order.OrderId} to {order.CustomerEmail}...");
            await Task.Delay(700); // 700ms to mimic email service
                                   // In a real system, integrate with SendGrid or Tesla's email service
        }

        

     
    }
}