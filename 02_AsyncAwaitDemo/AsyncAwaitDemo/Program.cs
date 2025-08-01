// See https://aka.ms/new-console-template for more information

using TeslaInventoryVehicle;

Console.WriteLine("Hello, World!");
Thread t = new Thread(PrintNumbers);
t.Start();
PrintNumbers();
ThreadPool.QueueUserWorkItem(WorkItem);
ThreadPool.QueueUserWorkItem(WorkItem);

var system = new TeslaInventoryOrderSystem();

  
        var orders = new List<TeslaOrder>
        {
            new TeslaOrder { OrderId = 1, ItemId = 1, Price = 5555,Quantity = 2, CustomerEmail = "customer1@example.com" },
            new TeslaOrder { OrderId = 2, ItemId = 2, Price= 5555,Quantity = 5, CustomerEmail = "customer2@example.com" },
            new TeslaOrder { OrderId = 3, ItemId = 1, Price =55555,Quantity = 10, CustomerEmail = "customer3@example.com" } // Will fail due to insufficient inventory
        };

        // Process orders concurrently
        var tasks = orders.Select(order => system.ProcessOrderAsync(order)).ToList();
        await Task.WhenAll(tasks);



static void PrintNumbers()
{
    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine($"Thread {i}", i);
        Thread.Sleep(1000);

    }
}

static void WorkItem(object state)
{
    Console.WriteLine($"Working on Thread: {Thread.CurrentThread.ManagedThreadId}");

}

