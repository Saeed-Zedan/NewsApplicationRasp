Imports System.IO
Imports System.Drawing

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
                currentUser = newForm.getUserName()
                userPriv = newForm.getPriv()
                MessageBox.Show(newForm.getUserName() & userPriv)
            Else
                Me.Dispose()
            End If
        End Using

    End Sub
    Private Sub addingRows(dirPath As String, ByRef dict As Dictionary(Of String, String))
        If Not (Directory.Exists(dirPath)) Then
            FileSystem.MkDir(dirPath)
        End If

        Dim files = My.Computer.FileSystem.GetFiles(dirPath) 'retrieve all the files' name
        Dim Info As String()


        Try
            For Each filename As String In files
                If filename.EndsWith(".txt") Then
                    Info = dirManipulator.readFile(filename)
                    dict.Add(Info(1), filename) 'adding new element to the dictionary (creation date -as its the only unique attribute int the News Class-, File name)
                    newsDataGridView.Rows.Add({Info(0), Info(1), Info(2)}) 'adding a new row to the grid (Title, Creation date, description

                End If
            Next
        Catch ex As IOException
            MessageBox.Show("Process failed", "IO ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub addingRow(filePath As String, ByRef dict As Dictionary(Of String, String))
        If (File.Exists(filePath)) Then
            Dim Info As String()
            Try
                If filePath.EndsWith(".txt") Then
                    Info = dirManipulator.readFile(filePath)
                    dict.Add(Info(1), filePath) 'adding new element to the dictionary (creation date -as its the only unique attribute int the News Class-, File name)
                    newsDataGridView.Rows.Add({Info(0), Info(1), Info(2)}) 'adding a new row to the grid (Title, Creation date, description

                End If
            Catch ex As IOException
                MessageBox.Show("Process failed", "IO ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized

    End Sub
    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles OpenToolStripMenuItem.Click
        EmptyFields()
        newsDataGridView.Rows.Clear() 'Clear the table to avoid redundancy

        'a dictionary to keep tracking of every file i display by storing its creation date and name
        newsDict = New Dictionary(Of String, String)
        imageDict = New Dictionary(Of String, String)

        Dim dirPath = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\News" 'get the directory path where the files are saved
        addingRows(dirPath, newsDict)

        dirPath = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Images" 'get the directory path where the files are saved
        addingRows(dirPath, imageDict)


    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        EmptyFields()
        Dim dirPathNews = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\News" 'get the directory path where the file/s are saved
        Dim dirPathImages = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Images" 'get the directory path where the file/s are saved
        Dim rows = newsDataGridView.SelectedRows
        Dim files As List(Of String) = New List(Of String)

        If rows.Count = 0 Then 'no selected file
            MessageBox.Show("There is no selected file/s", "Duck", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If


        If Not (Directory.Exists(dirPathNews)) Then
            FileSystem.MkDir(dirPathNews)
        End If

        If Not (Directory.Exists(dirPathImages)) Then
            FileSystem.MkDir(dirPathImages)
        End If

        For Each item As DataGridViewRow In rows
            Dim creationDate1 = item.Cells(1).Value
            newsDataGridView.Rows.Remove(item) 'remove the file from the gridview

            If newsDict.ContainsKey(creationDate1) Then
                File.Delete(newsDict(creationDate1)) 'using the creation date as primary key to retireive the file name from the dictionary and delete it
                newsDict.Remove(creationDate1) 'remove the file from the dictionaty
            ElseIf imageDict.ContainsKey(creationDate1) Then
                File.Delete(imageDict(creationDate1))
                imageDict.Remove(creationDate1)
            End If
        Next
    End Sub

    Private Sub UserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserToolStripMenuItem.Click
        Dim userForm As UserAdd = New UserAdd(currentUser, userPriv)
        userForm.ShowDialog()
    End Sub

    Private Sub NewsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewsToolStripMenuItem.Click
        'Dim newForm As addNews = New addNews()
        'newForm.ShowDialog()

        Using newForm = New NewsAdd
            If newForm.ShowDialog() = DialogResult.OK Then
                addingRow(newForm.filename, newsDict)
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
        Dim editNews = newsDataGridView.SelectedRows

        If editNews.Count = 1 Then
            Dim creationdate1 = editNews.Item(0).Cells(1).Value
            Dim filePath As String = String.Empty
            Dim Info As String()
            Dim newForm
            If newsDict.ContainsKey(creationdate1) Then
                filePath = newsDict(creationdate1)
                Info = dirManipulator.readFile(filePath)
                newForm = New NewsEdit(filePath)
            ElseIf imageDict.ContainsKey(creationdate1) Then
                filePath = imageDict(creationdate1)
                Info = dirManipulator.readFile(filePath)
                newForm = New ImageEdit(filePath)
            Else
                MessageBox.Show("Error")
                Exit Sub
            End If

            If filePath <> String.Empty Then

                Dim result = newForm.ShowDialog()
                If result = DialogResult.OK Then
                    Dim Info2 = dirManipulator.readFile(filePath)
                    newsDataGridView.Rows.Remove(editNews(0))
                    newsDataGridView.Rows.Add({Info2(0), Info2(1), Info2(2)}) 'adding a new row to the grid (Title, Creation date, description
                End If
            End If
        End If

    End Sub
    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        GroupBox1.Height = Me.Height \ 3

    End Sub
    Private Sub newsDataGridView_SelectionChanged(sender As Object, e As EventArgs) Handles newsDataGridView.SelectionChanged
        EmptyFields()

        Dim row = newsDataGridView.SelectedRows
        If row.Count > 0 Then
            displayNewsData(row(0))

        End If

    End Sub

    Private Sub ImageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImageToolStripMenuItem.Click
        Using newForm = New ImageAdd
            If newForm.ShowDialog() = DialogResult.OK Then
                addingRow(newForm.filename, imageDict)
            End If
        End Using
    End Sub

    Private Sub EmptyFields()
        titleTextBox.Text = String.Empty
        bodyTextBox.Text = String.Empty
        categoryTextBox.Text = String.Empty
        creationDateTextBox.Text = String.Empty
        PictureBox1.Image = Nothing

    End Sub

    Private Sub newsDataGridView_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles newsDataGridView.RowsAdded
        Dim row = newsDataGridView.Rows(0)
        displayNewsData(row)
    End Sub

    Private Sub displayNewsData(row As DataGridViewRow)
        Dim creationDate1 = row.Cells(1).Value
        If newsDict.ContainsKey(creationDate1) Then
            categoryLabel.Enabled = True
            categoryTextBox.Enabled = True
            categoryLabel.Visible = True
            categoryTextBox.Visible = True

            imageTabPage.Enabled = False
            imageTabPage.Visible = False

            displayTabControl.TabPages(1).Visible = False
            displayTabControl.TabPages(1).Enabled = False

            Dim filePath = newsDict(creationDate1)
            Dim info = dirManipulator.readFile(filePath)

            titleTextBox.Text = info(0)
            creationDateTextBox.Text = info(1)
            categoryTextBox.Text = info(3)
            bodyTextBox.Text = info(4)

        ElseIf imageDict.ContainsKey(creationDate1) Then
            categoryLabel.Enabled = False
            categoryTextBox.Enabled = False
            categoryLabel.Visible = False
            categoryTextBox.Visible = False

            imageTabPage.Enabled = True
            imageTabPage.Visible = True

            Dim filePath = imageDict(creationDate1)
            Dim info = dirManipulator.readFile(filePath)

            titleTextBox.Text = info(0)
            creationDateTextBox.Text = info(1)
            PictureBox1.Image = Image.FromFile(info(3))
            bodyTextBox.Text = info(4)

        End If
    End Sub

    Private Sub logoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles logoutToolStripMenuItem.Click
        currentUser = String.Empty
        Me.Hide()
        Using newForm = New LoginScreen()
            If newForm.ShowDialog = DialogResult.OK Then
                currentUser = newForm.getUserName()
                userPriv = newForm.getPriv()
                MessageBox.Show(newForm.getUserName())
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