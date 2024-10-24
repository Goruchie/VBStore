Imports dominio
Imports Negocio

Public Class Carrito
    Private ventaItemList As List(Of VentaItem)
    Private ventaId As Integer
    Public Sub New(ventaId As Integer)
        InitializeComponent()
        Me.ventaId = ventaId
    End Sub
    Private Sub LoadCarritoDgv()
        Dim negocioVI As New VentaItemNegocios()
        Try
            ' Usar la variable de nivel de clase ventaId
            ventaItemList = negocioVI.List(ventaId)
            dgvCarrito.DataSource = ventaItemList
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub Carrito_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCarritoDgv()
        nuevoTotal()
        ocultarColumnas()
    End Sub
    Private Sub ocultarColumnas()
        dgvCarrito.Columns("Id").Visible = False
        dgvCarrito.Columns("IDVenta").Visible = False
        dgvCarrito.Columns("Venta").Visible = False
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            Dim seleccionado As VentaItem
            If dgvCarrito.CurrentRow Is Nothing Then
                MessageBox.Show("Tienes que seleccionar un cliente para modificar")
                Return
            End If

            seleccionado = CType(dgvCarrito.CurrentRow.DataBoundItem, VentaItem)
            Dim modificar As ModificarCarrito = New ModificarCarrito(seleccionado)
            modificar.ShowDialog()
            LoadCarritoDgv()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dim negocio As New VentaNegocios
        Dim Venta = New Venta()
        Try
            Dim respuesta As DialogResult = MessageBox.Show("Estas seguro/a que quieres actualizar el Total del carrito?", "Actualizar total", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If respuesta = DialogResult.Yes Then
                Venta.Total = txtTotalV.Text
                Venta.Id = Me.ventaId
                negocio.modificarTotal(Venta)
                Dim frmVentas As Ventas = CType(Application.OpenForms("Ventas"), Ventas)
                frmVentas.LoadVentasDgv()
                MessageBox.Show("Total actualizado")
                Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Public Sub nuevoTotal()
        Dim sumatotal As Decimal = 0
        Try
            For Each row As DataGridViewRow In dgvCarrito.Rows
                If Not row.IsNewRow Then
                    sumatotal += Convert.ToDecimal(row.Cells("PrecioTotal").Value)
                End If
            Next
            txtTotalV.Text = sumatotal
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class