Imports modelo.modelo
Imports negocio

Public Class Interaccion
    Public Sub mostrarProductos()
        Try
            Dim productoNegocio As New ProductoNegocio
            Dim lista As New List(Of Producto)
            lista = productoNegocio.listar()
            For Each producto In lista
                Console.WriteLine(producto.ToString())
            Next
            Console.WriteLine("Toca una tecla para continuar")
            Console.ReadKey()
        Catch ex As Exception
            Console.WriteLine("Hubo un error al mostrar la lista:" + ex.Message)
            Console.WriteLine("Toca una tecla para continuar")
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
            Console.WriteLine("Toca una tecla para continuar")
            Console.ReadKey()
            Console.Clear()
        Catch ex As Exception
            Console.WriteLine("Hubo un error al agregar el producto: " + ex.Message)
            Console.WriteLine("Toca una tecla para continuar")
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
            Console.WriteLine("Toca una tecla para continuar")
            Console.ReadKey()
            Console.Clear()

        Catch ex As Exception
            Console.WriteLine("Hubo un error al modificar el producto: " + ex.Message)
            Console.WriteLine("Toca una tecla para continuar")
            Console.ReadKey()
            Console.Clear()
        End Try
    End Sub

    Public Sub mostrarClientes()
        Try
            Dim clienteNegocio As New ClienteNegocio
            Dim lista As New List(Of Cliente)
            lista = clienteNegocio.listar()
            For Each cliente In lista
                Console.WriteLine(cliente.ToString())
            Next
            Console.WriteLine("Toca una tecla para continuar")
            Console.ReadKey()
        Catch ex As Exception
            Console.WriteLine("Hubo un error al mostrar la lista:" + ex.Message)
            Console.WriteLine("Toca una tecla para continuar")
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
            Console.WriteLine("Toca una tecla para continuar")
            Console.ReadKey()
            Console.Clear()
        Catch ex As Exception
            Console.WriteLine("Hubo un error al agregar el cliente: " + ex.Message)
            Console.WriteLine("Toca una tecla para continuar")
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
            Console.WriteLine("Toca una tecla para continuar")
            Console.ReadKey()
            Console.Clear()

        Catch ex As Exception
            Console.WriteLine("Hubo un error al modificar el producto: " + ex.Message)
            Console.WriteLine("Toca una tecla para continuar")
            Console.ReadKey()
            Console.Clear()
        End Try
    End Sub

    Public Sub mostrarVentas()
        Try
            Dim negocio As New VentaNegocio
            Dim lista As New List(Of Venta)
            lista = negocio.listar()
            For Each venta In lista
                Console.WriteLine(venta.ToString())
            Next
            Console.WriteLine("Toca una tecla para continuar")
            Console.ReadKey()
        Catch ex As Exception
            Console.WriteLine("Hubo un error al mostrar la lista:" + ex.Message)
            Console.WriteLine("Toca una tecla para continuar")
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
            Console.WriteLine("Toca una tecla para continuar")
            Console.ReadKey()
            Console.Clear()
        Catch ex As Exception
            Console.WriteLine("Hubo un error al agregar la venta: " + ex.Message)
            Console.WriteLine("Toca una tecla para continuar")
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
            Console.WriteLine("Toca una tecla para continuar")
            Console.ReadKey()
            Console.Clear()
        Catch ex As Exception
            Console.WriteLine("Hubo un error al modificar la venta: " + ex.Message)
            Console.WriteLine("Toca una tecla para continuar")
            Console.ReadKey()
            Console.Clear()
        End Try
    End Sub

    Public Sub mostrarVentaItems()
        Try
            Dim negocio As New VentaItemNegocio
            Dim lista As New List(Of VentaItem)
            lista = negocio.listar()
            For Each ventaItem In lista
                Console.WriteLine(ventaItem.ToString())
            Next
            Console.WriteLine("Toca una tecla para continuar")
            Console.ReadKey()
        Catch ex As Exception
            Console.WriteLine("Hubo un error al mostrar la lista:" + ex.Message)
            Console.WriteLine("Toca una tecla para continuar")
            Console.ReadKey()
            Console.Clear()
        End Try
    End Sub

    Public Sub agregarVenta()
        Try
            Dim aux As New VentaItem
            Dim negocio As New VentaItemNegocio
            Console.WriteLine("CREAR NUEVO VENTA ITEM:")
            aux.idVenta = InputBox("Fecha yyyy-mm-dd : ")
            aux.idProducto = InputBox("Total: ")
            negocio.agregar(aux)
            Console.Clear()
            Console.WriteLine("La venta se agrego correctamente.")
            Console.WriteLine(aux.ToString())
            Console.WriteLine("Toca una tecla para continuar")
            Console.ReadKey()
            Console.Clear()
        Catch ex As Exception
            Console.WriteLine("Hubo un error al agregar la venta: " + ex.Message)
            Console.WriteLine("Toca una tecla para continuar")
            Console.ReadKey()
            Console.Clear()
        End Try
    End Sub
End Class
