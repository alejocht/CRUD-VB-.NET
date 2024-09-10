USE [pruebademo]
GO

-- Vaciar las tablas
--TRUNCATE TABLE [dbo].[ventasitems];
--TRUNCATE TABLE [dbo].[ventas];
--TRUNCATE TABLE [dbo].[productos];
--TRUNCATE TABLE [dbo].[clientes];
--GO

-- Reiniciar los valores de identidad
--DBCC CHECKIDENT ('[dbo].[ventasitems]', RESEED, 1);
--DBCC CHECKIDENT ('[dbo].[ventas]', RESEED, 1);
--DBCC CHECKIDENT ('[dbo].[productos]', RESEED, 1);
--DBCC CHECKIDENT ('[dbo].[clientes]', RESEED, 1);
--GO

-- Insertar datos en la tabla clientes
INSERT INTO [dbo].[clientes] ([Cliente], [Telefono], [Correo])
VALUES
    ('Juan Pérez', '555-1234', 'juan.perez@example.com'),
    ('Ana Gómez', '555-5678', 'ana.gomez@example.com'),
    ('Carlos Martínez', '555-8765', 'carlos.martinez@example.com'),
    ('Laura Fernández', '555-4321', 'laura.fernandez@example.com'),
    ('Pedro Sánchez', '555-6789', 'pedro.sanchez@example.com');
GO

-- Insertar datos en la tabla productos
INSERT INTO [dbo].[productos] ([Nombre], [Precio], [Categoria])
VALUES
    ('Laptop', 1200.00, 'Electronics'),
    ('Smartphone', 800.00, 'Electronics'),
    ('Tablet', 400.00, 'Electronics'),
    ('Chair', 100.00, 'Furniture'),
    ('Desk', 250.00, 'Furniture'),
    ('Pen', 1.50, 'Stationery'),
    ('Notebook', 5.00, 'Stationery');
GO

-- Insertar datos en la tabla ventas
INSERT INTO [dbo].[ventas] ([IDCliente], [Fecha], [Total])
VALUES
    (1, '2024-09-01', 1200.00),
    (2, '2024-09-02', 800.00),
    (3, '2024-09-03', 250.00),
    (4, '2024-09-04', 105.00),
    (5, '2024-09-05', 6.50);
GO

-- Insertar datos en la tabla ventasitems
INSERT INTO [dbo].[ventasitems] ([IDVenta], [IDProducto], [PrecioUnitario], [Cantidad], [PrecioTotal])
VALUES
    (1, 1, 1200.00, 1, 1200.00),
    (2, 2, 800.00, 1, 800.00),
    (3, 5, 250.00, 1, 250.00),
    (4, 4, 100.00, 1, 100.00),
    (4, 7, 5.00, 1, 5.00),
    (5, 7, 5.00, 1, 5.00),
    (5, 6, 1.50, 1, 1.50);
GO
