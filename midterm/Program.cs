using System;

public class InventoryItem
{
    // Properties
    public string ItemName { get; set; }
    public int ItemId { get; set; }
    public double Price { get; set; }
    public int QuantityInStock { get; set; }

    // Constructor
    public InventoryItem(string itemName, int itemId, double price, int quantityInStock)
    {
        // Initialize the properties with the values passed to the constructor.
        ItemName = itemName;
        ItemId = itemId;
        Price = price;
        QuantityInStock = quantityInStock;
    }

    // Methods

    // Update the price of the item
    public void UpdatePrice(double newPrice)
    {
        // Update the item's price with the new price.
        Price = newPrice;
        Console.WriteLine($"{ItemName} price updated to {Price:C}");
    }

    // Restock the item
    public void RestockItem(int additionalQuantity)
    {
        // Increase the item's stock quantity by the additional quantity.
        QuantityInStock += additionalQuantity;
        Console.WriteLine($"{additionalQuantity} {ItemName}s restocked. Total quantity: {QuantityInStock}");
    }

    // Sell an item
    public void SellItem(int quantitySold)
    {
        // Decrease the item's stock quantity by the quantity sold.
        // Make sure the stock doesn't go negative.
        if (quantitySold <= QuantityInStock)
        {
            QuantityInStock -= quantitySold;
            Console.WriteLine($"{quantitySold} {ItemName}s sold. Remaining quantity: {QuantityInStock}");
        }
        else
        {
            Console.WriteLine($"There is not enough {ItemName} in stock to sell.");
        }
    }

    // Check if an item is in stock
    public bool IsInStock()
    {
        // Return true if the item is in stock (quantity > 0), otherwise false.
        return QuantityInStock > 0;
    }

    // Print item details


    public void PrintDetails()
    {
        Console.WriteLine($"Item: {ItemName,-10} | ID: {ItemId,-5} | Price: {Price,-10:C} | Stock: {QuantityInStock,-3}");
    }
}




class Program
{
    static void Main(string[] args)
    {
        // Creating instances of InventoryItem
        InventoryItem item1 = new InventoryItem("Laptop", 101, 1200.50, 10);
        InventoryItem item2 = new InventoryItem("Smartphone", 102, 800.30, 15);


        // print detaail of all items
        Console.WriteLine("Initial Details:");
        item1.PrintDetails();
        item2.PrintDetails();
        Console.WriteLine();

        // Show the update prices
        item1.UpdatePrice(1400.75);
        item2.UpdatePrice(1000.20);

        Console.WriteLine("\nAfter Price Update:");
        item1.PrintDetails();
        item2.PrintDetails();
        Console.WriteLine();

        // Sell some items and then print the updated details.
        item1.SellItem(1);
        item2.SellItem(4);

        Console.WriteLine("\nAfter Selling Items:");
        item1.PrintDetails();
        item2.PrintDetails();
        Console.WriteLine();

        // Restock items and print the updated details.
        item1.RestockItem(3);
        item2.RestockItem(5);

        Console.WriteLine("\nAfter Restocking Items:");
        item1.PrintDetails();
        item2.PrintDetails();
        Console.WriteLine();

        // Check if an item is in stock and print a message accordingly.
        Console.WriteLine($"Is {item1.ItemName} still in stock? ------>{item1.IsInStock()}");
        Console.WriteLine($"Is {item2.ItemName} still in stock? -->{item2.IsInStock()}");
    }
}
