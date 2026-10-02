namespace Part1_ProceduralToOOP;

public class Order
{
    private List<OrderLine> _orderLines = new List<OrderLine>(); 
    public int Id { get; set; }
    public Customer Customer { get; set; }
    public DateTime OrderDate { get; set; }
    public bool IsPaid { get; set; }

    // public List<OrderLine> OrderLines { get; private set; } = new List<OrderLine>();
    public List<OrderLine> OrderLines => _orderLines;
    
    public Order(int id, Customer customer, DateTime orderDate, bool isPaid)
    {
        this.Id = id;
        this.Customer = customer;
        this.OrderDate = orderDate;
        this.IsPaid = isPaid; 
    }

    public bool AddOrderLine(OrderLine? newLine)
    {
        if (newLine == null)
        {
            return false;
        }

        if (newLine.Quantity > newLine.Product.Stock)
        {
            Console.WriteLine($"Error: Not enough stock for {newLine.Product.Name}. Available: {newLine.Product.Stock}");
            return false; 
        }

        newLine.Product.Stock -= newLine.Quantity;
        _orderLines.Add(newLine);
        return true;
    }

    public decimal CalculateTotal()
    {
        decimal total = 0m;
        foreach (var line in _orderLines)
        {
            total += line.TotalPrice; 
        }

        if (Customer != null && Customer.IsVip == true)
        {
            total = total * 0.90m;
        }
        return total; 
    }
}