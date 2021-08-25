Imports System.Windows.Forms

Public Class NewsEdit
    Private currentUser As String
    Public newsOB As FileWorksObject.NewsQuery
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        Select Case String.Empty
            Case titleTextBox.Text
                MessageBox.Show("You must enter a title!", "Empty Title", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                titleTextBox.Select()
                Exit Sub
            Case categoryComboBox.Text
                MessageBox.Show("You must enter a category!", "Empty Title", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                categoryComboBox.Select()
                Exit Sub
        End Select

        newsOB.Name = titleTextBox.Text
        newsOB.Body = bodyTextBox.Text
        newsOB.Category = categoryComboBox.Text
        If descriptionTextBox.Text <> String.Empty Then
            newsOb.Description = descriptionTextBox.Text
        Else
            newsOB.Description = " "
        End If
        newsOB.LastModifier = currentUser

        Dim result = MessageBox.Show("Aru u sure u want to commit ur edits", "Warning msg", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            If newsOB.Update() Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                Me.DialogResult = System.Windows.Forms.DialogResult.No
                MessageBox.Show("NO")
                Me.Close()
            End If
        End If

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Sub New(Title As String)
        InitializeComponent()
        newsOB = New FileWorksObject.NewsQuery()
        newsOB.Name = Title
        Dim allInfo = newsOB.RetrieveData()
        If allInfo = "Failed" Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Abort
            Me.Close()
        ElseIf allInfo = "No Rows" Then
            Me.DialogResult = System.Windows.Forms.DialogResult.None
            Me.Close()
        Else
            Dim infos = Strings.Split(allInfo, "^_^")
            titleTextBox.Text = infos(2)
            descriptionTextBox.Text = infos(7)
            categoryComboBox.DropDownStyle = ComboBoxStyle.DropDown
            categoryComboBox.Text = infos(8)
            categoryComboBox.DropDownStyle = ComboBoxStyle.DropDownList
            bodyTextBox.Text = infos(5)
        End If

    End Sub

End Class
