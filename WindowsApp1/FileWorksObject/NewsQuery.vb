Imports System.Data.SqlClient

Public Class NewsQuery
    Inherits FileQuery
    'Private Q_Select As String = "Select T_NEWS.ID, C_CREATIONDATE, C_NAME, C_CLASSID, C_LASTMODIFIER, C_BODY, C_Description, C_CATEGORY"
    'Private Q_From As String = "From T_BUSINESSOBJECT, T_FILE, T_NEWS"
    'Private Q_Where As String = "Where T_BUSINESSOBJECT.ID = T_FILE.ID and T_FILE.ID = T_NEWS.ID"
    Private mTableName As String = "T_NEWS"
    Public Overrides Function Run() As List(Of String)
        Dim result As List(Of String) = New List(Of String)
        BuildingQuery()
        Dim query = GenerateQuery()
        Dim record As String
        Dim reader As SqlDataReader

        Try
            dbManipulator.OpenConnection()
            dbManipulator.Query = query
            reader = dbManipulator.ExecReader()

            If Not reader.HasRows Then
                dbManipulator.CloseConnection()
                Return Nothing
            End If

            Do While reader.Read()
                Me.ID = reader.GetInt32(0)
                Me.C_CreationDate = reader.GetDateTime(1)
                Me.C_Name = reader.GetString(2)
                Me.C_ClassID = reader.GetInt32(3)
                Me.C_LastModifier = reader.GetString(4)
                Me.C_Body = reader.GetString(5)
                Me.C_Description = If((reader.GetString(6) = Nothing), " ", reader.GetString(6))
                Me.C_Category = reader.GetString(7)
                record = Me.ToString()
                result.Add(record)
            Loop

            dbManipulator.CloseConnection()
            Return result
        Catch ex As SqlException
            ResetProperties()
            Throw New Exception("Couldn't EXecute query", ex)
        End Try

        ResetProperties()
        Return result
    End Function

    Protected Overrides Sub BuildingQuery()
        MyBase.BuildingQuery()

        Dim C_Category As String = "C_CATEGORY"

        Q_From &= $" {mTableName},"
        Q_Where &= $" and {Me.mTableName}.ID = {MyBase.GetTableName}.ID"

        AddingCol(C_Category, Me.C_Category)
    End Sub
    Protected Overrides Function GetTableName() As String
        Return mTableName
    End Function
    'Private Sub AddingCol(colName As String, colValue As Integer)
    '    If colValue <> Nothing Then
    '        If Q_Where = "Where" Then
    '            Q_Where &= $" {colName} = {colValue}"
    '        Else
    '            Q_Where &= $" and {colName} = {colValue}"
    '        End If
    '    End If
    'End Sub
    'Private Sub AddingCol(colName As String, colValue As String)
    '    If colValue <> Nothing Then
    '        If Q_Where = "Where" Then
    '            Q_Where &= $" {colName} = N'{colValue}'"
    '        Else
    '            Q_Where &= $" and {colName} = N'{colValue}'"
    '        End If
    '    End If
    'End Sub
    Protected Overrides Sub ResetProperties()
        MyBase.ResetProperties()
        C_Category = Nothing
    End Sub
    Public Overrides Function ToString() As String
        Dim Info As String = $"^_^{Me.C_Category}"
        Return MyBase.ToString() & Info
    End Function

    Public Property C_Category As String = Nothing
End Class
