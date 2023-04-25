CREATE DATABASE Validaciones
USE Validaciones
CREATE TABLE Users (
   Id INT PRIMARY KEY IDENTITY(1,1),
   Username VARCHAR(50) NOT NULL UNIQUE,
   PasswordHash VARBINARY(256) NOT NULL
);
CREATE TABLE Product (
    Id INT PRIMARY KEY IDENTITY,
    Name VARCHAR(50) NOT NULL,
    Description VARCHAR(100),
    Price DECIMAL(10,2) NOT NULL,
    Quantity INT NOT NULL DEFAULT 0,
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE()
)
INSERT INTO Product (Name, Description, Price, Quantity, IsActive, CreatedDate)
VALUES	('Camiseta', 'Camiseta de algodón para hombre', 15.99, 50, 1, GETDATE()),
		('Pantalón', 'Pantalón de mezclilla para mujer', 25.50, 30, 1, GETDATE()),
	    ('Zapatos', 'Zapatos de cuero para niño', 19.99, 20, 1, GETDATE());

INSERT INTO Users (Username, PasswordHash) 
VALUES ('usuario1', HASHBYTES('SHA2_256', '1231')),
       ('usuario2', HASHBYTES('SHA2_256', '1232')),
       ('usuario3', HASHBYTES('SHA2_256', '1233'));

GO
CREATE PROCEDURE SP_UserValidator --SP_UserValidator 'usuario1','1231'
  @VCH_Username VARCHAR(50),
  @VCH_Password VARCHAR(50)
AS
BEGIN
  IF EXISTS (
    SELECT 1
    FROM Users
    WHERE Username = @VCH_Username AND PasswordHash = HASHBYTES('SHA2_256', @VCH_Password)
  )
  BEGIN
    SELECT 1 AS Result;
  END
  ELSE
  BEGIN
    SELECT 0 AS Result;
  END
END
GO
CREATE PROCEDURE SP_ListAllProducts
AS
BEGIN
    SELECT Id, Name, Description, Price, Quantity, IsActive, CreatedDate
    FROM Product
END
GO
CREATE PROCEDURE sp_ListProductById
    @ProductId INT
AS
BEGIN
    SELECT Id, Name, Description, Price, Quantity, IsActive, CreatedDate
    FROM Product
    WHERE Id = @ProductId
END