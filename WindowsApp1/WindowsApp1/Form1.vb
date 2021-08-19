Imports System.IO

Public Class Form1
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
        Dim fileRead As FileStream
        Dim SR As StreamReader
        Dim Info As String()
        newsDict = New Dictionary(Of String, String) 'a dictionary to keep tracking of every file i display by storing its creation date and name
        Try
            For Each filename As String In files
                If filename.EndsWith(".txt") Then
                    fileRead = New FileStream(filename, FileMode.Open, FileAccess.Read)

                    SR = New StreamReader(fileRead)
                    Info = Split(SR.ReadLine(), "^_^")
                    If Info(2) = "%%##" Then 'NUll description
                        Info(2) = String.Empty
                    End If
                    newsDataGridView.Rows.Add({Info(0), Info(1), Info(2)}) 'adding a new row to the grid (Title, Creation date, description

                    newsDict.Add(Info(1), filename) 'adding new element to the dictionary (creation date -as its the only unique attribute int the News Class-, File name)
                    fileRead.Close()
                End If
            Next
        Catch ex As IOException
            MessageBox.Show("Process failed", "IO ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim rows = newsDataGridView.SelectedRows
        If rows.Count = 0 Then 'no selected file
            MessageBox.Show("There is no selected file/s", "Duck", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim dirPath = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\News" 'get the directory path where the file/s are saved
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
        userForm.Show()
    End Sub

    Private Sub NewsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewsToolStripMenuItem.Click
        Dim newForm As addNews = New addNews()
        newForm.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Dispose()
    End Sub

    Private Sub displayUsersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles displayUsersToolStripMenuItem.Click

    End Sub
End Class