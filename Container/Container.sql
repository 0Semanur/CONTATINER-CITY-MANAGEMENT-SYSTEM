create database container
use container
-- PERSON TABLE
CREATE TABLE PERSON (
    ssN VARCHAR(11) PRIMARY KEY,
    BirthDate DATE NOT NULL,
    Surname NVARCHAR(50) NOT NULL,
    Age INT NOT NULL,
    BloodType CHAR(3) CHECK (BloodType IN ('A+', 'A-', 'B+', 'B-', 'AB+', 'AB-', 'O+', 'O-')),
    City NVARCHAR(50),
    District NVARCHAR(50),
    Neighbourhood NVARCHAR(50),
    Pname NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100),
    PhoneNumber NVARCHAR(20),
    BirthPlace NVARCHAR(50),
    Address NVARCHAR(100),
    FullName AS (Pname + ' ' + Surname) PERSISTED,
    CONSTRAINT chk_Age CHECK (Age >= 0)
);

-- PERSONRECEIVINGSERVICE TABLE
CREATE TABLE PersonReceivingService (
    ServiceID INT PRIMARY KEY IDENTITY(1,1),
    ssN VARCHAR(11),
    containerNo INT UNIQUE, -- Benzersiz kýsýtlama eklendi
    FOREIGN KEY (ssN) REFERENCES PERSON(ssN) ON DELETE CASCADE
);


-- DEPARTMENT TABLE
CREATE TABLE department (
    deptno INT PRIMARY KEY,
    deptname NVARCHAR(50),
    deptLocation NVARCHAR(50)
);

-- EMP TABLE
CREATE TABLE emp (
    empno INT PRIMARY KEY NOT NULL IDENTITY(1000,1),
    ename NVARCHAR(50),
    salary FLOAT,
    deptno INT,
    hireDate DATETIME,
    deptDescription NVARCHAR(50),
    ssN VARCHAR(11),
    FOREIGN KEY (deptno) REFERENCES department(deptno),
    FOREIGN KEY (ssN) REFERENCES person(ssN) ON DELETE CASCADE
);


-- WAREHOUSE TABLE
CREATE TABLE Warehouse (
    warehouseId DECIMAL(4) PRIMARY KEY,
    locations NVARCHAR(100)
);

-- SUPPLIER TABLE
CREATE TABLE Supplier (
    supplierName NVARCHAR(100),
    supplierId DECIMAL(4) PRIMARY KEY
);

-- PRODUCTS TABLE
CREATE TABLE Products (
    descriptions NVARCHAR(100),
    ProductName NVARCHAR(100),
    ProductId DECIMAL(4) PRIMARY KEY,
    StockQuantity DECIMAL(5) CHECK (StockQuantity >= 0)
);

-- ORDERS TABLE
create TABLE Orders (
    OrderId INT PRIMARY KEY IDENTITY(1,1),
    OrderName NVARCHAR(100) NOT NULL,
    OrderDescription NVARCHAR(255),
    containerNo INT,
	 ProductId DECIMAL(4),
	  FOREIGN KEY (ProductId) REFERENCES Products(ProductId),
    FOREIGN KEY (containerNo) REFERENCES PersonReceivingService(containerNo)
);


-- SHIPMENT TABLE
CREATE TABLE Shipment (
    shipmentId DECIMAL(4) PRIMARY KEY,
    warehouseId DECIMAL(4) NOT NULL,
    supplierId DECIMAL(4) NOT NULL,
    productId DECIMAL(4) NOT NULL,
    shipmentDate DATE NOT NULL,
    quantity INT NOT NULL,
    FOREIGN KEY (warehouseId) REFERENCES Warehouse(warehouseId),
    FOREIGN KEY (supplierId) REFERENCES Supplier(supplierId),
    FOREIGN KEY (productId) REFERENCES Products(ProductId)
);

-- EMPTASK TABLE
CREATE TABLE Emptask (
    taskId INT PRIMARY KEY IDENTITY(1,1),
    empno INT,
    task NVARCHAR(100),
    FOREIGN KEY (empno) REFERENCES emp(empno) ON DELETE CASCADE
);

