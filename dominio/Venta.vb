Public Class Venta
    Public Property Id As Int32
    Public Property Fecha As DateTime
    Public Property Cliente As Cliente
    Public Property Total As Decimal
    Public Overrides Function ToString() As String
        Return Total
    End Function
End Class
