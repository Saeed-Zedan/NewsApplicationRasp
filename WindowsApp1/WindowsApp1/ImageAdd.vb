﻿
Imports System.IO
Public Class ImageAdd
    Public currentUser As String
    Public newOb As FileWorksObject.PhotoQuery

    Public Sub New(currentUser As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.currentUser = currentUser
    End Sub
    Private Sub browseButton_Click(sender As Object, e As EventArgs) Handles browseButton.Click
        Dim result As DialogResult
        Dim filename As String
        Dim ImageExtensions = {".JPG", ".JPE", ".BMP", ".GIF", ".PNG"}
        Using fileChooser As New OpenFileDialog()
            result = fileChooser.ShowDialog()
            filename = fileChooser.FileName
            If Not ImageExtensions.Contains(Path.GetExtension(filename).ToUpper()) Then
                MessageBox.Show("The file extension was invalid." & Path.GetExtension(filename), "Invalid file type", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End Using

        If result <> DialogResult.Cancel Then
            imagePathTextBox.Text = filename
            PictureBox1.Image = Image.FromFile(filename)
        End If

    End Sub

    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles cancelButton.Click
        Me.Close()
    End Sub

    Private Sub saveButton_Click(sender As Object, e As EventArgs) Handles saveButton.Click
        Select Case String.Empty
            Case titleTextBox.Text
                MessageBox.Show("You must enter a title!", "Empty Title", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                titleTextBox.Select()
                Exit Sub
            Case imagePathTextBox.Text
                MessageBox.Show("You must select a picture!", "Empty picture", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
        End Select

        newOb = New FileWorksObject.PhotoQuery()

        newOb.Name = titleTextBox.Text
        newOb.Body = bodyTextBox.Text
        newOb.ClassID = "F"
        newOb.LastModifier = currentUser
        newOb.CreationDate = DateTime.Now
        If descriptionTextBox.Text <> String.Empty Then
            newOb.Description = descriptionTextBox.Text
        Else
            newOb.Description = " "
        End If
        newOb.Tagged = "P"
        Dim newPhotoName = Guid.NewGuid.ToString() & Path.GetExtension(imagePathTextBox.Text)
        Dim dirPath = My.Computer.FileSystem.SpecialDirectories.Desktop & "\Photos"
        If Not Directory.Exists(dirPath) Then
            Directory.CreateDirectory(dirPath)
        End If
        Dim newPath = Path.Combine(dirPath, newPhotoName)
        File.Copy(imagePathTextBox.Text, newPath)
        newOb.PhotoPath = newPath
        If newOb.Add() Then
            Me.DialogResult = DialogResult.OK
        Else
            Me.DialogResult = DialogResult.Cancel
        End If

    End Sub
End Class