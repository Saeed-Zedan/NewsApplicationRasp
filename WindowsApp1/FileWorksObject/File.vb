Imports System.Data.SqlClient

Public Class File
    Inherits BusinessObject
    'Feilds
    Private bodyValue As String
    Private taggedValue As Char
    Private descriptionValue As String

    Public Sub New(Body As String, Tagged As Char, Description As String,
                  CreationDate As DateTime, Name As String, ClassID As Char, LastModifier As String, Optional ID As Integer = 0)
        MyBase.New(CreationDate, Name, ClassID, LastModifier, ID)
        bodyValue = Body
        taggedValue = Tagged
        descriptionValue = Description
    End Sub
    Public Sub New()
        MyBase.New()
    End Sub
    'Properties implementation
    Public Property Body As String
        Get
            Return bodyValue
        End Get
        Set(value As String)
            bodyValue = value
        End Set
    End Property
    Public Property Tagged As Char
        Get
            Return taggedValue
        End Get
        Set(value As Char)
            taggedValue = value
        End Set
    End Property
    Public Property Description As String
        Get
            Return descriptionValue
        End Get
        Set(value As String)
            descriptionValue = value
        End Set
    End Property
    'Methods Implementation
    Public Overrides Function Read() As Boolean
        Try
            Dim connectionString As String = "Data Source=SAEED\MSSQLSERVER01;Initial Catalog=NewsApplicationDB;Integrated Security=True"
            Dim connection As New SqlConnection(connectionString)

            Dim query As String = $"select * 
                                    from  T_BUSINESSOBJECT, T_FILE
                                    where T_BUSINESSOBJECT.ID = T_FILE.ID and T_FILE.ID = {Me.ID}"

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
            query = $"update	T_FILE
                                set		C_BODY = '{Me.Body}', C_TAGGED = '{Me.Tagged}', C_Description = '{Me.Description}'
                                where	ID = {Me.ID}"
        Else
            query = $"insert into T_FILE 
                       values( IDENT_CURRENT('T_BUSINESSOBJECT'), '{Me.Body}', '{Me.Tagged}', '{Me.Description}')"
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
        Catch ex As SqlException
            Throw New Exception("DB Crashed", ex)
        End Try
    End Function
    Public Overrides Function ToString() As String
        Dim Info As String = $"^_^{Me.Body}^_^{Me.Tagged}^_^{Me.Description}"
        Return MyBase.ToString() & Info
    End Function
End Class
