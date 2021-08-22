﻿Imports System.Windows.Forms

Public Class editUser
    Private filePath As String
    Private password As String

    Sub New(filePath As String)
        InitializeComponent()
        Me.filePath = filePath
        Dim Info = dirManipulator.readFile(filePath)

        nameTextBox.Text = Info(0)
        longNameTextBox.Text = Info(1)
        password = Info(2)

    End Sub
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles edit_Button.Click

        Select Case String.Empty
            Case nameTextBox.Text
                MessageBox.Show("You must enter a Name!", "Empty Name", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                nameTextBox.Select()
                Exit Sub
            Case longNameTextBox.Text
                MessageBox.Show("You must enter a long name!", "Empty Long Name", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                longNameTextBox.Select()
                Exit Sub
        End Select

        Dim newsOb As User = New User()
        newsOb.loginName = nameTextBox.Text
        newsOb.fullName = longNameTextBox.Text

        Dim info = newsOb.loginName & "^_^" & newsOb.fullName & "^_^" & password
        Dim result = MessageBox.Show("Aru u sure u want to commit ur edits", "Warning msg", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            dirManipulator.editFile(filePath, info)
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class
