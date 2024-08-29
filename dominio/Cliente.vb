Public Class Cliente
    Public Property Id As Int32
    Public Property Cliente As String
    Public Property Telefono As String
    Public Property Correo As String
    Public Overrides Function ToString() As String
        Return Cliente
    End Function
End Class
