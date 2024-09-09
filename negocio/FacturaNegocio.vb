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

    Public Sub agregar(factura As Factura)
        Try
            Dim negocioVenta As New VentaNegocio
            Dim negocioVentaItem As New VentaItemNegocio

            negocioVenta.agregar(factura.cabecera)
            For Each ventaItem In factura.detalle
                negocioVentaItem.agregar(ventaItem)
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
