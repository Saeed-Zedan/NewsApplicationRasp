Imports System.Data.SqlClient

Public Class File
    Inherits BusinessObject
    'Feilds
    Private bodyValue As String
    Private descriptionValue As String

    Public Sub New(Body As String, Description As String,
                  CreationDate As DateTime, Name As String, ClassID As Integer, LastModifier As String, Optional ID As Integer = 0)
        MyBase.New(CreationDate, Name, ClassID, LastModifier, ID)
        bodyValue = Body
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
            Dim query As String = $"select C_BODY, C_Description 
                                    from  T_BUSINESSOBJECT, T_FILE
                                    where T_BUSINESSOBJECT.ID = T_FILE.ID and T_FILE.ID = {Me.ID}"
            Dim reader As SqlDataReader

            If MyBase.Read() Then

                dbManipulator.OpenConnection()
                dbManipulator.Query = query
                reader = dbManipulator.ExecReader()

                If Not reader.HasRows Then
                    Return False
                End If

                reader.Read()
                Me.Body = reader.GetString(0)
                Me.Description = reader.GetString(1)

                dbManipulator.CloseConnection()

                Return True
            End If

            Return False
        Catch ex As SqlException
            Throw New Exception("DB Crashed", ex)
        End Try
    End Function
    Public Overrides Function Update() As Integer
        Dim query As String
        Dim id = MyBase.Update()

        If id > 0 Then

            If Me.ID <> 0 Then
                query = $"update	T_FILE
                                set		C_BODY = N'{Me.Body}', C_Description = N'{Me.Description}'
                                where	ID = {Me.ID}"
            Else
                query = $"insert into T_FILE 
                       values({id}, N'{Me.Body}', N'{Me.Description}')"
            End If

            If ExecNonQuery(query) Then
                Return id
            End If

            Return 0
        Else
            Return 0
        End If

    End Function
    Public Overrides Function ToString() As String
        Dim Info As String = $"^_^{Me.Body}^_^{Me.Description}"
        Return MyBase.ToString() & Info
    End Function
End Class
