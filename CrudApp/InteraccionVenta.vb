Imports modelo.modelo
Imports negocio

Public Class InteraccionVenta
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
            negocio.agregar(aux)
            Console.Clear()
            agregarVentaItem()
            Console.WriteLine("La venta se agrego correctamente.")
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
            aux.fecha = InputBox("Fecha Actual: " + aux.fecha.ToString("yyyy-MM-dd") + "  Nueva fecha: ")
            aux.total = InputBox("Total Actual: " + aux.total.ToString() + "   Nuevo total: ")
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

    Public Sub agregarVentaItem(idVenta As Integer)
        Try
            Dim aux As New VentaItem
            Dim negocio As New VentaItemNegocio
            Dim producto As New Producto
            Dim negocioProducto As New ProductoNegocio
            Console.WriteLine("CREAR NUEVO VENTA ITEM:")
            aux.idVenta = idVenta
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

    Public Sub mostrarSubMenuVentas()
        Console.WriteLine("-MENU VENTAS-")
        Console.WriteLine("1. Listar")
        Console.WriteLine("2. Agregar")
        Console.WriteLine("3. Modificar")
        Console.WriteLine("4. Filtrar")
        Console.WriteLine("5. Mostrar Factura")
        Console.WriteLine("0. Volver")
        Console.WriteLine("Presione el numero que desee...")
        Dim key As ConsoleKeyInfo = Console.ReadKey()
        Console.Clear()
        Select Case key.KeyChar
            Case "1"
                mostrarVentas()
            Case "2"
                'agregarFactura()
            Case "3"
                modificarVenta()
            Case "4"
                'falta desarrollar
            Case "5"
                mostrarFactura()
            Case "0"
                Exit Sub
        End Select
    End Sub

    Public Sub mostrarFactura()
        Dim nroVenta As Integer
        nroVenta = CType(InputBox("Indique el numero de Factura: "), Integer)

        Dim negocioVenta As New VentaNegocio
        Dim negocioventaItem As New VentaItemNegocio
        Dim negocioCliente As New ClienteNegocio
        Dim venta As New Venta
        Dim lista As New List(Of VentaItem)
        Dim cliente As New Cliente


        venta = negocioVenta.listar(nroVenta)
        cliente = negocioCliente.listar(venta.idCliente)
        lista = negocioventaItem.listarItemsDeVenta(nroVenta)

        Console.WriteLine($"{"Fecha" + venta.fecha.ToString.PadRight(20)} {"Cliente: " + cliente.cliente.PadRight(80)}")
        Console.WriteLine(New String("-"c, 100))

        Console.WriteLine($"{"ID".PadRight(10)} {"ID Venta".PadRight(13)} {"ID Producto".PadRight(12)} {"Precio".PadRight(12)} {"Cantidad".PadRight(11)} {"Importe".PadRight(15)}")
        Console.WriteLine(New String("-"c, 73))
        For Each ventaItem In lista
            Console.WriteLine(ventaItem.ToString())
        Next
        Console.WriteLine($"{" ".PadRight(50)} {"TOTAL: $" + venta.total.ToString.PadRight(23)}")

        Console.ReadKey()

    End Sub

End Class
