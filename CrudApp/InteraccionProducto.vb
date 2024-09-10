Imports modelo.modelo
Imports negocio

Public Class InteraccionProducto
    Public Sub diccionarioDeProductos()
        Try
            Dim productoNegocio As New ProductoNegocio
            Dim lista As New List(Of Producto)
            lista = productoNegocio.listar()
            Console.WriteLine($"{"ID".PadRight(10)} {"Nombre".PadRight(50)}")
            Console.WriteLine(New String("-"c, 60))
            For Each producto In lista
                Console.WriteLine($"{producto.id.ToString.PadRight(10)} {producto.nombre.PadRight(50)}")
            Next
        Catch ex As Exception
            Console.WriteLine("Hubo un error al mostrar la lista:" + ex.Message)
            Console.WriteLine("Toca una tecla para continuar...")
            Console.ReadKey()
            Console.Clear()
        End Try
    End Sub
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
            Console.WriteLine("El producto" + aux.nombre + " se agrego correctamente.")
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

    Public Sub mostrarSubMenuProductos()
        Console.WriteLine("-MENU PRODUCTOS-")
        Console.WriteLine("1. Listar")
        Console.WriteLine("2. Agregar")
        Console.WriteLine("3. Modificar")
        Console.WriteLine("0. Volver")
        Console.WriteLine("Presione el numero que desee...")
        Dim key As ConsoleKeyInfo = Console.ReadKey()
        Console.Clear()
        Select Case key.KeyChar
            Case "1"
                mostrarProductos()
            Case "2"
                agregarProducto()
            Case "3"
                modificarProducto()
            Case "0"
                Exit Sub
        End Select
    End Sub

End Class
