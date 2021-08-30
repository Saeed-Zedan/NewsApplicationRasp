Imports System.Data.SqlClient

Public Class News
    Inherits File
    'Fields
    Private categoryValue As String
    'Properties
    Public Property Category As String
        Get
            Return categoryValue
        End Get
        Set(value As String)
            categoryValue = value
        End Set
    End Property
    'Methods
    Public Overrides Function Read() As Boolean
        Try
            Dim query As String = $"select C_CATEGORY
                                    from T_BUSINESSOBJECT, T_FILE, T_NEWS
                                    where T_BUSINESSOBJECT.ID = T_FILE.ID and T_FILE.ID = T_NEWS.ID and T_NEWS.ID = {Me.ID}"
            Dim reader As SqlDataReader

            If MyBase.Read() Then

                dbManipulator.OpenConnection()
                dbManipulator.Query = query
                reader = dbManipulator.ExecReader()

                If Not reader.HasRows Then
                    Return False
                End If

                reader.Read()
                Me.Category = reader.GetString(0)

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
                query = $"update	T_NEWS
                                set		C_CATEGORY = '{Me.Category}'
                                where	ID = {Me.ID}"
            Else
                Me.ID = id
                query = $"insert into T_NEWS 
                       values( {id}, '{Me.Category}')"
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
        Dim Info As String = $"^_^{Me.Category}"
        Return MyBase.ToString() & Info
    End Function
End Class
