Imports modelo
Imports modelo.modelo

Public Class FacturaNegocio
    Public Function listar(id As Integer) As Factura
        Dim factura As New Factura
        Dim negocioVenta As New VentaNegocio
        Dim negocioVentaItem As New VentaItemNegocio
        factura.cabecera = negocioVenta.listar(id)
        factura.detalle = negocioVentaItem.listarItemsDeVenta(id)
        Return factura
    End Function
End Class
