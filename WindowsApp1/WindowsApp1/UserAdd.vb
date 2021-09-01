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
    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles saveButton.Click
        Dim userNameFormat = "^[-\w\.\$@\*\!]{1,255}$"
        Dim longNameFormat As String = "[a-zA-Z]+(\s[a-zA-Z]+)+"
        Dim userOb As FileWorksObject.User = New FileWorksObject.User()

        Dim query As FileWorksObject.UserQuery = New FileWorksObject.UserQuery()

        query.Name.ColumnValue = nameTextBox.Text
        query.Name.ConditionType = 1
        query.ClassID.ColumnValue = 1
        query.ClassID.ConditionType = 1

        If nameTextBox.Text = String.Empty Or Not Regex.IsMatch(nameTextBox.Text, userNameFormat) Then
            MessageBox.Show("You must enter a Valid Name!", "Not valid value", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            nameTextBox.Select()
            Exit Sub
        End If
        If query.Run() IsNot Nothing Then
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
            passwordTextBox.Select()
            Exit Sub
        End If

        userOb.FullName = longNameTextBox.Text
        userOb.Name = nameTextBox.Text
        userOb.Password = HashingPassword(passwordTextBox.Text)
        userOb.PrivilegeLevel = adminCheckBox.Checked
        userOb.LastModifier = curUser
        userOb.ClassID = 1
        If userOb.Update() Then
            MessageBox.Show("YaaaaaaaaaaaaaY")
        Else
            MessageBox.Show("Bad Luck :(")
        End If

        Me.Dispose()
    End Sub

    Private Sub ExitButton2_Click(sender As Object, e As EventArgs) Handles exitButton2.Click
        Me.Dispose()
    End Sub
    Private Sub UserAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not userPriv Then
            adminCheckBox.Checked = False
            adminCheckBox.Enabled = False
        End If
    End Sub
    Private Function HashingPassword(Password As String)
        Dim hashingOb As New SHA1CryptoServiceProvider
        Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(Password)
        bytesToHash = hashingOb.ComputeHash(bytesToHash)
        Dim strResult As String = ""
        For Each item In bytesToHash
            strResult += item.ToString("x2")
        Next

        Return strResult
    End Function
End Class