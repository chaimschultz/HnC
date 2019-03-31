using IO.Swagger.Api;
using System;

namespace HnC.Client.Library.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running simple API client tests...");
            var orderRequest = new IO.Swagger.Model.AddOrderRequest { UserId = 1 };
            Console.WriteLine("Adding order...");
            Console.WriteLine($"Order Request Details : UserId->{orderRequest.UserId}");
            OrdersApiInstance.AddOrder(orderRequest);
            Console.WriteLine("Retrieving order...");
            var orderResponse = OrdersApiInstance.GetOrder(1);
            Console.WriteLine($"Order Response Details : OrderID->{orderResponse.OrderId} UserId->{orderResponse.UserId}");
            Console.WriteLine("Removing order...");
            OrdersApiInstance.RemoveOrder(1);
            Console.WriteLine("Order Removed!");
            Console.ReadLine();
        }

        private static OrdersApi OrdersApiInstance
        {
            get
            {
                return new OrdersApi("https://localhost:5001");
            }
        }
    }
}
