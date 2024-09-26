﻿Imports System.Windows.Forms

Public Class NewsEdit
    Private currentUser As String
    Public newsOB As FileWorxObject.News
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        Select Case String.Empty
            Case titleTextBox.Text
                MessageBox.Show("You must enter a title!", "Empty Title", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                titleTextBox.Select()
                Exit Sub
            Case categoryComboBox.Text
                MessageBox.Show("You must enter a category!", "Empty Title", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                categoryComboBox.Select()
                Exit Sub
        End Select

        FillInfo()

        Dim service = New DataLayer.NewsService()

        Dim result = MessageBox.Show("Aru u sure u want to commit ur edits", "Warning msg", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Dim serviceResult = service.Update(newsOB)

            If serviceResult <> String.Empty Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                Me.DialogResult = System.Windows.Forms.DialogResult.No
                MessageBox.Show("NO")
                Me.Close()
            End If

        End If

    End Sub

    Private Sub FillInfo()
        newsOB.Name = titleTextBox.Text
        newsOB.Body = bodyTextBox.Text
        newsOB.Category = categoryComboBox.Text
        If descriptionTextBox.Text <> String.Empty Then
            newsOB.Description = descriptionTextBox.Text
        Else
            newsOB.Description = " "
        End If
        newsOB.LastModifier = currentUser
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Sub New(currentUser As String, Title As String, ID As Integer)
        InitializeComponent()
        newsOB = New FileWorxObject.News()
        newsOB.Name = Title
        newsOB.ID = ID

        If Not newsOB.Read() Then
            MessageBox.Show("No matching Row")
            Me.DialogResult = System.Windows.Forms.DialogResult.Abort
            Me.Close()

        End If

        Dim infos = Strings.Split(newsOB.ToString(), "^_^")
        titleTextBox.Text = infos(2)
        descriptionTextBox.Text = infos(6)
        categoryComboBox.DropDownStyle = ComboBoxStyle.DropDown
        categoryComboBox.Text = infos(7)
        categoryComboBox.DropDownStyle = ComboBoxStyle.DropDownList
        bodyTextBox.Text = infos(5)
        Me.currentUser = currentUser

    End Sub

End Class
