Imports System.Data.SqlClient

Public Class UserQuery
    Inherits BusinessQuery
    Private Q_Select As String = "Select T_USER.ID, C_CREATIONDATE, C_NAME, C_CLASSID, C_LASTMODIFIER, C_FULLNAME, C_PASSWORD, C_PRIVILEGELEVEL"
    Private Q_From As String = "From T_BUSINESSOBJECT, T_USER"
    Private Q_Where As String = "Where T_BUSINESSOBJECT.ID = T_USER.ID"
    Public Overrides Function Run() As List(Of String)
        Dim result As List(Of String) = New List(Of String)
        Dim Query = BuildingQuery()
        Dim connectionString As String = "Data Source=SAEED\MSSQLSERVER01;Initial Catalog=NewsApplicationDB;Integrated Security=True"
        Dim record As String
        Try
            Using connection As New SqlConnection(connectionString)
                Using command As SqlCommand = New SqlCommand(Query, connection)

                    connection.Open()
                    Dim reader As SqlDataReader
                    reader = command.ExecuteReader()
                    If Not reader.HasRows Then
                        connection.Close()
                        Return Nothing
                    End If
                    Do While reader.Read()
                        Me.ID = reader.GetInt32(0)
                        Me.C_CreationDate = reader.GetDateTime(1)
                        Me.C_Name = reader.GetString(2)
                        Me.C_ClassID = CChar(reader.GetString(3))
                        Me.C_LastModifier = reader.GetString(4)
                        Me.C_FullName = reader.GetString(5)
                        Me.C_Password = reader.GetString(6)
                        Me.C_PrivilegeLevel = reader.GetBoolean(7)
                        record = Me.ToString()
                        result.Add(record)
                    Loop


                End Using
            End Using

            Return result
        Catch ex As SqlException
            ResetProperties()
            Throw New Exception("Couldn't EXecute query", ex)
        End Try

        ResetProperties()
        Return result
    End Function

    Private Function BuildingQuery() As String
        Dim ID As String = "T_USER.ID"
        Dim C_CreationDate As String = "C_CreationDate"
        Dim C_Name As String = "C_Name"
        Dim C_ClassID As String = "C_ClassID"
        Dim C_LastModifier As String = "C_LastModifier"
        Dim C_FullName As String = "C_FullName"
        Dim C_Password As String = "C_Password"
        Dim C_PrivilegeLevel As String = "C_PrivilegeLevel"

        AddingCol(ID, Me.ID)

        If Me.C_CreationDate = Nothing Then
            AddingCol(C_CreationDate, String.Empty)
        Else
            AddingCol(C_CreationDate, Format(C_CreationDate, "yyyy-MM-dd hh:mm:ss"))
        End If
        AddingCol(C_Name, Me.C_Name)
        AddingCol(C_ClassID, Me.C_ClassID)
        AddingCol(C_LastModifier, Me.C_LastModifier)
        AddingCol(C_FullName, Me.C_FullName)
        AddingCol(C_Password, Me.C_Password)
        AddingCol(C_PrivilegeLevel, Convert.ToInt32(Me.C_PrivilegeLevel))

        Dim Query As String = ""
        Query &= $"{Q_Select}{vbCrLf}{Q_From}"
        If Not Q_Where = "Where" Then
            Query &= $"{vbCrLf}{Q_Where}"
        End If

        Return Query
    End Function
    Private Sub AddingCol(colName As String, colValue As Integer)
        If colValue <> Nothing Then
            If Q_Where = "Where" Then
                Q_Where &= $" {colName} = {colValue}"
            Else
                Q_Where &= $" and {colName} = {colValue}"
            End If
        End If
    End Sub
    Private Sub AddingCol(colName As String, colValue As String)
        If colValue <> Nothing Then
            If Q_Where = "Where" Then
                Q_Where &= $" {colName} = '{colValue}'"
            Else
                Q_Where &= $" and {colName} = '{colValue}'"
            End If
        End If
    End Sub
    Private Sub ResetProperties()
        ID = Nothing
        C_CreationDate = Nothing
        C_Name = Nothing
        C_ClassID = Nothing
        C_LastModifier = Nothing
        C_FullName = Nothing
        C_Password = Nothing
        C_PrivilegeLevel = Nothing
    End Sub
    Public Overrides Function ToString() As String
        Dim Info As String = $"^_^{Me.C_FullName}^_^{Me.C_Password}^_^{Me.C_PrivilegeLevel}"
        Return MyBase.ToString() & Info
    End Function

    Public Property C_FullName As String = Nothing
    Public Property C_Password As String = Nothing
    Public Property C_PrivilegeLevel As Boolean = Nothing
End Class
