Imports System.Data.SqlClient

Public Class Photo
    Inherits File
    'Fields
    Private photoPathValue As String
    'Properties
    Public Property PhotoPath As String
        Get
            Return photoPathValue
        End Get
        Set(value As String)
            photoPathValue = value
        End Set
    End Property
    'Methods
    Public Overrides Function Add() As Boolean
        If MyBase.Add() Then
            Dim query As String = $"insert into T_PHOTO
                                    values( IDENT_CURRENT('T_BUSINESSOBJECT'), '{Me.PhotoPath}')"

            Return Exec(query)
        Else
            Return False
        End If
    End Function
    Public Overrides Function Delete() As Boolean
        Return MyBase.Delete()
    End Function
    Public Overrides Function Read() As String
        Return MyBase.Read()
    End Function
    Public Overrides Function Update() As Boolean
        If MyBase.Update() Then
            Dim query As String = $"update	T_PHOTO
                                    set		C_LOCATION = '{Me.PhotoPath}'
                                    where	C_NAME = '{Me.Name}'"
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
        Dim Info As String = $"^_^{Me.PhotoPath}"
        Return MyBase.ToString() & Info
    End Function
End Class
