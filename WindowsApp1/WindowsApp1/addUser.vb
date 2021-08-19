Imports System.IO
Imports System.Text.RegularExpressions
Public Class addUser
    Private Sub saveButton_Click(sender As Object, e As EventArgs) Handles saveButton.Click

        Dim longNameFormat As String = "[a-zA-Z]+(\s[a-zA-Z]+)+"
        Dim userOb As User = New User()
        If nameTextBox.Text = String.Empty Then
            MessageBox.Show("You must enter a Valid Name!", "Not valid value", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            nameTextBox.Select()
            Exit Sub
        End If

        If longNameTextBox.Text = String.Empty Or Not Regex.IsMatch(longNameTextBox.Text, longNameFormat) Then
            MessageBox.Show("You must enter a Valid Long Name!", "Not valid value", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            longNameTextBox.Select()
            Exit Sub
        End If

        If passwordTextBox.Text = String.Empty Then
            MessageBox.Show("You must enter a Password!", "Empty Password", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            longNameTextBox.Select()
            Exit Sub
        End If

        userOb.fullName = longNameTextBox.Text
        userOb.loginName = nameTextBox.Text
        userOb.Password = passwordTextBox.Text

        Try
            Dim dirPath = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Users"
            If Not (Directory.Exists(dirPath)) Then
                FileSystem.MkDir(dirPath)
            End If
            Dim fileName = dirPath & "\" & Guid.NewGuid.ToString() & ".txt"
            Dim fileWrite As FileStream = New FileStream(fileName, FileMode.Create, FileAccess.Write)
            Dim streamWr As StreamWriter = New StreamWriter(fileWrite)

            streamWr.Write(userOb.loginName & "^_^" & userOb.fullName & "^_^" & userOb.Password)
            streamWr.Flush()
            fileWrite.Close()
            MessageBox.Show("Process end successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As IOException
            MessageBox.Show("Process failed", "IO ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Dispose()

    End Sub

    Private Sub exitButton2_Click(sender As Object, e As EventArgs) Handles exitButton2.Click
        Me.Dispose()
    End Sub
End Class