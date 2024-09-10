USE [pruebademo]
GO

-- Insertar datos en la tabla 'clientes'
INSERT INTO [dbo].[clientes] ([Cliente], [Telefono], [Correo])
VALUES 
('Juan Pérez', '555-1234', 'juan.perez@example.com'),
('María López', '555-5678', 'maria.lopez@example.com'),
('Carlos Gómez', '555-8765', 'carlos.gomez@example.com');

-- Insertar datos en la tabla 'productos'
INSERT INTO [dbo].[productos] ([Nombre], [Precio], [Categoria])
VALUES 
('Laptop', 1200.00, 'Electrónica'),
('Teléfono Móvil', 800.00, 'Electrónica'),
('Teclado', 50.00, 'Accesorios');

-- Insertar datos en la tabla 'ventas'
INSERT INTO [dbo].[ventas] ([IDCliente], [Fecha], [Total])
VALUES 
(1, '2024-09-10', 1250.00),
(2, '2024-09-11', 800.00),
(3, '2024-09-12', 50.00);

-- Insertar datos en la tabla 'ventasitems'
INSERT INTO [dbo].[ventasitems] ([IDVenta], [IDProducto], [PrecioUnitario], [Cantidad], [PrecioTotal])
VALUES 
(1, 1, 1200.00, 1, 1200.00),
(1, 3, 50.00, 1, 50.00),
(2, 2, 800.00, 1, 800.00),
(3, 3, 50.00, 1, 50.00);

GO
