Imports modelo.modelo
Imports negocio

Public Class InteraccionCliente
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

    Public Sub mostrarSubMenuClientes()
        Console.WriteLine("-MENU CLIENTES-")
        Console.WriteLine("1. Listar")
        Console.WriteLine("2. Agregar")
        Console.WriteLine("3. Modificar")
        Console.WriteLine("4. Filtrar")
        Console.WriteLine("0. Volver")
        Console.WriteLine("Presione el numero que desee...")
        Dim key As ConsoleKeyInfo = Console.ReadKey()
        Console.Clear()
        Select Case key.KeyChar
            Case "1"
                mostrarClientes()
            Case "2"
                agregarCliente()
            Case "3"
                modificarCliente()
            Case "4"
                'falta desarrollar
            Case "0"
                Exit Sub
        End Select
    End Sub

End Class
