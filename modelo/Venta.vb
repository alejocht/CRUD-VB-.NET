﻿Namespace modelo
    Public Class Venta
        Private _id As Integer
        Private _idCliente As Integer
        Private _fecha As DateTime
        Private _total As Decimal

        Public Sub New()

        End Sub

        Public Sub New(ByVal id As Integer, ByVal idCliente As Integer, ByVal fecha As DateTime, total As Decimal)
            _id = id
            _idCliente = idCliente
            _fecha = fecha
            _total = total
        End Sub
        Public Property id As Integer
            Get
                Return _id
            End Get
            Set(value As Integer)
                _id = value
            End Set
        End Property

        Public Property idCliente As Integer
            Get
                Return _idCliente
            End Get
            Set(value As Integer)
                _idCliente = value
            End Set
        End Property

        Public Property fecha As DateTime
            Get
                Return _fecha
            End Get
            Set(value As DateTime)
                _fecha = value
            End Set
        End Property

        Public Property total As Decimal
            Get
                Return _total
            End Get
            Set(value As Decimal)
                _total = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return $"{id.ToString.PadRight(10)} {idCliente.ToString.PadRight(13)} {fecha.ToString("yyyy-MM-dd").PadRight(12)} {"$" + total.ToString.PadRight(20)}"
        End Function
    End Class
End Namespace
