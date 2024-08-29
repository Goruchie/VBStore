Imports dominio

Public Class VentaItemNegocios
    Public Function List() As List(Of VentaItem)
        Dim ventaItems As New List(Of VentaItem)()
        Dim data As New AccesoDatos()
        Try
            data.SetQuery("SELECT ventas.ID AS VentaID, ventas.Fecha, ventas.Total, clientes.ID AS ClienteID, clientes.Cliente, clientes.Telefono, clientes.Correo,  
                productos.ID AS ProductoID, productos.Nombre, productos.Precio, ventasitems.Cantidad, ventasitems.PrecioTotal, ventasitems.PrecioUnitario  
                FROM ventas  
                JOIN clientes ON ventas.IDCliente = clientes.ID  
                JOIN ventasitems ON ventas.ID = ventasitems.IDVenta  
                JOIN productos ON ventasitems.IDProducto = productos.ID")

            data.EjecutarLectura()
            While data.Lector.Read()
                Dim aux As New VentaItem()
                aux.Id = Convert.ToInt32(data.Lector("VentaID"))
                aux.PrecioUnitario = Convert.ToDouble(data.Lector("PrecioUnitario"))
                aux.Cantidad = Convert.ToInt32(data.Lector("Cantidad"))
                aux.PrecioTotal = Convert.ToDouble(data.Lector("PrecioTotal"))

                aux.Venta = New Venta()
                aux.Venta.Id = Convert.ToInt32(data.Lector("VentaID"))
                aux.Venta.Fecha = Convert.ToDateTime(data.Lector("Fecha"))
                aux.Venta.Total = Convert.ToDecimal(data.Lector("Total"))

                aux.Producto = New Producto()
                aux.Producto.Id = Convert.ToInt32(data.Lector("ProductoID"))
                aux.Producto.Nombre = Convert.ToString(data.Lector("Nombre"))
                aux.Producto.Precio = Convert.ToDecimal(data.Lector("Precio"))


                aux.Venta.Cliente = New Cliente()
                aux.Venta.Cliente.Id = Convert.ToInt32(data.Lector("ClienteID"))
                aux.Venta.Cliente.Cliente = Convert.ToString(data.Lector("Cliente"))
                aux.Venta.Cliente.Telefono = Convert.ToString(data.Lector("Telefono"))
                aux.Venta.Cliente.Correo = Convert.ToString(data.Lector("Correo"))


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
End Class
