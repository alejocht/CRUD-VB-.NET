Imports modelo
Imports modelo.modelo
Imports negocio

Public Class InteraccionVenta
    Public Sub mostrarSubMenuVentas()
        Console.WriteLine("-MENU VENTAS-")
        Console.WriteLine("1. Listar")
        Console.WriteLine("2. Agregar")
        Console.WriteLine("3. Modificar")
        Console.WriteLine("4. Mostrar Factura")
        Console.WriteLine("0. Volver")
        Console.WriteLine("Presione el numero que desee...")
        Dim key As ConsoleKeyInfo = Console.ReadKey()
        Console.Clear()
        Select Case key.KeyChar
            Case "1"
                mostrarVentas()
            Case "2"
                agregarFactura()
            Case "3"
                modificarVenta()
            Case "4"
                mostrarFactura()
            Case "0"
                Exit Sub
        End Select
    End Sub
    Public Sub mostrarFactura()
        Try
            Dim nroVenta As Integer
            mostrarVentas()
            nroVenta = CType(InputBox("Indique el ID de Venta que quiera abrir (Ventas disponibles por consola) : "), Integer)

            Dim factura As New Factura
            Dim negocio As New FacturaNegocio

            factura = negocio.listar(nroVenta)
            Console.WriteLine($"{"Fecha" + factura.cabecera.fecha.ToString("yyyy-MM-dd").PadRight(20)} {"Cliente: " + factura.cabecera.cliente.cliente.ToString.PadRight(80)}")
            Console.WriteLine(New String("-"c, 100))

            Console.WriteLine($"{"ID".PadRight(8)} {"ID Venta".PadRight(13)} {"ID Producto".PadRight(12)} {"Precio".PadRight(12)} {"Cantidad".PadRight(11)} {"Importe".PadRight(15)}")
            Console.WriteLine(New String("-"c, 73))
            For Each ventaItem In factura.detalle
                Console.WriteLine(ventaItem.ToString())
            Next
            Console.WriteLine($"{" ".PadRight(50)} {"TOTAL: $" + factura.cabecera.total.ToString.PadRight(23)}")

            Console.ReadKey()
        Catch ex As Exception
            Console.Clear()
            Console.WriteLine("Hubo un error al mostrar la factura: " + ex.Message)
            Console.WriteLine("Toca una tecla para continuar...")
            Console.ReadKey()
        End Try


    End Sub
    Public Sub mostrarFactura(nroVenta As Integer)
        Try

            Dim factura As New Factura
            Dim negocio As New FacturaNegocio

            factura = negocio.listar(nroVenta)
            Console.WriteLine($"{"Fecha" + factura.cabecera.fecha.ToString("yyyy-MM-dd").PadRight(20)} {"Cliente: " + factura.cabecera.cliente.cliente.ToString.PadRight(80)}")
            Console.WriteLine(New String("-"c, 100))

            Console.WriteLine($"{"ID".PadRight(8)} {"ID Venta".PadRight(13)} {"ID Producto".PadRight(12)} {"Precio".PadRight(12)} {"Cantidad".PadRight(11)} {"Importe".PadRight(15)}")
            Console.WriteLine(New String("-"c, 73))
            For Each ventaItem In factura.detalle
                Console.WriteLine(ventaItem.ToString())
            Next
            Console.WriteLine($"{" ".PadRight(50)} {"TOTAL: $" + factura.cabecera.total.ToString.PadRight(23)}")

            Console.ReadKey()
        Catch ex As Exception
            Console.Clear()
            Console.WriteLine("Hubo un error al mostrar la factura: " + ex.Message)
            Console.WriteLine("Toca una tecla para continuar...")
            Console.ReadKey()
        End Try


    End Sub
    Public Sub agregarFactura()
        Try
            Dim factura As New Factura
            Dim negocioVenta As New VentaNegocio
            Dim negocioVentaItem As New VentaItemNegocio
            Dim listaAux As New List(Of Venta)


            factura.cabecera = agregarVenta()
            negocioVenta.agregar(factura.cabecera)
            listaAux = negocioVenta.listar()
            Dim id As Integer

            If listaAux IsNot Nothing AndAlso listaAux.Count > 0 Then
                id = listaAux.Last.id
            Else
                id = 1
            End If

            Dim finCargaDeItems As Boolean = False
            While Not finCargaDeItems
                factura.detalle.Add(agregarVentaItem(id))
                Console.Clear()
                Console.WriteLine("Desea cargar otro item?")
                Console.WriteLine("Presione cualquier tecla para seguir o 0 para terminar la carga")
                Dim key As ConsoleKeyInfo = Console.ReadKey()
                Console.Clear()
                If key.KeyChar = "0" Then
                    finCargaDeItems = True
                End If

            End While

            For Each ventaItem In factura.detalle
                negocioVentaItem.agregar(ventaItem)
            Next

            negocioVenta.modificarTotal(id)

            Console.WriteLine("Carga exitosa")
            Console.ReadKey()
        Catch ex As Exception
            Console.Clear()
            Console.WriteLine("Hubo un error al crear la factura: " + ex.Message)
            Console.WriteLine("Toca una tecla para continuar...")
            Console.ReadKey()
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
    Public Function agregarVenta() As Venta
        Try
            Dim aux As New Venta
            Dim consola As New InteraccionCliente
            consola.diccionarioDeClientes()
            aux.cliente.id = InputBox("ID Cliente (Clientes Disponibles mostrados por consola): ")
            Console.Clear()
            aux.fecha = InputBox("Fecha yyyy-mm-dd : ")
            Console.Clear()
            Return aux
        Catch ex As Exception
            Console.WriteLine("Hubo un error al agregar la venta: " + ex.Message)
            Console.WriteLine("Toca una tecla para continuar...")
            Console.ReadKey()
            Console.Clear()
        End Try
    End Function
    Public Sub modificarVenta()
        Try
            Dim aux As New Venta
            Dim negocio As New VentaNegocio
            Dim idBuscar As Integer
            idBuscar = InputBox("Ingrese el ID de la venta a modificar: ")
            aux = negocio.listar(idBuscar)
            Console.Clear()
            aux.cliente.id = InputBox("ID Cliente Actual: " + aux.cliente.ToString() + "  Nuevo ID Cliente: ")
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
    Public Function agregarVentaItem(idVenta As Integer) As VentaItem
        Try
            Dim aux As New VentaItem
            Dim producto As New Producto
            Dim negocioProducto As New ProductoNegocio
            Dim consola As New InteraccionProducto
            aux.idVenta = idVenta
            consola.diccionarioDeProductos()
            aux.idProducto = InputBox("ID de Producto (Productos Disponibles mostrados por consola): ")
            producto = negocioProducto.listar(aux.idProducto)
            aux.precioUnitario = producto.precio
            aux.cantidad = InputBox("Cantidad: ")
            aux.precioTotal = aux.precioUnitario * aux.cantidad
            Console.Clear()
            Console.WriteLine("El item de venta se agrego correctamente.")
            Console.WriteLine("Toca una tecla para continuar...")
            Console.ReadKey()
            Console.Clear()
            Return aux
        Catch ex As Exception
            Console.WriteLine("Hubo un error al agregar el item: " + ex.Message)
            Console.WriteLine("Toca una tecla para continuar...")
            Console.ReadKey()
            Console.Clear()
        End Try
    End Function

    Public Sub modificarFactura()
        Try
            mostrarVentas()
            Dim id As Integer = InputBox("Elija el ID de la venta a modificar (Ventas Disponibles mostrados por consola):")
            Console.Clear()

            Dim factura As New Factura
            Dim negocio As New FacturaNegocio
            Dim negocioVenta As New VentaNegocio
            Dim negocioVentaItem As New VentaItemNegocio

            Dim consola As New InteraccionCliente

            factura = negocio.listar(id)

            Console.WriteLine("-MENU- VENTA ID " + id.ToString)
            Console.WriteLine("1. Modificar Cliente")
            Console.WriteLine("2. Modificar Fecha")
            Console.WriteLine("3. Modificar Items")
            Console.WriteLine("0. Volver")
            Console.WriteLine("Presione el numero que desee...")
            Dim key As ConsoleKeyInfo = Console.ReadKey()
            Console.Clear()
            Select Case key.KeyChar
                Case "1"
                    consola.diccionarioDeClientes()
                    factura.cabecera.cliente.id = InputBox("Elija el ID de Cliente nuevo (Clientes Disponibles mostrados por consola):")
                    negocioVenta.modificar(factura.cabecera)
                    Console.WriteLine("Modificacion completa.")
                    Console.ReadKey()

                Case "2"
                    factura.cabecera.fecha = InputBox("Nueva Fecha yyyy-MM-dd :")
                    negocioVenta.modificar(factura.cabecera)
                    Console.WriteLine("Modificacion completa.")
                    Console.ReadKey()
                Case "3"

                Case "0"
                    Exit Sub
            End Select
        Catch ex As Exception
            Console.WriteLine("Hubo un error al modificar la venta: " + ex.Message)
            Console.WriteLine("Toca una tecla para continuar...")
            Console.ReadKey()
            Console.Clear()
        End Try



    End Sub

    Sub menuDeItems(factura As Factura)
        Dim auxventaItem As New VentaItem
        Dim negocio As New VentaItemNegocio

        Console.Clear()
        Console.WriteLine("-SUBMENU- VENTA ID " + factura.cabecera.cliente.id.ToString)
        Console.WriteLine("1. Agregar Item")
        Console.WriteLine("2. Modificar Item")
        Console.WriteLine("0. Volver")
        Console.WriteLine("Presione el numero que desee...")
        Dim key As ConsoleKeyInfo = Console.ReadKey()
        Console.Clear()
        Select Case key.KeyChar
            Case "1"
                auxventaItem = agregarVentaItem(factura.cabecera.cliente.id)
                negocio.agregar(auxventaItem)
            Case "2"
                mostrarFactura(factura.cabecera.cliente.id)
                Dim idItem As Integer
                idItem = InputBox("Seleccione el ID del item a Modificar (Items disponibles en consola):")
                auxventaItem = agregarVentaItem(idItem)
                negocio.modificar(auxventaItem)
            Case "0"
                Exit Sub
        End Select
    End Sub
End Class
