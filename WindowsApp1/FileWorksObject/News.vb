Imports System.Data.SqlClient

Public Class News
    Inherits File
    'Fields
    Private categoryValue As String
    'Properties
    Public Property Category As String
        Get
            Return categoryValue
        End Get
        Set(value As String)
            categoryValue = value
        End Set
    End Property
    'Methods
    Public Overrides Function Read() As Boolean
        Try
            Dim connectionString As String = "Data Source=SAEED\MSSQLSERVER01;Initial Catalog=NewsApplicationDB;Integrated Security=True"
            Dim connection As New SqlConnection(connectionString)

            Dim query As String = $"select *
                                    from T_BUSINESSOBJECT, T_FILE, T_NEWS
                                    where T_BUSINESSOBJECT.ID = T_FILE.ID and T_FILE.ID = T_NEWS.ID and C_NAME = '{Me.Name}'"

            Dim command As SqlCommand = New SqlCommand(query, connection)

            connection.Open()
            Dim reader As SqlDataReader
            reader = command.ExecuteReader()
            If Not reader.HasRows Then
                Return False
            End If
            reader.Read()
            Me.ID = reader.GetInt32(0)
            Me.CreationDate = reader.GetDateTime(1)
            Me.Name = reader.GetString(2)
            Me.ClassID = CChar(reader.GetString(3))
            Me.LastModifier = reader.GetString(4)
            Me.Body = reader.GetString(6)
            Me.Tagged = CChar(reader.GetString(7))
            Me.Description = reader.GetString(8)
            Me.Category = reader.GetString(10)
            connection.Close()

            Return True
        Catch ex As SqlException
            Throw New Exception("DB Crashed", ex)
        End Try
    End Function
    Public Overrides Function Delete() As Boolean
        Return MyBase.Delete()
    End Function
    Public Overrides Function Update() As Boolean
        Dim query As String
        If Me.ID <> 0 Then
            query = $"update	T_NEWS
                                set		C_CATEGORY = '{Me.Category}'
                                where	ID = {Me.ID}"
        Else
            query = $"insert into T_NEWS 
                       values( IDENT_CURRENT('T_BUSINESSOBJECT'), '{Me.Category}')"
        End If

        If MyBase.Update() Then
            Return Exec(query)
        Else
            Return False
        End If
    End Function
    Private Function Exec(query As String) As Boolean
        Try
            Dim connectionString As String = "Data Source=SAEED\MSSQLSERVER01;Initial Catalog=NewsApplicationDB;Integrated Security=True"
            Dim connection As New SqlConnection(connectionString)
            Dim command As SqlCommand = New SqlCommand(query, connection)

            connection.Open()
            Dim effectedRows = command.ExecuteNonQuery()
            connection.Close()

            If effectedRows > 0 Then
                Return True
            End If

            Return False
        Catch ex As Exception
            Throw New Exception("DB Crashed", ex)
        End Try
    End Function
    Public Overrides Function ToString() As String
        Dim Info As String = $"^_^{Me.Category}"
        Return MyBase.ToString() & Info
    End Function
End Class
