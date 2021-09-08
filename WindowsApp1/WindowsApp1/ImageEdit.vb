Imports System.IO

Public Class ImageEdit
    Private currentUserValue As String
    Private newObValue As FileWorxObject.Photo
    Sub New(currentUser As String, name As String, ID As Integer)
        InitializeComponent()
        'newObValue.Name = name
        'newObValue.ID = ID
        'newObValue.Read()
        Dim service = New DataLayer.PhotoService()
        Dim result = service.Read(ID)
        If result <> "Not Found" Or result <> "Error" Then
            newObValue = New FileWorxObject.Photo()
            newObValue.FillData(result.Split("^_^"))
        Else
            MessageBox.Show("Conflict with DB", "Item Not Found")
            Me.Close()
        End If

        InitializeControls()

        Me.currentUserValue = currentUser
    End Sub
    Public ReadOnly Property newOb As FileWorxObject.Photo
        Get
            Return newObValue
        End Get
    End Property
    Private Sub BrowseButton_Click(sender As Object, e As EventArgs) Handles browseButton.Click
        Dim result As DialogResult
        Dim filename As String
        Dim ImageExtensions = {".JPG", ".JPE", ".BMP", ".GIF", ".PNG", ".JPEG"}

        Using fileChooser As New OpenFileDialog()
            result = fileChooser.ShowDialog()
            filename = fileChooser.FileName
            If Not ImageExtensions.Contains(Path.GetExtension(filename).ToUpper()) Then
                MessageBox.Show("The file extension was invalid : " & Path.GetExtension(filename), "Invalid file type", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End Using

        If result <> DialogResult.Cancel Then
            FreeImageResources()
            imagePathTextBox.Text = filename
            PictureBox1.Image = Image.FromFile(filename)
        End If

    End Sub

    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles cancelButton.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub EditButton_Click(sender As Object, e As EventArgs) Handles editButton.Click

        If titleTextBox.Text = String.Empty Then
            MessageBox.Show("You must enter a title!", "Empty Title", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            titleTextBox.Select()
            Exit Sub
        ElseIf PictureBox1.Image Is Nothing Then
            MessageBox.Show("You must enter a category!", "Empty Title", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            PictureBox1.Select()
            Exit Sub
        End If

        FillInfo()

        Dim result = MessageBox.Show("Aru u sure u want to commit ur edits", "Warning msg", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then

            FreeImageResources()
            Dim service As DataLayer.PhotoService = New DataLayer.PhotoService()
            Dim serviceResult = service.Update(newObValue)
            If serviceResult <> String.Empty Then
                Me.DialogResult = DialogResult.OK
            Else
                Me.DialogResult = DialogResult.No
            End If

        End If

        Me.Close()
    End Sub
    Private Sub InitializeControls()
        titleTextBox.Text = newObValue.Name
        descriptionTextBox.Text = newObValue.Description
        imagePathTextBox.Text = newObValue.PhotoPath
        bodyTextBox.Text = newObValue.Body
        PictureBox1.Image = Image.FromFile(newObValue.PhotoPath)
    End Sub

    Private Sub ImageEdit_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        FreeImageResources()
    End Sub

    Private Sub FreeImageResources()
        If PictureBox1.Image IsNot Nothing Then
            PictureBox1.Image.Dispose()
        End If
        PictureBox1.Image = Nothing
    End Sub

    Private Sub FillInfo()
        newObValue.Name = titleTextBox.Text
        newObValue.Body = bodyTextBox.Text
        newObValue.PhotoPath = imagePathTextBox.Text

        If descriptionTextBox.Text <> String.Empty Then
            newObValue.Description = descriptionTextBox.Text
        Else
            newObValue.Description = " "
        End If
        newObValue.LastModifier = currentUserValue
    End Sub
End Class