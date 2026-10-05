using System;

namespace Part3_BuilderPattern
{
    public class InvoiceBuilder
    {
        internal string InvoiceId;
        internal string CustomerName;
        internal string CustomerEmail;
        internal string CustomerPhone;

        internal string BillingStreet, BillingCity, BillingState, BillingZipCode, BillingCountry;
        internal string ShippingStreet, ShippingCity, ShippingState, ShippingZipCode, ShippingCountry;

        internal DateTime OrderDate = DateTime.Now;
        internal string PaymentMethod;
        internal string Currency = "USD";
        internal decimal SubTotal;
        internal decimal DiscountAmount;
        internal decimal TaxAmount;

        public InvoiceBuilder WithId(string invoiceId)
        {
            InvoiceId = invoiceId;
            return this;
        }

        public InvoiceBuilder WithCustomer(string name, string email, string phone)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Customer name and email are mandatory.");
            CustomerName = name;
            CustomerEmail = email;
            CustomerPhone = phone;
            return this;
        }

        public InvoiceBuilder WithBillingAddress(Action<AddressBuilder> action)
        {
            var addressBuilder = new AddressBuilder();
            action(addressBuilder);

            BillingStreet = addressBuilder.Street;
            BillingCity = addressBuilder.City;
            BillingState = addressBuilder.State;
            BillingZipCode = addressBuilder.ZipCode;
            BillingCountry = addressBuilder.Country;
            return this;
        }

        public InvoiceBuilder WithShippingAddress(Action<AddressBuilder> action)
        {
            var addressBuilder = new AddressBuilder();
            action(addressBuilder);

            ShippingStreet = addressBuilder.Street;
            ShippingCity = addressBuilder.City;
            ShippingState = addressBuilder.State;
            ShippingZipCode = addressBuilder.ZipCode;
            ShippingCountry = addressBuilder.Country;
            return this;
        }

        public InvoiceBuilder WithOrderInfo(Action<OrderBuilder> action)
        {
            var orderBuilder = new OrderBuilder();
            action(orderBuilder);

            OrderDate = orderBuilder.OrderDate;
            PaymentMethod = orderBuilder.PaymentMethod;
            Currency = orderBuilder.Currency;
            SubTotal = orderBuilder.SubTotal;
            DiscountAmount = orderBuilder.DiscountAmount;
            TaxAmount = orderBuilder.TaxAmount;
            return this;
        }

        public Invoice Build()
        {
            if (string.IsNullOrWhiteSpace(InvoiceId)) throw new InvalidOperationException("InvoiceId is mandatory.");
            if (string.IsNullOrWhiteSpace(CustomerName)) throw new InvalidOperationException("CustomerName is mandatory.");
            if (string.IsNullOrWhiteSpace(BillingCity)) throw new InvalidOperationException("Billing Address is incomplete.");

            return new Invoice(this);
        }
    }
}