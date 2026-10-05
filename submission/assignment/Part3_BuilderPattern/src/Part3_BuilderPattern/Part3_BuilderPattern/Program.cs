using System;

namespace Part3_BuilderPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var invoice = new InvoiceBuilder()
                    .WithId("INV-2026-001")
                    .WithCustomer("Mohamed Assem", "mohamed@example.com", "+201000000000")
                    .WithBillingAddress(ab => ab
                        .WithStreet("Tahrir Street")
                        .WithCity("Cairo")
                        .WithState("Cairo Governorate")
                        .WithZipCode("11511")
                        .WithCountry("Egypt"))
                    .WithShippingAddress(ab => ab
                        .WithStreet("Nile Street")
                        .WithCity("Giza")
                        .WithState("Giza Governorate")
                        .WithZipCode("12511")
                        .WithCountry("Egypt"))
                    .WithOrderInfo(ob => ob
                        .WithPaymentMethod("Credit Card")
                        .WithCurrency("USD")
                        .WithFinancials(500.0m, 50.0m, 25.0m))
                    .Build();

                invoice.PrintInvoiceSummary();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error building invoice: {ex.Message}");
            }
        }
    }
}