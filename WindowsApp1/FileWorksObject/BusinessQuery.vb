Imports System.Data.SqlClient

Public Class BusinessQuery
    Private Q_Select As String = "Select *"
    Private Q_From As String = "From T_BUSINESSOBJECT"
    Private Q_Where As String = "Where"
    Public Overridable Function Run() As List(Of String)
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
        Dim ID As String = "ID"
        Dim C_CreationDate As String = "C_CreationDate"
        Dim C_Name As String = "C_Name"
        Dim C_ClassID As String = "C_ClassID"
        Dim C_LastModifier As String = "C_LastModifier"

        AddingCol(ID, Me.ID)

        If Me.C_CreationDate = Nothing Then
            AddingCol(C_CreationDate, String.Empty)
        Else
            AddingCol(C_CreationDate, Format(C_CreationDate, "yyyy-MM-dd hh:mm:ss"))
        End If
        AddingCol(C_Name, Me.C_Name)
        AddingCol(C_ClassID, Me.C_ClassID)
        AddingCol(C_LastModifier, Me.C_LastModifier)

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
    End Sub
    Public Overrides Function ToString() As String
        Dim info As String = $"{Me.ID}^_^{Me.C_CreationDate}^_^{Me.C_Name}^_^{Me.C_ClassID}^_^{Me.C_LastModifier}"
        Return info
    End Function
    Public Property ID As Integer = Nothing
    Public Property C_CreationDate As DateTime = Nothing
    Public Property C_Name As String = Nothing
    Public Property C_ClassID As String = Nothing
    Public Property C_LastModifier As String = Nothing

End Class