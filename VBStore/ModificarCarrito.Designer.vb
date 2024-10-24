<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ModificarCarrito
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblProducto = New System.Windows.Forms.Label()
        Me.lblPrecioU = New System.Windows.Forms.Label()
        Me.lblCantidad = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.txtPrecioU = New System.Windows.Forms.TextBox()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.txtPrecioT = New System.Windows.Forms.TextBox()
        Me.cboProducto = New System.Windows.Forms.ComboBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.Location = New System.Drawing.Point(100, 79)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(104, 25)
        Me.lblProducto.TabIndex = 0
        Me.lblProducto.Text = "Producto:"
        '
        'lblPrecioU
        '
        Me.lblPrecioU.AutoSize = True
        Me.lblPrecioU.Location = New System.Drawing.Point(104, 173)
        Me.lblPrecioU.Name = "lblPrecioU"
        Me.lblPrecioU.Size = New System.Drawing.Size(100, 25)
        Me.lblPrecioU.TabIndex = 1
        Me.lblPrecioU.Text = "Precio/U:"
        '
        'lblCantidad
        '
        Me.lblCantidad.AutoSize = True
        Me.lblCantidad.Location = New System.Drawing.Point(100, 270)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(104, 25)
        Me.lblCantidad.TabIndex = 2
        Me.lblCantidad.Text = "Cantidad:"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Location = New System.Drawing.Point(71, 355)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(133, 25)
        Me.lblTotal.TabIndex = 3
        Me.lblTotal.Text = "Precio Total:"
        '
        'txtPrecioU
        '
        Me.txtPrecioU.Location = New System.Drawing.Point(210, 170)
        Me.txtPrecioU.Name = "txtPrecioU"
        Me.txtPrecioU.Size = New System.Drawing.Size(184, 31)
        Me.txtPrecioU.TabIndex = 5
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(210, 267)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(184, 31)
        Me.txtCantidad.TabIndex = 6
        '
        'txtPrecioT
        '
        Me.txtPrecioT.Location = New System.Drawing.Point(210, 352)
        Me.txtPrecioT.Name = "txtPrecioT"
        Me.txtPrecioT.Size = New System.Drawing.Size(184, 31)
        Me.txtPrecioT.TabIndex = 7
        '
        'cboProducto
        '
        Me.cboProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProducto.FormattingEnabled = True
        Me.cboProducto.Location = New System.Drawing.Point(210, 76)
        Me.cboProducto.Name = "cboProducto"
        Me.cboProducto.Size = New System.Drawing.Size(184, 33)
        Me.cboProducto.TabIndex = 8
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(78, 434)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(156, 49)
        Me.btnAceptar.TabIndex = 9
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(240, 434)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(156, 49)
        Me.btnCancelar.TabIndex = 10
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'ModificarCarrito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(474, 551)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.cboProducto)
        Me.Controls.Add(Me.txtPrecioT)
        Me.Controls.Add(Me.txtCantidad)
        Me.Controls.Add(Me.txtPrecioU)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.lblCantidad)
        Me.Controls.Add(Me.lblPrecioU)
        Me.Controls.Add(Me.lblProducto)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(500, 622)
        Me.MinimumSize = New System.Drawing.Size(500, 622)
        Me.Name = "ModificarCarrito"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "ModificarCarrito"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblProducto As Label
    Friend WithEvents lblPrecioU As Label
    Friend WithEvents lblCantidad As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents txtPrecioU As TextBox
    Friend WithEvents txtCantidad As TextBox
    Friend WithEvents txtPrecioT As TextBox
    Friend WithEvents cboProducto As ComboBox
    Friend WithEvents btnAceptar As Button
    Friend WithEvents btnCancelar As Button
End Class
