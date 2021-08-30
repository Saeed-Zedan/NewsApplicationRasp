Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Security.Cryptography

Public Class User
    Inherits BusinessObject
    'Feilds
    'Private Shared connectionString As String = "Data Source=SAEED\MSSQLSERVER01;Initial Catalog=NewsApplicationDB;Integrated Security=True"
    Private mFullName As String
    Private mPassword As String
    Private mPrivilegeLevel As Boolean
    Public Sub New(fullName As String, Password As String, privilegeLevel As Boolean,
              CreationDate As DateTime, Name As String, ClassID As Integer, LastModifier As String, Optional ID As Integer = 0)
        MyBase.New(CreationDate, Name, ClassID, LastModifier, ID)
        Me.mFullName = fullName
        Me.Password = Password
        Me.mPrivilegeLevel = privilegeLevel
    End Sub
    Public Sub New(Obj As User)
        MyBase.New(Obj)
        Me.mFullName = Obj.mFullName
        Me.mPassword = Obj.mPassword
        Me.mPrivilegeLevel = Obj.mPrivilegeLevel
    End Sub
    Public Sub New()
        MyBase.New()
    End Sub
    'Properties Implementation
    Public Property FullName As String
        Get
            Return mFullName
        End Get
        Set(value As String)
            mFullName = value
        End Set
    End Property
    Public Property Password As String
        Get
            Return mPassword
        End Get
        Set(value As String)
            mPassword = value
        End Set
    End Property
    Public Property PrivilegeLevel As Boolean
        Get
            Return mPrivilegeLevel
        End Get
        Set(value As Boolean)
            mPrivilegeLevel = value
        End Set
    End Property

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
                Me.mPassword = reader.GetString(1)
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
            'IDENT_CURRENT('T_BUSINESSOBJECT')

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
