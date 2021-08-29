Imports System.IO

Public Class ImageEdit
    Private currentUserValue As String
    Private newObValue As FileWorksObject.Photo
    Sub New(currentUser As String, name As String, ID As Integer)
        InitializeComponent()

        newObValue = New FileWorksObject.Photo()
        newObValue.Name = name
        newObValue.ID = ID
        newObValue.Read()
        InitializeControls()

        Me.currentUserValue = currentUser
    End Sub
    Public ReadOnly Property newOb As FileWorksObject.Photo
        Get
            Return newObValue
        End Get
    End Property
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
            If PictureBox1.Image IsNot Nothing Then
                PictureBox1.Image.Dispose()
            End If
            PictureBox1.Image = Nothing
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

        newObValue.Name = titleTextBox.Text
        newObValue.Body = bodyTextBox.Text
        newObValue.PhotoPath = CopyImage(newObValue.PhotoPath)
        If descriptionTextBox.Text <> String.Empty Then
            newObValue.Description = descriptionTextBox.Text
        Else
            newObValue.Description = " "
        End If
        newObValue.LastModifier = currentUserValue

        Dim result = MessageBox.Show("Aru u sure u want to commit ur edits", "Warning msg", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            If newObValue.Update() Then
                Me.DialogResult = DialogResult.OK
            Else
                Me.DialogResult = DialogResult.No
            End If
        End If

        Me.Close()
    End Sub
    Private Function CopyImage(oldPath As String) As String
        Dim newPath As String = oldPath
        If oldPath <> imagePathTextBox.Text Then
            Dim newPhotoName = Guid.NewGuid.ToString() & Path.GetExtension(imagePathTextBox.Text)
            Dim dirPath = My.Computer.FileSystem.SpecialDirectories.Desktop & "\Photos"
            If Not Directory.Exists(dirPath) Then
                Directory.CreateDirectory(dirPath)
            End If

            newPath = Path.Combine(dirPath, newPhotoName)
            File.Copy(imagePathTextBox.Text, newPath)
            File.Delete(oldPath)
        End If

        Return newPath
    End Function
    Private Sub InitializeControls()
        titleTextBox.Text = newObValue.Name
        descriptionTextBox.Text = newObValue.Description
        imagePathTextBox.Text = newObValue.PhotoPath
        bodyTextBox.Text = newObValue.Body
        PictureBox1.Image = Image.FromFile(newObValue.PhotoPath)
    End Sub

    Private Sub ImageEdit_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If PictureBox1.Image IsNot Nothing Then
            PictureBox1.Image.Dispose()
        End If
        PictureBox1.Image = Nothing
    End Sub
End Class