public class Product
{
    public string? ProductName;
    public int Price;
    public string? Size;

    public Product(string productname, int price, string size)
    {
        ProductName = productname;
        Price = price; 
        Size = size;
    }
}
public class Chocolate : Product
{
  public Chocolate(string name, int price, string size) : base(name, price, size)
  {
    ProductName = name;
    Price = price;
    Size = size;

  }
}
public class Chip : Product
{
    public Chip(string nameofChoc, int priceofChoc, string sizeOfChoc) : base(nameofChoc, priceofChoc,sizeOfChoc)
    {
        ProductName = nameofChoc;
        Price = priceofChoc;
        Size = sizeOfChoc;
    }
    
}
public class Soda : Product
{
    public Soda(string nameOfSoda, int priceOfSoda, string sizeOfSoda) : base(nameOfSoda, priceOfSoda, sizeOfSoda)
    {
        ProductName = nameOfSoda;
        Price = priceOfSoda;
        Size = sizeOfSoda;
    }
}
public class Sweeets : Product
{
    public Sweeets(string sweetsName, int sweetPrice, string sweetSize) : base(sweetsName, sweetPrice, sweetSize)
    {
        ProductName = sweetsName;
        Price = sweetPrice;
        Size = sweetSize;
    }

}