namespace MachineFunction;

public class VendingMachine
{
    public int totalAmountMadeInSales = 0;
    public List<Product> myProducts = new List<Product>{
        new Chip ( "Doritos", 5, "100g"),
        new Chip ("Lays", 6, "100g"),
        new Chocolate ("Bar-one", 4, "5g"),
        new Chocolate ("LunchBar", 7, "5g"),
        new Chocolate ("Nugget", 3, "5g"),
        new Soda ("Coca-Cola", 10, "500ml"),
        new Soda ("Sprit", 9, "500ml"),
        new Soda ("Fanta", 11, "500ml"),
        new Soda ("Fanta", 11, "500ml"),
        new Soda ("Fanta", 11, "500ml")
    };
    int count = 1;
    public Dictionary<string, int> trackingSoldItem = new Dictionary<string, int>();
    public IPower PowerSource{get; private set;}
    public VendingMachine(PowerSource power)
    {
        PowerSource = power;
        Console.WriteLine($"{PowerSource.GetDescription()} power.");
    }
    public string SellProduct(Product product)
    {
        if(PowerSource.PowerOn())
        {
            var purchasedItem = myProducts.Find(xProduct => xProduct.ProductName == product.ProductName);
            if(purchasedItem == null)
            {
                return "Product not available";
            }
            else if(purchasedItem.Price != product.Price)
            {
                return "Not enough money";
            }
            else 
            {
                if(trackingSoldItem.ContainsKey(product.ProductName!))
                {
                    trackingSoldItem[product.ProductName!]++;
                }
                else{
                    trackingSoldItem.Add(purchasedItem.ProductName!, count); 
                } 
                
                totalAmountMadeInSales += product.Price;

                return "Thank you for buying " + product.ProductName;

            }
        }
        else
        {
            return "There is no power";
        }
    }
    public Dictionary<string, int> ItemsSold()
    {
        return trackingSoldItem;
    }
   
    public int MoneyAccumulated()
    {
        return totalAmountMadeInSales;
    }
    public string PriceOfItem(Product product)
    {
        if(PowerSource.PowerOn())
        {
            var currproduct = myProducts.Find(xProduct => xProduct.ProductName == product.ProductName);

            if(currproduct == null)
            {
                return "Product not available";
            }
            else
            {
            return "R " + currproduct.Price;
            }
        }
        else
        {
            return "There is no power";
        }
    }
    public List<Product> ProductsAvailable()
    {
        return myProducts;
    }
    public List<Product> RefillMachine(Product product)
    {
        myProducts.Add(new Product(product.ProductName!, product.Price, product.Size!));
        return myProducts;
    }
}
