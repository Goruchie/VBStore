Imports dominio

Public Class VentaItemNegocios
    Public Function List(ventaId As Integer) As List(Of VentaItem)
        Dim ventaItems As New List(Of VentaItem)()
        Dim data As New AccesoDatos()
        Try
            data.SetQuery("select I.ID, IDVenta, I.IDProducto, PrecioUnitario, Cantidad, PrecioTotal, V.Total, V.ID, P.ID, P.Nombre from ventasitems I, ventas V, productos P Where V.Id = I.IDVenta And P.ID = I.IDProducto and IDVenta = @VentaId")
            data.SetearParametro("@VentaId", ventaId)
            data.EjecutarLectura()
            While data.Lector.Read()
                Dim aux As New VentaItem()

                aux.Id = Convert.ToInt32(data.Lector("ID"))
                aux.IDVenta = Convert.ToInt32(data.Lector("IDVenta"))
                aux.IdProducto = Convert.ToInt32(data.Lector("IDProducto"))
                aux.PrecioUnitario = Convert.ToDouble(data.Lector("PrecioUnitario"))
                aux.Cantidad = Convert.ToInt32(data.Lector("Cantidad"))
                aux.PrecioTotal = Convert.ToDouble(data.Lector("PrecioTotal"))
                aux.Producto = New Producto()
                aux.Producto.Id = Convert.ToInt32(data.Lector("Id"))
                aux.Producto.Nombre = Convert.ToString(data.Lector("Nombre"))
                aux.Venta = New Venta()
                aux.Venta.Id = Convert.ToInt32(data.Lector("ID"))
                aux.Venta.Total = Convert.ToDecimal(data.Lector("Total"))

                ventaItems.Add(aux)
            End While
            Return ventaItems
        Catch ex As Exception
            Throw ex
        Finally
            data.CerrarConexion()
        End Try
    End Function
    Public Sub agregar(nuevo As VentaItem)
        Dim data As New AccesoDatos()
        Try
            data.SetQuery("insert into ventasitems(PrecioUnitario, Cantidad, PrecioTotal, IDVenta, IDProducto) values (@PrecioUnitario, @Cantidad, @PrecioTotal, @IDVenta, @IDProducto)")
            data.SetearParametro("@PrecioUnitario", nuevo.PrecioUnitario)
            data.SetearParametro("@Cantidad", nuevo.Cantidad)
            data.SetearParametro("@PrecioTotal", nuevo.PrecioTotal)
            data.SetearParametro("@IDVenta", nuevo.Venta.Id)
            data.SetearParametro("@IDProducto", nuevo.Producto.Id)

            data.EjecutarAccion()
        Catch ex As Exception
            Throw ex
        Finally
            data.CerrarConexion()
        End Try
    End Sub
    Public Sub modificar(modificado As VentaItem)
        Dim data As New AccesoDatos()
        Try
            data.SetQuery("update ventasitems Set PrecioUnitario = @PrecioUnitario, Cantidad = @Cantidad, PrecioTotal = @PrecioTotal, IDProducto = @IDProducto Where ID = @id")
            data.SetearParametro("@PrecioUnitario", modificado.PrecioUnitario)
            data.SetearParametro("@Cantidad", modificado.Cantidad)
            data.SetearParametro("@PrecioTotal", modificado.PrecioTotal)
            data.SetearParametro("@IDProducto", modificado.IDProducto)
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
            data.SetQuery("delete from ventasitems where id = @id")
            data.SetearParametro("@id", id)
            data.EjecutarAccion()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub EliminarPorVentaId(ventaId As Int32)
        Try
            Dim data As AccesoDatos = New AccesoDatos()
            data.SetQuery("DELETE FROM ventasitems WHERE IDVenta = @VentaId")
            data.SetearParametro("@VentaId", ventaId)
            data.EjecutarAccion()
        Catch ex As Exception

        End Try
    End Sub
End Class
