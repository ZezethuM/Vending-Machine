using Xunit;

namespace MachineFunction.Tests;

public class UnitTest1
{
    
    VendingMachine myMachine = new VendingMachine(new EskomPower(true));
    VendingMachine myMachine2 = new VendingMachine(new SolarPower(true));
    VendingMachine myMachine3 = new VendingMachine(new BatteryPower(true));
    Manager manager = new Manager();

    [Fact]
    public void FunctioningVMs()
    {
        manager.Register(myMachine);
        manager.Register(myMachine2);
        manager.Register(myMachine3);
    }
    [Fact]
    public void ShouldReturnNumberOfVendingMachines()
    {
        FunctioningVMs();
        Assert.Equal(3, manager.NumberOfVm());
    }
    [Fact]
    public void ShouldSellAProduct()
    {
        Assert.Equal("Thank you for buying LunchBar", myMachine.SellProduct(new Chocolate("LunchBar", 7, "5g")));
        Assert.Equal("Thank you for buying Lays", myMachine.SellProduct(new Chip("Lays", 6, "15g")));
        Assert.Equal("Thank you for buying Fanta", myMachine.SellProduct(new Soda("Fanta", 11, "500ml")));
        Assert.Equal("Thank you for buying Fanta", myMachine.SellProduct(new Soda("Fanta", 11, "500ml")));
    }

    [Fact]
    public void ShouldReturnPriceOfAProduct()
    {
        Assert.Equal("R 10", myMachine.PriceOfItem(new Soda("Coca-Cola", 10, "500ml")));
    }
    [Fact]
    public void ShouldReturnItemsAvailable()
    {
        Assert.Equal(myMachine.myProducts, myMachine.ProductsAvailable());
    }
    [Fact]
    public void ShouldReturnItemsSoldOnAVendingMachine()
    {
        myMachine.SellProduct(new Chocolate("Bar-one", 4, "5g"));
        myMachine.SellProduct(new Chocolate("Bar-one", 4, "5g"));
        myMachine.SellProduct(new Chocolate("Bar-one", 4, "5g"));
        myMachine2.SellProduct(new Chocolate("Nugget", 3, "5g"));

        Assert.Equal(myMachine.trackingSoldItem, myMachine.ItemsSold());
    }
    [Fact]
    public void ShouldReturnTotalAmountMadeFromSalesForManager()
    {
        FunctioningVMs();
        
        myMachine.SellProduct(new Chocolate("Bar-one", 4, "5g"));
        myMachine2.SellProduct(new Chocolate("Nugget", 3, "5g"));
        myMachine3.SellProduct(new Soda("Coca-Cola", 10, "500ml"));

        Assert.Equal(17, manager.SoldItems());
    }
    [Fact]
    public void ShouldReturnMostPopularProductForTheManager()
    {
        FunctioningVMs();
        myMachine.SellProduct(new Chocolate("Bar-one", 4, "5g"));
        myMachine.SellProduct(new Chocolate("Bar-one", 4, "5g"));
        myMachine.SellProduct(new Soda("Coca-Cola", 10, "500ml"));
        myMachine.SellProduct(new Chocolate("Bar-one", 4, "5g"));
        myMachine2.SellProduct(new Chocolate("Bar-one", 4, "5g"));
        myMachine2.SellProduct(new Chocolate("Bar-one", 4, "5g"));
        Assert.Equal("Bar-one", manager.MostPopularProduct());
    }
     [Fact]
    public void ShouldReturnAllSoldProductsForTheManager()
    {
       FunctioningVMs();

        myMachine.SellProduct(new Chocolate("Bar-one", 4, "5g"));
        myMachine.SellProduct(new Chocolate("Bar-one", 4, "5g"));
        myMachine3.SellProduct(new Soda("Coca-Cola", 10, "500ml"));
        myMachine3.SellProduct(new Chocolate("Bar-one", 4, "5g"));
        myMachine2.SellProduct(new Chocolate("Bar-one", 4, "5g"));
        myMachine2.SellProduct(new Chocolate("Bar-one", 4, "5g"));

        Assert.Equal(manager.soldProducts, manager.AllSoldItems());
    }
     public void ShouldReturnLeastPopularProductForManager()
    {
        FunctioningVMs();
        myMachine.SellProduct(new Chocolate("Bar-one", 4, "5g"));
        myMachine3.SellProduct(new Chocolate("Bar-one", 4, "5g"));
        myMachine2.SellProduct(new Chocolate("Bar-one", 4, "5g"));
        myMachine.SellProduct(new Chocolate("Bar-one", 4, "5g"));
        myMachine.SellProduct(new Chocolate("Bar-one", 4, "5g"));
        myMachine3.SellProduct(new Soda("Coca-Cola", 10, "500ml"));
        myMachine2.SellProduct(new Soda("Coca-Cola", 10, "500ml"));
        myMachine2.SellProduct(new Soda("Coca-Cola", 10, "500ml"));
        myMachine3.SellProduct(new Soda("Coca-Cola", 10, "500ml"));
        myMachine.SellProduct(new Soda("Fanta", 11, "500ml"));
       
        Assert.Equal("Fanta", manager.LeastPopularProduct());
    }
    [Fact]
    public void ShouldReturnAmountMadeOnAVendingMachine()
    {
        myMachine.SellProduct(new Chocolate("Bar-one", 4, "5g"));
        myMachine.SellProduct(new Chocolate("Nugget", 3, "5g"));
        myMachine.SellProduct(new Soda("Coca-Cola", 10, "500ml"));
        Assert.Equal(17, myMachine.MoneyAccumulated());
    }
    [Fact]
    public void ShouldBeAbleToRefilVendingMachine()
    {
        Assert.Equal(myMachine.myProducts, myMachine.RefillMachine(new Chip("Snipers", 2, "5g")));
    }
}