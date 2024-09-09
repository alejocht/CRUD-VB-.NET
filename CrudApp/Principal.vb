Imports modelo.modelo
Imports negocio

Module Principal

    Sub Main()
        'Dim producto As New Producto(1, "Taza", 300, "Hogar")
        'productoNegocio.agregar(producto)
        Dim interaccion As New Interaccion

        'interaccion.agregarCliente()
        interaccion.mostrarClientes()
        interaccion.modificarCliente()

    End Sub

End Module
