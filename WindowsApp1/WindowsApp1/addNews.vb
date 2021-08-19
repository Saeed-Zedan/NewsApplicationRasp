Imports System.IO
Public Class addNews
    Private Sub saveButton_Click(sender As Object, e As EventArgs) Handles saveButton.Click
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


        Dim newsOb As News = New News()
        newsOb.Title = titleTextBox.Text
        newsOb.Body = bodyTextBox.Text
        newsOb.Category = categoryComboBox1.Text
        If descriptionTextBox.Text <> String.Empty Then
            newsOb.Description = descriptionTextBox.Text
        Else
            newsOb.Description = "  " 'this will indicate a null field i can use space instead but Daaah
        End If

        Dim dirPath = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\News"
        Dim info = newsOb.Title & "^_^" & newsOb.creationDate & "^_^" & newsOb.Description & "^_^" & newsOb.Category & "^_^" & newsOb.Body
        dirManipulator.addFile(dirPath, info)
        Me.Dispose()
    End Sub

    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles exitButton.Click
        Me.Dispose()
    End Sub
End Class