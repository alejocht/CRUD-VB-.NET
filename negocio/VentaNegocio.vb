Imports modelo.modelo

Public Class VentaNegocio
    Public Function listar() As List(Of Venta)
        Dim datos As New AccesoDatos
        Dim lista As New List(Of Venta)
        Try
            datos.setearConsulta("SELECT * FROM Ventas")
            datos.ejecutarLectura()
            While (datos.lector.Read())
                Dim aux As New Venta
                aux.id = CType(datos.lector("ID"), Integer)
                aux.idCliente = CType(datos.lector("IDCliente"), Integer)
                aux.fecha = CType(datos.lector("Fecha"), Date)
                aux.total = CType(datos.lector("Total"), Decimal)
                lista.Add(aux)
            End While
            Return lista
        Catch ex As Exception
            Throw ex
        Finally
            datos.cerrarConexion()
        End Try
    End Function

    Public Sub agregar(venta As Venta)
        Dim datos As New AccesoDatos
        Try
            datos.setearConsulta("INSERT INTO ventas (ID, IDCliente, Fecha, Total) values (@id, @idcliente, @fecha, @total)")
            datos.setearParametro("@id", venta.id)
            datos.setearParametro("@idcliente", venta.idCliente)
            datos.setearParametro("@fecha", venta.fecha)
            datos.setearParametro("@total", venta.total)
            datos.ejecutarAccion()
        Catch ex As Exception
            Throw ex
        Finally
            datos.cerrarConexion()
        End Try
    End Sub

    Public Sub modificar(venta As Venta)
        Dim datos As New AccesoDatos
        Try
            datos.setearConsulta("UPDATE ventas SET IDCliente = @idcliente, Fecha = @fecha, Total = @total where ID = @id")
            datos.setearParametro("@id", venta.id)
            datos.setearParametro("@idcliente", venta.idCliente)
            datos.setearParametro("@fecha", venta.fecha)
            datos.setearParametro("@total", venta.total)
            datos.ejecutarAccion()
        Catch ex As Exception
            Throw ex
        Finally
            datos.cerrarConexion()
        End Try
    End Sub
End Class
