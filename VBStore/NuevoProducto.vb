﻿Imports dominio
Imports Negocio

Public Class NuevoProducto
    Private Producto As Producto = Nothing
    Private file As OpenFileDialog = Nothing
    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub New(producto As Producto)
        InitializeComponent()
        Me.Producto = producto
        Me.Text = "Modificar Producto"
    End Sub

    Private Sub NuevoProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If Producto IsNot Nothing Then
                txtNombre.Text = Producto.Nombre
                txtPrecio.Text = Producto.Precio
                txtCategoria.Text = Producto.Categoria
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
    Public Function OnlyNumbers(ByVal chain As String) As Boolean
        For Each character As Char In chain
            If Not Char.IsNumber(character) Then
                Return False
            End If
        Next
        Return True
    End Function

    Private Sub btnAceptarP_Click(sender As Object, e As EventArgs) Handles btnAceptarP.Click
        Dim negocio As New ProductoNegocios

        Try
            If OnlyNumbers(txtPrecio.Text) = False Then
                MessageBox.Show("Solo puede utilizar numeros para el campo Precio.")
                Return
            ElseIf String.IsNullOrWhiteSpace(txtPrecio.Text) OrElse
                String.IsNullOrWhiteSpace(txtCategoria.Text) OrElse
                String.IsNullOrWhiteSpace(txtNombre.Text) Then
                MessageBox.Show("Debes llenar los espacios en blanco para continuar.")
                Return
            Else
                If Producto Is Nothing Then
                    Producto = New Producto()
                End If
                Producto.Nombre = txtNombre.Text
                Producto.Precio = txtPrecio.Text
                Producto.Categoria = txtCategoria.Text

                If Producto.Id <> 0 Then
                    negocio.modificar(Producto)
                    MessageBox.Show("Producto modificado")
                Else
                    negocio.agregar(Producto)
                    MessageBox.Show("Producto agregado")
                End If
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