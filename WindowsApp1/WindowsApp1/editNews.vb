Imports System.Windows.Forms

Public Class editNews
    Private filePath As String
    Private creationDate As String
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


        Dim newsOb As News = New News()
        newsOb.Title = titleTextBox.Text
        newsOb.Body = bodyTextBox.Text
        newsOb.Category = categoryComboBox.Text
        If descriptionTextBox.Text <> String.Empty Then
            newsOb.Description = descriptionTextBox.Text
        Else
            newsOb.Description = "  "
        End If

        Dim info = newsOb.Title & "^_^" & creationDate & "^_^" & newsOb.Description & "^_^" & newsOb.Category & "^_^" & newsOb.Body
        Dim result = MessageBox.Show("Aru u sure u want to commit ur edits", "Warning msg", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            dirManipulator.editFile(filePath, info)
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If


    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Sub New(filePath As String)
        InitializeComponent()
        Me.filePath = filePath
        Dim Info = dirManipulator.readFile(filePath)

        titleTextBox.Text = Info(0)
        creationDate = Info(1)
        descriptionTextBox.Text = Info(2)
        categoryComboBox.DropDownStyle = ComboBoxStyle.DropDown
        categoryComboBox.Text = Info(3)
        categoryComboBox.DropDownStyle = ComboBoxStyle.DropDownList
        bodyTextBox.Text = Info(4)

    End Sub

End Class
