
    
alter table Orders  drop constraint Fk_Order_Customer


    
alter table ProductInOrders  drop constraint Fk_ProductInOrder_Product


    
alter table ProductInOrders  drop constraint Fk_ProductInOrder_Order


    
alter table ProductMetadata  drop constraint Fk_ProductMetadata_Product


    drop table Customers

    drop table EntityWithComplexIds

    drop table Orders

    drop table ProductInOrders

    drop table Products

    drop table ProductMetadata

    create table Customers (
        Id INT IDENTITY NOT NULL,
       FirstName NVARCHAR(255) null,
       LastName NVARCHAR(255) null,
       Type INT not null,
       primary key (Id)
    )

    create table EntityWithComplexIds (
        Id1 NVARCHAR(255) not null,
       Id2 UNIQUEIDENTIFIER not null,
       Id3 INT not null,
       Property1 NVARCHAR(255) null,
       Property2 NVARCHAR(255) null,
       primary key (Id1, Id2, Id3)
    )

    create table Orders (
        Id INT IDENTITY NOT NULL,
       DeliveryStatus INT null,
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

    create table ProductMetadata (
        ProductId INT not null,
       Name NVARCHAR(255) null,
       Description NVARCHAR(255) null,
       Locale NVARCHAR(255) not null,
       primary key (ProductId, Locale)
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

    alter table ProductMetadata 
        add constraint Fk_ProductMetadata_Product 
        foreign key (ProductId) 
        references Products