-- PERSON TABLOSU ÝÇÝN INSERT
INSERT INTO PERSON (ssN, BirthDate, Surname, Age, BloodType, City, District, Neighbourhood, Pname, Email, PhoneNumber, BirthPlace, Address)
VALUES
('12345678901', '1990-05-15', 'Ali', 34, 'O+', 'Osmaniye', 'Merkez', 'Brooklyn', 'John', 'john.doe@gmail.com', '555-1234', 'New York', '1234 Elm Street'),
('23456789012', '1985-08-25', 'Hülya', 39, 'A-', 'Osmaniye', 'Merkez', 'Westwood', 'Jane', 'jane.smith@gmail.com', '555-5678', 'Los Angeles', '5678 Oak Avenue'),
('34567890123', '1992-03-10', 'Mehmet', 32, 'B+', 'Adana', 'Seyhan', 'Yüreðir', 'Ahmet', 'ahmet.kilic@gmail.com', '555-8765', 'Mersin', '1234 River Road'),
('45678901234', '1987-11-20', 'Ayþe', 37, 'AB-', 'Ýstanbul', 'Kadýköy', 'Fenerbahçe', 'Fatma', 'fatma.tunc@gmail.com', '555-4321', 'Ýstanbul', '12 Bosphorus St.'),
('56789012345', '1995-07-30', 'Kemal', 29, 'O-', 'Ankara', 'Çankaya', 'Kocatepe', 'Murat', 'murat.ozdemir@gmail.com', '555-9988', 'Bolu', '5 Atatürk Boulevard'),
('67890123456', '1983-02-14', 'Emine', 41, 'A+', 'Antalya', 'Konyaaltý', 'Liman', 'Elif', 'elif.ozdemir@gmail.com', '555-3344', 'Bursa', '34 Seaside Road'),
('78901234567', '1997-09-05', 'Hasan', 27, 'B-', 'Konya', 'Selçuklu', 'Yeniþehir', 'Süleyman', 'suleyman.yildirim@gmail.com', '555-2233', 'Sakarya', '45 Orchard Lane'),
('89012345678', '2000-01-01', 'Zeynep', 24, 'O+', 'Ýzmir', 'Bornova', 'Çýplak', 'Cemre', 'cemre.karaca@gmail.com', '555-7788', 'Bolu', '99 Coastal Road'),
('90123456789', '1998-05-22', 'Murat', 26, 'AB+', 'Trabzon', 'Ortahisar', 'Yenimahalle', 'Gökhan', 'gokhan.kucuk@gmail.com', '555-1122', 'Eskiþehir', '15 Dede Korkut Avenue'),
('01234567890', '1994-12-05', 'Fatma', 30, 'A-', 'Kayseri', 'Melikgazi', 'Ýldem', 'Burcu', 'burcu.kaya@gmail.com', '555-7766', 'Sivas', '25 Mountain View Blvd');

-- PERSONRECEIVINGSERVICE TABLOSU ÝÇÝN INSERT
INSERT INTO PersonReceivingService (ssN, containerNo)
VALUES
('12345678901', 101),
('23456789012', 102);

-- DEPARTMENT TABLOSU ÝÇÝN INSERT
INSERT INTO Department (deptNo, deptName, deptLocation)
VALUES
    (10, 'Administrator', 'Building A'),
    (20, 'Information Processing', 'Building B'),
    (30, 'Cooker', 'Kitchen'),
    (40, 'Security', 'Main Entrance'),
    (50, 'Cleaning', 'Maintenance'),
    (60, 'Technical', 'Tech Lab'),
    (70, 'Psychologist', 'Office 101'),
    (80, 'Attendant', 'Lobby'),
    (90, 'Controller', 'Control Room'),
    (100, 'Distributor', 'Warehouse');


