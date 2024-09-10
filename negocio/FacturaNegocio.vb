Imports modelo
Imports modelo.modelo

Public Class FacturaNegocio
    Public Function listar(id As Integer) As Factura
        Try
            Dim factura As New Factura
            Dim negocioVenta As New VentaNegocio
            Dim negocioVentaItem As New VentaItemNegocio
            factura.cabecera = negocioVenta.listar(id)
            factura.detalle = negocioVentaItem.listarItemsDeVenta(id)
            Return factura
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
