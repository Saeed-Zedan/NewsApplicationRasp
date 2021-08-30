﻿Imports System.IO
Public Class NewsAdd
    Public currentUser As String
    Private newsObValue As FileWorksObject.News
    Public Sub New(curUser As String)

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.currentUser = curUser
    End Sub
    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles saveButton.Click
        Select Case String.Empty
            Case titleTextBox.Text
                MessageBox.Show("You must enter a title!", "Empty Title", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                titleTextBox.Select()
                Exit Sub
            Case categoryComboBox1.Text
                MessageBox.Show("You must enter a category!", "Empty Title", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                categoryComboBox1.Select()
                Exit Sub
        End Select


        newsObValue = New FileWorksObject.News()
        newsObValue.Name = titleTextBox.Text
        newsObValue.Body = bodyTextBox.Text
        newsObValue.Category = categoryComboBox1.Text
        newsObValue.ClassID = 3
        newsObValue.LastModifier = currentUser
        newsObValue.CreationDate = DateTime.Now
        If descriptionTextBox.Text <> String.Empty Then
            newsObValue.Description = descriptionTextBox.Text
        Else
            newsObValue.Description = " "
        End If

        If newsObValue.Update() Then

            'Dim query = New FileWorksObject.NewsQuery _
            '    With {.C_Name = newsObValue.Name}
            'Dim result = query.Run()
            'newsObValue.ID = 0
            'For Each item In result
            '    Dim allinfo = item.Split("^_^")
            '    If Convert.ToInt32(allinfo(0)) > newsObValue.ID Then
            '        newsObValue.ID = Convert.ToInt32(allinfo(0))
            '    End If

            'Next
            Me.DialogResult = DialogResult.OK
        End If

    End Sub

    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles exitButton.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Dispose()
    End Sub
    Public ReadOnly Property newsOb As FileWorksObject.News
        Get
            Return newsObValue
        End Get
    End Property
End Class