Public Class Producto
    Public Property Id As Int32
    Public Property Nombre As String
    Public Property Precio As Double
    Public Property Categoria As String
    Public Overrides Function ToString() As String
        Return Nombre
    End Function
End Class
