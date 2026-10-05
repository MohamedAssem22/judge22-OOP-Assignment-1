namespace Part1_ProceduralToOOP;

public class Customer
{
    public string Name { get; set; }
    public int Id { get; set; }
    public string Email { get; set; }
    public string City { get; set; }
    public bool IsVip { get; set; }

    public Customer(string name, string email, string city, bool isVip)
    {
        this.Name = name;
        this.Email = email;
        this.City = city;
        this.IsVip = isVip; 
    }

    public void CustomerInfo()
    {
        Console.WriteLine($"#{Id}  {Name}  <{Email}>  {City}  vip={(IsVip ? "yes" : "no")}");
    }
}