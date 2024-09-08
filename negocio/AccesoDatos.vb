Imports System.Data.SqlClient
Imports System.Configuration
Public Class AccesoDatos
    Private _conexion As SqlConnection
    Private _comando As SqlCommand
    Private _lector As SqlDataReader

    Public Property conexion As SqlConnection
        Get
            Return _conexion
        End Get
        Set(value As SqlConnection)
            _conexion = value
        End Set
    End Property

    Public Property comando As SqlCommand
        Get
            Return _comando
        End Get
        Set(value As SqlCommand)
            _comando = value
        End Set
    End Property

    Public Property lector As SqlDataReader
        Get
            Return _lector
        End Get
        Set(value As SqlDataReader)
            _lector = value
        End Set
    End Property

    Public Sub New()
        Dim strConexion As String = ConfigurationManager.ConnectionStrings("MiConexion").ConnectionString
        conexion = New SqlConnection(strConexion)
        comando = New SqlCommand
    End Sub

    Public Sub setearConsulta(consulta As String)
        comando.CommandType = System.Data.CommandType.Text
        comando.CommandText = consulta
    End Sub

    Public Sub ejecutarLectura()
        comando.Connection = conexion
        Try
            conexion.Open()
            lector = comando.ExecuteReader()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ejecutarAccion()
        comando.Connection = conexion
        Try
            conexion.Open()
            comando.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub setearParametro(nombre As String, valor As Object)
        comando.Parameters.AddWithValue(nombre, valor)
    End Sub

    Public Sub cerrarConexion()
        If lector IsNot Nothing Then
            lector.Close()
        End If
        conexion.Close()
    End Sub
End Class
