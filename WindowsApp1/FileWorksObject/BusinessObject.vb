Imports System.Data.SqlClient

Public Class BusinessObject
    Protected dbManipulator As DBAccess = New DBAccess()

    Public Sub New()
        ID = 0
    End Sub
    Public Sub New(creationDate As DateTime, name As String, classID As Integer, lastModifier As String, Optional ID As Integer = 0)
        Me.ID = ID
        Me.CreationDate = creationDate
        Me.Name = name
        Me.ClassID = classID
        Me.LastModifier = lastModifier
    End Sub

    Public Sub New(Obj As BusinessObject)
        Me.ID = Obj.ID
        Me.CreationDate = Obj.CreationDate
        Me.Name = Obj.Name
        Me.ClassID = Obj.ClassID
        Me.LastModifier = Obj.LastModifier
    End Sub

    Public Property ID As Integer
    Public Property CreationDate As DateTime
    Public Property Name As String
    Public Property ClassID As Integer
    Public Property LastModifier As String

    'Methods Implementation
    Public Overridable Function Read() As Boolean
        Try
            Dim query As String = $"select ID, C_CREATIONDATE, C_NAME, C_CLASSID, C_LASTMODIFIER 
                                    from T_BUSINESSOBJECT
                                    where ID = {Me.ID}"
            Dim reader As SqlDataReader

            dbManipulator.OpenConnection()
            dbManipulator.Query = query
            reader = dbManipulator.ExecReader()

            If Not reader.HasRows Then
                Return False
            End If

            reader.Read()

            Me.ID = reader.GetInt32(0)
            Me.CreationDate = reader.GetDateTime(1)
            Me.Name = reader.GetString(2)
            Me.ClassID = reader.GetInt32(3)
            Me.LastModifier = reader.GetString(4)

            dbManipulator.CloseConnection()

            Return True
        Catch ex As SqlException
            Throw New Exception("DB Crashed", ex)
        End Try
    End Function
    Public Overridable Function Delete() As Boolean
        Dim query As String = $"delete from	T_BUSINESSOBJECT
                                OUTPUT deleted.ID
                                where	ID = {Me.ID}"

        If ExecScaler(Of Integer)(query) > 0 Then
            Return True
        End If

        Return False
    End Function
    Public Overridable Function Update() As Integer
        Dim query As String
        If ID <> 0 Then
            query = $"update	T_BUSINESSOBJECT
                                set		C_NAME = N'{Me.name}', C_CLASSID = {Me.ClassID}, C_LASTMODIFIER = N'{Me.LastModifier}'
                                output inserted.id
                                where	ID = {Me.ID}"
        Else
            query = $"insert into T_BUSINESSOBJECT 
                      OUTPUT INSERTED.ID
                      values(getdate(), N'{Me.name}', {Me.ClassID}, N'{Me.LastModifier}')"
        End If

        Return ExecScaler(Of Integer)(query)

    End Function
    Protected Function ExecNonQuery(query As String) As Boolean
        Try

            dbManipulator.OpenConnection()
            dbManipulator.Query = query
            Dim effectedRows = dbManipulator.ExecNonQuery()
            dbManipulator.CloseConnection()

            Return True
        Catch ex As SqlException
            Throw New Exception("DB Crashed", ex)
        End Try
    End Function
    Protected Function ExecScaler(Of T)(query As String) As T

        dbManipulator.Query = query
        dbManipulator.OpenConnection()
        Dim result = dbManipulator.ExecScaler(Of T)()
        dbManipulator.CloseConnection()

        Return result
    End Function
    Public Overrides Function ToString() As String
        Dim info As String = $"{Me.ID}^_^{Me.CreationDate}^_^{Me.name}^_^{Me.ClassID}^_^{Me.LastModifier}"
        Return Info
    End Function

End Class
