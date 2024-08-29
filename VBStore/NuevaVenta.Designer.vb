<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmNuevaVenta
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.dgvNuevaVenta = New System.Windows.Forms.DataGridView()
        Me.dgvClientesV = New System.Windows.Forms.DataGridView()
        Me.dgvProductosV = New System.Windows.Forms.DataGridView()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.lblPrecioU = New System.Windows.Forms.Label()
        Me.lblCantidad = New System.Windows.Forms.Label()
        Me.lblPrecioT = New System.Windows.Forms.Label()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.numCantidad = New System.Windows.Forms.NumericUpDown()
        Me.lblFechaActual = New System.Windows.Forms.Label()
        Me.lblPrecioUR = New System.Windows.Forms.Label()
        Me.lblPrecioTR = New System.Windows.Forms.Label()
        Me.btnVender = New System.Windows.Forms.Button()
        Me.IdProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Producto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecioU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecioTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblCarrito = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblTotalR = New System.Windows.Forms.Label()
        CType(Me.dgvNuevaVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvClientesV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvProductosV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvNuevaVenta
        '
        Me.dgvNuevaVenta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvNuevaVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNuevaVenta.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdProducto, Me.Producto, Me.PrecioU, Me.Cantidad, Me.PrecioTotal})
        Me.dgvNuevaVenta.Location = New System.Drawing.Point(12, 382)
        Me.dgvNuevaVenta.Name = "dgvNuevaVenta"
        Me.dgvNuevaVenta.RowHeadersVisible = False
        Me.dgvNuevaVenta.RowHeadersWidth = 82
        Me.dgvNuevaVenta.RowTemplate.Height = 33
        Me.dgvNuevaVenta.Size = New System.Drawing.Size(833, 337)
        Me.dgvNuevaVenta.TabIndex = 1
        '
        'dgvClientesV
        '
        Me.dgvClientesV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvClientesV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvClientesV.Location = New System.Drawing.Point(12, 12)
        Me.dgvClientesV.Name = "dgvClientesV"
        Me.dgvClientesV.RowHeadersVisible = False
        Me.dgvClientesV.RowHeadersWidth = 82
        Me.dgvClientesV.RowTemplate.Height = 33
        Me.dgvClientesV.Size = New System.Drawing.Size(281, 339)
        Me.dgvClientesV.TabIndex = 2
        '
        'dgvProductosV
        '
        Me.dgvProductosV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvProductosV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProductosV.Location = New System.Drawing.Point(313, 12)
        Me.dgvProductosV.Name = "dgvProductosV"
        Me.dgvProductosV.RowHeadersVisible = False
        Me.dgvProductosV.RowHeadersWidth = 82
        Me.dgvProductosV.RowTemplate.Height = 33
        Me.dgvProductosV.Size = New System.Drawing.Size(532, 339)
        Me.dgvProductosV.TabIndex = 3
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Location = New System.Drawing.Point(941, 52)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(78, 25)
        Me.lblFecha.TabIndex = 4
        Me.lblFecha.Text = "Fecha:"
        '
        'lblPrecioU
        '
        Me.lblPrecioU.AutoSize = True
        Me.lblPrecioU.Location = New System.Drawing.Point(919, 106)
        Me.lblPrecioU.Name = "lblPrecioU"
        Me.lblPrecioU.Size = New System.Drawing.Size(100, 25)
        Me.lblPrecioU.TabIndex = 5
        Me.lblPrecioU.Text = "Precio/U:"
        '
        'lblCantidad
        '
        Me.lblCantidad.AutoSize = True
        Me.lblCantidad.Location = New System.Drawing.Point(915, 168)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(104, 25)
        Me.lblCantidad.TabIndex = 6
        Me.lblCantidad.Text = "Cantidad:"
        '
        'lblPrecioT
        '
        Me.lblPrecioT.AutoSize = True
        Me.lblPrecioT.Location = New System.Drawing.Point(886, 224)
        Me.lblPrecioT.Name = "lblPrecioT"
        Me.lblPrecioT.Size = New System.Drawing.Size(133, 25)
        Me.lblPrecioT.TabIndex = 7
        Me.lblPrecioT.Text = "Precio Total:"
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(891, 272)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(246, 79)
        Me.btnAgregar.TabIndex = 8
        Me.btnAgregar.Text = "Agregar al carrito"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Location = New System.Drawing.Point(851, 620)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(138, 99)
        Me.btnLimpiar.TabIndex = 9
        Me.btnLimpiar.Text = "Limpiar Carrito"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'numCantidad
        '
        Me.numCantidad.Location = New System.Drawing.Point(1025, 166)
        Me.numCantidad.Name = "numCantidad"
        Me.numCantidad.Size = New System.Drawing.Size(97, 31)
        Me.numCantidad.TabIndex = 14
        Me.numCantidad.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblFechaActual
        '
        Me.lblFechaActual.AutoSize = True
        Me.lblFechaActual.Location = New System.Drawing.Point(1021, 52)
        Me.lblFechaActual.Name = "lblFechaActual"
        Me.lblFechaActual.Size = New System.Drawing.Size(0, 25)
        Me.lblFechaActual.TabIndex = 15
        '
        'lblPrecioUR
        '
        Me.lblPrecioUR.AutoSize = True
        Me.lblPrecioUR.Location = New System.Drawing.Point(1020, 106)
        Me.lblPrecioUR.Name = "lblPrecioUR"
        Me.lblPrecioUR.Size = New System.Drawing.Size(0, 25)
        Me.lblPrecioUR.TabIndex = 16
        '
        'lblPrecioTR
        '
        Me.lblPrecioTR.AutoSize = True
        Me.lblPrecioTR.Location = New System.Drawing.Point(1020, 224)
        Me.lblPrecioTR.Name = "lblPrecioTR"
        Me.lblPrecioTR.Size = New System.Drawing.Size(0, 25)
        Me.lblPrecioTR.TabIndex = 17
        '
        'btnVender
        '
        Me.btnVender.Location = New System.Drawing.Point(995, 620)
        Me.btnVender.Name = "btnVender"
        Me.btnVender.Size = New System.Drawing.Size(138, 99)
        Me.btnVender.TabIndex = 18
        Me.btnVender.Text = "Vender"
        Me.btnVender.UseVisualStyleBackColor = True
        '
        'IdProducto
        '
        Me.IdProducto.HeaderText = "IdProducto"
        Me.IdProducto.MinimumWidth = 10
        Me.IdProducto.Name = "IdProducto"
        Me.IdProducto.ReadOnly = True
        '
        'Producto
        '
        Me.Producto.HeaderText = "Producto"
        Me.Producto.MinimumWidth = 10
        Me.Producto.Name = "Producto"
        Me.Producto.ReadOnly = True
        '
        'PrecioU
        '
        Me.PrecioU.HeaderText = "Precio/U"
        Me.PrecioU.MinimumWidth = 10
        Me.PrecioU.Name = "PrecioU"
        Me.PrecioU.ReadOnly = True
        '
        'Cantidad
        '
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.MinimumWidth = 10
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'PrecioTotal
        '
        Me.PrecioTotal.HeaderText = "Precio Total"
        Me.PrecioTotal.MinimumWidth = 10
        Me.PrecioTotal.Name = "PrecioTotal"
        Me.PrecioTotal.ReadOnly = True
        '
        'lblCarrito
        '
        Me.lblCarrito.AutoSize = True
        Me.lblCarrito.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.125!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCarrito.Location = New System.Drawing.Point(915, 382)
        Me.lblCarrito.Name = "lblCarrito"
        Me.lblCarrito.Size = New System.Drawing.Size(151, 51)
        Me.lblCarrito.TabIndex = 19
        Me.lblCarrito.Text = "Carrito"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Location = New System.Drawing.Point(851, 516)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(66, 25)
        Me.lblTotal.TabIndex = 20
        Me.lblTotal.Text = "Total:"
        '
        'lblTotalR
        '
        Me.lblTotalR.AutoSize = True
        Me.lblTotalR.Location = New System.Drawing.Point(915, 516)
        Me.lblTotalR.Name = "lblTotalR"
        Me.lblTotalR.Size = New System.Drawing.Size(0, 25)
        Me.lblTotalR.TabIndex = 21
        '
        'frmNuevaVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1149, 731)
        Me.Controls.Add(Me.lblTotalR)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.lblCarrito)
        Me.Controls.Add(Me.btnVender)
        Me.Controls.Add(Me.lblPrecioTR)
        Me.Controls.Add(Me.lblPrecioUR)
        Me.Controls.Add(Me.lblFechaActual)
        Me.Controls.Add(Me.numCantidad)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.lblPrecioT)
        Me.Controls.Add(Me.lblCantidad)
        Me.Controls.Add(Me.lblPrecioU)
        Me.Controls.Add(Me.lblFecha)
        Me.Controls.Add(Me.dgvProductosV)
        Me.Controls.Add(Me.dgvClientesV)
        Me.Controls.Add(Me.dgvNuevaVenta)
        Me.Name = "frmNuevaVenta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nueva Venta"
        CType(Me.dgvNuevaVenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvClientesV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvProductosV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvNuevaVenta As DataGridView
    Friend WithEvents dgvClientesV As DataGridView
    Friend WithEvents dgvProductosV As DataGridView
    Friend WithEvents lblFecha As Label
    Friend WithEvents lblPrecioU As Label
    Friend WithEvents lblCantidad As Label
    Friend WithEvents lblPrecioT As Label
    Friend WithEvents btnAgregar As Button
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents numCantidad As NumericUpDown
    Friend WithEvents lblFechaActual As Label
    Friend WithEvents lblPrecioUR As Label
    Friend WithEvents lblPrecioTR As Label
    Friend WithEvents btnVender As Button
    Friend WithEvents IdProducto As DataGridViewTextBoxColumn
    Friend WithEvents Producto As DataGridViewTextBoxColumn
    Friend WithEvents PrecioU As DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As DataGridViewTextBoxColumn
    Friend WithEvents PrecioTotal As DataGridViewTextBoxColumn
    Friend WithEvents lblCarrito As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents lblTotalR As Label
End Class
