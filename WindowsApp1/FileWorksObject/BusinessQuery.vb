Imports System.Data.SqlClient

Public Class BusinessQuery
    Protected Q_Select As String = "Select"
    Protected Q_From As String = "From"
    Protected Q_Where As String = "Where 1=1"
    Private mTableName As String = "T_BUSINESSOBJECT"
    Protected dbManipulator As DBAccess = New DBAccess()
    Public Overridable Function Run() As List(Of String)
        Dim result As List(Of String) = New List(Of String)
        BuildQuery()
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
                Me.mID.ColumnValue = reader.GetInt32(0)
                Me.CreationDate.ColumnValue = reader.GetDateTime(1)
                Me.Name.ColumnValue = reader.GetString(2)
                Me.ClassID.ColumnValue = reader.GetInt32(3)
                Me.LastModifier.ColumnValue = reader.GetString(4)
                record = Me.ToString()
                result.Add(record)
            Loop

            dbManipulator.CloseConnection()

            Return result
        Catch ex As SqlException
            ClearProperties()
            Throw New Exception("Couldn't EXecute query", ex)
        End Try

        ClearProperties()
        Return result
    End Function
    Protected Function GenerateQuery()
        Dim query As String = ""
        Q_Select = Q_Select.Substring(0, Q_Select.Length - 1)
        Q_From = Q_From.Substring(0, Q_From.Length - 1)
        query &= $"{Q_Select}{vbCrLf}{Q_From}{vbCrLf}{Q_Where}"

        Return query
    End Function
    Protected Overridable Function GetTableName() As String
        Return mTableName
    End Function
    Public Overrides Function ToString() As String
        Dim info As String = $"{Me.mID.ColumnValue}^_^{Me.CreationDate.ColumnValue}^_^{Me.Name.ColumnValue}^_^{Me.ClassID.ColumnValue}^_^{Me.LastModifier.ColumnValue}"
        Return info
    End Function

    'New Structure Implementation
    Public Property mID As New ColumnInformation(Of Integer) With {.ColumnName = "T_BUSINESSOBJECT.ID", .SelectFlag = True}
    Public Property CreationDate As New ColumnInformation(Of DateTime) With {.ColumnName = "C_CreationDate", .SelectFlag = True}
    Public Property Name As New ColumnInformation(Of String) With {.ColumnName = "C_Name", .SelectFlag = True}
    Public Property ClassID As New ColumnInformation(Of Integer) With {.ColumnName = "C_ClassID", .SelectFlag = True}
    Public Property LastModifier As New ColumnInformation(Of String) With {.ColumnName = "C_LastModifier", .SelectFlag = True}

    Protected Sub AddColumn(col As ColumnInformation(Of String))
        If col.SelectFlag = True Then
            Q_Select &= $" {col.ColumnName},"
        End If

        Select Case col.ConditionType
            Case 1
                Q_Where &= $" and {col.ColumnName} = N'{col.ColumnValue}'"
            Case 2
                Q_Where &= $" and {col.ColumnName} Like N'{col.ColumnValue}%'"
            Case 3
                Q_Where &= $" and {col.ColumnName} Like N'%{col.ColumnValue}'"
            Case 4
                Q_Where &= $" and {col.ColumnName} Like N'%{col.ColumnValue}%'"
        End Select

    End Sub

    Protected Sub AddColumn(col As ColumnInformation(Of Integer))
        If col.SelectFlag = True Then
            Q_Select &= $" {col.ColumnName},"
        End If

        Select Case col.ConditionType
            Case 1
                Q_Where &= $" and {col.ColumnName} = {col.ColumnValue}"
            Case 2
                Q_Where &= $" and {col.ColumnName} > {col.ColumnValue}"
            Case 3
                Q_Where &= $" and {col.ColumnName} < {col.ColumnValue}"
            Case 4
                Q_Where &= $" and {col.ColumnName} Between {col.ColumnValue} and {col.ColumnValue2}"
        End Select
    End Sub

    Protected Sub AddColumn(col As ColumnInformation(Of DateTime))
        If col.SelectFlag = True Then
            Q_Select &= $" {col.ColumnName},"
        End If

        Select Case col.ConditionType
            Case 1
                Q_Where &= $" and cast({col.ColumnName} As Date) = '{Format(col.ColumnValue, "yyyy-MM-dd")}'"
            Case 2
                Q_Where &= $" and cast({col.ColumnName} As Date) > '{Format(col.ColumnValue, "yyyy-MM-dd")}'"
            Case 3
                Q_Where &= $" and cast({col.ColumnName} As Date) < '{Format(col.ColumnValue, "yyyy-MM-dd")}'"
            Case 4
                Q_Where &= $" and cast({col.ColumnName} As Date) Between '{Format(col.ColumnValue, "yyyy-MM-dd")}' and '{Format(col.ColumnValue2, "yyyy-MM-dd")}'"
        End Select

    End Sub

    Protected Overridable Sub BuildQuery()

        Q_From &= $" {mTableName},"

        AddColumn(mID)
        AddColumn(CreationDate)
        AddColumn(Name)
        AddColumn(ClassID)
        AddColumn(LastModifier)

    End Sub
    Protected Overridable Sub ClearProperties()
        mID.Clear()
        CreationDate.Clear()
        Name.Clear()
        ClassID.Clear()
        LastModifier.Clear()
    End Sub
End Class