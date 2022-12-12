using MachineFunction;
public class Manager
{
   public List<VendingMachine> vendingMachines = new List<VendingMachine>();
   public Dictionary<string, int> soldProducts = new Dictionary<string, int>();
    
    public void Register(VendingMachine vm)
    {
        vendingMachines.Add(vm);
    }
    public int NumberOfVm()
    {
        return vendingMachines.Count();
    }
    public int SoldItems()
    {
        int totalSales = 0;
        foreach (var vm in vendingMachines)
        {
          totalSales +=  vm.MoneyAccumulated();
        }
        return totalSales;
    }
    public Dictionary<string, int> AllSoldItems()
    {
        foreach (var vm in vendingMachines)
        {
            foreach (var item in vm.trackingSoldItem)
            {
                if(soldProducts.ContainsKey(item.Key))
                {
                    soldProducts[item.Key] += item.Value;
                }
                else
                {
                    soldProducts.Add(item.Key, item.Value);
                }
                
            }
        }
        return soldProducts;
    }
    public string  MostPopularProduct()
    {
        int countPopularItem = 0; 
        string mostpopularItem = "";
        foreach (var item in AllSoldItems())
        {
            if(item.Value >= countPopularItem)
            {
                countPopularItem = item.Value;
                mostpopularItem = item.Key;
            }
        }
        return mostpopularItem;
    }
    public string LeastPopularProduct()
    {
        int countleastpopular = 1;
        string leastpopularitem = "";
        foreach (var product in AllSoldItems())
        {
            if(product.Value >= countleastpopular)
            {
                countleastpopular = product.Value;
                leastpopularitem = product.Key;
            }
        }
        return leastpopularitem;
    }
}
