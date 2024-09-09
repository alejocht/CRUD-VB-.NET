Imports modelo.modelo

Public Class VentaItemNegocio
    Public Function listar() As List(Of VentaItem)
        Dim datos As New AccesoDatos
        Dim lista As New List(Of VentaItem)
        Try
            datos.setearConsulta("SELECT * FROM ventasitems")
            datos.ejecutarLectura()
            While (datos.lector.Read())
                Dim aux As New VentaItem
                aux.id = CType(datos.lector("ID"), Integer)
                aux.idVenta = CType(datos.lector("IDVenta"), Integer)
                aux.idProducto = CType(datos.lector("IDProducto"), Integer)
                aux.precioUnitario = CType(datos.lector("PrecioUnitario"), Decimal)
                aux.cantidad = CType(datos.lector("Cantidad"), Integer)
                aux.precioTotal = CType(datos.lector("PrecioTotal"), Decimal)
                lista.Add(aux)
            End While
            Return lista
        Catch ex As Exception
            Throw ex
        Finally
            datos.cerrarConexion()
        End Try
    End Function

    Public Function listarItemsDeVenta(nroventa As Integer) As List(Of VentaItem)
        Dim datos As New AccesoDatos
        Dim lista As New List(Of VentaItem)
        Try
            datos.setearConsulta("SELECT * FROM ventasitems where IDVenta = @idventa")
            datos.setearParametro("@idventa", nroventa)
            datos.ejecutarLectura()
            While (datos.lector.Read())
                Dim aux As New VentaItem
                aux.id = CType(datos.lector("ID"), Integer)
                aux.idVenta = CType(datos.lector("IDVenta"), Integer)
                aux.idProducto = CType(datos.lector("IDProducto"), Integer)
                aux.precioUnitario = CType(datos.lector("PrecioUnitario"), Decimal)
                aux.cantidad = CType(datos.lector("Cantidad"), Integer)
                aux.precioTotal = CType(datos.lector("PrecioTotal"), Decimal)
                lista.Add(aux)
            End While
            Return lista
        Catch ex As Exception
            Throw ex
        Finally
            datos.cerrarConexion()
        End Try
    End Function

    Public Function listar(id As Integer) As VentaItem
        Dim datos As New AccesoDatos
        Dim aux As New VentaItem
        Try
            datos.setearConsulta("SELECT * FROM ventasitems where ID = @id")
            datos.setearParametro("@id", id)
            datos.ejecutarLectura()
            While (datos.lector.Read())
                aux.id = CType(datos.lector("ID"), Integer)
                aux.idVenta = CType(datos.lector("IDVenta"), Integer)
                aux.idProducto = CType(datos.lector("IDProducto"), Integer)
                aux.precioUnitario = CType(datos.lector("PrecioUnitario"), Decimal)
                aux.cantidad = CType(datos.lector("Cantidad"), Integer)
                aux.precioTotal = CType(datos.lector("PrecioTotal"), Decimal)
            End While
            Return aux
        Catch ex As Exception
            Throw ex
        Finally
            datos.cerrarConexion()
        End Try
    End Function

    Public Sub agregar(ventaItem As VentaItem)
        Dim datos As New AccesoDatos
        Try
            datos.setearConsulta("INSERT INTO ventasitems ( IDVenta, IDProducto, PrecioUnitario, Cantidad, PrecioTotal) values ( @idventa, @idproducto, @precioUnitario, @cantidad, @precioTotal)")
            datos.setearParametro("@idventa", ventaItem.idVenta)
            datos.setearParametro("@idproducto", ventaItem.idProducto)
            datos.setearParametro("@precioUnitario", ventaItem.precioUnitario)
            datos.setearParametro("@cantidad", ventaItem.cantidad)
            datos.setearParametro("@precioTotal", ventaItem.precioTotal)
            datos.ejecutarAccion()
        Catch ex As Exception
            Throw ex
        Finally
            datos.cerrarConexion()
        End Try
    End Sub

    Public Sub modificar(ventaItem As VentaItem)
        Dim datos As New AccesoDatos
        Try
            datos.setearConsulta("UPDATE ventasitems SET IDVenta = @idventa,IDProducto = @idproducto,PrecioUnitario = @precioUnitario,Cantidad = @cantidad,PrecioTotal = @precioTotal WHERE ID = @id")
            datos.setearParametro("@id", ventaItem.id)
            datos.setearParametro("@idventa", ventaItem.idVenta)
            datos.setearParametro("@idproducto", ventaItem.idProducto)
            datos.setearParametro("@precioUnitario", ventaItem.precioUnitario)
            datos.setearParametro("@cantidad", ventaItem.cantidad)
            datos.setearParametro("@precioTotal", ventaItem.precioTotal)
            datos.ejecutarAccion()
        Catch ex As Exception
            Throw ex
        Finally
            datos.cerrarConexion()
        End Try
    End Sub
End Class
