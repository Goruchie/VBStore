Imports dominio
Imports Negocio

Public Class Ventas
    Private ventaList As List(Of Venta)
    Private ventaItemList As List(Of VentaItem)
    Public Sub LoadVentasDgv()
        Dim negocioV As New VentaNegocios()
        Dim negocioVI As New VentaItemNegocios()

        Try
            ventaList = negocioV.List()
            dgvVentas.DataSource = ventaList
            'ventaItemList = negocioVI.List()
            'dgvVentas.DataSource = ventaItemList
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub Ventas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadVentasDgv()
        cboCampo.Items.Add("Total")
        cboCampo.Items.Add("Cliente")
        cboCampo.Items.Add("Fecha")
    End Sub

    Private Sub btnCarrito_Click(sender As Object, e As EventArgs) Handles btnCarrito.Click
        Dim ventaIdSeleccionada As Integer = Convert.ToInt32(dgvVentas.SelectedRows(0).Cells("Id").Value)
        Dim carrito As New Carrito(ventaIdSeleccionada)
        carrito.ShowDialog()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        ' Asegúrate de tener la venta seleccionada en el DataGridView
        Dim ventaIdSeleccionada As Integer = Convert.ToInt32(dgvVentas.SelectedRows(0).Cells("Id").Value)

        Dim ventaItemNegocios As New VentaItemNegocios()
        Dim ventaNegocios As New VentaNegocios()

        Try
            Dim respuesta As DialogResult = MessageBox.Show("Estas seguro/a que quieres eliminar esta venta?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If respuesta = DialogResult.Yes Then
                ventaItemNegocios.EliminarPorVentaId(ventaIdSeleccionada)
                ventaNegocios.eliminar(ventaIdSeleccionada)
                LoadVentasDgv()
                MessageBox.Show("Venta eliminada con éxito.")
            End If

        Catch ex As Exception
            MessageBox.Show("Error al eliminar la venta: " & ex.Message)
        End Try
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            Dim seleccionado As Venta
            If dgvVentas.CurrentRow Is Nothing Then
                MessageBox.Show("Tienes que seleccionar una venta para modificar")
                Return
            End If
            seleccionado = CType(dgvVentas.CurrentRow.DataBoundItem, Venta)
            Dim modificar As ModificarVenta = New ModificarVenta(seleccionado)
            modificar.ShowDialog()
            LoadVentasDgv()

        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim service As New VentaNegocios()
        Try
            If validateFilter() = True Then
                Return
            End If
            If String.IsNullOrWhiteSpace(txtFiltrar.Text) Then
                LoadVentasDgv()
                Return
            Else
                Dim campo As String = cboCampo.SelectedItem.ToString()
                Dim criterio As String = cboCriteria.SelectedItem.ToString()
                Dim busqueda As String

                If campo = "Fecha" Then
                    busqueda = dtpFecha.Value.ToString("yyyy-MM-dd")
                    MessageBox.Show("Fecha seleccionada: " & busqueda)  ' Mensaje de depuración para ver la fecha
                Else
                    busqueda = txtFiltrar.Text
                End If

                dgvVentas.DataSource = service.Filtrar(campo, criterio, busqueda)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub cboCampo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCampo.SelectedIndexChanged
        Dim opcion As String = cboCampo.SelectedItem.ToString()

        If opcion = "Total" Then
            dtpFecha.Visible = False
            cboCriteria.Items.Clear()
            cboCriteria.Items.Add("Menor que")
            cboCriteria.Items.Add("Mayor que")
            cboCriteria.Items.Add("Igual a")
        ElseIf opcion = "Fecha" Then
            dtpFecha.Visible = True
            cboCriteria.Items.Clear()
            cboCriteria.Items.Add("Antes de")
            cboCriteria.Items.Add("Después de")
            cboCriteria.Items.Add("Igual a")
        Else
            dtpFecha.Visible = False
            cboCriteria.Items.Clear()
            cboCriteria.Items.Add("Contiene")
            cboCriteria.Items.Add("Comienza con")
            cboCriteria.Items.Add("Termina con")
        End If
    End Sub

    Private Function validateFilter() As Boolean
        If cboCampo.SelectedItem Is Nothing Then
            MessageBox.Show("Seleccione un campo antes de buscar.")
            Return True
        End If
        If cboCriteria.SelectedItem Is Nothing Then
            MessageBox.Show("Seleccione un criterio antes de buscar.")
            Return True
        End If
        If cboCampo.SelectedItem.ToString() = "Total" Then
            If OnlyNumbers(txtFiltrar.Text) = False Then
                MessageBox.Show("Solo puede utilizar numeros para este filtro.")
                Return True
            End If
        End If

        Return False
    End Function

    Public Function OnlyNumbers(ByVal chain As String) As Boolean
        For Each character As Char In chain
            If Not Char.IsNumber(character) Then
                Return False
            End If
        Next
        Return True
    End Function

End Class