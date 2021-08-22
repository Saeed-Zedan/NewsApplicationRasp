﻿Imports System.IO
Imports System.Drawing

Public Class newsApplication
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
                    newsDataGridView.Rows.Add({Info(0), Info(1), Info(2)}) 'adding a new row to the grid (Title, Creation date, description
                    dict.Add(Info(1), filename) 'adding new element to the dictionary (creation date -as its the only unique attribute int the News Class-, File name)
                End If
            Next
        Catch ex As IOException
            MessageBox.Show("Process failed", "IO ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
        EmptyFields()
        Dim editNews = newsDataGridView.SelectedRows

        If editNews.Count = 1 Then
            MessageBox.Show(editNews(0).Index)
            Dim creationdate1 = editNews.Item(0).Cells(1).Value
            Dim filePath As String = String.Empty

            If newsDict.ContainsKey(creationdate1) Then
                filePath = newsDict(editNews.Item(0).Cells(1).Value)
            ElseIf imageDict.ContainsKey(creationdate1) Then
                filePath = imageDict(creationdate1)
            End If

            If filePath <> String.Empty Then
                Dim Info = dirManipulator.readFile(filePath)
                Dim newForm As newsEdit = New newsEdit(filePath)
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
        MessageBox.Show("selc " & row.Count & " " & newsDict.Count & imageDict.Count)
        If row.Count > 0 Then
            Dim creationDate1 = row(0).Cells(1).Value

            If newsDict.ContainsKey(creationDate1) Then
                categoryLabel.Enabled = True
                categoryTextBox.Enabled = True
                categoryLabel.Visible = True
                categoryTextBox.Visible = True
                imageTabPage.Enabled = False
                imageTabPage.Visible = False



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
        End If

    End Sub

    Private Sub ImageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImageToolStripMenuItem.Click
        Dim newForm = New addImage()
        newForm.ShowDialog()
    End Sub

    Private Sub EmptyFields()
        titleTextBox.Text = String.Empty
        bodyTextBox.Text = String.Empty
        categoryTextBox.Text = String.Empty
        creationDateTextBox.Text = String.Empty
        If PictureBox1.Image IsNot Nothing Then
            PictureBox1.Image.Dispose()
        End If

    End Sub

    Private Sub newsDataGridView_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles newsDataGridView.RowsAdded
        Dim row = newsDataGridView.Rows(0)
        displayNewsData(row)
    End Sub

    Private Sub displayNewsData(row As DataGridViewRow)
        Dim creationDate1 = row.Cells(1).Value
        MessageBox.Show("dis")
        If newsDict.ContainsKey(creationDate1) Then
            categoryLabel.Enabled = True
            categoryTextBox.Enabled = True
            categoryLabel.Visible = True
            categoryTextBox.Visible = True
            imageTabPage.Enabled = False
            imageTabPage.Visible = False



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
End Class