--- EMP ÝCÝN ÝNSERT
INSERT INTO Emp (ename, salary, deptNo, hireDate, deptDescription, ssN)
VALUES
('Murat', 55000.00, 10, '2020-01-15', 'Administrator', '90123456789'),
('Ayþe', 60000.00, 20, '2021-03-10', 'Information Processing', '45678901234'),
('Emre', 50000.00, 30, '2022-05-20', 'Cooker', '34567890123'),
('Fatma', 45000.00, 40, '2023-06-25', 'Security', '01234567890'),
('Elif', 65000.00, 50, '2019-08-11', 'Cleaning', '56789012345'),
('Ahmet', 70000.00, 60, '2018-07-15', 'Technical', '67890123456'),
('Zeynep', 53000.00, 70, '2022-02-18', 'Psychologist', '89012345678'),
('Mehmet', 56000.00, 80, '2021-11-03', 'Attendant', '23456789012'),
('Hasan', 48000.00, 90, '2020-12-08', 'Controller', '78901234567'),
('Serap', 60000.00, 100, '2023-01-22', 'Distributor', '90123456789');



-- WAREHOUSE TABLOSU ÝÇÝN INSERT
INSERT INTO Warehouse (warehouseId, locations)
VALUES
(1, 'Konteyner Kent Deposu A1'),
(2, 'Konteyner Kent Deposu B3'),
(3, 'Konteyner Kent Deposu C2'),
(4, 'Konteyner Kent Deposu D5'),
(5, 'Konteyner Kent Deposu E3');

-- SUPPLIER TABLOSU ÝÇÝN INSERT
INSERT INTO Supplier (supplierName, supplierId)
VALUES
('Gýda Tedarik Firmasý', 1),
('Temizlik Malzemeleri Tedarik Firmasý', 2),
('Saðlýk Malzemeleri Tedarik Firmasý', 3),
('Çocuk Bakým Ürünleri Tedarik Firmasý', 4),
('Giyim Tedarik Firmasý', 5);

-- PRODUCTS TABLOSU ÝÇÝN INSERT
INSERT INTO Products (descriptions, ProductName, ProductId, StockQuantity)
VALUES
('Portable fan for hot weather', 'Fan', 201, 100),
('Basic first aid kit for emergencies', 'First Aid Kit', 202, 50),
('Portable stove for cooking', 'Portable Stove', 203, 80),
('Camping tent for outdoor use', 'Tent', 204, 40),
('Sleeping bags for warmth', 'Sleeping Bag', 205, 60),
('Water purifier for safe drinking water', 'Water Purifier', 206, 70),
('Flashlight for nighttime use', 'Flashlight', 207, 150),
('Portable charger for phones', 'Portable Charger', 208, 120),
('Heavy duty trash bags for waste disposal', 'Trash Bags', 209, 200),
('Compact cooking utensils set', 'Cooking Utensils', 210, 90),
('Hygiene products (soap, sanitizer)', 'Hygiene Kit', 211, 180),
('Clothing for cold weather', 'Winter Clothes', 212, 110),
('Basic tools for repairs', 'Tool Kit', 213, 30),
('Water bottles for hydration', 'Water Bottles', 214, 160),
('Cushions for comfort in containers', 'Cushions', 215, 130);

-- SHIPMENT TABLOSU ÝÇÝN INSERT
INSERT INTO Shipment (shipmentId, warehouseId, supplierId, productId, shipmentDate, quantity)
VALUES
(1, 1, 1, 201, '2024-12-01', 100),
(2, 2, 2, 202, '2024-12-02', 150),
(3, 3, 3, 203, '2024-12-03', 200),
(4, 4, 4, 204, '2024-12-04', 50),
(5, 5, 5, 205, '2024-12-05', 75);


INSERT INTO Emptask (empno, task)
VALUES
(1000, 'Administrative tasks and team coordination'),
(1001, 'Data analysis and reporting for information systems'),
(1002, 'Prepare and serve meals in the company cafeteria'),
(1003, 'Monitor and ensure safety protocols are followed at the security gate'),
(1004, 'Maintain cleanliness and organization within the building'),
(1005, 'Provide technical support and maintain equipment functionality'),
(1006, 'Provide counseling and mental health support for employees'),
(1007, 'Assist visitors and clients in the lobby and direct them to appropriate services'),
(1008, 'Monitor control room systems and manage operational efficiency'),
(1009, 'Coordinate product shipments and distribution schedules');



go
-- Add Employee Procedure
create PROCEDURE addEmp
    @empname NVARCHAR(50),
    @deptno INT,
    @salary FLOAT,
	@ssn varchar(11),
    @deptdecription NVARCHAR(50)
