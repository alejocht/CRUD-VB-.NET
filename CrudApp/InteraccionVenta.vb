Imports modelo
Imports modelo.modelo
Imports negocio

Public Class InteraccionVenta
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
                agregarFactura()
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
        Try
            Dim nroVenta As Integer
            nroVenta = CType(InputBox("Indique el numero de Factura: "), Integer)

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
            listaAux = negocioVenta.listar()
            negocioVenta.agregar(factura.cabecera)

            Dim finCargaDeItems As Boolean = False
            While Not finCargaDeItems
                factura.detalle.Add(agregarVentaItem(listaAux.Last.id))
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
            aux.cliente.id = InputBox("ID Cliente: ")
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

    Public Function agregarVentaItem() As VentaItem
        Try
            Dim aux As New VentaItem
            Dim producto As New Producto
            Dim negocioProducto As New ProductoNegocio
            Console.WriteLine("AGREGAR OTRO ITEM DE VENTA:")
            aux.idProducto = InputBox("ID de Producto: ")
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
            Console.WriteLine("Hubo un error al agregar la venta: " + ex.Message)
            Console.WriteLine("Toca una tecla para continuar...")
            Console.ReadKey()
            Console.Clear()
        End Try
    End Function

    Public Function agregarVentaItem(idVenta As Integer) As VentaItem
        Try
            Dim aux As New VentaItem
            Dim producto As New Producto
            Dim negocioProducto As New ProductoNegocio
            Console.WriteLine("AGREGAR OTRO ITEM DE VENTA:")
            aux.idVenta = idVenta
            aux.idProducto = InputBox("ID de Producto: ")
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
            Console.WriteLine("Hubo un error al agregar la venta: " + ex.Message)
            Console.WriteLine("Toca una tecla para continuar...")
            Console.ReadKey()
            Console.Clear()
        End Try
    End Function





End Class
