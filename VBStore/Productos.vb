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
        cboCampo.Items.Add("Id")
        cboCampo.Items.Add("Nombre")
        cboCampo.Items.Add("Precio")
        cboCampo.Items.Add("Categoria")
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim service As New ProductoNegocios()
        Try
            If validateFilter() = True Then
                Return
            End If
            If String.IsNullOrWhiteSpace(txtFiltrar.Text) Then
                LoadDgv()
                Return
            Else
                Dim campo As String = cboCampo.SelectedItem.ToString()
                Dim criterio As String = cboCriteria.SelectedItem.ToString()
                Dim busqueda As String

                busqueda = txtFiltrar.Text

                dgvProductos.DataSource = service.Filtrar(campo, criterio, busqueda)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub cboCampo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCampo.SelectedIndexChanged
        Dim opcion As String = cboCampo.SelectedItem.ToString()

        If opcion = "Id" Then
            cboCriteria.Items.Clear()
            cboCriteria.Items.Add("Menor que")
            cboCriteria.Items.Add("Mayor que")
            cboCriteria.Items.Add("Igual a")
        ElseIf opcion = "Precio" Then
            cboCriteria.Items.Clear()
            cboCriteria.Items.Add("Menor que")
            cboCriteria.Items.Add("Mayor que")
            cboCriteria.Items.Add("Igual a")
        Else
            cboCriteria.Items.Clear()
            cboCriteria.Items.Add("Contiene")
            cboCriteria.Items.Add("Comienza con")
            cboCriteria.Items.Add("Termina con")
        End If
    End Sub

    Public Function OnlyNumbers(ByVal chain As String) As Boolean
        For Each character As Char In chain
            If Not Char.IsNumber(character) Then
                Return False
            End If
        Next
        Return True
    End Function

    Private Function validateFilter() As Boolean
        If cboCampo.SelectedItem Is Nothing Then
            MessageBox.Show("Seleccione un campo antes de buscar.")
            Return True
        End If
        If cboCriteria.SelectedItem Is Nothing Then
            MessageBox.Show("Seleccione un criterio antes de buscar.")
            Return True
        End If
        If cboCampo.SelectedItem.ToString() = "Id" Then
            If OnlyNumbers(txtFiltrar.Text) = False Then
                MessageBox.Show("Solo puede utilizar numeros para este filtro.")
                Return True
            End If
        End If
        If cboCampo.SelectedItem.ToString() = "Precio" Then
            If OnlyNumbers(txtFiltrar.Text) = False Then
                MessageBox.Show("Solo puede utilizar numeros para este filtro.")
                Return True
            End If
        End If

        Return False
    End Function

End Class