AS
BEGIN
    INSERT INTO emp (salary, ename, deptno, hireDate, deptDescription,ssN)
    VALUES (@salary, @empname, @deptno, GETDATE(), @deptdecription,@ssn);
END;
GO

-- Add Person Receiving Service Procedure
CREATE PROCEDURE addPersonReceivingService
    @ssn VARCHAR(11),
    @containerNo INT
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM PERSON WHERE ssN = @ssn)
    BEGIN
        PRINT 'Person not found in the system.'
    END
    ELSE
    BEGIN
        INSERT INTO PersonReceivingService (ssn, containerNo)
        VALUES (@ssn, @containerNo);
        PRINT 'PersonReceivingService record added successfully.'
    END
END;
GO

-- Delete Employee Procedure
CREATE PROCEDURE deleteEmp
    @empno INT
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM emp WHERE empno = @empno)
    BEGIN
        PRINT 'Employee not found in the system.'
    END
    ELSE
    BEGIN
        DELETE FROM Emptask WHERE empno = @empno;
        DELETE FROM emp WHERE empno = @empno;
        PRINT 'Employee deleted successfully.'
    END
END;
GO

-- Delete Person Receiving Service Procedure
CREATE PROCEDURE deletePersonReceivingService
    @ssn INT
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM PersonReceivingService WHERE ssn  = @ssn)
    BEGIN
        PRINT 'PersonReceivingService record not found in the system.'
    END
    ELSE
    BEGIN
        DELETE FROM PersonReceivingService WHERE ssn = @ssn;
        PRINT 'PersonReceivingService record deleted successfully.'
    END
END;
GO

-- Add Product Procedure
CREATE PROCEDURE addProduct
    @description NVARCHAR(100),
    @ProductName NVARCHAR(100),
    @ProductId DECIMAL(4),
    @StockQuantity DECIMAL(5)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Products WHERE ProductId = @ProductId)
    BEGIN
        PRINT 'Product with this ID already exists.'
    END
    ELSE
    BEGIN
        INSERT INTO Products (descriptions, ProductId, ProductName, StockQuantity)
        VALUES (@description, @ProductId, @ProductName, @StockQuantity);
        PRINT 'Product added successfully.'
    END
END;
GO

go
--------------------------GEÇMÝÞ SÝPARÝSLERÝ GÖSTERÝR
CREATE PROCEDURE pastOrder
    @ssN VARCHAR(11)
AS
BEGIN
    -- Kiþinin sisteme kayýtlý olup olmadýðýný kontrol et
    IF NOT EXISTS (SELECT 1 FROM PERSON WHERE ssN = @ssN)
    BEGIN
        PRINT 'Person not found in the system.'
    END
    ELSE
    BEGIN
        -- Kiþinin geçmiþte aldýðý hizmetlerin listesini döndür
        SELECT 
            prs.containerNo,
           o.OrderName AS ServiceName,
           o.OrderDescription AS ServiceDescription
           FROM 
            PersonReceivingService prs
        JOIN 
            Orders o ON prs.containerNo = o.containerNo
        WHERE 
            prs.ssn = @ssN;

        PRINT 'Past orders retrieved successfully.'
    END
END;
GO
--------------------------------- EMPE GÖREV EKLEME
go
CREATE PROCEDURE addTask
    @adminEmpno INT,
    @empno INT,
    @ename NVARCHAR(50),
    @deptno INT,
    @TaskDescription NVARCHAR(50)
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM emp
        WHERE empno = @adminEmpno
          AND deptno IN (SELECT deptno FROM department WHERE deptname = 'Administrator')
    )
    BEGIN
        INSERT INTO Emptask (empno, task)
        VALUES (@empno, @TaskDescription);
    END
    ELSE
    BEGIN
        PRINT 'You are not an admin';
    END
END;

--------------EMP GÖREVLERÝNÝ GÖRÜNTÜLER
go
CREATE VIEW EmployeeTasks AS
SELECT 
    e.empno,
    e.ename,
    e.salary,
    e.deptno,
    e.hireDate,
    e.deptDescription,
    et.task
FROM 
    emp e
