Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Public Class UserEdit
    Private curUser As String
    Private oldUser As FileWorksObject.User

    Sub New(newUser As FileWorksObject.User, curUser As String)
        InitializeComponent()

        oldUser = newUser
        Me.curUser = curUser

        nameTextBox.Text = oldUser.Name
        longNameTextBox.Text = oldUser.FullName
    End Sub
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles edit_Button.Click
        Dim userNameFormat = "^[-\w\.\$@\*\!]{1,255}$"
        Dim longNameFormat As String = "[a-zA-Z]+(\s[a-zA-Z]+)+"
        Dim userOb As FileWorksObject.User = New FileWorksObject.User()

        Dim query As FileWorksObject.UserQuery = New FileWorksObject.UserQuery()

        query.Name.ColumnValue = nameTextBox.Text
        query.Name.ConditionType = 1
        query.ClassID.ColumnValue = 1
        query.ClassID.ConditionType = 1

        Dim result = query.Run()
        If nameTextBox.Text = String.Empty Or Not Regex.IsMatch(nameTextBox.Text, userNameFormat) Then
            MessageBox.Show("You must enter a Valid Name!", "Not valid value", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            nameTextBox.Select()
            Exit Sub
        ElseIf oldUser.Name <> nameTextBox.Text AndAlso result IsNot Nothing Then
            MessageBox.Show("The name is already used!", "Not valid value", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            nameTextBox.Select()
            Exit Sub
        End If

        If longNameTextBox.Text = String.Empty Or Not Regex.IsMatch(longNameTextBox.Text, longNameFormat) Then
            MessageBox.Show("You must enter a Valid Long Name!", "Not valid value", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            longNameTextBox.Select()
            Exit Sub
        End If


        If oldUser.Name = nameTextBox.Text AndAlso oldUser.FullName = longNameTextBox.Text Then
            MessageBox.Show("OPERATION NOT DONE :(")
            Me.Close()
        Else
            Dim msgBoxResult = MessageBox.Show("Aru u sure u want to commit ur edits", "Warning msg", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If oldUser.Name = curUser Then
                curUser = nameTextBox.Text
            End If

            oldUser.Name = nameTextBox.Text
            oldUser.FullName = longNameTextBox.Text
            oldUser.LastModifier = curUser

            If msgBoxResult = DialogResult.Yes AndAlso oldUser.Update() Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                MessageBox.Show("OPERATION DONE")
                Me.Close()
            End If
        End If



    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class
