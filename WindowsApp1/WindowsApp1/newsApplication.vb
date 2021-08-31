Imports System.IO
Imports WindowsApp1
Public Class newsApplication
    Private currentUser As String = String.Empty
    Private userPriv As Boolean
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

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
    Private Sub AddingRows(Rows As List(Of String))

        Try
            For Each Row In Rows
                Dim rowInfo = Strings.Split(Row, "^_^")
                newsDataGridView.Rows.Add({rowInfo(2), rowInfo(1), rowInfo(6), rowInfo(0)}) 'adding a new row to the grid (Title, Creation date, description
            Next
        Catch ex As IOException
            MessageBox.Show("Process failed", "IO ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub AddingRow(name As String, creationDate As DateTime, description As String, ID As Integer)
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

        Dim query As FileWorksObject.BusinessQuery

        For Each item As DataGridViewRow In rows
            Dim id = Convert.ToInt32(item.Cells(3).Value)
            Dim name = item.Cells(0).Value
            Dim result = MessageBox.Show("Aru u sure u want to delete the user : " & name, "Warning msg", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result = DialogResult.Yes Then
                query = New FileWorksObject.BusinessQuery With {.ID = id}
                Dim queryResult = query.Run()
                Dim tagged As Integer
                Dim allInfo As String()

                If queryResult.Count = 1 Then
                    allInfo = Strings.Split(queryResult(0), "^_^")
                    tagged = Convert.ToInt32(allInfo(3))
                Else
                    MessageBox.Show("Item Doesn't Exist")
                    Exit Sub
                End If

                If tagged = 4 Then

                    Dim newOb As FileWorksObject.Photo = New FileWorksObject.Photo With {.ID = allInfo(0)}
                    If newOb.Read() Then
                        If newOb.Delete() Then
                            newsDataGridView.Rows.Remove(item)
                        End If
                    End If

                ElseIf tagged = 3 Then

                    Dim newOb As FileWorksObject.BusinessObject = New FileWorksObject.BusinessObject With {.ID = allInfo(0)}
                    If newOb.Read() Then
                        If newOb.Delete() Then
                            newsDataGridView.Rows.Remove(item)
                        End If
                    End If

                End If

            End If
        Next
    End Sub

    Private Sub UserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserToolStripMenuItem.Click
        Dim userForm As UserAdd = New UserAdd(currentUser, userPriv)
        userForm.ShowDialog()
    End Sub

    Private Sub NewsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewsToolStripMenuItem.Click

        Using newForm = New NewsAdd(currentUser)
            If newForm.ShowDialog() = DialogResult.OK Then
                AddingRow(newForm.newsOb.Name, newForm.newsOb.CreationDate, newForm.newsOb.Description, newForm.newsOb.ID)
                MessageBox.Show("Done SUCCESSFULLY")
            End If
        End Using

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Dispose()
    End Sub

    Private Sub DisplayUsersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles displayUsersToolStripMenuItem.Click
        Dim newForm As UsersView = New UsersView(currentUser, userPriv)
        newForm.ShowDialog()
        currentUser = newForm.curUser
    End Sub
    Private Sub NewsDataGridView_DoubleClick(sender As Object, e As EventArgs) Handles newsDataGridView.DoubleClick
        EmptyFields()
        Dim selectedNews = newsDataGridView.SelectedRows

        If selectedNews.Count = 1 Then
            Dim row = selectedNews(0)
            Dim fileOb As FileWorksObject.File = New FileWorksObject.File()
            fileOb.ID = Convert.ToInt32(row.Cells(3).Value)
            Dim tagged As Integer
            If fileOb.Read() Then
                tagged = fileOb.ClassID
            Else
                tagged = 0
            End If


            If tagged = 3 Then
                Using newForm = New NewsEdit(currentUser, fileOb.Name, fileOb.ID)
                    If newForm.ShowDialog() = DialogResult.OK Then
                        newsDataGridView.Rows.Remove(row)
                        newsDataGridView.Rows.Add({newForm.newsOB.Name, newForm.newsOB.CreationDate.ToString(), newForm.newsOB.Description, newForm.newsOB.ID})
                        MessageBox.Show("IT'S DONE")
                    End If
                End Using

            ElseIf tagged = 4 Then
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

            ElseIf tagged = -1 Then
                MessageBox.Show("Couldn't Access DB")
            ElseIf tagged = 0 Then
                MessageBox.Show("No Match In DB")
            End If
        End If

    End Sub
    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        displayTabControl.Height = Me.Height \ 3
    End Sub
    Private Sub NewsDataGridView_SelectionChanged(sender As Object, e As EventArgs) Handles newsDataGridView.SelectionChanged
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

    Private Sub NewsDataGridView_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles newsDataGridView.RowsAdded
        Dim row = newsDataGridView.Rows(0)
        displayNewsData(row)
    End Sub

    Private Sub DisplayNewsData(row As DataGridViewRow)
        EmptyFields()

        Dim newob As FileWorksObject.File = New FileWorksObject.File()
        newob.ID = Convert.ToInt32(row.Cells(3).Value)
        Dim tagged As Integer
        If newob.Read() Then
            tagged = newob.ClassID
        End If

        If tagged = 3 Then
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

        ElseIf tagged = 4 Then
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

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles logoutToolStripMenuItem.Click
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
End Class