JOIN 
    Emptask et ON e.empno = et.empno;



---BÝRDEN FAZLA KÝÞÝNÝN AYNI ORDERS TALEBÝNDE, TALEPLERÝ SIRAYA KOYUP SIRAYLA ORDERS  ATAMAK
GO
CREATE PROCEDURE AssignOrders
AS
BEGIN
    DECLARE @ServiceID INT;
    DECLARE @SSN VARCHAR(11);
    DECLARE @ContainerNo INT;
    DECLARE @OrderID DECIMAL(4);

    -- Bir cursor tanýmlayarak sýrayla kiþilere hizmet atanmasýný saðlýyoruz
    DECLARE OrderCursor CURSOR FOR
    SELECT prs.ServiceID, prs.ssN, prs.containerNo
    FROM PersonReceivingService prs
    WHERE prs.containerNo IS NULL; -- ContainerNo atanmamýþ kayýtlar için seçim yapýlýyor

    OPEN OrderCursor;

    FETCH NEXT FROM OrderCursor INTO @ServiceID, @SSN, @ContainerNo;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Sýradaki uygun OrderID deðerini almak için kontrol yapýyoruz
        SELECT TOP 1 @OrderID = o.OrderId
        FROM Orders o
        WHERE NOT EXISTS (
            SELECT 1
            FROM PersonReceivingService prs
            WHERE prs.containerNo = o.containerNo
        )
        ORDER BY o.OrderId; -- OrderID'ye göre sýralanýp ilk uygun deðer alýnýr

        -- Eðer uygun bir OrderID bulunduysa, atama yapýyoruz
        IF @OrderID IS NOT NULL
        BEGIN
            UPDATE PersonReceivingService
            SET containerNo = @OrderID
            WHERE ServiceID = @ServiceID;

            PRINT 'Order assigned successfully for ServiceID: ' + CAST(@ServiceID AS NVARCHAR(50));
        END
        ELSE
        BEGIN
            PRINT 'No available orders to assign for ServiceID: ' + CAST(@ServiceID AS NVARCHAR(50));
        END

        FETCH NEXT FROM OrderCursor INTO @ServiceID, @SSN, @ContainerNo;
    END

    CLOSE OrderCursor;
    DEALLOCATE OrderCursor;
END;
GO
---Orders OLUÞTURULURKEN STOK DURUMU KONTROL EDÝLMESÝ
CREATE TRIGGER StockCheckOnOrder
ON Orders
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @OrderId DECIMAL(4);
    DECLARE @OrderName NVARCHAR(100);
    DECLARE @OrderDescription NVARCHAR(255);
    DECLARE @ContainerNo INT;
    DECLARE @ProductId DECIMAL(4);
    DECLARE @RequestedQuantity INT;

    -- Retrieve data from the inserted row
    SELECT 
        @OrderId = OrderId,
        @OrderName = OrderName,
        @OrderDescription = OrderDescription,
        @ContainerNo = containerNo
    FROM INSERTED;

    -- Find the corresponding product and requested quantity
    SELECT 
        @ProductId = p.ProductId,
        @RequestedQuantity = 1 -- Adjust logic here if the requested quantity is part of the order structure
    FROM Products p
    JOIN PersonReceivingService prs ON prs.containerNo = @ContainerNo
    JOIN Orders o ON prs.containerNo = o.containerNo
    WHERE o.OrderId = @OrderId;

    -- Check if the stock is sufficient
    IF EXISTS (
        SELECT 1
        FROM Products
        WHERE ProductId = @ProductId AND StockQuantity >= @RequestedQuantity
    )
    BEGIN
        -- Deduct the stock quantity
        UPDATE Products
        SET StockQuantity = StockQuantity - @RequestedQuantity
        WHERE ProductId = @ProductId;

        -- Insert the order into the Orders table
        INSERT INTO Orders (OrderId, OrderName, OrderDescription, containerNo)
        VALUES (@OrderId, @OrderName, @OrderDescription, @ContainerNo);

        PRINT 'Order created successfully, and stock updated.';
    END
    ELSE
    BEGIN
        PRINT 'Insufficient stock for the requested order.';
    END
END;
GO