Imports dominio
Imports Negocio

Public Class ModificarCarrito
    Private VentaItem As VentaItem = Nothing
    Private file As OpenFileDialog = Nothing
    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub New(VentaItem As VentaItem)
        InitializeComponent()
        Me.VentaItem = VentaItem
        Me.Text = "Modificar Item de Venta"
    End Sub
    Private Sub ModificarCarrito_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim productoNegocios As ProductoNegocios = New ProductoNegocios()
        Try
            cboProducto.DataSource = productoNegocios.List()
            cboProducto.ValueMember = "Id"
            cboProducto.DisplayMember = "Nombre"
            If VentaItem IsNot Nothing Then
                cboProducto.SelectedValue = VentaItem.IDProducto
                txtPrecioU.Text = VentaItem.PrecioUnitario
                txtCantidad.Text = VentaItem.Cantidad
                txtPrecioT.Text = VentaItem.PrecioTotal
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim negocio As New VentaItemNegocios
        Dim frmVentas As Ventas = CType(Application.OpenForms("Ventas"), Ventas)

        Try
            VentaItem.IDProducto = cboProducto.SelectedValue
            If frmVentas.OnlyNumbers(txtPrecioU.Text) = False Then
                MessageBox.Show("Solo puede utilizar numeros para este campo.")
                Return
            ElseIf String.IsNullOrWhiteSpace(txtPrecioU.Text) OrElse
                String.IsNullOrWhiteSpace(txtCantidad.Text) OrElse
                String.IsNullOrWhiteSpace(txtPrecioT.Text) Then
                MessageBox.Show("Debes llenar los espacios en blanco para continuar.")
                Return
            ElseIf frmVentas.OnlyNumbers(txtCantidad.Text) = False Then
                MessageBox.Show("Solo puede utilizar numeros para este campo.")
                Return
            ElseIf frmVentas.OnlyNumbers(txtPrecioT.Text) = False Then
                MessageBox.Show("Solo puede utilizar numeros para este campo.")
                Return
            Else
                VentaItem.PrecioUnitario = txtPrecioU.Text
                VentaItem.Cantidad = txtCantidad.Text
                VentaItem.PrecioTotal = txtPrecioT.Text
                negocio.modificar(VentaItem)
                MessageBox.Show("Cliente modificado")
                Dim frmCarrito As Carrito = CType(Application.OpenForms("Carrito"), Carrito)
                frmCarrito.nuevoTotal()
                Close()
            End If


        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Close()
    End Sub
End Class