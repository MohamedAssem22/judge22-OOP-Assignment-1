using System;

namespace Part3_BuilderPattern
{
    public class OrderBuilder
    {
        internal DateTime OrderDate = DateTime.Now;
        internal string PaymentMethod;
        internal string Currency = "USD";
        internal decimal SubTotal;
        internal decimal DiscountAmount;
        internal decimal TaxAmount;

        public OrderBuilder WithOrderDate(DateTime orderDate)
        {
            OrderDate = orderDate;
            return this;
        }

        public OrderBuilder WithPaymentMethod(string paymentMethod)
        {
            if (string.IsNullOrWhiteSpace(paymentMethod)) throw new ArgumentException("Payment method is required.");
            PaymentMethod = paymentMethod;
            return this;
        }

        public OrderBuilder WithCurrency(string currency)
        {
            Currency = currency;
            return this;
        }

        public OrderBuilder WithFinancials(decimal subTotal, decimal discountAmount, decimal taxAmount)
        {
            if (subTotal < 0) throw new ArgumentException("SubTotal cannot be negative.");
            SubTotal = subTotal;
            DiscountAmount = discountAmount;
            TaxAmount = taxAmount;
            return this;
        }
    }
}