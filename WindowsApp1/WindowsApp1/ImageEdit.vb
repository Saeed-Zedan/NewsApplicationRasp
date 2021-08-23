Imports System.IO

Public Class ImageEdit
    Private filePath As String
    Private creationDate As String
    Sub New(filePath As String)
        InitializeComponent()
        Me.filePath = filePath
        Dim Info = dirManipulator.readFile(filePath)
        titleTextBox.Text = Info(0)
        creationDate = Info(1)
        descriptionTextBox.Text = Info(2)
        imagePathTextBox.Text = Info(3)
        bodyTextBox.Text = Info(4)
        PictureBox1.Image = Image.FromFile(Info(3))
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
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub editButton_Click(sender As Object, e As EventArgs) Handles editButton.Click
        If titleTextBox.Text = String.Empty Then
            MessageBox.Show("You must enter a title!", "Empty Title", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            titleTextBox.Select()
            Exit Sub
        ElseIf PictureBox1.Image Is Nothing Then
            MessageBox.Show("You must enter a category!", "Empty Title", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            PictureBox1.Select()
            Exit Sub
        End If

        Dim newsOb As Images = New Images()
        newsOb.Title = titleTextBox.Text
        newsOb.Body = bodyTextBox.Text
        newsOb.Image = imagePathTextBox.Text
        If descriptionTextBox.Text <> String.Empty Then
            newsOb.Description = descriptionTextBox.Text
        Else
            newsOb.Description = "  "
        End If

        Dim info = newsOb.Title & "^_^" & creationDate & "^_^" & newsOb.Description & "^_^" & newsOb.Image & "^_^" & newsOb.Body
        Dim result = MessageBox.Show("Aru u sure u want to commit ur edits", "Warning msg", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            dirManipulator.editFile(filePath, info)
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub
End Class