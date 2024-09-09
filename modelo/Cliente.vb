Imports System.Runtime.CompilerServices
Namespace modelo
    Public Class Cliente
        Private _id As Integer
        Private _cliente As String
        Private _telefono As String
        Private _correo As String

        Public Sub New()

        End Sub
        Public Sub New(ByVal id As Integer, ByVal cliente As String, ByVal telefono As String, ByVal correo As String)
            _id = id
            _cliente = cliente
            _telefono = telefono
            _correo = correo
        End Sub

        Public Property id As Integer
            Get
                Return _id
            End Get
            Set(value As Integer)
                _id = value
            End Set
        End Property

        Public Property cliente As String
            Get
                Return _cliente
            End Get
            Set(value As String)
                _cliente = value
            End Set
        End Property

        Public Property telefono As String
            Get
                Return _telefono
            End Get
            Set(value As String)
                _telefono = value
            End Set
        End Property

        Public Property correo As String
            Get
                Return _correo
            End Get
            Set(value As String)
                _correo = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return $"{id.ToString.PadRight(10)} {cliente.PadRight(50)} {telefono.PadRight(20)} {correo.PadRight(20)}"
        End Function
    End Class
End Namespace
