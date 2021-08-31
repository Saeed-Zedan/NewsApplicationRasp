Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Security.Cryptography

Public Class User
    Inherits BusinessObject
    Public Sub New(fullName As String, password As String, privilegeLevel As Boolean,
              creationDate As DateTime, name As String, classID As Integer, lastModifier As String, Optional ID As Integer = 0)
        MyBase.New(creationDate, name, classID, lastModifier, ID)
        Me.FullName = fullName
        Me.Password = password
        Me.PrivilegeLevel = privilegeLevel
    End Sub
    Public Sub New(obj As User)
        MyBase.New(obj)
        Me.FullName = obj.FullName
        Me.Password = obj.Password
        Me.PrivilegeLevel = obj.PrivilegeLevel
    End Sub
    Public Sub New()
        MyBase.New()
    End Sub
    'Properties Implementation
    Public Property FullName As String

    Public Property Password As String

    Public Property PrivilegeLevel As Boolean


    'Methods Implementation
    Public Overrides Function Read() As Boolean
        Try
            Dim query As String = $"select C_FULLNAME, C_PASSWORD, C_PRIVILEGELEVEL 
                                    from T_BUSINESSOBJECT, T_USER
                                    where T_BUSINESSOBJECT.ID = T_USER.ID and T_USER.ID = {Me.ID}"
            Dim reader As SqlDataReader

            If MyBase.Read() Then
                dbManipulator.OpenConnection()
                dbManipulator.Query = query
                reader = dbManipulator.ExecReader()

                If Not reader.HasRows Then
                    Return False
                End If

                reader.Read()
                Me.FullName = reader.GetString(0)
                Me.Password = reader.GetString(1)
                Me.PrivilegeLevel = reader.GetBoolean(2)

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
                query = $"update	T_USER
                                set		C_FULLNAME = N'{Me.FullName}', C_PASSWORD = '{Me.Password}', C_PRIVILEGELEVEL = {Convert.ToInt32(Me.PrivilegeLevel)}
                                where   ID = {Me.ID}"
            Else
                Me.ID = id
                query = $"insert into T_USER 
                       values({id}, N'{Me.FullName}', '{Me.Password}', {Convert.ToInt32(Me.PrivilegeLevel)})"
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
        Dim Info As String = $"^_^{Me.FullName}^_^{Me.Password}^_^{Me.PrivilegeLevel}"
        Return MyBase.ToString() & Info
    End Function
    Public Overrides Function Equals(obj As Object) As Boolean
        Dim userOb = CType(obj, User)
        Select Case False
            Case Me.Name = userOb.Name
                Return False
            Case Me.FullName = userOb.FullName
                Return False
        End Select
        Return True
    End Function
End Class
