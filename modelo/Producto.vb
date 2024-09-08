Namespace modelo
    Public Class Producto
        Private _id As Integer
        Private _nombre As String
        Private _precio As Decimal
        Private _categoria As String

        Public Sub New()

        End Sub

        Public Sub New(ByVal id As Integer, ByVal nombre As String, ByVal precio As String, ByVal categoria As String)
            _id = id
            _nombre = nombre
            _precio = precio
            _categoria = categoria
        End Sub

        Public Property id As Integer
            Get
                Return _id
            End Get
            Set(value As Integer)
                _id = value
            End Set
        End Property

        Public Property nombre As String
            Get
                Return _nombre
            End Get
            Set(value As String)
                _nombre = value
            End Set
        End Property

        Public Property precio As Decimal
            Get
                Return _precio
            End Get
            Set(value As Decimal)
                _precio = value
            End Set
        End Property

        Public Property categoria As String
            Get
                Return _categoria
            End Get
            Set(value As String)
                _categoria = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return "[ ID: " + id.ToString() + " Nombre: " + nombre + " Precio: $" + precio.ToString() + " Categoria: " + categoria + " ]"
        End Function
    End Class
End Namespace
