<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NuevoProducto
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
        Me.btnAceptarP = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.txtCategoria = New System.Windows.Forms.TextBox()
        Me.txtPrecio = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblCategoriaP = New System.Windows.Forms.Label()
        Me.lblPrecioP = New System.Windows.Forms.Label()
        Me.lblNombreP = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnAceptarP
        '
        Me.btnAceptarP.Location = New System.Drawing.Point(301, 356)
        Me.btnAceptarP.Name = "btnAceptarP"
        Me.btnAceptarP.Size = New System.Drawing.Size(116, 45)
        Me.btnAceptarP.TabIndex = 16
        Me.btnAceptarP.Text = "Aceptar"
        Me.btnAceptarP.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(434, 356)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(116, 45)
        Me.btnCancelar.TabIndex = 15
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'txtCategoria
        '
        Me.txtCategoria.Location = New System.Drawing.Point(301, 232)
        Me.txtCategoria.Name = "txtCategoria"
        Me.txtCategoria.Size = New System.Drawing.Size(308, 31)
        Me.txtCategoria.TabIndex = 14
        '
        'txtPrecio
        '
        Me.txtPrecio.Location = New System.Drawing.Point(301, 138)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Size = New System.Drawing.Size(308, 31)
        Me.txtPrecio.TabIndex = 13
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(301, 49)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(308, 31)
        Me.txtNombre.TabIndex = 12
        '
        'lblCategoriaP
        '
        Me.lblCategoriaP.AutoSize = True
        Me.lblCategoriaP.Location = New System.Drawing.Point(184, 238)
        Me.lblCategoriaP.Name = "lblCategoriaP"
        Me.lblCategoriaP.Size = New System.Drawing.Size(111, 25)
        Me.lblCategoriaP.TabIndex = 11
        Me.lblCategoriaP.Text = "Categoria:"
        '
        'lblPrecioP
        '
        Me.lblPrecioP.AutoSize = True
        Me.lblPrecioP.Location = New System.Drawing.Point(216, 144)
        Me.lblPrecioP.Name = "lblPrecioP"
        Me.lblPrecioP.Size = New System.Drawing.Size(79, 25)
        Me.lblPrecioP.TabIndex = 10
        Me.lblPrecioP.Text = "Precio:"
        '
        'lblNombreP
        '
        Me.lblNombreP.AutoSize = True
        Me.lblNombreP.Location = New System.Drawing.Point(202, 52)
        Me.lblNombreP.Name = "lblNombreP"
        Me.lblNombreP.Size = New System.Drawing.Size(93, 25)
        Me.lblNombreP.TabIndex = 9
        Me.lblNombreP.Text = "Nombre:"
        '
        'NuevoProducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnAceptarP)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.txtCategoria)
        Me.Controls.Add(Me.txtPrecio)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.lblCategoriaP)
        Me.Controls.Add(Me.lblPrecioP)
        Me.Controls.Add(Me.lblNombreP)
        Me.Name = "NuevoProducto"
        Me.Text = "NuevoProducto"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnAceptarP As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents txtCategoria As TextBox
    Friend WithEvents txtPrecio As TextBox
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents lblCategoriaP As Label
    Friend WithEvents lblPrecioP As Label
    Friend WithEvents lblNombreP As Label
End Class
