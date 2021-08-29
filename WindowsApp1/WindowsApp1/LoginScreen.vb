Imports System.IO
Imports System.Security.Cryptography

Public Class LoginScreen
    Private privValue As Boolean
    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See https://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.
    Public ReadOnly Property UserName As String
        Get
            Return UsernameTextBox.Text
        End Get
    End Property

    Public ReadOnly Property Priv As Boolean
        Get
            Return privValue
        End Get
    End Property

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
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click

        If UsernameTextBox.Text = Nothing Then
            MessageBox.Show("You must enter a User!", "Not valid value", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            UsernameTextBox.Select()
            Exit Sub
        ElseIf PasswordTextBox.Text = Nothing Then
            MessageBox.Show("You must enter a Password!", "Empty Password", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            PasswordTextBox.Select()
            Exit Sub
        End If

        Dim curUser As FileWorksObject.UserQuery = New FileWorksObject.UserQuery _
            With {.C_Name = UsernameTextBox.Text,
                  .C_Password = HashingPassword(PasswordTextBox.Text),
                  .C_ClassID = "U"}


        Dim result = curUser.Run()

        If result IsNot Nothing Then
            Dim info = Strings.Split(result(0), "^_^")
            privValue = info(7)
            Me.DialogResult = DialogResult.OK
            Me.Close()
            Exit Sub
        ElseIf result Is Nothing Then
            MessageBox.Show("Wrong name or password", "Invalid Login", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        MessageBox.Show("Wrong name or password", "Invalid Login", MessageBoxButtons.OK, MessageBoxIcon.Stop)
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub



End Class
