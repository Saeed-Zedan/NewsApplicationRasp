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


        Dim query As FileWorksObject.UserQuery = New FileWorksObject.UserQuery()
        Dim allUsers = query.Run()
        If allUsers.Count = 0 Then
            MessageBox.Show("There is no users in the system", "That's Impossible", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Dim w = Me.Width
            Dim strDeatail = "{0,-5}{1,-29}{2,-60}{3,-29}"
            usersListBox.Items.Add(String.Format(strDeatail, "ID", "Name", "Long Name", "Last Modifier"))
            userDict = New Dictionary(Of String, String)
            For Each user In allUsers
                usersListBox.Items.Add(String.Format(strDeatail, user(0), user(2), user(5), user(4)))
            Next


        End If
    End Sub
    Private Sub usersListBox_DoubleClick(sender As Object, e As EventArgs) Handles usersListBox.DoubleClick
        Dim row = usersListBox.SelectedItem
        Dim strDeatail = "{0,-5}{1,-29}{2,-60}{3,-29}"

        If row = String.Empty Then 'no selected file
            MessageBox.Show("There is no selected user/s", "Duck", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        ElseIf row = String.Format(strDeatail, "ID", "Name", "Long Name", "Last Modifier") Then 'Can't remove the header
            Exit Sub
        ElseIf Not Priv And curUser <> row.ToString().Split()(1) Then 'only admins and user himself can delete his account
            MessageBox.Show("You are not allowed to modify users information", "Privilage Violation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim info = row.ToString().Split()
        Dim userOb As FileWorksObject.User = New FileWorksObject.User()
        userOb.ID = info(0)
        userOb.Read()
        Dim newUser As FileWorksObject.User = New FileWorksObject.User(userOb)

        Dim newForm As UserEdit = New UserEdit(newUser, curUser)
        Dim result = newForm.ShowDialog()

        If result = DialogResult.OK Then
            newUser.Read()
            If Not newUser.Equals(userOb) Then
                usersListBox.Items.Remove(row)
                usersListBox.Items.Add(String.Format(strDeatail, newUser.ID, newUser.Name, newUser.FullName, newUser.LastModifier))
            End If
        End If
    End Sub

    Private Sub deleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles deleteToolStripMenuItem.Click
        Dim row = usersListBox.SelectedItem
        Dim strDeatail = "{0,-5}{1,-29}{2,-60}{3,-29}"

        If row = String.Empty Then 'no selected file
            MessageBox.Show("There is no selected user/s", "Duck", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        ElseIf row = String.Format(strDeatail, "ID", "Name", "Long Name", "Last Modifier") Then 'Can't remove the header
            Exit Sub
        ElseIf Not Priv And curUser <> row.ToString().Split()(1) Then 'only admins and user himself can delete his account
            MessageBox.Show("You are not allowed to modify users information", "Privilage Violation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If


        Dim result = MessageBox.Show("Aru u sure u want to delete the user : " & row.ToString.Split(" ")(1), "Warning msg", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            row = CType(row, String)
            Dim columns As String() = Split(row)
            Dim userOb As FileWorksObject.User = New FileWorksObject.User()
            userOb.ID = columns(0)
            If userOb.Delete() Then
                usersListBox.Items.Remove(row) 'remove the file from the gridview
                MessageBox.Show("User has been deleted", "POOR USER")
            Else
                MessageBox.Show("User doesn't exist", "LUCKY")
            End If

        End If

    End Sub
End Class
