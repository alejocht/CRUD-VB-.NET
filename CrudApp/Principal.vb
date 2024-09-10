Imports System.Linq.Expressions
Imports modelo.modelo
Imports negocio

Module Principal

    Sub Main()
        Dim finDelPrograma As Boolean = False
        While Not (finDelPrograma)
            Console.Clear()
            Console.WriteLine("-MENU-")
            Console.WriteLine("1. Clientes")
            Console.WriteLine("2. Productos")
            Console.WriteLine("3. Ventas")
            Console.WriteLine("0. Salir")
            Console.WriteLine("Presione el numero que desee...")
            Dim key As ConsoleKeyInfo = Console.ReadKey()
            Console.Clear()
            Select Case key.KeyChar
                Case "1"
                    Dim consola As New InteraccionCliente
                    consola.mostrarSubMenuClientes()
                Case "2"
                    Dim consola As New InteraccionProducto
                    consola.mostrarSubMenuProductos()
                Case "3"
                    Dim consola As New InteraccionVenta
                    consola.mostrarSubMenuVentas()
                Case "0"
                    finDelPrograma = True
            End Select
            Console.Clear()
        End While

    End Sub

End Module
