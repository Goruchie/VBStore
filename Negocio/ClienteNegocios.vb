Imports dominio
Public Class ClienteNegocios
    Public Function List() As List(Of Cliente)
        Dim clientes As New List(Of Cliente)()
        Dim data As New AccesoDatos()

        Try
            data.SetQuery("SELECT Cliente, Telefono, Correo, ID FROM clientes")
            data.EjecutarLectura()

            While data.Lector.Read()
                Dim aux As New Cliente()
                aux.Id = Convert.ToInt32(data.Lector("ID"))
                aux.Cliente = Convert.ToString(data.Lector("Cliente"))
                aux.Telefono = Convert.ToString(data.Lector("Telefono"))
                aux.Correo = Convert.ToString(data.Lector("Correo"))

                clientes.Add(aux)
            End While

            Return clientes
        Catch ex As Exception
            Throw ex
        Finally
            data.CerrarConexion()
        End Try
    End Function
    Public Sub agregar(nuevo As Cliente)
        Dim data As New AccesoDatos()
        Try
            data.SetQuery("insert into clientes (Cliente, Telefono, Correo) values (@Cliente, @Telefono, @Correo)")
            data.SetearParametro("@Cliente", nuevo.Cliente)
            data.SetearParametro("@Telefono", nuevo.Telefono)
            data.SetearParametro("@Correo", nuevo.Correo)

            data.EjecutarAccion()
        Catch ex As Exception
            Throw ex
        Finally
            data.CerrarConexion()
        End Try
    End Sub
    Public Sub modificar(modificado As Cliente)
        Dim data As New AccesoDatos()
        Try
            data.SetQuery("update clientes set Cliente = @Cliente, Telefono = @Telefono, Correo = @Correo Where ID = @id")
            data.SetearParametro("@Cliente", modificado.Cliente)
            data.SetearParametro("@Telefono", modificado.Telefono)
            data.SetearParametro("@Correo", modificado.Correo)
            data.SetearParametro("Id", modificado.Id)
            data.EjecutarAccion()

        Catch ex As Exception
            Throw ex
        Finally
            data.CerrarConexion()
        End Try
    End Sub
    Public Sub eliminar(id As Int32)
        Try
            Dim data As AccesoDatos = New AccesoDatos()
            data.SetQuery("delete from clientes where id = @id")
            data.SetearParametro("@id", id)
            data.EjecutarAccion()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
