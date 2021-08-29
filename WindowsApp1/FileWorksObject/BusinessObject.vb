Imports System.Data.SqlClient

Public Class BusinessObject
    Private mId As Integer
    Private creationDateValue As DateTime
    Private nameValue As String
    Private classIDValue As Char 'U: User, F: File 
    Private lastModifierValue As String

    Public Sub New(creationDate As DateTime, Name As String, classID As Char, lastModifier As String, Optional ID As Integer = 0)
        [mId] = ID
        creationDateValue = creationDate
        nameValue = Name
        classIDValue = classID
        lastModifierValue = lastModifier
    End Sub
    Public Sub New()
        [mId] = 0
    End Sub
    Public Sub New(Obj As BusinessObject)
        Me.ID = Obj.ID
        Me.CreationDate = Obj.CreationDate
        Me.nameValue = Obj.nameValue
        Me.classIDValue = Obj.classIDValue
        Me.lastModifierValue = Obj.lastModifierValue
    End Sub
    Public Property ID As Integer
        Get
            Return mId
        End Get
        Set(value As Integer)
            [mId] = value
        End Set
    End Property
    Public Property CreationDate As DateTime
        Get
            Return creationDateValue
        End Get
        Set(value As DateTime)
            creationDateValue = value
        End Set
    End Property
    Public Property Name As String
        Get
            Return nameValue
        End Get
        Set(value As String)
            nameValue = value
        End Set
    End Property
    Public Property ClassID As Char
        Get
            Return classIDValue
        End Get
        Set(value As Char)
            classIDValue = value
        End Set
    End Property
    Public Property LastModifier As String
        Get
            Return lastModifierValue
        End Get
        Set(value As String)
            lastModifierValue = value
        End Set
    End Property
    'Methods Implementation
    Public Overridable Function Read() As Boolean
        Try
            Dim connectionString As String = "Data Source=SAEED\MSSQLSERVER01;Initial Catalog=NewsApplicationDB;Integrated Security=True"
            Dim connection As New SqlConnection(connectionString)

            Dim query As String = $"select * 
                                    from T_BUSINESSOBJECT
                                    where C_NAME = '{Me.Name}'"

            Dim command As SqlCommand = New SqlCommand(query, connection)

            connection.Open()
            Dim reader As SqlDataReader
            reader = command.ExecuteReader()
            If Not reader.HasRows Then
                Return False
            End If
            reader.Read()
            Me.ID = reader.GetInt32(0)
            Me.CreationDate = reader.GetDateTime(1)
            Me.Name = reader.GetString(2)
            Me.ClassID = CChar(reader.GetString(3))
            Me.LastModifier = reader.GetString(4)
            connection.Close()

            Return True
        Catch ex As SqlException
            Throw New Exception("DB Crashed", ex)
        End Try
    End Function
    Public Overridable Function Delete() As Boolean
        Dim query As String = $"delete from	T_BUSINESSOBJECT
                                    where	ID = {Me.ID}"
        Return Exec(query)
    End Function
    Public Overridable Function Update() As Boolean
        Dim query As String
        If ID <> 0 Then
            query = $"update	T_BUSINESSOBJECT
                                set		C_NAME = '{Me.Name}', C_CLASSID = '{Me.ClassID}', C_LASTMODIFIER = '{Me.LastModifier}'
                                where	ID = {Me.ID}"
        Else
            query = $"insert into T_BUSINESSOBJECT 
                      values(getdate(), '{Me.Name}', '{Me.ClassID}', '{Me.LastModifier}')"
        End If

        Return Exec(query)
    End Function
    Private Function Exec(query As String) As Boolean
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
        Catch ex As SqlException
            Throw New Exception("DB Crashed", ex)
        End Try
    End Function
    Public Overrides Function ToString() As String
        Dim info As String = $"{Me.ID}^_^{Me.CreationDate}^_^{Me.Name}^_^{Me.ClassID}^_^{Me.LastModifier}"
        Return Info
    End Function

End Class
