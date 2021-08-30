Imports System.Data.SqlClient

Public Class BusinessQuery
    Protected Q_Select As String = "Select"
    Protected Q_From As String = "From"
    Protected Q_Where As String = "Where 1=1"
    Private mTableName As String = "T_BUSINESSOBJECT"
    Protected dbManipulator As DBAccess = New DBAccess()
    Public Overridable Function Run() As List(Of String)
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

    Protected Overridable Sub BuildingQuery()
        Dim ID As String = "T_BUSINESSOBJECT.ID"
        Dim C_CreationDate As String = "C_CreationDate"
        Dim C_Name As String = "C_Name"
        Dim C_ClassID As String = "C_ClassID"
        Dim C_LastModifier As String = "C_LastModifier"

        Q_From &= $" {mTableName},"

        AddingCol(ID, Me.ID)
        If Me.C_CreationDate = Nothing Then
            AddingCol(C_CreationDate, String.Empty)
        Else
            AddingCol(C_CreationDate, Format(C_CreationDate, "yyyy-MM-dd hh:mm:ss"))
        End If
        AddingCol(C_Name, Me.C_Name)
        AddingCol(C_ClassID, Me.C_ClassID)
        AddingCol(C_LastModifier, Me.C_LastModifier)
    End Sub
    Protected Sub AddingCol(colName As String, colValue As Integer)
        Q_Select &= $" {colName},"
        If colValue <> Nothing Then
            Q_Where &= $" and {colName} = {colValue}"
        End If
    End Sub
    Protected Sub AddingCol(colName As String, colValue As String)
        Q_Select &= $" {colName},"
        If colValue <> Nothing Then
            Q_Where &= $" and {colName} = N'{colValue}'"
        End If
    End Sub
    Protected Function GenerateQuery()
        Dim query As String = ""
        Q_Select = Q_Select.Substring(0, Q_Select.Length - 1)
        Q_From = Q_From.Substring(0, Q_From.Length - 1)
        query &= $"{Q_Select}{vbCrLf}{Q_From}{vbCrLf}{Q_Where}"

        Return query
    End Function
    Protected Overridable Sub ResetProperties()
        ID = Nothing
        C_CreationDate = Nothing
        C_Name = Nothing
        C_ClassID = Nothing
        C_LastModifier = Nothing
    End Sub
    Protected Overridable Function GetTableName() As String
        Return mTableName
    End Function
    Public Overrides Function ToString() As String
        Dim info As String = $"{Me.ID}^_^{Me.C_CreationDate}^_^{Me.C_Name}^_^{Me.C_ClassID}^_^{Me.C_LastModifier}"
        Return info
    End Function
    Public Property ID As Integer = Nothing
    Public Property C_CreationDate As DateTime = Nothing
    Public Property C_Name As String = Nothing
    Public Property C_ClassID As Integer = Nothing
    Public Property C_LastModifier As String = Nothing

End Class