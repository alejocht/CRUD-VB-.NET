Imports modelo.modelo

Public Class Factura
    Private _cabecera As Venta
    Private _detalle As List(Of VentaItem)
    Public Property cabecera As Venta
        Get
            Return _cabecera
        End Get
        Set(value As Venta)
            _cabecera = value
        End Set
    End Property

    Public Property detalle As List(Of VentaItem)
        Get
            Return _detalle
        End Get
        Set(value As List(Of VentaItem))
            _detalle = value
        End Set
    End Property

End Class
