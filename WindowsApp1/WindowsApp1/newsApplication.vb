Imports System.IO
Imports WindowsApp1
Public Class newsApplication
    Private currentUser As String = String.Empty
    Private userPriv As Boolean
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        'Dim newForm As LoginScreen = New LoginScreen()
        'Dim result = LoginScreen.ShowDialog()
        Using newForm = New LoginScreen()
            If newForm.ShowDialog = DialogResult.OK Then
                currentUser = newForm.UserName
                userPriv = newForm.Priv
                MessageBox.Show($"Welcome {currentUser}")
            Else
                Me.Dispose()
            End If
        End Using
    End Sub
    Private Sub addingRows(Rows As List(Of String))

        Try
            For Each Row In Rows
                Dim rowInfo = Strings.Split(Row, "^_^")
                newsDataGridView.Rows.Add({rowInfo(2), rowInfo(1), rowInfo(7), rowInfo(0)}) 'adding a new row to the grid (Title, Creation date, description
            Next
        Catch ex As IOException
            MessageBox.Show("Process failed", "IO ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub addingRow(name As String, creationDate As DateTime, description As String, ID As Integer)
        Try
            newsDataGridView.Rows.Add({name, creationDate.ToString(), description, ID}) 'adding a new row to the grid (Title, Creation date, description
        Catch ex As IOException
            MessageBox.Show("Process failed", "IO ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        addingRows((New FileWorksObject.FileQuery()).Run())
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        EmptyFields()

        Dim rows = newsDataGridView.SelectedRows
        Dim files As List(Of String) = New List(Of String)

        If rows.Count = 0 Then 'no selected file
            MessageBox.Show("There is no selected file/s", "Duck", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Dim newOb As FileWorksObject.File
        For Each item As DataGridViewRow In rows
            Dim name = item.Cells(0).Value
            Dim id = Convert.ToInt32(item.Cells(3).Value)
            Dim result = MessageBox.Show("Aru u sure u want to delete the user : " & name, "Warning msg", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                newOb = New FileWorksObject.File()
                newOb.Name = name
                newOb.ID = id

                If newOb.Read() Then
                    Dim Tagged = newOb.Tagged
                    If Char.ToUpper(Tagged) = "P" Then
                        RemovePhoto(newOb.Name, newOb.ID)
                    End If
                    If newOb.Delete() Then
                        newsDataGridView.Rows.Remove(item) 'remove the file from the gridview
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub RemovePhoto(name As String, ID As Integer)
        Dim newob As FileWorksObject.Photo = New FileWorksObject.Photo()
        newob.Name = name
        newob.ID = ID
        newob.Read()
        Dim photoPath = newob.PhotoPath
        If File.Exists(photoPath) Then
            File.Delete(photoPath)
        End If
    End Sub

    Private Sub UserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserToolStripMenuItem.Click
        Dim userForm As UserAdd = New UserAdd(currentUser, userPriv)
        userForm.ShowDialog()
    End Sub

    Private Sub NewsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewsToolStripMenuItem.Click
        'Dim newForm As addNews = New addNews()
        'newForm.ShowDialog()

        Using newForm = New NewsAdd(currentUser)
            If newForm.ShowDialog() = DialogResult.OK Then
                addingRow(newForm.newsOb.Name, newForm.newsOb.CreationDate, newForm.newsOb.Description, newForm.newsOb.ID)
                MessageBox.Show("Done SUCCESSFULLY")
            End If

        End Using

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Dispose()
    End Sub

    Private Sub displayUsersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles displayUsersToolStripMenuItem.Click
        Dim newForm As UsersView = New UsersView(currentUser, userPriv)
        newForm.ShowDialog()
    End Sub
    Private Sub newsDataGridView_DoubleClick(sender As Object, e As EventArgs) Handles newsDataGridView.DoubleClick
        EmptyFields()
        Dim selectedNews = newsDataGridView.SelectedRows

        If selectedNews.Count = 1 Then
            Dim row = selectedNews(0)
            Dim fileOb As FileWorksObject.File = New FileWorksObject.File()
            fileOb.ID = Convert.ToInt32(row.Cells(3).Value)
            Dim Tagged As Char
            If fileOb.Read() Then
                Tagged = fileOb.Tagged()
            Else
                Tagged = "E"
            End If


            If Tagged = "N" Then
                Using newForm = New NewsEdit(currentUser, fileOb.Name, fileOb.ID)
                    If newForm.ShowDialog() = DialogResult.OK Then
                        newsDataGridView.Rows.Remove(row)
                        newsDataGridView.Rows.Add({newForm.newsOB.Name, newForm.newsOB.CreationDate.ToString(), newForm.newsOB.Description, newForm.newsOB.ID})
                        MessageBox.Show("IT'S DONE")
                    End If
                End Using

            ElseIf Tagged = "P" Then
                If PictureBox1.Image IsNot Nothing Then
                    MessageBox.Show("HEre is the problem")
                End If
                Using newForm = New ImageEdit(currentUser, fileOb.Name, fileOb.ID)
                    If newForm.ShowDialog() = DialogResult.OK Then
                        newsDataGridView.Rows.Remove(row)
                        newsDataGridView.Rows.Add({newForm.newOb.Name, newForm.newOb.CreationDate.ToString(), newForm.newOb.Description, newForm.newOb.ID})
                        'addingRow(newForm., imageDict)
                    End If
                End Using

            ElseIf Tagged = "X" Then
                MessageBox.Show("Couldn't Access DB")
            ElseIf Tagged = "E" Then
                MessageBox.Show("No Match In DB")
            End If
        End If

    End Sub
    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        displayTabControl.Height = Me.Height \ 3
    End Sub
    Private Sub newsDataGridView_SelectionChanged(sender As Object, e As EventArgs) Handles newsDataGridView.SelectionChanged
        EmptyFields()

        Dim row = newsDataGridView.SelectedRows
        If row.Count > 0 Then
            displayNewsData(row(0))
        End If

    End Sub

    Private Sub ImageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImageToolStripMenuItem.Click
        Using newForm = New ImageAdd(currentUser)
            If newForm.ShowDialog() = DialogResult.OK Then
                addingRow(newForm.newOb.Name, newForm.newOb.CreationDate.ToString(), newForm.newOb.Description, newForm.newOb.ID)
            Else
                MessageBox.Show("Not completed.")
            End If
        End Using
    End Sub

    Private Sub EmptyFields()
        titleTextBox.Text = String.Empty
        bodyTextBox.Text = String.Empty
        categoryTextBox.Text = String.Empty
        creationDateTextBox.Text = String.Empty
        If PictureBox1.Image IsNot Nothing Then
            PictureBox1.Image.Dispose()
        End If
        PictureBox1.Image = Nothing

    End Sub

    Private Sub newsDataGridView_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles newsDataGridView.RowsAdded
        Dim row = newsDataGridView.Rows(0)
        displayNewsData(row)
    End Sub

    Private Sub displayNewsData(row As DataGridViewRow)
        EmptyFields()
        Dim newob As FileWorksObject.File = New FileWorksObject.File()
        newob.Name = row.Cells(0).Value
        newob.ID = Convert.ToInt32(row.Cells(3).Value)
        Dim Tagged As Char
        If newob.Read() Then
            Tagged = newob.Tagged
        End If

        If Tagged = "N" Then
            categoryLabel.Enabled = True
            categoryTextBox.Enabled = True
            categoryLabel.Visible = True
            categoryTextBox.Visible = True

            Dim displayOb As FileWorksObject.News = New FileWorksObject.News()
            displayOb.Name = newob.Name
            displayOb.ID = newob.ID
            displayOb.Read()
            titleTextBox.Text = displayOb.Name
            creationDateTextBox.Text = displayOb.CreationDate.ToString
            categoryTextBox.Text = displayOb.Category
            bodyTextBox.Text = displayOb.Body

        ElseIf Tagged = "P" Then
            categoryLabel.Enabled = False
            categoryTextBox.Enabled = False
            categoryLabel.Visible = False
            categoryTextBox.Visible = False

            Dim displayOb As FileWorksObject.Photo = New FileWorksObject.Photo()
            displayOb.Name = newob.Name
            displayOb.ID = newob.ID
            displayOb.Read()
            titleTextBox.Text = displayOb.Name
            creationDateTextBox.Text = displayOb.CreationDate.ToString
            PictureBox1.Image = Image.FromFile(displayOb.PhotoPath)
            bodyTextBox.Text = displayOb.Body

        End If
    End Sub

    Private Sub logoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles logoutToolStripMenuItem.Click
        currentUser = String.Empty
        Me.Hide()
        Using newForm = New LoginScreen()
            If newForm.ShowDialog = DialogResult.OK Then
                currentUser = newForm.UserName
                userPriv = newForm.Priv
                MessageBox.Show($"Welcome {currentUser}")
                Me.Show()
            Else
                Me.Dispose()
            End If
        End Using

    End Sub
    Private Sub CurrentUserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CurrentUserToolStripMenuItem.Click
        MessageBox.Show(currentUser)
    End Sub

    Private Sub TryNewUserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TryNewUserToolStripMenuItem.Click
        Dim newUser As FileWorksObject.User = New FileWorksObject.User("saeed hell", "123456", True, DateTime.Now, "Ahmed", "U", "Auto Run")
        newUser.ID = 0

        If True Then
            MessageBox.Show("Mission Done Successfully." & newUser.Update())
        Else
            MessageBox.Show("Retreat Retreat Mission Failed.")
        End If
    End Sub
End Class