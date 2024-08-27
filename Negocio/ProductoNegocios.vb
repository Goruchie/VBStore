Imports dominio
Public Class ProductoNegocios
    Public Function List() As List(Of Producto)
        Dim productos As New List(Of Producto)()
        Dim data As New AccesoDatos()
        Try
            data.SetQuery("SELECT Nombre, Precio, Categoria, ID FROM productos")
            data.EjecutarLectura()
            While data.Lector.Read()
                Dim aux As New Producto()
                aux.Id = Convert.ToInt32(data.Lector("ID"))
                aux.Nombre = Convert.ToString(data.Lector("Nombre"))
                aux.Precio = Convert.ToInt32(data.Lector("Precio"))
                aux.Categoria = Convert.ToString(data.Lector("Categoria"))
                productos.Add(aux)
            End While
            Return productos
        Catch ex As Exception
            Throw ex
        Finally
            data.CerrarConexion()
        End Try
    End Function
    Public Sub agregar(nuevo As Producto)
        Dim data As New AccesoDatos()
        Try
            data.SetQuery("insert into productos (Nombre, Precio, Categoria) values (@Nombre, @Precio, @Categoria)")
            data.SetearParametro("@Nombre", nuevo.Nombre)
            data.SetearParametro("@Precio", nuevo.Precio)
            data.SetearParametro("@Categoria", nuevo.Categoria)
            data.EjecutarAccion()
        Catch ex As Exception
            Throw ex
        Finally
            data.CerrarConexion()
        End Try
    End Sub
    Public Sub modificar(modificado As Producto)
        Dim data As New AccesoDatos()
        Try
            data.SetQuery("update productos set Nombre = @Nombre, Precio = @Precio, Categoria = @Categoria Where ID = @id")
            data.SetearParametro("@Nombre", modificado.Nombre)
            data.SetearParametro("@Precio", modificado.Precio)
            data.SetearParametro("@Categoria", modificado.Categoria)
            data.SetearParametro("@Id", modificado.Id)
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
            data.SetQuery("delete from productos where id = @id")
            data.SetearParametro("@id", id)
            data.EjecutarAccion()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
