using System;

namespace Part3_BuilderPattern
{
    public class Invoice
    {
        public string InvoiceId { get; }
        public string CustomerName { get; }
        public string CustomerEmail { get; }
        public string CustomerPhone { get; }

        public string BillingStreet { get; }
        public string BillingCity { get; }
        public string BillingState { get; }
        public string BillingZipCode { get; }
        public string BillingCountry { get; }

        public string ShippingStreet { get; }
        public string ShippingCity { get; }
        public string ShippingState { get; }
        public string ShippingZipCode { get; }
        public string ShippingCountry { get; }

        public DateTime OrderDate { get; }
        public string PaymentMethod { get; }
        public string Currency { get; }
        public decimal SubTotal { get; }
        public decimal DiscountAmount { get; }
        public decimal TaxAmount { get; }
        public decimal TotalAmount { get; }

        internal Invoice(InvoiceBuilder builder)
        {
            InvoiceId = builder.InvoiceId;
            CustomerName = builder.CustomerName;
            CustomerEmail = builder.CustomerEmail;
            CustomerPhone = builder.CustomerPhone;

            BillingStreet = builder.BillingStreet;
            BillingCity = builder.BillingCity;
            BillingState = builder.BillingState;
            BillingZipCode = builder.BillingZipCode;
            BillingCountry = builder.BillingCountry;

            ShippingStreet = builder.ShippingStreet;
            ShippingCity = builder.ShippingCity;
            ShippingState = builder.ShippingState;
            ShippingZipCode = builder.ShippingZipCode;
            ShippingCountry = builder.ShippingCountry;

            OrderDate = builder.OrderDate;
            PaymentMethod = builder.PaymentMethod;
            Currency = builder.Currency;
            SubTotal = builder.SubTotal;
            DiscountAmount = builder.DiscountAmount;
            TaxAmount = builder.TaxAmount;
            TotalAmount = builder.SubTotal - builder.DiscountAmount + builder.TaxAmount;
        }

        public void PrintInvoiceSummary()
        {
            Console.WriteLine($"=== INVOICE: {InvoiceId} ===");
            Console.WriteLine($"Customer: {CustomerName} ({CustomerEmail})");
            Console.WriteLine($"Billing Address: {BillingStreet}, {BillingCity}, {BillingCountry}");
            Console.WriteLine($"Shipping Address: {ShippingStreet}, {ShippingCity}, {ShippingCountry}");
            Console.WriteLine($"Total Amount: {TotalAmount} {Currency}");
            Console.WriteLine("============================");
        }
    }
}