Imports System.IO

Public Class LoginScreen
    Private privValue As Boolean
    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See https://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click

        Dim curUser As FileWorksObject.UserQuery = New FileWorksObject.UserQuery()
        curUser.Name = UsernameTextBox.Text
        curUser.Password = PasswordTextBox.Text
        Dim result = curUser.ValidatingUser()

        If result = 1 Then
            curUser.Read()
            privValue = curUser.PrivilegeLevel
            Me.DialogResult = DialogResult.OK
            Me.Close()
            Exit Sub
        ElseIf result = -1 Then
            MessageBox.Show("Failed to access DB", "Invalid DB Access", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        MessageBox.Show("Wrong name or password", "Invalid Login", MessageBoxButtons.OK, MessageBoxIcon.Stop)
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

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

End Class
