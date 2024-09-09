
Imports modelo.modelo
Public Class ProductoNegocio
    Public Function listar() As List(Of Producto)
        Dim datos As New AccesoDatos
        Dim lista As New List(Of Producto)
        Try
            datos.setearConsulta("SELECT * FROM productos")
            datos.ejecutarLectura()
            While (datos.lector.Read())
                Dim aux As New Producto
                aux.id = CType(datos.lector("ID"), Integer)
                aux.nombre = CType(datos.lector("Nombre"), String)
                aux.precio = CType(datos.lector("Precio"), Decimal)
                aux.categoria = CType(datos.lector("Categoria"), String)
                lista.Add(aux)
            End While

            Return lista
        Catch ex As Exception
            Throw ex
        Finally
            datos.cerrarConexion()
        End Try

    End Function

    Public Function listar(id As Integer) As Producto
        Dim datos As New AccesoDatos
        Dim aux As New Producto
        Try
            datos.setearConsulta("SELECT * FROM productos where ID = @id")
            datos.setearParametro("@id", id)
            datos.ejecutarLectura()
            While (datos.lector.Read())
                aux.id = CType(datos.lector("ID"), Integer)
                aux.nombre = CType(datos.lector("Nombre"), String)
                aux.precio = CType(datos.lector("Precio"), Decimal)
                aux.categoria = CType(datos.lector("Categoria"), String)
            End While

            Return aux
        Catch ex As Exception
            Throw ex
        Finally
            datos.cerrarConexion()
        End Try

    End Function

    Public Sub agregar(producto As Producto)
        Dim datos As New AccesoDatos
        Try
            datos.setearConsulta("INSERT INTO productos (Nombre, Precio, Categoria) values (@nombre, @precio, @categoria)")
            datos.setearParametro("@nombre", producto.nombre)
            datos.setearParametro("@precio", producto.precio)
            datos.setearParametro("@categoria", producto.categoria)
            datos.ejecutarAccion()
        Catch ex As Exception
            Throw ex
        Finally
            datos.cerrarConexion()
        End Try
    End Sub

    Public Sub modificar(producto As Producto)
        Dim datos As New AccesoDatos
        Try
            datos.setearConsulta("update productos set Nombre = @nombre, Precio = @precio, Categoria = @categoria where ID = @id")
            datos.setearParametro("@id", producto.id)
            datos.setearParametro("@nombre", producto.nombre)
            datos.setearParametro("@precio", producto.precio)
            datos.setearParametro("@categoria", producto.categoria)
            datos.ejecutarAccion()
        Catch ex As Exception
            Throw ex
        Finally
            datos.cerrarConexion()
        End Try
    End Sub
End Class
