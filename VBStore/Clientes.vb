Imports dominio
Imports Negocio

Public Class Clientes
    Private clienteList As List(Of Cliente)

    Private Sub LoadDgv()
        Dim negocio As New ClienteNegocios()

        Try
            clienteList = negocio.List()
            dgvClientes.DataSource = clienteList
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub Clientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDgv()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim registrar As New NuevoCliente()
        registrar.ShowDialog()
        LoadDgv()
    End Sub
    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            Dim seleccionado As Cliente
            If dgvClientes.CurrentRow Is Nothing Then
                MessageBox.Show("Tienes que seleccionar un cliente para modificar")
                Return
            End If
            seleccionado = CType(dgvClientes.CurrentRow.DataBoundItem, Cliente)
            Dim modificar As NuevoCliente = New NuevoCliente(seleccionado)
            modificar.ShowDialog()
            LoadDgv()

        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
    Private Sub dgvClientes_SelectionChanged(sender As Object, e As EventArgs) Handles dgvClientes.SelectionChanged
        Dim seleccionado As Cliente = CType(dgvClientes.CurrentRow.DataBoundItem, Cliente)
    End Sub
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim negocio As ClienteNegocios = New ClienteNegocios()
        Dim seleccionado As Cliente
        If dgvClientes.CurrentRow Is Nothing Then
            MessageBox.Show("Debes seleccionar un cliente para eliminar")
            Return
        End If
        Try
            Dim respuesta As DialogResult = MessageBox.Show("Estas seguro/a que quieres eliminar este cliente?", "Eliminado", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If respuesta = DialogResult.Yes Then
                seleccionado = CType(dgvClientes.CurrentRow.DataBoundItem, Cliente)
                negocio.eliminar(seleccionado.Id)
                LoadDgv()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
End Class