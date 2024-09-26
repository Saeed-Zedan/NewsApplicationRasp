Imports System.Windows.Forms
Imports System.IO
Public Class UsersView

    Public curUser As String
    Public priv As Boolean
    Private strDeatail = "{0,-5}{1,-29}{2,-60}{3,-29}"
    Public Sub New(curUser As String, priv As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.curUser = curUser
        Me.priv = priv

    End Sub
    Private Sub veiwUsers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim service = New DataLayer.UserQueryService()
        Dim result = service.Run(New FileWorxObject.UserQuery())

        If result Is Nothing Then
            MessageBox.Show("There is no users in the system", "That's Impossible", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            usersListBox.Items.Add(String.Format(strDeatail, "ID", "Name", "Long Name", "Last Modifier"))

            For Each user In result
                Dim userInfo = Strings.Split(user, "^_^")
                usersListBox.Items.Add(String.Format(strDeatail, userInfo(0), userInfo(2), userInfo(5), userInfo(4)))
            Next

        End If

    End Sub
    Private Sub usersListBox_DoubleClick(sender As Object, e As EventArgs) Handles usersListBox.DoubleClick
        Dim row = usersListBox.SelectedItem

        Dim rowCopy As String = row
        Do Until InStr(row, "  ") = 0       ' Loop until there are no more double spaces
            row = Replace(row, "  ", " ")   ' Replace 2 spaces with 1 space
        Loop

        If row = String.Empty Then 'no selected file
            MessageBox.Show("There is no selected user/s", "Duck", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        ElseIf row = String.Format(strDeatail, "ID", "Name", "Long Name", "Last Modifier") Then 'Can't remove the header
            Exit Sub
        ElseIf Not priv And curUser <> row.ToString().Split()(1) Then 'only admins and user himself can delete his account
            MessageBox.Show("You are not allowed to modify users information", "Privilage Violation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim info = row.ToString().Split()
        Dim userOb As FileWorxObject.User = New FileWorxObject.User()
        userOb.ID = info(0)

        'userOb.Read()
        'Dim newUser As FileWorxObject.User = New FileWorxObject.User(userOb)

        Dim newForm As UserEdit = New UserEdit(userOb.ID, curUser)
        Dim result = newForm.ShowDialog()

        If result = DialogResult.OK Then
            Dim service = New DataLayer.UserService()
            Dim serviceResult = service.Read(userOb.ID)
            userOb.FillData(serviceResult.Split("^_^"))
            usersListBox.Items.Remove(rowCopy)
            usersListBox.Items.Add(String.Format(strDeatail, userOb.ID, userOb.Name, userOb.FullName, userOb.LastModifier))
            curUser = userOb.LastModifier
        End If

    End Sub

    Private Sub deleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles deleteToolStripMenuItem.Click
        Dim row = usersListBox.SelectedItem

        If row = String.Empty Then 'no selected file
            MessageBox.Show("There is no selected user/s", "Duck", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        ElseIf row = String.Format(strDeatail, "ID", "Name", "Long Name", "Last Modifier") Then 'Can't remove the header
            Exit Sub
        ElseIf Not priv And curUser <> row.ToString().Split()(1) Then 'only admins and user himself can delete his account
            MessageBox.Show("You are not allowed to modify users information", "Privilage Violation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If


        Dim result = MessageBox.Show("Aru u sure u want to delete the user : " & row.ToString.Split(" ")(1), "Warning msg", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            row = CType(row, String)

            Dim columns As String() = Split(row)
            'Dim userOb As FileWorxObject.User = New FileWorxObject.User()
            'userOb.ID = columns(0)

            Dim service = New DataLayer.UserService()
            Dim serviceResult = service.Delete(columns(0))
            If serviceResult <> "Not Found" And serviceResult <> "Error" Then
                usersListBox.Items.Remove(row) 'remove the file from the gridview
                MessageBox.Show("User has been deleted", "POOR USER")
            Else
                MessageBox.Show("User doesn't exist", "LUCKY")
            End If

        End If

    End Sub
End Class
