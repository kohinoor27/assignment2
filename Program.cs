using Assignment4coplur;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4coplur
{
class FoodItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }

        public FoodItem(int id, string name, double price, string category)
        {
            Id = id;
            Name = name;
            Price = price;
            Category = category;
        }

        public override string ToString()
        {
            return $"{Id}. {Name} - ${Price} [{Category}]";
        }
    }

}
class Order
{
    public int OrderId { get; set; }
    public List<FoodItem> Items { get; set; }

    public Order(int orderId)
    {
        OrderId = orderId;
        Items = new List<FoodItem>();
    }

    public void AddItem(FoodItem item)
    {
        Items.Add(item);
    }

    public override string ToString()
    {
        string details = $"Order {OrderId}:\n";
        foreach (var item in Items)
        {
            details += $"- {item.Name} (${item.Price})\n";
        }
        return details;
    }
}
class FoodOrderingSystem
{
    private List<FoodItem> menu = new List<FoodItem>();     
    private Dictionary<int, List<FoodItem>> orders = new Dictionary<int, List<FoodItem>>(); 
    private Queue<int> pendingOrders = new Queue<int>();  
    private Stack<int> deliveredOrders = new Stack<int>();    
    private HashSet<string> categories = new HashSet<string>();     
    private int orderCounter = 1;

      
    public void AddFoodItem(string name, double price, string category)
    {
        int id = menu.Count + 1;
        menu.Add(new FoodItem(id, name, price, category));
        categories.Add(category);
        Console.WriteLine($"Added: {name} (${price}) under {category}");
    }

         public void ShowMenu()
    {
        Console.WriteLine("\n--- Menu ---");
        foreach (var item in menu)
        {
            Console.WriteLine(item);
        }
    }

     
    public void PlaceOrder(List<int> foodItemIds)
    {
        Order order = new Order(orderCounter);
        foreach (int id in foodItemIds)
        {
            FoodItem item = menu.Find(f => f.Id == id);
            if (item != null)
                order.AddItem(item);
        }

        orders[orderCounter] = order.Items;
        pendingOrders.Enqueue(orderCounter);
        Console.WriteLine($"Order {orderCounter} placed!");
        orderCounter++;
    }

      
    public void DeliverOrder()
    {
        if (pendingOrders.Count > 0)
        {
            int orderId = pendingOrders.Dequeue();
            deliveredOrders.Push(orderId);
            Console.WriteLine($"Order {orderId} delivered!");
        }
        else
        {
            Console.WriteLine("No pending orders!");
        }
    }

       
    public void ShowPendingDeliveries()
    {
        Console.WriteLine("\n--- Pending Orders ---");
        foreach (var orderId in pendingOrders)
        {
            Console.WriteLine($"Order {orderId}");
        }
    }

       
    public void ShowDeliveredOrders()
    {
        Console.WriteLine("\n--- Delivered Orders ---");
        foreach (var orderId in deliveredOrders)
        {
            Console.WriteLine($"Order {orderId}");
        }
    }

       
    public void ShowFoodCategories()
    {
        Console.WriteLine("\n--- Food Categories ---");
        foreach (var category in categories)
        {
            Console.WriteLine(category);
        }
    }
}
class Program
{
    static void Main()
    {
        FoodOrderingSystem system = new FoodOrderingSystem();

        
        system.AddFoodItem("Chilli potato", 12.99, "Fast Food");
        system.AddFoodItem("Burger", 5.99, "Fast Food");
        system.AddFoodItem("whitesauce pasta", 8.99, "Italian");
        system.AddFoodItem("Colddrinks", 1.99, "Beverage");

        while (true)
        {
            Console.WriteLine("\n1. Show Menu");
            Console.WriteLine("2. Place Order");
            Console.WriteLine("3. Deliver Order");
            Console.WriteLine("4. Show Pending Deliveries");
            Console.WriteLine("5. Show Delivered Orders");
            Console.WriteLine("6. Show Food Categories");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an option: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    system.ShowMenu();
                    break;

                case 2:
                    Console.Write("Enter food item IDs separated by space: ");
                    string[] input = Console.ReadLine().Split(' ');
                    List<int> foodItemIds = new List<int>();
                    foreach (string id in input)
                        foodItemIds.Add(int.Parse(id));
                    system.PlaceOrder(foodItemIds);
                    break;

                case 3:
                    system.DeliverOrder();
                    break;

                case 4:
                    system.ShowPendingDeliveries();
                    break;

                case 5:
                    system.ShowDeliveredOrders();
                    break;

                case 6:
                    system.ShowFoodCategories();
                    break;

                case 7:
                    Console.WriteLine("Exiting...");
                    return;

                default:
                    Console.WriteLine("Invalid choice, try again!");
                    break;
            }
        }
    }
}

