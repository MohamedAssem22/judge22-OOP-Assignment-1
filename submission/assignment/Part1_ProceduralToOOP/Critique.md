# Architectural Critique: Procedural Order System (C++)

This document analyzes the design flaws and architectural issues present in the legacy procedural C++ order management system (`order_system.cpp`).

## 1. Massive Global State & Lack of Encapsulation
- **The Problem:** All state variables (e.g., `customerCount`, `customerIds`, `productPrices`, `orderCount`, etc.) are declared globally at file scope. Furthermore, parallel arrays (`customerIds`, `customerNames`, `customerEmails`) are used to represent relational data instead of cohesive objects.
- **Why it’s dangerous:** Any function in the file can modify any global variable at any time without restriction. There is no encapsulation or data protection, making it impossible to guarantee valid system state.

## 2. Rigid Array Limits & Magic Numbers
- **The Problem:** The system uses fixed-size global arrays (`MAX_CUSTOMERS = 50`, `MAX_PRODUCTS = 50`, `MAX_ORDERS = 100`, `MAX_LINES_PER_ORDER = 20`).
- **Why it’s dangerous:** The application will crash, reject data, or behave unpredictably if these arbitrary limits are exceeded. There is no dynamic memory allocation or collection resizing.

## 3. Separation of Data and Behavior (Anemic Design)
- **The Problem:** Data lives in raw arrays, while behavior (functions like `calculateOrderTotal`, `markOrderPaid`, `addLineToOrder`) lives in free-floating functions scattered outside the data structures.
- **Why it’s dangerous:** Functions must manually search for indices using IDs (`findCustomerIndexById`, `findOrderIndexById`) repeatedly. This leads to tightly coupled code where business logic is heavily dependent on array manipulation and index lookups.

## 4. Fragile Parallel Array Synchronization
- **The Problem:** Relational data is split across independent arrays linked only by index positions (e.g., `customerIds[i]` corresponds to `customerNames[i]`).
- **Why it’s dangerous:** If an error occurs during sorting, deletion, or insertion logic, indices can easily go out of sync, leading to data corruption (e.g., assigning an order to the wrong customer or mixing up product prices).

## 5. Poor Maintainability and Scalability
- **The Problem:** All logic—from data storage and business rules to user interface menus—is crammed into a single massive file.
- **Why it’s dangerous:** Adding a new feature (like discounts, tax calculations, or multiple payment methods) requires modifying global structures and risking side effects across the entire codebase.