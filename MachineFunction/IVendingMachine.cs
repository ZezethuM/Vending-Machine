using MachineFunction;


public interface IVendingMachine
{
    public string SellProduct(Product product);
    public int MoneyAccumulated();

    public string PriceOfItem(Product product);
    public List<Product> ProductsAvailable();
    public List<Product> RefillMachine(Product product);
}