Imports System.Configuration
Imports System.Data.SqlClient
Public Class AccesoDatos
    Private conexionString As String
    Private conexion As SqlConnection
    Private comando As SqlCommand
    Private lectorPrivado As SqlDataReader

    Public ReadOnly Property Lector As SqlDataReader
        Get
            Return lectorPrivado
        End Get
    End Property

    Public Sub New()
        conexionString = ConfigurationManager.ConnectionStrings("MyDbConnection").ConnectionString
        conexion = New SqlConnection(conexionString)
        comando = New SqlCommand()
    End Sub

    Public Sub SetQuery(ByVal query As String)
        comando.CommandType = System.Data.CommandType.Text
        comando.CommandText = query
    End Sub

    Public Sub EjecutarLectura()
        comando.Connection = conexion
        Try
            conexion.Open()
            lectorPrivado = comando.ExecuteReader()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub EjecutarAccion()
        comando.Connection = conexion
        Try
            conexion.Open()
            comando.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub SetearParametro(ByVal name As String, ByVal value As Object)
        comando.Parameters.AddWithValue(name, value)
    End Sub

    Public Sub CerrarConexion()
        If Lector IsNot Nothing Then
            Lector.Close()
        End If
        conexion.Close()
    End Sub

End Class
