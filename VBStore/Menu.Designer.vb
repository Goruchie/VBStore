﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Menu
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
        Me.btnProductos = New System.Windows.Forms.Button()
        Me.btnClientes = New System.Windows.Forms.Button()
        Me.btnVender = New System.Windows.Forms.Button()
        Me.btnVentas = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnProductos
        '
        Me.btnProductos.Location = New System.Drawing.Point(103, 213)
        Me.btnProductos.Name = "btnProductos"
        Me.btnProductos.Size = New System.Drawing.Size(268, 75)
        Me.btnProductos.TabIndex = 0
        Me.btnProductos.Text = "Productos"
        Me.btnProductos.UseVisualStyleBackColor = True
        '
        'btnClientes
        '
        Me.btnClientes.Location = New System.Drawing.Point(103, 86)
        Me.btnClientes.Name = "btnClientes"
        Me.btnClientes.Size = New System.Drawing.Size(268, 75)
        Me.btnClientes.TabIndex = 1
        Me.btnClientes.Text = "Clientes"
        Me.btnClientes.UseVisualStyleBackColor = True
        '
        'btnVender
        '
        Me.btnVender.Location = New System.Drawing.Point(103, 348)
        Me.btnVender.Name = "btnVender"
        Me.btnVender.Size = New System.Drawing.Size(268, 75)
        Me.btnVender.TabIndex = 2
        Me.btnVender.Text = "Vender"
        Me.btnVender.UseVisualStyleBackColor = True
        '
        'btnVentas
        '
        Me.btnVentas.Location = New System.Drawing.Point(103, 488)
        Me.btnVentas.Name = "btnVentas"
        Me.btnVentas.Size = New System.Drawing.Size(268, 75)
        Me.btnVentas.TabIndex = 3
        Me.btnVentas.Text = "Ventas"
        Me.btnVentas.UseVisualStyleBackColor = True
        '
        'Menu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(474, 649)
        Me.Controls.Add(Me.btnVentas)
        Me.Controls.Add(Me.btnVender)
        Me.Controls.Add(Me.btnClientes)
        Me.Controls.Add(Me.btnProductos)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(500, 720)
        Me.MinimumSize = New System.Drawing.Size(500, 720)
        Me.Name = "Menu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VBStore"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnProductos As Button
    Friend WithEvents btnClientes As Button
    Friend WithEvents btnVender As Button
    Friend WithEvents btnVentas As Button
End Class
