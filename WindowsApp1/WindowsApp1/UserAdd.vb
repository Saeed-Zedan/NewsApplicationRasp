Imports System.IO
Imports System.Security.Cryptography

Imports System.Text.RegularExpressions
Public Class UserAdd
    Private curUser As String = String.Empty
    Private userPriv As Boolean
    Public Sub New(curUser As String, userPriv As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.curUser = curUser
        Me.userPriv = userPriv
    End Sub
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
        userOb.Priv = adminCheckBox.Checked
        userOb.lastModifier = curUser
        Dim Info = userOb.loginName & "^_^" & userOb.fullName & "^_^" & userOb.Password & "^_^" & userOb.lastModifier & "^_^" & userOb.Priv
        dirManipulator.addFile(dirPath, Info)

        Me.Dispose()
    End Sub

    Private Sub exitButton2_Click(sender As Object, e As EventArgs) Handles exitButton2.Click
        Me.Dispose()
    End Sub
    Private Sub UserAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not userPriv Then
            adminCheckBox.Checked = False
            adminCheckBox.Enabled = False
        End If
    End Sub
End Class