Imports System.IO
Imports System.Drawing
Public Class newsApplication
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized

    End Sub
    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles OpenToolStripMenuItem.Click

        newsDataGridView.Rows.Clear() 'Clear the table to avoid redundancy

        Dim dirPath = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\News" 'get the directory path where the files are saved
        If Not (Directory.Exists(dirPath)) Then
            FileSystem.MkDir(dirPath)
        End If

        Dim files = My.Computer.FileSystem.GetFiles(dirPath) 'retrieve all the files' name
        Dim Info As String()
        newsDict = New Dictionary(Of String, String) 'a dictionary to keep tracking of every file i display by storing its creation date and name

        Try
            For Each filename As String In files
                If filename.EndsWith(".txt") Then
                    Info = dirManipulator.readFile(filename)
                    newsDataGridView.Rows.Add({Info(0), Info(1), Info(2)}) 'adding a new row to the grid (Title, Creation date, description
                    newsDict.Add(Info(1), filename) 'adding new element to the dictionary (creation date -as its the only unique attribute int the News Class-, File name)
                End If
            Next
        Catch ex As IOException
            MessageBox.Show("Process failed", "IO ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click

        Dim dirPath = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\News" 'get the directory path where the file/s are saved
        Dim rows = newsDataGridView.SelectedRows
        Dim files As List(Of String) = New List(Of String)

        If rows.Count = 0 Then 'no selected file
            MessageBox.Show("There is no selected file/s", "Duck", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If


        If Not (Directory.Exists(dirPath)) Then
            FileSystem.MkDir(dirPath)
        End If

        For Each item As DataGridViewRow In rows
            newsDataGridView.Rows.Remove(item) 'remove the file from the gridview
            File.Delete(newsDict(item.Cells(1).Value)) 'using the creation date as primary key to retireive the file name from the dictionary and delete it
            newsDict.Remove(item.Cells(1).Value) 'remove the file from the dictionaty 
        Next
    End Sub

    Private Sub UserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserToolStripMenuItem.Click
        Dim userForm As addUser = New addUser()
        userForm.ShowDialog()
    End Sub

    Private Sub NewsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewsToolStripMenuItem.Click
        Dim newForm As addNews = New addNews()
        newForm.ShowDialog()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Dispose()
    End Sub

    Private Sub displayUsersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles displayUsersToolStripMenuItem.Click
        Dim newForm As veiwUsers = New veiwUsers()
        newForm.ShowDialog()
    End Sub

    Private Sub newsDataGridView_DoubleClick(sender As Object, e As EventArgs) Handles newsDataGridView.DoubleClick

        Dim editNews = newsDataGridView.SelectedRows

        If editNews.Count = 1 Then
            MessageBox.Show(editNews(0).Index)
            Dim filePath = newsDict(editNews.Item(0).Cells(1).Value)
            Dim Info = dirManipulator.readFile(filePath)
            Dim newForm As newsEdit = New newsEdit(filePath)
            Dim result = newForm.ShowDialog()
            If result = DialogResult.OK Then
                Dim Info2 = dirManipulator.readFile(filePath)
                newsDataGridView.Rows.Remove(editNews(0))
                newsDataGridView.Rows.Add({Info2(0), Info2(1), Info2(2)}) 'adding a new row to the grid (Title, Creation date, description
            End If
        End If

    End Sub
    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        GroupBox1.Height = Me.Height \ 3

    End Sub
    Private Sub newsDataGridView_SelectionChanged(sender As Object, e As EventArgs) Handles newsDataGridView.SelectionChanged

        Dim row = newsDataGridView.SelectedRows
        Dim creationDate1 = row(0).Cells(1).Value
        If newsDict.ContainsKey(creationDate1) Then

            'Button2.Enabled = False
            'Button2.Visible = False
            'PictureBox1.Visible = False
            'PictureBox1.Enabled = False

            Dim filePath = newsDict(creationDate1)
            'Label1.Text = dirManipulator.readFile(filePath)(4)
        ElseIf imageDict.ContainsKey(creationDate1) Then
            MessageBox.Show("To be implemented")

        End If
    End Sub

    Private Sub ImageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImageToolStripMenuItem.Click
        Dim newForm = New addImage()
        newForm.ShowDialog()
    End Sub
End Class