Imports System.IO
Imports System.Security.Cryptography

Imports System.Text.RegularExpressions
Public Class addUser
    Private Sub saveButton_Click(sender As Object, e As EventArgs) Handles saveButton.Click

        Dim longNameFormat As String = "[a-zA-Z]+(\s[a-zA-Z]+)+"
        Dim userOb As User = New User()

        Dim allUsersName As List(Of String) = New List(Of String)
        Dim dirPath = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Users"

        Dim files = Directory.GetFiles(dirPath)

        For Each item In files
            If item.EndsWith(".txt") Then
                Dim name = readFile(item)(0)
                allUsersName.Add(name)
            End If
        Next

        If nameTextBox.Text = String.Empty Then
            MessageBox.Show("You must enter a Valid Name!", "Not valid value", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            nameTextBox.Select()
            Exit Sub
        ElseIf allUsersName.Contains(nameTextBox.Text) Then
            MessageBox.Show("The name is already used!", "Not valid value", MessageBoxButtons.OK, MessageBoxIcon.Stop)
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


        Dim Info = userOb.loginName & "^_^" & userOb.fullName & "^_^" & userOb.Password
        dirManipulator.addFile(dirPath, Info)

        Me.Dispose()
    End Sub

    Private Sub exitButton2_Click(sender As Object, e As EventArgs) Handles exitButton2.Click
        Me.Dispose()
    End Sub
End Class