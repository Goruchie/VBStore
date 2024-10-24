Imports System.Text.RegularExpressions
Imports dominio

Public Class VentaNegocios
    Public Function List() As List(Of Venta)
        Dim ventas As New List(Of Venta)()
        Dim data As New AccesoDatos()

        Try
            data.SetQuery("SELECT V.Id, V.IdCliente, V.Fecha, V.Total, C.Cliente, C.Id FROM ventas v, clientes C where C.ID = v.IDCliente")
            data.EjecutarLectura()

            While data.Lector.Read()
                Dim aux As New Venta()
                aux.Id = Convert.ToInt32(data.Lector("ID"))
                aux.IdCliente = Convert.ToInt32(data.Lector("IdCliente"))
                aux.Cliente = New Cliente()
                aux.Cliente.Id = Convert.ToInt32(data.Lector("ID"))
                aux.Cliente.Cliente = Convert.ToString(data.Lector("Cliente"))
                aux.Fecha = Convert.ToString(data.Lector("Fecha"))
                aux.Total = Convert.ToString(data.Lector("Total"))

                ventas.Add(aux)
            End While

            Return ventas
        Catch ex As Exception
            Throw ex
        Finally
            data.CerrarConexion()
        End Try
    End Function
    Public Sub agregar(nuevo As Venta)
        Dim data As New AccesoDatos()
        Try
            Dim Fecha As DateTime = DateTime.Parse(nuevo.Fecha)

            data.SetQuery("INSERT INTO ventas(IDCliente, Fecha, Total) OUTPUT INSERTED.ID VALUES (@IDCliente, @Fecha, @Total)")
            data.SetearParametro("@IDCliente", nuevo.Cliente.Id)
            data.SetearParametro("@Fecha", nuevo.Fecha)
            data.SetearParametro("@Total", nuevo.Total)
            nuevo.Id = Convert.ToInt32(data.EjecutarEscalar())
            Debug.WriteLine(nuevo.Id)
        Catch ex As Exception
            Throw ex
        Finally
            data.CerrarConexion()
        End Try
    End Sub
    Public Sub modificar(modificado As Venta)
        Dim data As New AccesoDatos()
        Try
            data.SetQuery("update ventas Set IDCliente = @IDCliente, Fecha = @Fecha, Total = @Total Where ID = @id")
            data.SetearParametro("@IDCliente", modificado.IdCliente)
            data.SetearParametro("@Fecha", modificado.Fecha)
            data.SetearParametro("@Total", modificado.Total)
            data.SetearParametro("Id", modificado.Id)

            data.EjecutarAccion()
        Catch ex As Exception
            Throw ex
        Finally
            data.CerrarConexion()
        End Try
    End Sub
    Public Sub modificarTotal(modificado As Venta)
        Dim data As New AccesoDatos()
        Try
            data.SetQuery("update ventas Set Total = @Total Where ID = @id")
            data.SetearParametro("@Total", modificado.Total)
            data.SetearParametro("Id", modificado.Id)

            data.EjecutarAccion()
        Catch ex As Exception
            Throw ex
        Finally
            data.CerrarConexion()
        End Try
    End Sub
    Public Sub eliminar(ventaId As Integer)
        Dim data As New AccesoDatos()
        Try
            data.SetQuery("DELETE FROM ventas WHERE ID = @VentaId")
            data.SetearParametro("@VentaId", ventaId)
            data.EjecutarAccion()
        Catch ex As Exception
            Throw ex
        Finally
            data.CerrarConexion()
        End Try
    End Sub

    Public Function Filtrar(campo As String, criterio As String, buscar As String) As List(Of Venta)
        Dim lista As New List(Of Venta)()
        Dim data As New AccesoDatos()

        Try
            Dim query As String = "SELECT V.Id, V.IDCliente, V.Fecha, V.Total, C.Cliente FROM ventas V INNER JOIN clientes C ON C.Id = V.IDCliente WHERE "

            If campo = "Total" Then
                Select Case criterio
                    Case "Menor que"
                        query &= "Total < " & buscar
                    Case "Mayor que"
                        query &= "Total > " & buscar
                    Case Else
                        query &= "Total = " & buscar
                End Select

            ElseIf campo = "Cliente" Then
                Select Case criterio
                    Case "Comienza con"
                        query &= "C.Cliente LIKE '" & buscar & "%'"
                    Case "Termina con"
                        query &= "C.Cliente LIKE '%" & buscar & "'"
                    Case Else
                        query &= "C.Cliente LIKE '%" & buscar & "%'"
                End Select

            ElseIf campo = "Fecha" Then
                ' Convertimos la fecha al formato YYYY-MM-DD para la comparación
                query &= "CONVERT(varchar, Fecha, 23) "

                Select Case criterio
                    Case "Antes de"
                        query &= "< '" & buscar & "'"
                    Case "Después de"
                        query &= "> '" & buscar & "'"
                    Case Else
                        query &= "= '" & buscar & "'"
                End Select

            End If

            data.SetQuery(query)
            data.EjecutarLectura()

            While data.Lector.Read()
                Dim aux As New Venta()
                aux.Id = Convert.ToInt32(data.Lector("Id"))
                aux.IdCliente = Convert.ToInt32(data.Lector("IDCliente"))
                aux.Total = Convert.ToDecimal(data.Lector("Total"))
                aux.Cliente = New Cliente()
                aux.Cliente.Id = Convert.ToInt32(data.Lector("IDCliente"))
                aux.Cliente.Cliente = Convert.ToString(data.Lector("Cliente"))

                If Not IsDBNull(data.Lector("Fecha")) Then
                    aux.Fecha = Convert.ToDateTime(data.Lector("Fecha"))
                End If

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
