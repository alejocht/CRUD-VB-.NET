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

            Console.ReadKey()
        Catch ex As Exception
            Console.WriteLine("Hubo un error al mostrar la lista:" + ex.Message)
            Throw ex
        End Try

    End Sub
End Class
