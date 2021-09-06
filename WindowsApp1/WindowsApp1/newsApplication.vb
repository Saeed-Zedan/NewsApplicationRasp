Imports System.IO
Imports WindowsApp1
Imports 
Public Class newsApplication
    Private currentUser As String = String.Empty
    Private userPriv As Boolean
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        Using newForm = New LoginScreen()
            If newForm.ShowDialog = DialogResult.OK Then
                currentUser = newForm.UserName
                userPriv = newForm.Priv
                MessageBox.Show($"Welcome {currentUser}")
            Else
                Me.Dispose()
            End If
        End Using
    End Sub
    Private Sub AddingRows(Rows As List(Of String))

        Try
            For Each Row In Rows
                Dim rowInfo = Strings.Split(Row, "^_^")
                newsDataGridView.Rows.Add({rowInfo(2), rowInfo(1), rowInfo(6), rowInfo(0)}) 'adding a new row to the grid (Title, Creation date, description
            Next
        Catch ex As IOException
            MessageBox.Show("Process failed", "IO ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub AddingRow(name As String, creationDate As DateTime, description As String, ID As Integer)
        Try
            newsDataGridView.Rows.Add({name, creationDate.ToString(), description, ID}) 'adding a new row to the grid (Title, Creation date, description
        Catch ex As IOException
            MessageBox.Show("Process failed", "IO ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        AddingRows((New FileWorksObject.FileQuery()).Run())
        'AddingRows((New ))
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        EmptyFields()

        Dim rows = newsDataGridView.SelectedRows
        Dim files As List(Of String) = New List(Of String)

        If rows.Count = 0 Then 'no selected file
            MessageBox.Show("There is no selected file/s", "Duck", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim query As FileWorksObject.BusinessQuery

        For Each item As DataGridViewRow In rows
            Dim id = Convert.ToInt32(item.Cells(3).Value)
            Dim name = item.Cells(0).Value
            Dim result = MessageBox.Show("Aru u sure u want to delete the user : " & name, "Warning msg", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result = DialogResult.Yes Then
                query = New FileWorksObject.BusinessQuery()
                query.mID.ColumnValue = id
                Dim queryResult = query.Run()
                Dim tagged As Integer
                Dim allInfo As String()

                If queryResult.Count = 1 Then
                    allInfo = Strings.Split(queryResult(0), "^_^")
                    tagged = Convert.ToInt32(allInfo(3))
                Else
                    MessageBox.Show("Item Doesn't Exist")
                    Exit Sub
                End If

                If tagged = 4 Then

                    Dim newOb As FileWorksObject.Photo = New FileWorksObject.Photo With {.ID = allInfo(0)}
                    If newOb.Read() Then
                        If newOb.Delete() Then
                            newsDataGridView.Rows.Remove(item)
                        End If
                    End If

                ElseIf tagged = 3 Then

                    Dim newOb As FileWorksObject.BusinessObject = New FileWorksObject.BusinessObject With {.ID = allInfo(0)}
                    If newOb.Read() Then
                        If newOb.Delete() Then
                            newsDataGridView.Rows.Remove(item)
                        End If
                    End If

                End If

            End If
        Next
    End Sub

    Private Sub UserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserToolStripMenuItem.Click
        Dim userForm As UserAdd = New UserAdd(currentUser, userPriv)
        userForm.ShowDialog()
    End Sub

    Private Sub NewsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewsToolStripMenuItem.Click

        Using newForm = New NewsAdd(currentUser)
            If newForm.ShowDialog() = DialogResult.OK Then
                AddingRow(newForm.newsOb.Name, newForm.newsOb.CreationDate, newForm.newsOb.Description, newForm.newsOb.ID)
                MessageBox.Show("Done SUCCESSFULLY")
            End If
        End Using

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Dispose()
    End Sub

    Private Sub DisplayUsersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles displayUsersToolStripMenuItem.Click
        Dim newForm As UsersView = New UsersView(currentUser, userPriv)
        newForm.ShowDialog()
        currentUser = newForm.curUser
    End Sub
    Private Sub NewsDataGridView_DoubleClick(sender As Object, e As EventArgs) Handles newsDataGridView.DoubleClick
        EmptyFields()
        Dim selectedNews = newsDataGridView.SelectedRows

        If selectedNews.Count = 1 Then
            Dim row = selectedNews(0)
            Dim fileOb As FileWorksObject.File = New FileWorksObject.File()
            fileOb.ID = Convert.ToInt32(row.Cells(3).Value)
            Dim tagged As Integer
            If fileOb.Read() Then
                tagged = fileOb.ClassID
            Else
                tagged = 0
            End If


            If tagged = 3 Then
                Using newForm = New NewsEdit(currentUser, fileOb.Name, fileOb.ID)
                    If newForm.ShowDialog() = DialogResult.OK Then
                        newsDataGridView.Rows.Remove(row)
                        newsDataGridView.Rows.Add({newForm.newsOB.Name, newForm.newsOB.CreationDate.ToString(), newForm.newsOB.Description, newForm.newsOB.ID})
                        MessageBox.Show("IT'S DONE")
                    End If
                End Using

            ElseIf tagged = 4 Then
                If PictureBox1.Image IsNot Nothing Then
                    MessageBox.Show("HEre is the problem")
                End If

                Using newForm = New ImageEdit(currentUser, fileOb.Name, fileOb.ID)
                    If newForm.ShowDialog() = DialogResult.OK Then
                        newsDataGridView.Rows.Remove(row)
                        newsDataGridView.Rows.Add({newForm.newOb.Name, newForm.newOb.CreationDate.ToString(), newForm.newOb.Description, newForm.newOb.ID})
                        'addingRow(newForm., imageDict)
                    End If
                End Using

            ElseIf tagged = -1 Then
                MessageBox.Show("Couldn't Access DB")
            ElseIf tagged = 0 Then
                MessageBox.Show("No Match In DB")
            End If
        End If

    End Sub
    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        displayTabControl.Height = Me.Height \ 3
    End Sub
    Private Sub NewsDataGridView_SelectionChanged(sender As Object, e As EventArgs) Handles newsDataGridView.SelectionChanged
        EmptyFields()

        Dim row = newsDataGridView.SelectedRows
        If row.Count > 0 Then
            displayNewsData(row(0))
        End If

    End Sub

    Private Sub ImageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImageToolStripMenuItem.Click
        Using newForm = New ImageAdd(currentUser)
            If newForm.ShowDialog() = DialogResult.OK Then
                addingRow(newForm.newOb.Name, newForm.newOb.CreationDate.ToString(), newForm.newOb.Description, newForm.newOb.ID)
            Else
                MessageBox.Show("Not completed.")
            End If
        End Using
    End Sub

    Private Sub EmptyFields()
        titleTextBox.Text = String.Empty
        bodyTextBox.Text = String.Empty
        categoryTextBox.Text = String.Empty
        creationDateTextBox.Text = String.Empty
        If PictureBox1.Image IsNot Nothing Then
            PictureBox1.Image.Dispose()
        End If
        PictureBox1.Image = Nothing

    End Sub

    Private Sub NewsDataGridView_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles newsDataGridView.RowsAdded
        Dim row = newsDataGridView.Rows(0)
        displayNewsData(row)
    End Sub

    Private Sub DisplayNewsData(row As DataGridViewRow)
        EmptyFields()

        Dim newob As FileWorksObject.File = New FileWorksObject.File()
        newob.ID = Convert.ToInt32(row.Cells(3).Value)
        Dim tagged As Integer
        If newob.Read() Then
            tagged = newob.ClassID
        End If

        If tagged = 3 Then
            categoryLabel.Enabled = True
            categoryTextBox.Enabled = True
            categoryLabel.Visible = True
            categoryTextBox.Visible = True

            Dim displayOb As FileWorksObject.News = New FileWorksObject.News()
            displayOb.Name = newob.Name
            displayOb.ID = newob.ID
            displayOb.Read()
            titleTextBox.Text = displayOb.Name
            creationDateTextBox.Text = displayOb.CreationDate.ToString
            categoryTextBox.Text = displayOb.Category
            bodyTextBox.Text = displayOb.Body

        ElseIf tagged = 4 Then
            categoryLabel.Enabled = False
            categoryTextBox.Enabled = False
            categoryLabel.Visible = False
            categoryTextBox.Visible = False

            Dim displayOb As FileWorksObject.Photo = New FileWorksObject.Photo()
            displayOb.Name = newob.Name
            displayOb.ID = newob.ID
            displayOb.Read()
            titleTextBox.Text = displayOb.Name
            creationDateTextBox.Text = displayOb.CreationDate.ToString
            PictureBox1.Image = Image.FromFile(displayOb.PhotoPath)
            bodyTextBox.Text = displayOb.Body

        End If
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles logoutToolStripMenuItem.Click
        currentUser = String.Empty
        Me.Hide()

        Using newForm = New LoginScreen()
            If newForm.ShowDialog = DialogResult.OK Then
                currentUser = newForm.UserName
                userPriv = newForm.Priv
                MessageBox.Show($"Welcome {currentUser}")
                Me.Show()
            Else
                Me.Dispose()
            End If
        End Using

    End Sub
    Private Sub CurrentUserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CurrentUserToolStripMenuItem.Click
        MessageBox.Show(currentUser)
    End Sub

    Private Sub IDConditionComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles IDConditionComboBox.SelectedIndexChanged
        If IDConditionComboBox.SelectedItem = "Between" Then
            IDSearchTextBox2.Enabled = True
        ElseIf IDSearchTextBox2.Enabled Then
            IDSearchTextBox2.Enabled = False
            IDSearchTextBox2.Clear()
        End If
    End Sub

    Private Sub IDFilterCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles IDFilterCheckBox.CheckedChanged
        If Not IDFilterCheckBox.Checked Then
            IDSearchTextBox.Enabled = False
            IDConditionComboBox.Enabled = False
            IDSearchTextBox2.Enabled = False
        Else
            IDSearchTextBox.Enabled = True
            IDConditionComboBox.Enabled = True
            If IDConditionComboBox.SelectedItem = "Between" Then
                IDSearchTextBox2.Enabled = True
            End If
        End If
    End Sub

    Private Sub CreationDateConditionComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CreationDateConditionComboBox.SelectedIndexChanged
        If CreationDateConditionComboBox.SelectedItem = "Between" Then
            DateTimePickerSearch2.Enabled = True
        ElseIf DateTimePickerSearch2.Enabled Then
            DateTimePickerSearch2.Enabled = False
            DateTimePickerSearch2.ResetText()
        End If
    End Sub

    Private Sub CreationDateFilterCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles CreationDateFilterCheckBox.CheckedChanged
        If Not CreationDateFilterCheckBox.Checked Then
            DateTimePickerSearch.Enabled = False
            CreationDateConditionComboBox.Enabled = False
            DateTimePickerSearch2.Enabled = False
        Else
            DateTimePickerSearch.Enabled = True
            CreationDateConditionComboBox.Enabled = True
            If CreationDateConditionComboBox.SelectedItem = "Between" Then
                DateTimePickerSearch2.Enabled = True
            End If
        End If
    End Sub

    Private Sub TitleFilterCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles TitleFilterCheckBox.CheckedChanged
        If Not TitleFilterCheckBox.Checked Then
            TitleSearchTextBox.Enabled = False
            TitleConditionComboBox.Enabled = False
        Else
            TitleSearchTextBox.Enabled = True
            TitleConditionComboBox.Enabled = True
        End If
    End Sub

    Private Sub DescriptionFilterCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles DescriptionFilterCheckBox.CheckedChanged
        If Not DescriptionFilterCheckBox.Checked Then
            DescriptionSearchTextBox.Enabled = False
            DescriptionConditionComboBox.Enabled = False
        Else
            DescriptionSearchTextBox.Enabled = True
            DescriptionConditionComboBox.Enabled = True
        End If
    End Sub

    Private Sub ClassIDSearchComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ClassIDSearchComboBox.SelectedIndexChanged
        If ClassIDSearchComboBox.SelectedItem = "News" Then
            CategoryFilterCheckBox.Enabled = True
            CategoryFilterCheckBox.Checked = False
        Else
            CategoryFilterCheckBox.Checked = False
            CategoryFilterCheckBox.Enabled = False
        End If
    End Sub

    Private Sub ClassIDFilterCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles ClassIDFilterCheckBox.CheckedChanged
        If Not ClassIDFilterCheckBox.Checked Then
            ClassIDSearchComboBox.Enabled = False
            CategoryFilterCheckBox.Checked = False
            CategoryFilterCheckBox.Enabled = False
        Else
            ClassIDSearchComboBox.Enabled = True

            If ClassIDSearchComboBox.SelectedItem = "News" Then
                CategoryFilterCheckBox.Enabled = True
            End If

        End If

    End Sub

    Private Sub CategoryFilterCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles CategoryFilterCheckBox.CheckedChanged
        If Not CategoryFilterCheckBox.Checked Then
            CategorySearchComboBox.Enabled = False
        Else
            CategorySearchComboBox.Enabled = True
        End If
    End Sub

    Private Sub LastModifierFilterCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles LastModifierFilterCheckBox.CheckedChanged
        If Not LastModifierFilterCheckBox.Checked Then
            LastModifierConditionComboBox.Enabled = False
            LastModifierSearchTextBox.Enabled = False
        Else
            LastModifierConditionComboBox.Enabled = True
            LastModifierSearchTextBox.Enabled = True
        End If
    End Sub

    Private Sub BodyFilterCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles BodyFilterCheckBox.CheckedChanged
        If Not BodyFilterCheckBox.Checked Then
            BodyConditionComboBox.Enabled = False
            BodySearchTextBox.Enabled = False
        Else
            BodyConditionComboBox.Enabled = True
            BodySearchTextBox.Enabled = True
        End If
    End Sub

    Private Sub ResetButton_Click(sender As Object, e As EventArgs) Handles ResetButton.Click
        IDFilterCheckBox.Checked = False
        CreationDateFilterCheckBox.Checked = False
        TitleFilterCheckBox.Checked = False
        DescriptionFilterCheckBox.Checked = False
        ClassIDFilterCheckBox.Checked = False
        CategoryFilterCheckBox.Checked = False
        LastModifierFilterCheckBox.Checked = False
        BodyFilterCheckBox.Checked = False
    End Sub

    Private Sub SearchButton_Click(sender As Object, e As EventArgs) Handles SearchButton.Click
        newsDataGridView.Rows.Clear()

        Dim query As FileWorksObject.FileQuery = New FileWorksObject.FileQuery()

        If ClassIDFilterCheckBox.Checked Then
            If ClassIDSearchComboBox.SelectedItem = String.Empty Then
                MessageBox.Show("Please Fill File Type Filter Feilds")
                Exit Sub
            End If
            query.ClassID.ConditionType = 1

            Dim classID = ClassIDSearchComboBox.SelectedItem
            If classID = "All" Then

                query.ClassID.ConditionType = 0
            ElseIf classID = "News" Then
                query.ClassID.ConditionType = 1
                query.ClassID.ColumnValue = 3
            ElseIf classID = "Photo" Then
                query.ClassID.ColumnValue = 4
            End If


        End If

        If IDFilterCheckBox.Checked Then
            If IDSearchTextBox.Text = String.Empty Or IDConditionComboBox.SelectedItem = String.Empty Then
                MessageBox.Show("Please Fill The ID Filter Feilds")
                Exit Sub
            End If

            query.mID.ColumnValue = IDSearchTextBox.Text
            query.mID.ConditionType = SelectCondition(IDConditionComboBox.SelectedItem)

            If query.mID.ConditionType = 4 Then
                If IDSearchTextBox2.Text = String.Empty Then
                    MessageBox.Show("Please Fill The Second ID Value")
                    Exit Sub
                End If

                query.mID.ColumnValue2 = IDSearchTextBox2.Text
            End If

        End If

        If CreationDateFilterCheckBox.Checked Then
            query.CreationDate.ColumnValue = DateTimePickerSearch.Value
            query.CreationDate.ConditionType = SelectCondition(CreationDateConditionComboBox.SelectedItem)

            If query.CreationDate.ConditionType = 4 Then
                query.CreationDate.ColumnValue2 = DateTimePickerSearch2.Value
            End If

        End If

        If TitleFilterCheckBox.Checked Then

            If TitleSearchTextBox.Text = String.Empty Or TitleConditionComboBox.SelectedItem = String.Empty Then
                MessageBox.Show("Please Fill The Name-Title Filter Feilds")
                Exit Sub
            End If

            query.Name.ColumnValue = TitleSearchTextBox.Text
            query.Name.ConditionType = SelectCondition(TitleConditionComboBox.SelectedItem)
        End If

        If DescriptionFilterCheckBox.Checked Then
            If DescriptionSearchTextBox.Text = String.Empty Or DescriptionConditionComboBox.SelectedItem = String.Empty Then
                MessageBox.Show("Please Fill Name-Description Filter Feilds")
                Exit Sub
            End If

            query.Description.ColumnValue = DescriptionSearchTextBox.Text
            query.Description.ConditionType = SelectCondition(DescriptionConditionComboBox.SelectedItem)
        End If

        If LastModifierFilterCheckBox.Checked Then
            If LastModifierSearchTextBox.Text = String.Empty Or LastModifierConditionComboBox.SelectedItem = String.Empty Then
                MessageBox.Show("Please Fill Last Modifier Filter Feilds")
                Exit Sub
            End If

            query.LastModifier.ColumnValue = LastModifierSearchTextBox.Text
            query.LastModifier.ConditionType = SelectCondition(LastModifierConditionComboBox.SelectedItem)

        End If

        If BodyFilterCheckBox.Checked Then
            If BodySearchTextBox.Text = String.Empty Or BodyConditionComboBox.SelectedItem = String.Empty Then
                MessageBox.Show("Please Fill Last Modifier Filter Feilds")
                Exit Sub
            End If

            query.Body.ColumnValue = BodySearchTextBox.Text
            query.Body.ConditionType = SelectCondition(BodyConditionComboBox.SelectedItem)

        End If

        If CategoryFilterCheckBox.Checked Then

        End If

        Dim result = query.Run()

        If result IsNot Nothing AndAlso result.Count > 0 Then
            AddingRows(result)
        Else
            MessageBox.Show("There is no rows that match ur order")
        End If

    End Sub

    'Exactly
    'Start With
    'End With
    'Contain

    'After
    'Before
    'Between

    'Exactly
    'Greater
    'Smaller
    'Between
    Private Function SelectCondition(condition As String) As Integer
        Select Case condition
            Case "Exactly"
                Return 1
            Case "Start With", "After", "Greater"
                Return 2
            Case "End With", "Before", "Smaller"
                Return 3
            Case "Contain", "Between"
                Return 4
        End Select

        Return 0
    End Function
End Class