Imports dominio
Imports Negocio

Public Class frmNuevaVenta
    Private clienteList As List(Of Cliente)
    Public productoList As List(Of Producto)
    Public ventaList As List(Of Venta)

    Private Sub ocultarColumnasC()
        dgvClientesV.Columns("Id").Visible = False
        dgvClientesV.Columns("Telefono").Visible = False
        dgvClientesV.Columns("Correo").Visible = False
    End Sub
    Private Sub frmNuevaVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RemoveHandler dgvProductosV.SelectionChanged, AddressOf dgvProductosV_SelectionChanged
        lblFechaActual.Text = DateTime.Now.ToString("dd/MM/yyyy")
        LoadClientesDgv()
        LoadProductosDgv()
        ocultarColumnasV()

        AddHandler dgvProductosV.SelectionChanged, AddressOf dgvProductosV_SelectionChanged
    End Sub

    'Clientes
    Private Sub LoadClientesDgv()
        Dim negocio As New ClienteNegocios()

        Try
            clienteList = negocio.List()
            dgvClientesV.DataSource = clienteList
            ocultarColumnasC()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub dgvClientesV_SelectionChanged(sender As Object, e As EventArgs) Handles dgvClientesV.SelectionChanged
        Dim seleccionado As Cliente = CType(dgvClientesV.CurrentRow.DataBoundItem, Cliente)
        If selectedIndex >= 0 Then
            dgvClientesV.ClearSelection() ' Limpiar cualquier selección actual
            dgvClientesV.Rows(selectedIndex).Selected = True ' Forzar la selección del cliente guardado
        End If
    End Sub

    'Productos
    Private Sub ocultarColumnasP()
        dgvProductosV.Columns("Id").Visible = False
        dgvProductosV.Columns("Categoria").Visible = False
        dgvProductosV.Columns("Precio").Visible = False
    End Sub
    Private Sub LoadProductosDgv()
        Dim negocio As New ProductoNegocios()

        Try
            productoList = negocio.List()
            dgvProductosV.DataSource = productoList
            ocultarColumnasP()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
    Private Sub dgvProductosV_SelectionChanged(sender As Object, e As EventArgs) Handles dgvProductosV.SelectionChanged
        If dgvProductosV.CurrentRow IsNot Nothing Then
            Dim seleccionado As Producto = CType(dgvProductosV.CurrentRow.DataBoundItem, Producto)
            lblPrecioUR.Text = seleccionado.Precio.ToString("F2")
            lblPrecioTR.Text = (seleccionado.Precio * Convert.ToDecimal(numCantidad.Value)).ToString("F2")
        End If
    End Sub

    Private Sub numCantidad_ValueChanged(sender As Object, e As EventArgs) Handles numCantidad.ValueChanged
        If dgvProductosV.CurrentRow IsNot Nothing Then
            Dim seleccionado As Producto = CType(dgvProductosV.CurrentRow.DataBoundItem, Producto)
            lblPrecioTR.Text = (seleccionado.Precio * Convert.ToDecimal(numCantidad.Value)).ToString("F2")
        End If
    End Sub

    'Venta

    Private Sub ocultarColumnasV()
        dgvNuevaVenta.Columns("IdProducto").Visible = False
    End Sub

    Private selectedIndex As Integer = -1
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim cSeleccionado As Cliente = CType(dgvClientesV.CurrentRow.DataBoundItem, Cliente)
        Dim pSeleccionado As Producto = CType(dgvProductosV.CurrentRow.DataBoundItem, Producto)

        If dgvClientesV.CurrentRow IsNot Nothing Then
            selectedIndex = dgvClientesV.CurrentRow.Index
            dgvClientesV.Enabled = False ' Deshabilita el DataGridView para evitar más selecciones
        End If

        dgvNuevaVenta.Rows.Add(pSeleccionado.Id, pSeleccionado, lblPrecioUR.Text, numCantidad.Value, lblPrecioTR.Text)

    End Sub

    Private Sub btnVender_Click(sender As Object, e As EventArgs) Handles btnVender.Click
        ' Calcular el total de la venta
        Dim sumatotal As Decimal = 0
        For Each row As DataGridViewRow In dgvNuevaVenta.Rows
            If Not row.IsNewRow Then
                sumatotal += Convert.ToDecimal(row.Cells("preciototal").Value)
            End If
        Next
        lblTotalR.Text = sumatotal.ToString("c")

        ' Crear la instancia de Venta y asignar los valores
        Dim nuevaVenta As New Venta()
        nuevaVenta.Cliente = CType(dgvClientesV.CurrentRow.DataBoundItem, Cliente)
        nuevaVenta.Fecha = DateTime.Now
        nuevaVenta.Total = lblTotalR.Text

        ' Insertar la venta en la base de datos y obtener el ID generado
        Dim ventaNegocios As New VentaNegocios()
        Try
            ventaNegocios.agregar(nuevaVenta) ' Esto asignará el Id de la venta creada a nuevaVenta.Id
        Catch ex As Exception
            MessageBox.Show("Error al agregar la venta: " & ex.Message)
            Return
        End Try

        ' Iterar sobre las filas de la DataGridView para insertar cada VentaItem
        For Each row As DataGridViewRow In dgvNuevaVenta.Rows
            If Not row.IsNewRow Then
                Dim nuevoItem As New VentaItem()
                nuevoItem.PrecioUnitario = Convert.ToDecimal(row.Cells("PrecioU").Value)
                nuevoItem.Cantidad = Convert.ToInt32(row.Cells("Cantidad").Value)
                nuevoItem.PrecioTotal = Convert.ToDecimal(row.Cells("PrecioTotal").Value)
                nuevoItem.Producto = CType(row.Cells("Producto").Value, Producto)

                ' Asociar el VentaItem a la Venta recién creada
                nuevoItem.Venta = nuevaVenta ' Vincula el VentaItem a la Venta con el ID correcto

                ' Insertar el VentaItem en la base de datos
                Dim ventaItemNegocios As New VentaItemNegocios()
                Try
                    ventaItemNegocios.agregar(nuevoItem)
                Catch ex As Exception
                    MessageBox.Show("Error al agregar el ítem de venta: " & ex.Message)
                End Try
            End If
        Next

        MessageBox.Show("Compra realizada exitosamente.")
    End Sub
End Class