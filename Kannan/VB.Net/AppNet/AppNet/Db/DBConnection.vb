Imports System.Data.SqlClient

Public Class DBConnection
    Shared _dbConnection As DBConnection

    Private ReadOnly Property Connection() As SqlConnection
        Get
            Dim connectionString As String
            connectionString = "Data Source=ILPT547;Initial Catalog=KannanDB;Integrated Security=SSPI"
            dim con As SqlConnection=New SqlConnection(connectionString)
            if con.State = ConnectionState.Closed
                con.Open()
            End If
                    Return con
        End Get
    End Property

    Private Sub New()

    End Sub

    Public Shared Function GetInstanc() As DBConnection
        If (_dbConnection Is Nothing) Then
            _dbConnection = New DBConnection()
        End If
        Return _dbConnection
    End Function

    Public Function ExecuteReader(ByVal queryString As String) As SqlDataReader
        Dim cmd As SqlCommand = New SqlCommand(queryString)
        cmd.Connection = Connection()
        Return cmd.ExecuteReader()
    End Function

    Public Function GetDataSet(ByVal queryString As String, ByVal tableName As String ) As DataSet

        Dim adapter As SqlDataAdapter = New SqlDataAdapter(queryString, Connection())

        Dim data As DataSet = New DataSet()
        adapter.Fill(data, tableName)
        Return data

    End Function

    Public Sub ExecuteNonQuery(ByVal queryString As String) 

          Dim command As SqlCommand = New SqlCommand(queryString, Connection())
    command.CommandType = CommandType.Text
        command.ExecuteNonQuery()
    End Sub


End Class
