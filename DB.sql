CREATE DATABASE Validaciones
USE Validaciones
CREATE TABLE Users (
   Id INT PRIMARY KEY IDENTITY(1,1),
   Username NVARCHAR(50) NOT NULL UNIQUE,
   PasswordHash VARBINARY(256) NOT NULL
);

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
    SELECT 1 AS IsValid;
  END
  ELSE
  BEGIN
    SELECT 0 AS IsValid;
  END
END