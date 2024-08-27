Imports dominio
Imports Negocio
Public Class Menu
    Private Sub btnClientes_Click(sender As Object, e As EventArgs) Handles btnClientes.Click
        Try
            Dim clientes As New Clientes()
            clientes.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try

    End Sub

    Private Sub btnProductos_Click(sender As Object, e As EventArgs) Handles btnProductos.Click
        Dim productos As New Productos()
        productos.ShowDialog()
    End Sub

    Private Sub btnVentas_Click(sender As Object, e As EventArgs) Handles btnVentas.Click
        Dim ventas As New Ventas()
        ventas.ShowDialog()
    End Sub
End Class
