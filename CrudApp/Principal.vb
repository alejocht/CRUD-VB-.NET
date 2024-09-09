Imports System.Linq.Expressions
Imports modelo.modelo
Imports negocio

Module Principal

    Sub Main()
        Dim finDelPrograma As Boolean = False
        While Not (finDelPrograma)
            Dim consola As New Interaccion
            consola.mostrarMenu()
            Dim key As ConsoleKeyInfo = Console.ReadKey()
            Console.Clear()
            Select Case key.KeyChar
                Case "1"
                    consola.mostrarSubMenuClientes()
                Case "2"
                    consola.mostrarSubMenuProductos()
                Case "3"
                    consola.mostrarSubMenuVentas()
                Case "0"
                    Console.WriteLine($"{"ID".PadRight(10)} {"Cliente".PadRight(50)} {"Telefono".PadRight(20)} {"Correo".PadRight(20)}")
                    Console.WriteLine(New String("-"c, 100))
                    Console.ReadKey()
                    finDelPrograma = True
            End Select
            Console.Clear()
        End While

    End Sub

End Module
