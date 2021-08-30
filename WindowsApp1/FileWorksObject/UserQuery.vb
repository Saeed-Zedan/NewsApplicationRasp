Imports System.Data.SqlClient

Public Class UserQuery
    Inherits BusinessQuery
    Private mTableName As String = "T_USER"
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
                Me.C_FullName = reader.GetString(5)
                Me.C_Password = reader.GetString(6)
                Me.C_PrivilegeLevel = reader.GetBoolean(7)
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

        Dim C_FullName As String = "C_FullName"
        Dim C_Password As String = "C_Password"
        Dim C_PrivilegeLevel As String = "C_PrivilegeLevel"

        Q_From &= $" {mTableName},"
        Q_Where &= $" and {Me.mTableName}.ID = {MyBase.GetTableName}.ID"

        AddingCol(C_FullName, Me.C_FullName)
        AddingCol(C_Password, Me.C_Password)
        AddingCol(C_PrivilegeLevel, Convert.ToInt32(Me.C_PrivilegeLevel))

    End Sub
    Protected Sub JoinTables()
        Q_Where &= $" and {Me.mTableName}.ID = {MyBase.GetTableName}.ID"
    End Sub
    Protected Overrides Function GetTableName() As String
        Return mTableName
    End Function
    Protected Overrides Sub ResetProperties()
        MyBase.ResetProperties()
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
