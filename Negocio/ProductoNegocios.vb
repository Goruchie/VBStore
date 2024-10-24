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

    Public Function Filtrar(campo As String, criterio As String, buscar As String) As List(Of Producto)
        Dim lista As New List(Of Producto)()
        Dim data As New AccesoDatos()

        Try
            Dim query As String = "SELECT Nombre, Precio, Categoria, ID FROM productos WHERE "

            If campo = "Id" Then
                Select Case criterio
                    Case "Menor que"
                        query &= "Id < " & buscar
                    Case "Mayor que"
                        query &= "Id > " & buscar
                    Case Else
                        query &= "Id = " & buscar
                End Select

            ElseIf campo = "Nombre" Then
                Select Case criterio
                    Case "Comienza con"
                        query &= "Nombre LIKE '" & buscar & "%'"
                    Case "Termina con"
                        query &= "Nombre LIKE '%" & buscar & "'"
                    Case Else
                        query &= "Nombre LIKE '%" & buscar & "%'"
                End Select

            ElseIf campo = "Precio" Then
                Select Case criterio
                    Case "Menor que"
                        query &= "Precio < " & buscar
                    Case "Mayor que"
                        query &= "Precio > " & buscar
                    Case Else
                        query &= "Precio = " & buscar
                End Select

            ElseIf campo = "Categoria" Then
                Select Case criterio
                    Case "Comienza con"
                        query &= "Categoria LIKE '" & buscar & "%'"
                    Case "Termina con"
                        query &= "Categoria LIKE '%" & buscar & "'"
                    Case Else
                        query &= "Categoria LIKE '%" & buscar & "%'"
                End Select
            End If

            data.SetQuery(query)
            data.EjecutarLectura()

            While data.Lector.Read()
                Dim aux As New Producto()
                aux.Id = Convert.ToInt32(data.Lector("ID"))
                aux.Nombre = Convert.ToString(data.Lector("Nombre"))
                aux.Precio = Convert.ToInt32(data.Lector("Precio"))
                aux.Categoria = Convert.ToString(data.Lector("Categoria"))

                lista.Add(aux)
            End While

            Return lista

        Catch ex As Exception
            Throw ex
        Finally
            data.CerrarConexion()
        End Try
    End Function

End Class
