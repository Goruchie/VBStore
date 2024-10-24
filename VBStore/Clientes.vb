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
        cboCampo.Items.Add("Id")
        cboCampo.Items.Add("Cliente")
        cboCampo.Items.Add("Teléfono")
        cboCampo.Items.Add("Correo")
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
            Dim respuesta As DialogResult = MessageBox.Show("Estas seguro/a que quieres eliminar este cliente?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If respuesta = DialogResult.Yes Then
                seleccionado = CType(dgvClientes.CurrentRow.DataBoundItem, Cliente)
                negocio.eliminar(seleccionado.Id)
                LoadDgv()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim service As New ClienteNegocios()
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

                dgvClientes.DataSource = service.Filtrar(campo, criterio, busqueda)
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
        If cboCampo.SelectedItem.ToString() = "Teléfono" Then
            If OnlyNumbers(txtFiltrar.Text) = False Then
                MessageBox.Show("Solo puede utilizar numeros para este filtro.")
                Return True
            End If
        End If

        Return False
    End Function

    Private Sub cboCampo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCampo.SelectedIndexChanged
        Dim opcion As String = cboCampo.SelectedItem.ToString()

        If opcion = "Id" Then
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
End Class