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
                modificarTotal(aux.id)
                lista.Add(aux)
            End While
            Return lista
        Catch ex As Exception
            Throw ex
        Finally
            datos.cerrarConexion()
        End Try
    End Function

    Public Function listar(id As Integer) As Venta
        Dim datos As New AccesoDatos
        Dim aux As New Venta
        Try
            datos.setearConsulta("SELECT * FROM Ventas where ID = @id")
            datos.setearParametro("@id", id)
            datos.ejecutarLectura()
            While (datos.lector.Read())
                aux.id = CType(datos.lector("ID"), Integer)
                aux.idCliente = CType(datos.lector("IDCliente"), Integer)
                aux.fecha = CType(datos.lector("Fecha"), Date)
                aux.total = CType(datos.lector("Total"), Decimal)
            End While
            Return aux
        Catch ex As Exception
            Throw ex
        Finally
            datos.cerrarConexion()
        End Try
    End Function

    Public Sub agregar(venta As Venta)
        Dim datos As New AccesoDatos
        Try
            datos.setearConsulta("INSERT INTO ventas ( IDCliente, Fecha) values ( @idcliente, @fecha)")
            datos.setearParametro("@idcliente", venta.idCliente)
            datos.setearParametro("@fecha", venta.fecha)
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
            datos.setearConsulta("UPDATE ventas SET IDCliente = @idcliente, Fecha = @fecha where ID = @id")
            datos.setearParametro("@id", venta.id)
            datos.setearParametro("@idcliente", venta.idCliente)
            datos.setearParametro("@fecha", venta.fecha)
            modificarTotal(venta.id)
            datos.ejecutarAccion()
        Catch ex As Exception
            Throw ex
        Finally
            datos.cerrarConexion()
        End Try
    End Sub

    Public Sub modificarTotal(id As Integer)
        Dim datos As New AccesoDatos
        Try
            datos.setearConsulta("UPDATE ventas SET Total = Totales.TotalVentas FROM ventas JOIN (SELECT IDVenta, SUM(PrecioTotal) AS TotalVentas FROM ventasitems GROUP BY IDVenta) AS Totales ON ventas.ID = Totales.IDVenta WHERE ventas.ID = @id")
            datos.setearParametro("@id", id)
            datos.ejecutarAccion()
        Catch ex As Exception
            Throw ex
        Finally
            datos.cerrarConexion()
        End Try
    End Sub
End Class
