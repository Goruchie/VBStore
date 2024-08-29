Imports dominio

Public Class VentaNegocios
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
End Class
