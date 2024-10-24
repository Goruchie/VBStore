Imports dominio
Imports Negocio

Public Class ModificarVenta
    Private Venta As Venta = Nothing
    Private file As OpenFileDialog = Nothing
    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub New(venta As Venta)
        InitializeComponent()
        Me.Venta = venta
        Me.Text = "Modificar Venta"
    End Sub
    Private Sub ModificarVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim clienteNegocios As ClienteNegocios = New ClienteNegocios()
        Try
            cboCliente.DataSource = ClienteNegocios.List()
            cboCliente.ValueMember = "Id"
            cboCliente.DisplayMember = "Cliente"
            cboCliente.Text = Venta.Cliente.Cliente
            dtpVenta.Text = Venta.Fecha
            txtTotal.Text = Venta.Total
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim negocio As New VentaNegocios
        Dim frmVentas As Ventas = CType(Application.OpenForms("Ventas"), Ventas)

        Try
            If frmVentas.OnlyNumbers(txtTotal.Text) = False Then
                MessageBox.Show("Solo puede utilizar numeros para este campo.")
                Return
            ElseIf String.IsNullOrWhiteSpace(txtTotal.Text) Then
                MessageBox.Show("Debes llenar los espacios en blanco para continuar.")
                Return
            Else
                Venta.IdCliente = cboCliente.SelectedValue
                Venta.Fecha = dtpVenta.Value
                Venta.Total = txtTotal.Text

                negocio.modificar(Venta)
                MessageBox.Show("Venta modificada")

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