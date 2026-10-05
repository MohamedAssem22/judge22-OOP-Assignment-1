# Part 3: Builder Pattern - Answers & Design Rationale

## Task 3.1 — The 20-Parameter Constructor Problem

### 1. Why is a single 20-parameter constructor for this class a problem in practice?
Using a single 20-parameter constructor introduces several severe practical issues:
* **Call-Site Readability & Maintainability:** Reading or writing a method call with 20 arguments is extremely difficult. It is nearly impossible to tell which argument corresponds to which property without constantly jumping back and forth to the constructor definition.
* **Type & Position Errors (Data Swapping):** Because many properties share the same data types (e.g., multiple `string` values for addresses/names, or multiple `decimal` values for amounts), passing two arguments in the wrong order compiles successfully but leads to logical bugs that are hard to track down (e.g., swapping `BillingZipCode` with `ShippingZipCode` or `TaxAmount` with `DiscountAmount`).
* **Fragility with Optional Properties:** The day a developer needs to add an optional property, they are forced to either modify the massive constructor, create multiple overloaded constructors (telescoping constructor anti-pattern), or break existing client code.

### 2. Is this purely a "constructor is too long" problem, or a deeper design issue?
It is a **deeper architectural design issue** rather than just a superficial formatting problem. Having ~20 loosely related properties slapped onto a single class violates core Object-Oriented principles, specifically the **Single Responsibility Principle (SRP)**. An Invoice shouldn't have to directly manage and know the granular validation rules of separate sub-domains like billing addresses, shipping addresses, and payment calculations all by itself. It indicates that the class is missing proper composition (grouping related data into smaller, cohesive domain concepts like `Address` or `PaymentDetails`).

---

### Task 3.3 — Why Composed Builders are Better

### 1. Single Responsibility Principle (SRP)
Each small builder focuses exclusively on its own domain context. `AddressBuilder` only knows how to construct and validate a valid address, while `OrderBuilder` only handles order-specific data. They do not need to care about the rest of the invoice.

### 2. Independent Validation
With composed builders, validation logic is decentralized and localized. `AddressBuilder` can independently guarantee that a complete, valid address is constructed (e.g., checking that street, city, and zip code are valid) before the parent invoice object even touches it, preventing invalid states in memory.

### 3. Code Reuse & Avoiding Duplication
An invoice requires both a billing address and a shipping address. By using a reusable `AddressBuilder`, we avoid duplicating the validation and construction logic twice for both address types. Without it, you would have to rewrite or copy-paste identical address-handling logic.

### 4. Readability at the Call Site
Constructing an object using composed fluent builders reads almost like natural language:
```csharp
var invoice = new InvoiceBuilder()
    .WithCustomerDetails("John Doe", "john@email.com", "555-0199")
    .WithBillingAddress(ab => ab.WithStreet("123 Main St").WithCity("Cairo").WithZip("11511").WithCountry("Egypt"))
    .WithShippingAddress(ab => ab.WithStreet("456 Market St").WithCity("Giza").WithZip("12511").WithCountry("Egypt"))
    .WithOrderInfo(ob => ob.WithPaymentMethod("CreditCard").WithCurrency("USD").WithAmounts(100.0m, 10.0m, 5.0m))
    .Build();