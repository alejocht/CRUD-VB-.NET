Imports modelo.modelo

Public Class ClienteNegocio
    Public Function listar() As List(Of Cliente)
        Dim datos As New AccesoDatos
        Dim lista As New List(Of Cliente)
        Try
            datos.setearConsulta("SELECT * FROM Clientes")
            datos.ejecutarLectura()
            While (datos.lector.Read())
                Dim aux As New Cliente
                aux.id = CType(datos.lector("ID"), Integer)
                aux.cliente = CType(datos.lector("Cliente"), String)
                aux.telefono = CType(datos.lector("Telefono"), String)
                aux.correo = CType(datos.lector("Correo"), String)
                lista.Add(aux)
            End While
            Return lista
        Catch ex As Exception
            Throw ex
        Finally
            datos.cerrarConexion()
        End Try
    End Function

    Public Function listar(id As Integer) As Cliente
        Dim datos As New AccesoDatos
        Dim aux As New Cliente
        Try
            datos.setearConsulta("SELECT * FROM Clientes where ID = @id")
            datos.setearParametro("@id", id)
            datos.ejecutarLectura()
            While (datos.lector.Read())
                aux.id = CType(datos.lector("ID"), Integer)
                aux.cliente = CType(datos.lector("Cliente"), String)
                aux.telefono = CType(datos.lector("Telefono"), String)
                aux.correo = CType(datos.lector("Correo"), String)
            End While
            Return aux
        Catch ex As Exception
            Throw ex
        Finally
            datos.cerrarConexion()
        End Try
    End Function

    Public Sub agregar(cliente As Cliente)
        Dim datos As New AccesoDatos
        Try
            datos.setearConsulta("INSERT INTO clientes ( Cliente, Telefono, Correo) VALUES ( @cliente, @telefono, @correo)")
            datos.setearParametro("@cliente", cliente.cliente)
            datos.setearParametro("@telefono", cliente.telefono)
            datos.setearParametro("@correo", cliente.correo)
            datos.ejecutarAccion()
        Catch ex As Exception
            Throw ex
        Finally
            datos.cerrarConexion()
        End Try
    End Sub

    Public Sub modificar(cliente As Cliente)
        Dim datos As New AccesoDatos
        Try
            datos.setearConsulta("UPDATE clientes set Cliente = @cliente, Telefono = @telefono, Correo = @correo where ID = @id")
            datos.setearParametro("@id", cliente.id)
            datos.setearParametro("@cliente", cliente.cliente)
            datos.setearParametro("@telefono", cliente.telefono)
            datos.setearParametro("@correo", cliente.correo)
            datos.ejecutarAccion()
        Catch ex As Exception
            Throw ex
        Finally
            datos.cerrarConexion()
        End Try
    End Sub

End Class
