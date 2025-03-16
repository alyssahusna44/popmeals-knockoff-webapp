# 🥡 PopMealsKnockoff Web Application

## 📌 Overview
This project is an **ASP.NET-based online ordering system** for food and beverages. This project enables **customers** to browse menu items, place orders, and make payments, while **administrators** manage orders, sales, and transactions efficiently.

## 📖 Table of Contents
1. [Overview](#-overview)
2. [System Overview](#-system-overview)
3. [Features & Functionalities](#-features--functionalities)
4. [Technology Stack](#-technology-stack)
5. [Database Design](#-database-design)
6. [User Interface](#-user-interface)
7. [Installation & Setup](#-installation--setup)
8. [Usage](#-usage)
9. [Conclusion](#-conclusion)

## 🔎 System Overview
The **PopMeals Web Application** is designed for the **food and beverage industry**, enabling seamless order management through an interactive **web-based platform**.

**User Roles:**
- **Admin**: Manages orders, sales, and menu items.
- **Customer**: Browses menu, places orders, and completes payments.

## 🚀 Features & Functionalities
### ✅ Admin
- **Dashboard** for monitoring key metrics.
- **View Orders** and **update order status**.
- **View Sales Reports** with transaction history.
- **Manage Menu Items** (Add, Update, Delete).

### ✅ Customer
- **Browse Menu Items** with filtering options.
- **Add Items to Cart** and modify orders.
- **Checkout & Make Payment** via secure transactions.
- **View Order Confirmation** and track order status.

 🛠️ Technology Stack
- **Frontend**: HTML, CSS
- **Backend**: ASP.NET, C#
- **Database**: Microsoft SQL Server
- **Development Tools**: Visual Studio, SQL Server Management Studio##

## 🗃️ Database Design
### 📌 Tables
- **Admin**: Stores admin login credentials.
- **Customers**: Stores customer details.
- **MenuItems**: Stores food item details.
- **Orders & OrderItems**: Handles order tracking.
- **Transactions**: Manages payment records.

### 📌 Stored Procedures
- `GetAllMenuItems()`
- `InsertCustomer()`
- `InsertOrder()`
- `GetOrdersByCustomer()`
- `UpdateOrderStatus()`
- `InsertTransaction()`

## 🎨 User Interface
### 🛒 Customer Pages
- **Login / Register**
- **Menu Page**
- **Cart & Checkout**
- **Order Confirmation**

### 🛠️ Admin Pages
- **Login Page**
- **Admin Dashboard**
- **Order Management**
- **Sales Reports**

## ⚙️ Installation & Setup
1. **Clone the Repository**
   ```bash
   git clone https://github.com/alys-source14/popmeals-webapp.git
   cd popmeals-webapp
   ```

2. **Open in Visual Studio**
   - Load the solution file (`.sln`).
   - Ensure dependencies are restored.

3. **Configure Database**
   - Import `PopMealsDB.mdf` into **SQL Server**.
   - Run the provided **Stored Procedures**.

4. **Run the Application**
   - Press `F5` in Visual Studio.
   - Navigate to `http://localhost:xxxx/` in your browser.

## 📝 Usage
### 🛒 For Customers
1. **Register/Login** into the system.
2. **Browse Menu** and add items to cart.
3. **Checkout** and complete payment.
4. **Track Orders** from the dashboard.

### 🔑 For Admins
1. **Login** using admin credentials.
2. **Manage Orders** and update statuses.
3. **Track Sales Reports** for business insights.

## 📌 Conclusion
PopMeals provides an **efficient online ordering system** for restaurants and night markets. With its **user-friendly interface** and **secure transactions**, it ensures a seamless experience for both **customers and administrators**.

## 💡 Contributors
- **Alyssa Husna binti Jamarizan**
- **Alya Azwin binti Zamri**
- Nur Aisyah binti Anauar

📌 **Course:** ISB42403 Web Application Development  
📌 **Lecturer:** Sir Azrai Abdul Aziz  

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
