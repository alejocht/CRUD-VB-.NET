Imports modelo.modelo
Imports negocio

Public Class Interaccion
    Public Sub mostrarProductos()
        Try
            Dim productoNegocio As New ProductoNegocio
            Dim lista As New List(Of Producto)
            lista = productoNegocio.listar()
            Console.WriteLine($"{"ID".PadRight(10)} {"Nombre".PadRight(50)} {"Precio".PadRight(20)} {"Categoria".PadRight(20)}")
            Console.WriteLine(New String("-"c, 100))
            For Each producto In lista
                Console.WriteLine(producto.ToString())
            Next
            Console.WriteLine("Toca una tecla para continuar...")
            Console.ReadKey()
        Catch ex As Exception
            Console.WriteLine("Hubo un error al mostrar la lista:" + ex.Message)
            Console.WriteLine("Toca una tecla para continuar...")
            Console.ReadKey()
            Console.Clear()
        End Try

    End Sub

    Public Sub agregarProducto()
        Try
            Dim aux As New Producto
            Dim productoNegocio As New ProductoNegocio
            Console.WriteLine("CREAR NUEVO PRODUCTO:")
            aux.nombre = InputBox("Nombre: ")
            aux.precio = InputBox("Precio: ")
            aux.categoria = InputBox("Categoria: ")
            productoNegocio.agregar(aux)
            Console.Clear()
            Console.WriteLine("El producto se agrego correctamente.")
            Console.WriteLine(aux.ToString())
            Console.WriteLine("Toca una tecla para continuar...")
            Console.ReadKey()
            Console.Clear()
        Catch ex As Exception
            Console.WriteLine("Hubo un error al agregar el producto: " + ex.Message)
            Console.WriteLine("Toca una tecla para continuar...")
            Console.ReadKey()
            Console.Clear()
        End Try
    End Sub

    Public Sub modificarProducto()
        Try
            Dim aux As New Producto
            Dim productoNegocio As New ProductoNegocio
            Dim idBuscar As Integer
            idBuscar = InputBox("Ingrese el ID del producto a modificar: ")
            aux = productoNegocio.listar(idBuscar)
            Console.Clear()
            aux.nombre = InputBox("Nombre Actual: " + aux.nombre + "  Nuevo Nombre: ")
            aux.precio = InputBox("Precio Actual: " + aux.precio.ToString() + "  Nuevo Precio: ")
            aux.categoria = InputBox("Categoria Actual: " + aux.categoria + "   Nueva Categoria: ")
            productoNegocio.modificar(aux)
            Console.WriteLine("Modificacion Exitosa.")
            Console.WriteLine("Toca una tecla para continuar...")
            Console.ReadKey()
            Console.Clear()

        Catch ex As Exception
            Console.WriteLine("Hubo un error al modificar el producto: " + ex.Message)
            Console.WriteLine("Toca una tecla para continuar...")
            Console.ReadKey()
            Console.Clear()
        End Try
    End Sub

    Public Sub mostrarClientes()
        Try
            Dim clienteNegocio As New ClienteNegocio
            Dim lista As New List(Of Cliente)
            lista = clienteNegocio.listar()
            Console.WriteLine($"{"ID".PadRight(10)} {"Cliente".PadRight(50)} {"Telefono".PadRight(20)} {"Correo".PadRight(20)}")
            Console.WriteLine(New String("-"c, 100))
            For Each cliente In lista
                Console.WriteLine(cliente.ToString())
            Next
            Console.WriteLine("Toca una tecla para continuar...")
            Console.ReadKey()
        Catch ex As Exception
            Console.WriteLine("Hubo un error al mostrar la lista:" + ex.Message)
            Console.WriteLine("Toca una tecla para continuar...")
            Console.ReadKey()
            Console.Clear()
        End Try
    End Sub

    Public Sub agregarCliente()
        Try
            Dim aux As New Cliente
            Dim clienteNegocio As New ClienteNegocio
            Console.WriteLine("CREAR NUEVO CLIENTE:")
            aux.cliente = InputBox("Cliente: ")
            aux.telefono = InputBox("Telefono: ")
            aux.correo = InputBox("Correo: ")
            clienteNegocio.agregar(aux)
            Console.Clear()
            Console.WriteLine("El cliente se agrego correctamente.")
            Console.WriteLine(aux.ToString())
            Console.WriteLine("Toca una tecla para continuar...")
            Console.ReadKey()
            Console.Clear()
        Catch ex As Exception
            Console.WriteLine("Hubo un error al agregar el cliente: " + ex.Message)
            Console.WriteLine("Toca una tecla para continuar...")
            Console.ReadKey()
            Console.Clear()
        End Try
    End Sub

    Public Sub modificarCliente()
        Try
            Dim aux As New Cliente
            Dim clienteNegocio As New ClienteNegocio
            Dim idBuscar As Integer
            idBuscar = InputBox("Ingrese el ID del cliente a modificar: ")
            aux = clienteNegocio.listar(idBuscar)
            Console.Clear()
            aux.cliente = InputBox("Cliente Actual: " + aux.cliente + "  Nuevo Cliente: ")
            aux.telefono = InputBox("Telefono Actual: " + aux.telefono + "  Nuevo telefono: ")
            aux.correo = InputBox("Categoria Actual: " + aux.correo + "   Nueva Categoria: ")
            clienteNegocio.modificar(aux)
            Console.WriteLine("Modificacion Exitosa.")
            Console.WriteLine("Toca una tecla para continuar...")
            Console.ReadKey()
            Console.Clear()

        Catch ex As Exception
            Console.WriteLine("Hubo un error al modificar el producto: " + ex.Message)
            Console.WriteLine("Toca una tecla para continuar...")
            Console.ReadKey()
            Console.Clear()
        End Try
    End Sub

    Public Sub mostrarVentas()
        Try
            Dim negocio As New VentaNegocio
            Dim lista As New List(Of Venta)
            lista = negocio.listar()
            Console.WriteLine($"{"ID".PadRight(10)} {"ID Cliente".PadRight(13)} {"Fecha".PadRight(12)} {"Total".PadRight(20)}")
            Console.WriteLine(New String("-"c, 52))
            For Each venta In lista
                Console.WriteLine(venta.ToString())
            Next
            Console.WriteLine("Toca una tecla para continuar...")
            Console.ReadKey()
        Catch ex As Exception
            Console.WriteLine("Hubo un error al mostrar la lista:" + ex.Message)
            Console.WriteLine("Toca una tecla para continuar...")
            Console.ReadKey()
            Console.Clear()
        End Try
    End Sub

    Public Sub agregarVenta()
        Try
            Dim aux As New Venta
            Dim negocio As New VentaNegocio
            Console.WriteLine("CREAR NUEVA VENTA:")
            aux.idCliente = InputBox("ID Cliente: ")
            aux.fecha = InputBox("Fecha yyyy-mm-dd : ")
            aux.total = InputBox("Total: ")
            negocio.agregar(aux)
            Console.Clear()
            Console.WriteLine("La venta se agrego correctamente.")
            Console.WriteLine(aux.ToString())
            Console.WriteLine("Toca una tecla para continuar...")
            Console.ReadKey()
            Console.Clear()
        Catch ex As Exception
            Console.WriteLine("Hubo un error al agregar la venta: " + ex.Message)
            Console.WriteLine("Toca una tecla para continuar...")
            Console.ReadKey()
            Console.Clear()
        End Try
    End Sub

    Public Sub modificarVenta()
        Try
            Dim aux As New Venta
            Dim negocio As New VentaNegocio
            Dim idBuscar As Integer
            idBuscar = InputBox("Ingrese el ID de la venta a modificar: ")
            aux = negocio.listar(idBuscar)
            Console.Clear()
            aux.idCliente = InputBox("ID Cliente Actual: " + aux.idCliente.ToString() + "  Nuevo ID Cliente: ")
            aux.fecha = InputBox("Fecha Actual: " + aux.fecha.ToString() + "  Nueva fecha: ")
            aux.total = InputBox("Total Actual: " + aux.total + "   Nuevo total: ")
            negocio.modificar(aux)
            Console.WriteLine("Modificacion Exitosa.")
            Console.WriteLine("Toca una tecla para continuar...")
            Console.ReadKey()
            Console.Clear()
        Catch ex As Exception
            Console.WriteLine("Hubo un error al modificar la venta: " + ex.Message)
            Console.WriteLine("Toca una tecla para continuar...")
            Console.ReadKey()
            Console.Clear()
        End Try
    End Sub

    Public Sub mostrarVentaItems()
        Try
            Dim negocio As New VentaItemNegocio
            Dim lista As New List(Of VentaItem)
            lista = negocio.listar()
            Console.WriteLine($"{"ID".PadRight(10)} {"ID Venta".PadRight(13)} {"ID Producto".PadRight(12)} {"Precio".PadRight(12)} {"Cantidad".PadRight(11)} {"Importe".PadRight(15)}")
            Console.WriteLine(New String("-"c, 73))
            For Each ventaItem In lista
                Console.WriteLine(ventaItem.ToString())
            Next
            Console.WriteLine("Toca una tecla para continuar...")
            Console.ReadKey()
        Catch ex As Exception
            Console.WriteLine("Hubo un error al mostrar la lista:" + ex.Message)
            Console.WriteLine("Toca una tecla para continuar...")
            Console.ReadKey()
            Console.Clear()
        End Try
    End Sub

    Public Sub agregarVentaItem()
        Try
            Dim aux As New VentaItem
            Dim negocio As New VentaItemNegocio
            Dim producto As New Producto
            Dim negocioProducto As New ProductoNegocio
            Console.WriteLine("CREAR NUEVO VENTA ITEM:")
            aux.idVenta = InputBox("ID de Venta: ")
            aux.idProducto = InputBox("ID de Producto: ")
            producto = negocioProducto.listar(aux.idProducto)
            aux.precioUnitario = producto.precio
            aux.cantidad = InputBox("Cantidad: ")
            aux.precioTotal = aux.precioUnitario * aux.cantidad
            negocio.agregar(aux)
            Console.Clear()
            Console.WriteLine("El item de venta se agrego correctamente.")
            Console.WriteLine(aux.ToString())
            Console.WriteLine("Toca una tecla para continuar...")
            Console.ReadKey()
            Console.Clear()
        Catch ex As Exception
            Console.WriteLine("Hubo un error al agregar la venta: " + ex.Message)
            Console.WriteLine("Toca una tecla para continuar...")
            Console.ReadKey()
            Console.Clear()
        End Try
    End Sub

    Public Sub modificarVentaItem()
        Try
            Dim aux As New VentaItem
            Dim negocio As New VentaItemNegocio
            Dim idBuscar As Integer
            idBuscar = InputBox("Ingrese el ID del item de venta a modificar: ")
            aux = negocio.listar(idBuscar)
            Console.Clear()
            aux.idVenta = InputBox("ID Venta Actual: " + aux.idVenta.ToString() + "  Nuevo ID Venta: ")
            aux.idProducto = InputBox("ID Producto Actual: " + aux.idProducto.ToString() + "  Nuevo ID Producto: ")
            aux.cantidad = InputBox("Cantidad Actual: " + aux.cantidad + "   Nueva cantidad: ")
            negocio.modificar(aux)
            Console.WriteLine("Modificacion Exitosa.")
            Console.WriteLine("Toca una tecla para continuar...")
            Console.ReadKey()
            Console.Clear()
        Catch ex As Exception
            Console.WriteLine("Hubo un error al modificar el item de venta: " + ex.Message)
            Console.WriteLine("Toca una tecla para continuar...")
            Console.ReadKey()
            Console.Clear()
        End Try
    End Sub

    Public Sub mostrarMenu()
        Console.WriteLine("-MENU-")
        Console.WriteLine("1. Clientes")
        Console.WriteLine("2. Productos")
        Console.WriteLine("3. Ventas")
        Console.WriteLine("0. Salir")
        Console.WriteLine("Presione el numero que desee...")
    End Sub

    Public Sub mostrarSubMenuClientes()
        Console.WriteLine("-MENU CLIENTES-")
        Console.WriteLine("1. Listar")
        Console.WriteLine("2. Agregar")
        Console.WriteLine("3. Modificar")
        Console.WriteLine("4. Filtrar")
        Console.WriteLine("0. Volver")
        Console.WriteLine("Presione el numero que desee...")
        Dim consola As New Interaccion
        Dim key As ConsoleKeyInfo = Console.ReadKey()
        Console.Clear()
        Select Case key.KeyChar
            Case "1"
                consola.mostrarClientes()
            Case "2"
                consola.agregarCliente()
            Case "3"
                consola.modificarCliente()
            Case "4"
                'falta desarrollar
            Case "0"
                Exit Sub
        End Select
    End Sub

    Public Sub mostrarSubMenuProductos()
        Console.WriteLine("-MENU PRODUCTOS-")
        Console.WriteLine("1. Listar")
        Console.WriteLine("2. Agregar")
        Console.WriteLine("3. Modificar")
        Console.WriteLine("4. Filtrar")
        Console.WriteLine("0. Volver")
        Console.WriteLine("Presione el numero que desee...")
        Dim consola As New Interaccion
        Dim key As ConsoleKeyInfo = Console.ReadKey()
        Console.Clear()
        Select Case key.KeyChar
            Case "1"
                consola.mostrarProductos()
            Case "2"
                consola.agregarProducto()
            Case "3"
                consola.modificarProducto()
            Case "4"
                'falta desarrollar
            Case "0"
                Exit Sub
        End Select
    End Sub

    Public Sub mostrarSubMenuVentas()
        Console.WriteLine("-MENU VENTAS-")
        Console.WriteLine("1. Listar")
        Console.WriteLine("2. Agregar")
        Console.WriteLine("3. Modificar")
        Console.WriteLine("4. Filtrar")
        Console.WriteLine("0. Volver")
        Console.WriteLine("Presione el numero que desee...")
        Dim consola As New Interaccion
        Dim key As ConsoleKeyInfo = Console.ReadKey()
        Console.Clear()
        Select Case key.KeyChar
            Case "1"
                consola.mostrarVentas()
            Case "2"
                consola.agregarVenta()
            Case "3"
                consola.modificarVenta()
            Case "4"
                'falta desarrollar
            Case "0"
                Exit Sub
        End Select
    End Sub

End Class
