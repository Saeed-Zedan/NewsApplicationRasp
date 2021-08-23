Imports System.Windows.Forms
Imports System.IO
Public Class UsersView
    Dim userDict As Dictionary(Of String, String)
    Dim curUser As String
    Dim Priv As Boolean

    Public Sub New(curUser As String, priv As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.curUser = curUser
        Me.Priv = priv

    End Sub
    Private Sub veiwUsers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dirPath = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\Users"

        If Not Directory.Exists(dirPath) Then
            Directory.CreateDirectory(dirPath)
        End If

        Dim files = Directory.GetFiles(dirPath)

        If files.Length = 0 Then
            MessageBox.Show("There is no users in the system", "Empty Directory", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Dim w = Me.Width
            Dim strDeatail = "{0,-60}{1,-120}"
            usersListBox.Items.Add(String.Format(strDeatail, "Name", "Long Name"))
            userDict = New Dictionary(Of String, String)
            For Each filename In files
                Dim Info = dirManipulator.readFile(filename)
                usersListBox.Items.Add(String.Format(strDeatail, Info(0), Info(1)))
                userDict.Add(Info(0), filename)
            Next


        End If
    End Sub
    Private Sub usersListBox_DoubleClick(sender As Object, e As EventArgs) Handles usersListBox.DoubleClick
        If Not Priv Then
            MessageBox.Show("You are not allowed to modify users information", "Privilage Violation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Dim row = usersListBox.SelectedItem
        If row IsNot Nothing Then
            Dim info = row.ToString().Split()
            Dim filename = userDict(info(0))
            Dim newForm As UserEdit = New UserEdit(filename, curUser)
            Dim result = newForm.ShowDialog()
            If result = DialogResult.OK Then
                userDict.Remove(info(0))
                info = dirManipulator.readFile(filename)
                userDict.Add(info(0), filename)
                usersListBox.Items.Remove(row)
                Dim strDeatail = "{0,-60}{1,-120}"
                usersListBox.Items.Add(String.Format(strDeatail, info(0), info(1)))

            End If
        End If
    End Sub

    Private Sub deleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles deleteToolStripMenuItem.Click
        If Not Priv Then
            MessageBox.Show("You are not allowed to modify users information", "Privilage Violation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim dirPath = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Users" 'get the directory path where the file/s are saved
        Dim row = usersListBox.SelectedItem
        Dim files As List(Of String) = New List(Of String)

        If row = String.Empty Then 'no selected file
            MessageBox.Show("There is no selected user/s", "Duck", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim strDeatail = "{0,-60}{1,-120}"
        If row = String.Format(strDeatail, "Name", "Long Name") Then
            Exit Sub
        End If
        If Not (Directory.Exists(dirPath)) Then
            FileSystem.MkDir(dirPath)
        End If


        Dim result = MessageBox.Show("Aru u sure u want to delete the user : " & row.ToString.Split(" ")(0), "Warning msg", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            usersListBox.Items.Remove(row) 'remove the file from the gridview
            row = CType(row, String)
            Dim rows As String() = Split(row)
            File.Delete(userDict(rows(0))) 'using the creation date as primary key to retireive the file name from the dictionary and delete it
            userDict.Remove(rows(0)) 'remove the file from the dictionaty 
        End If

    End Sub
End Class
