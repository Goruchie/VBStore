Imports dominio
Imports Negocio
Public Class Productos
    Public productoList As List(Of Producto)
    Private Sub LoadDgv()
        Dim negocio As New ProductoNegocios()

        Try
            productoList = negocio.List()
            dgvProductos.DataSource = productoList
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim registrar As New NuevoProducto()
        registrar.ShowDialog()
        LoadDgv()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            Dim seleccionado As Producto
            If dgvProductos.CurrentRow Is Nothing Then
                MessageBox.Show("Tienes que seleccionar un producto para modificar")
                Return
            End If
            seleccionado = CType(dgvProductos.CurrentRow.DataBoundItem, Producto)
            Dim modificar As NuevoProducto = New NuevoProducto(seleccionado)
            modificar.ShowDialog()
            LoadDgv()

        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim negocio As ProductoNegocios = New ProductoNegocios()
        Dim seleccionado As Producto
        If dgvProductos.CurrentRow Is Nothing Then
            MessageBox.Show("Debes seleccionar un producto para eliminar")
            Return
        End If
        Try
            Dim respuesta As DialogResult = MessageBox.Show("Estas seguro/a que quieres eliminar este producto?", "Eliminado", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If respuesta = DialogResult.Yes Then
                seleccionado = CType(dgvProductos.CurrentRow.DataBoundItem, Producto)
                negocio.eliminar(seleccionado.Id)
                LoadDgv()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub Productos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDgv()
    End Sub
End Class