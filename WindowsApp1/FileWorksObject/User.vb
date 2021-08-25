Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Security.Cryptography

Public Class User
    Inherits BusinessObject
    'Feilds
    'Private Shared connectionString As String = "Data Source=SAEED\MSSQLSERVER01;Initial Catalog=NewsApplicationDB;Integrated Security=True"
    Private fullNameValue As String
    Private passwordValue As String
    Private privilegeLevelValue As Boolean
    Public Sub New(fullName As String, Password As String, privilegeLevel As Boolean,
              CreationDate As DateTime, Name As String, ClassID As Char, LastModifier As String, Optional ID As Integer = 0)
        MyBase.New(CreationDate, Name, ClassID, LastModifier, ID)
        Me.fullNameValue = fullName
        Me.Password = Password
        Me.privilegeLevelValue = privilegeLevel
    End Sub
    Public Sub New(Obj As User)
        MyBase.New(Obj)
        Me.fullNameValue = Obj.fullNameValue
        Me.passwordValue = Obj.passwordValue
        Me.privilegeLevelValue = Obj.privilegeLevelValue
    End Sub
    Public Sub New()
        MyBase.New()
    End Sub
    'Properties Implementation
    Public Property FullName As String
        Get
            Return fullNameValue
        End Get
        Set(value As String)
            fullNameValue = value
        End Set
    End Property
    Public Property Password As String
        Get
            Return passwordValue
        End Get
        Set(value As String)
            Dim hashingOb As New SHA1CryptoServiceProvider
            Dim bytesToHash() As Byte = Text.Encoding.ASCII.GetBytes(value)

            bytesToHash = hashingOb.ComputeHash(bytesToHash)

            Dim strResult As String = ""

            For Each item In bytesToHash
                passwordValue += item.ToString("x2")
            Next
        End Set
    End Property
    Public Property PrivilegeLevel As Boolean
        Get
            Return privilegeLevelValue
        End Get
        Set(value As Boolean)
            privilegeLevelValue = value
        End Set
    End Property
    'Methods Implementation
    Public Sub AssignPasswordDirectly(value As String)
        passwordValue = value
    End Sub 'Assign a hashed value directly to password without encrypt it
    Public Overrides Function Read() As String
        Try
            Dim connectionString As String = "Data Source=SAEED\MSSQLSERVER01;Initial Catalog=NewsApplicationDB;Integrated Security=True"
            Dim connection As New SqlConnection(connectionString)

            Dim query As String = $"select * 
                                    from T_USER, T_BUSINESSOBJECT
                                    where T_BUSINESSOBJECT.ID = T_USER.ID and T_USER.ID = {Me.ID}"

            Dim command As SqlCommand = New SqlCommand(query, connection)

            connection.Open()
            Dim reader As SqlDataReader
            reader = command.ExecuteReader()
            If Not reader.HasRows Then
                Return "No Rows"
            End If
            reader.Read()
            Me.ID = reader.GetInt32(0)
            Me.CreationDate = reader.GetDateTime(5)
            Me.Name = reader.GetString(6)
            Me.ClassID = CChar(reader.GetString(7))
            Me.LastModifier = reader.GetString(8)
            Me.FullName = reader.GetString(1)
            Me.passwordValue = reader.GetString(2)
            Me.PrivilegeLevel = reader.GetBoolean(3)
            connection.Close()

            Return Me.ToString()
        Catch ex As SqlException
            Return "Failed"
        End Try

    End Function
    Public Overrides Function Update() As Boolean
        If MyBase.Update() Then
            Dim query As String = $"update	T_USER
                                    set		C_FULLNAME = '{Me.FullName}', C_PASSWORD = '{Me.Password}', C_PRIVILEGELEVEL = {Convert.ToInt32(Me.PrivilegeLevel)}
                                    where	ID = {Me.ID}"
            Return Exec(query)
        Else
            Return False
        End If
    End Function
    Public Overrides Function Delete() As Boolean
        Return MyBase.Delete()
    End Function
    Public Overrides Function Add() As Boolean
        If MyBase.Add() Then
            Dim query As String = $"insert into T_USER 
                                    values( IDENT_CURRENT('T_BUSINESSOBJECT'), '{Me.FullName}', '{Me.Password}', {Convert.ToInt32(Me.PrivilegeLevel)})"

            Return Exec(query)
        Else
            Return False
        End If
    End Function
    Public Overrides Function Exec(query As String) As Boolean
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
        Catch ex As Exception
            Return False
        End Try
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
