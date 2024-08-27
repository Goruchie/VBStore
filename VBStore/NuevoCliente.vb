Imports System.Runtime.CompilerServices.RuntimeHelpers
Imports dominio
Imports Negocio

Public Class NuevoCliente
    Private Cliente As Cliente = Nothing
    Private file As OpenFileDialog = Nothing
    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub New(cliente As Cliente)
        InitializeComponent()
        Me.Cliente = cliente
        Me.Text = "Modificar Cliente"
    End Sub

    Private Sub NuevoCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If Cliente IsNot Nothing Then
                txtCliente.Text = Cliente.Cliente
                txtTelefono.Text = Cliente.Telefono
                txtCorreo.Text = Cliente.Correo
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub btnAceptarC_Click(sender As Object, e As EventArgs) Handles btnAceptarC.Click
        Dim negocio As New ClienteNegocios
        Try
            If Cliente Is Nothing Then
                Cliente = New Cliente()
            End If
            Cliente.Cliente = txtCliente.Text
            Cliente.Telefono = txtTelefono.Text
            Cliente.Correo = txtCorreo.Text

            If Cliente.Id <> 0 Then
                negocio.modificar(Cliente)
                MessageBox.Show("Cliente modificado")
            Else
                negocio.agregar(Cliente)
                MessageBox.Show("Cliente agregado")
            End If
            Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Close()
    End Sub
End Class