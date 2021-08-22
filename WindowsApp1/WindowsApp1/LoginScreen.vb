Imports System.IO

Public Class LoginScreen

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See https://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click

        Dim dirPath = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Users" 'get the directory path where the files are saved
        If Not (Directory.Exists(dirPath)) Then
            FileSystem.MkDir(dirPath)
        End If

        Dim curUser As User = New User()
        curUser.loginName = UsernameTextBox.Text
        curUser.Password = PasswordTextBox.Text
        Dim files = My.Computer.FileSystem.GetFiles(dirPath) 'retrieve all the files' name
        Dim Info As String()


        Try
            For Each filename As String In files
                If filename.EndsWith(".txt") Then
                    Info = dirManipulator.readFile(filename)
                    If Info(0) = curUser.loginName And Info(2) = curUser.Password Then
                        Me.DialogResult = DialogResult.OK
                        Me.Close()
                        Exit Sub
                    End If
                End If
            Next
            MessageBox.Show("Wrong name or password", "Invalid Login", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Catch ex As IOException
            MessageBox.Show("Process failed", "IO ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Public Function getUserName() As String
        Return UsernameTextBox.Text
    End Function

End Class
