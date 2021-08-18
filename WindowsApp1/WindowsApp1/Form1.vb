Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized

    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        MessageBox.Show("New Form Should Open", "Hint", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        For Each foundFile As String In
            My.Computer.FileSystem.GetFiles(My.Computer.FileSystem.SpecialDirectories.MyDocuments)

            If foundFile.EndsWith(".txt") Then
                newsDataGridView.Rows.Add(foundFile, "hi")
            End If

        Next
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim rows = newsDataGridView.SelectedRows
        For Each item As DataGridViewRow In rows
            newsDataGridView.Rows.Remove(item)
        Next
    End Sub
End Class