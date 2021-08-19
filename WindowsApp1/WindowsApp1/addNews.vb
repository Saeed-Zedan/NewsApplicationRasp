Imports System.IO
Public Class addNews
    Private Sub saveButton_Click(sender As Object, e As EventArgs) Handles saveButton.Click
        Select Case String.Empty
            Case titleTextBox.Text
                MessageBox.Show("You must enter a title!", "Empty Title", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            Case categoryComboBox1.Text
                MessageBox.Show("You must enter a category!", "Empty Title", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
        End Select
        Dim newsOb As News = New News()
        newsOb.Title = titleTextBox.Text
        newsOb.Body = bodyTextBox.Text
        newsOb.Category = categoryComboBox1.Text
        If descriptionTextBox.Text <> String.Empty Then
            newsOb.Description = descriptionTextBox.Text
        Else
            newsOb.Description = "%%##" 'this will indicate a null field i can use space instead but Daaah
        End If

        Try
            Dim dirPath = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\News"
            If Not (Directory.Exists(dirPath)) Then
                FileSystem.MkDir(dirPath)
            End If
            Dim fileName = dirPath & "\" & Guid.NewGuid.ToString() & ".txt"
            Dim fileWrite As FileStream = New FileStream(fileName, FileMode.Create, FileAccess.Write)
            Dim streamWr As StreamWriter = New StreamWriter(fileWrite)

            streamWr.Write(newsOb.Title & "^_^" & newsOb.creationDate & "^_^" & newsOb.Description & "^_^" & newsOb.Category & "^_^" & newsOb.Body)
            streamWr.Flush()
            fileWrite.Close()
            MessageBox.Show("Process end successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As IOException
            MessageBox.Show("Process failed", "IO ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Dispose()
    End Sub

    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles cancelButton.Click
        Me.Dispose()
    End Sub
End Class