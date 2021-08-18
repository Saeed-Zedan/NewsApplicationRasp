Imports System.IO

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized

    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        Dim newForm As addNews = New addNews()
        newForm.Show()
    End Sub
    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        newsDataGridView.Rows.Clear()
        Dim dirPath = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\News"
        If Not (Directory.Exists(dirPath)) Then
            FileSystem.MkDir(dirPath)
        End If
        Dim files = My.Computer.FileSystem.GetFiles(dirPath)
        Dim fileRead As FileStream
        Dim SR As StreamReader
        Dim Info As String()
        newsDict = New Dictionary(Of String, String)
        Try
            For Each filename As String In files
                If filename.EndsWith(".txt") Then
                    fileRead = New FileStream(filename, FileMode.Open, FileAccess.Read)

                    SR = New StreamReader(fileRead)
                    Info = Split(SR.ReadLine(), "^_^")
                    newsDataGridView.Rows.Add({Info(0), Info(1), Info(2)})

                    newsDict.Add(Info(1), filename)
                    fileRead.Close()
                End If
            Next
        Catch ex As IOException
            MessageBox.Show("Process failed", "IO ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim rows = newsDataGridView.SelectedRows
        Dim dirPath = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\News"
        If Not (Directory.Exists(dirPath)) Then
            FileSystem.MkDir(dirPath)
        End If

        For Each item As DataGridViewRow In rows
            newsDataGridView.Rows.Remove(item)
            File.Delete(newsDict(item.Cells(1).Value))
        Next
    End Sub
End Class