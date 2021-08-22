
Imports System.IO
Public Class addImage
    Public filename As String = String.Empty
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


        Dim newsOb As Images = New Images()
        newsOb.Title = titleTextBox.Text
        newsOb.Body = bodyTextBox.Text
        newsOb.Image = imagePathTextBox.Text
        If descriptionTextBox.Text <> String.Empty Then
            newsOb.Description = descriptionTextBox.Text
        Else
            newsOb.Description = "  "
        End If

        Dim dirPath = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Images"
        Dim info = newsOb.Title & "^_^" & newsOb.creationDate & "^_^" & newsOb.Description & "^_^" & newsOb.Image & "^_^" & newsOb.Body
        filename = dirManipulator.addFile(dirPath, info)
        Me.DialogResult = DialogResult.OK
    End Sub
End Class