-- Table creation (no changes to the original schema)
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100),
    Email NVARCHAR(100) UNIQUE,
    PhoneNumber NVARCHAR(20),
    Address NVARCHAR(255),
    PaymentMethod NVARCHAR(50)
);

CREATE TABLE MenuItems (
    MenuItemID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100),
    Description NVARCHAR(255),
    Price DECIMAL(10, 2),
    QuantityAvailable INT,
    ImageURL NVARCHAR(255)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT,
    OrderDate DATETIME,
    OrderTime TIME,
    OrderStatus NVARCHAR(50),
    TotalPrice DECIMAL(10, 2),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);

CREATE TABLE OrderItems (
    OrderItemID INT PRIMARY KEY IDENTITY(1,1),
    OrderID INT,
    MenuItemID INT,
    Quantity INT,
    Price DECIMAL(10, 2),
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (MenuItemID) REFERENCES MenuItems(MenuItemID)
);

CREATE TABLE Transactions (
    TransactionID INT PRIMARY KEY IDENTITY(1,1),
    OrderID INT,
    TransactionDate DATETIME,
    Amount DECIMAL(10, 2),
    PaymentMethod NVARCHAR(50),
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID)
);

CREATE TABLE Admin (
    AdminID INT PRIMARY KEY IDENTITY(1,1),
    Email NVARCHAR(100) UNIQUE,
    Password NVARCHAR(100),
    Name NVARCHAR(100)
);

CREATE TABLE EmployeeDetails (
    EmployeeID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100),
    Email NVARCHAR(100) UNIQUE,
    PhoneNumber NVARCHAR(20),
    BankName NVARCHAR(100),
    AccountNumber NVARCHAR(20),
    Password NVARCHAR(100)
);

CREATE TABLE SalesData (
    SalesID INT PRIMARY KEY IDENTITY(1,1),
    TransactionID INT,
    SalesAmount DECIMAL(10, 2),
    Date DATETIME,
    Time TIME,
    FOREIGN KEY (TransactionID) REFERENCES Transactions(TransactionID)
);

-- Insert Admin Data
INSERT INTO Admin (Email, Password, Name) VALUES 
('alyssa@gmail.com', 'alyssa14POP', 'Alyssa'),
('azwin@gmail.com', 'azwin02POP', 'Azwin'),
('aisyah@gmail.com', 'aisyah00POP', 'Aisyah');

-- Insert Employee Data
INSERT INTO EmployeeDetails (Name, Email, PhoneNumber, BankName, AccountNumber, Password) VALUES
('Alyssa', 'alyssa@gmail.com', '1234567890', 'Bank A', '123456789', 'alyssa14POP'),
('Azwin', 'azwin@gmail.com', '0987654321', 'Bank B', '987654321', 'azwin02POP'),
('Aisyah', 'aisyah@gmail.com', '1122334455', 'Bank C', '112233445', 'aisyah00POP');
