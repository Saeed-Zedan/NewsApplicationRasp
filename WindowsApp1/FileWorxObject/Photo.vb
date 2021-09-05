Imports System.Data.SqlClient
Imports System.Drawing
Imports System.IO

Public Class Photo
    Inherits File
    'Properties
    Public Property PhotoPath As String
    'Methods
    Public Overrides Function Read() As Boolean
        Try
            Dim query As String = $"select C_LOCATION
                                    from T_PHOTO
                                    where T_PHOTO.ID = {Me.ID}"
            Dim reader As SqlDataReader

            If MyBase.Read() Then

                dbManipulator.OpenConnection()
                dbManipulator.Query = query
                reader = dbManipulator.ExecReader()

                If Not reader.HasRows Then
                    Return False
                End If

                reader.Read()
                Me.PhotoPath = reader.GetString(0)

                dbManipulator.CloseConnection()

                Return True
            End If
            Return False
        Catch ex As SqlException
            Throw New Exception("DB Crashed", ex)
        End Try
    End Function
    Public Overrides Function Delete() As Boolean
        If MyBase.Delete() Then
            If IO.File.Exists(PhotoPath) Then
                IO.File.Delete(PhotoPath)
            End If
            Return True
        Else
            Return False
        End If
    End Function
    Public Overrides Function Update() As Integer
        Dim query As String
        Dim id = MyBase.Update()
        If id > 0 Then
            If Me.ID <> 0 Then

                Dim oldPath = GetOldPath()
                If oldPath <> Me.PhotoPath Then
                    If IO.File.Exists(oldPath) Then
                        IO.File.Delete(oldPath)
                    End If

                    Me.PhotoPath = InsertPhoto()
                End If

                query = $"update	T_PHOTO
                                set		C_LOCATION = '{Me.PhotoPath}'
                                where	ID = '{Me.ID}'"
                Else
                    Me.ID = id
                Me.PhotoPath = InsertPhoto()
                query = $"insert into T_PHOTO
                       values( {id}, '{Me.PhotoPath}')"

            End If

            If ExecNonQuery(query) Then
                Return id
            End If
            Return 0

        Else
            Return 0
        End If

    End Function
    Private Function CreateNewPath()
        Dim newPhotoName = Guid.NewGuid.ToString() & ".jpeg" 'Path.GetExtension(Me.PhotoPath)
        Dim dirPath = "C:\Users\saeed.z\Desktop\Photos" 'My.Computer.FileSystem.SpecialDirectories.Desktop & "\Photos"

        If Not Directory.Exists(dirPath) Then
            Directory.CreateDirectory(dirPath)
        End If

        Dim newPath = Path.Combine(dirPath, newPhotoName)
        Return newPath
    End Function
    Private Function InsertPhoto() As String

        Dim newPath = CreateNewPath()
        IO.File.Copy(Me.PhotoPath, newPath)

        Return newPath
    End Function
    Private Function GetOldPath() As String
        Dim query = $"select C_LOCATION
                    from T_PHOTO
                    where ID = {Me.ID}"
        Return ExecScaler(Of String)(query)
    End Function

    Public Overrides Function ToString() As String
        Dim Info As String = $"^_^{Me.PhotoPath}"
        Return MyBase.ToString() & Info
    End Function
End Class
