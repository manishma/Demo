
    
alter table Orders  drop constraint Fk_Order_Customer


    
alter table ProductInOrders  drop constraint Fk_ProductInOrder_Product


    
alter table ProductInOrders  drop constraint Fk_ProductInOrder_Order


    drop table Customers

    drop table Orders

    drop table ProductInOrders

    drop table Products

    create table Customers (
        Id INT IDENTITY NOT NULL,
       FirstName NVARCHAR(255) null,
       LastName NVARCHAR(255) null,
       primary key (Id)
    )

    create table Orders (
        Id INT IDENTITY NOT NULL,
       CustomerId INT null,
       primary key (Id)
    )

    create table ProductInOrders (
        Id INT IDENTITY NOT NULL,
       Quantity INT null,
       ProductId INT null,
       OrderId INT null,
       primary key (Id)
    )

    create table Products (
        Id INT IDENTITY NOT NULL,
       Name NVARCHAR(255) null,
       Price NUMERIC(19,5) null,
       primary key (Id)
    )

    alter table Orders 
        add constraint Fk_Order_Customer 
        foreign key (CustomerId) 
        references Customers

    alter table ProductInOrders 
        add constraint Fk_ProductInOrder_Product 
        foreign key (ProductId) 
        references Products

    alter table ProductInOrders 
        add constraint Fk_ProductInOrder_Order 
        foreign key (OrderId) 
        references Orders
