namespace Part1_ProceduralToOOP;

public class OrderLine
{
    public Product Product { get; set; }
    public int Quantity { get; set; }

    public decimal TotalPrice => Product.Price * this.Quantity;

    public OrderLine(Product product, int quantity)
    {
        this.Product = product;
        this.Quantity = quantity; 
    }
}