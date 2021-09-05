<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class newsApplication
    Inherits System.Windows.Forms.Form
    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(newsApplication))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.displayUsersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.logoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CurrentUserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.newsDataGridView = New System.Windows.Forms.DataGridView()
        Me.Title = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.creationDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.displayTabControl = New System.Windows.Forms.TabControl()
        Me.previewTabPage = New System.Windows.Forms.TabPage()
        Me.bodyTextBox = New System.Windows.Forms.TextBox()
        Me.imageTabPage = New System.Windows.Forms.TabPage()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.titleLabel = New System.Windows.Forms.Label()
        Me.creationDateLabel = New System.Windows.Forms.Label()
        Me.categoryLabel = New System.Windows.Forms.Label()
        Me.titleTextBox = New System.Windows.Forms.TextBox()
        Me.creationDateTextBox = New System.Windows.Forms.TextBox()
        Me.categoryTextBox = New System.Windows.Forms.TextBox()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.SearchTabControl = New System.Windows.Forms.TabControl()
        Me.IDTabPage = New System.Windows.Forms.TabPage()
        Me.IDFilterCheckBox = New System.Windows.Forms.CheckBox()
        Me.IDSearchTextBox2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.IDConditionComboBox = New System.Windows.Forms.ComboBox()
        Me.IDSearchTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CreationDateTabPage = New System.Windows.Forms.TabPage()
        Me.CreationDateFilterCheckBox = New System.Windows.Forms.CheckBox()
        Me.DateTimePickerSearch2 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePickerSearch = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CreationDateConditionComboBox = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.NameTabPage = New System.Windows.Forms.TabPage()
        Me.DescriptionFilterCheckBox = New System.Windows.Forms.CheckBox()
        Me.TitleFilterCheckBox = New System.Windows.Forms.CheckBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.DescriptionConditionComboBox = New System.Windows.Forms.ComboBox()
        Me.DescriptionSearchTextBox = New System.Windows.Forms.TextBox()
        Me.TitleConditionComboBox = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TitleSearchTextBox = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ClassIDTabPage = New System.Windows.Forms.TabPage()
        Me.LastModifierTabPage = New System.Windows.Forms.TabPage()
        Me.BodyTabPage = New System.Windows.Forms.TabPage()
        Me.BodyFilterCheckBox = New System.Windows.Forms.CheckBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.BodyConditionComboBox = New System.Windows.Forms.ComboBox()
        Me.BodySearchTextBox = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.CategoryFilterCheckBox = New System.Windows.Forms.CheckBox()
        Me.ClassIDFilterCheckBox = New System.Windows.Forms.CheckBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.CategorySearchComboBox = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ClassIDSearchComboBox = New System.Windows.Forms.ComboBox()
        Me.LastModifierFilterCheckBox = New System.Windows.Forms.CheckBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.LastModifierConditionComboBox = New System.Windows.Forms.ComboBox()
        Me.LastModifierSearchTextBox = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.SearchButton = New System.Windows.Forms.Button()
        Me.ResetButton = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.newsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.displayTabControl.SuspendLayout()
        Me.previewTabPage.SuspendLayout()
        Me.imageTabPage.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SearchTabControl.SuspendLayout()
        Me.IDTabPage.SuspendLayout()
        Me.CreationDateTabPage.SuspendLayout()
        Me.NameTabPage.SuspendLayout()
        Me.ClassIDTabPage.SuspendLayout()
        Me.LastModifierTabPage.SuspendLayout()
        Me.BodyTabPage.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ToolsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1008, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.toolStripSeparator2, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UserToolStripMenuItem, Me.NewsToolStripMenuItem, Me.ImageToolStripMenuItem})
        Me.NewToolStripMenuItem.Image = CType(resources.GetObject("NewToolStripMenuItem.Image"), System.Drawing.Image)
        Me.NewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(98, 22)
        Me.NewToolStripMenuItem.Text = "&New"
        '
        'UserToolStripMenuItem
        '
        Me.UserToolStripMenuItem.Name = "UserToolStripMenuItem"
        Me.UserToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.U), System.Windows.Forms.Keys)
        Me.UserToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.UserToolStripMenuItem.Text = "User"
        '
        'NewsToolStripMenuItem
        '
        Me.NewsToolStripMenuItem.Name = "NewsToolStripMenuItem"
        Me.NewsToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NewsToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.NewsToolStripMenuItem.Text = "News"
        '
        'ImageToolStripMenuItem
        '
        Me.ImageToolStripMenuItem.Name = "ImageToolStripMenuItem"
        Me.ImageToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.I), System.Windows.Forms.Keys)
        Me.ImageToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.ImageToolStripMenuItem.Text = "Image"
        '
        'toolStripSeparator2
        '
        Me.toolStripSeparator2.Name = "toolStripSeparator2"
        Me.toolStripSeparator2.Size = New System.Drawing.Size(95, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(98, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.displayUsersToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.EditToolStripMenuItem.Text = "Show"
        '
        'displayUsersToolStripMenuItem
        '
        Me.displayUsersToolStripMenuItem.Name = "displayUsersToolStripMenuItem"
        Me.displayUsersToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.displayUsersToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.displayUsersToolStripMenuItem.Text = "&Display Users"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.logoutToolStripMenuItem, Me.CurrentUserToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.ToolsToolStripMenuItem.Text = "Settings"
        '
        'logoutToolStripMenuItem
        '
        Me.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem"
        Me.logoutToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.logoutToolStripMenuItem.Text = "&Logout"
        '
        'CurrentUserToolStripMenuItem
        '
        Me.CurrentUserToolStripMenuItem.Name = "CurrentUserToolStripMenuItem"
        Me.CurrentUserToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.CurrentUserToolStripMenuItem.Text = "Current User"
        '
        'newsDataGridView
        '
        Me.newsDataGridView.AllowUserToAddRows = False
        Me.newsDataGridView.AllowUserToDeleteRows = False
        Me.newsDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.newsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.newsDataGridView.BackgroundColor = System.Drawing.SystemColors.Control
        Me.newsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.newsDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Title, Me.creationDate, Me.Description, Me.ID})
        Me.newsDataGridView.ContextMenuStrip = Me.ContextMenuStrip1
        Me.newsDataGridView.Location = New System.Drawing.Point(0, 121)
        Me.newsDataGridView.Name = "newsDataGridView"
        Me.newsDataGridView.ReadOnly = True
        Me.newsDataGridView.RowHeadersVisible = False
        Me.newsDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader
        Me.newsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.newsDataGridView.Size = New System.Drawing.Size(1008, 108)
        Me.newsDataGridView.TabIndex = 1
        '
        'Title
        '
        Me.Title.HeaderText = "Title"
        Me.Title.Name = "Title"
        Me.Title.ReadOnly = True
        '
        'creationDate
        '
        Me.creationDate.HeaderText = "Creation Date"
        Me.creationDate.Name = "creationDate"
        Me.creationDate.ReadOnly = True
        '
        'Description
        '
        Me.Description.HeaderText = "Description "
        Me.Description.Name = "Description"
        Me.Description.ReadOnly = True
        '
        'ID
        '
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(108, 26)
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'displayTabControl
        '
        Me.displayTabControl.Controls.Add(Me.previewTabPage)
        Me.displayTabControl.Controls.Add(Me.imageTabPage)
        Me.displayTabControl.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.displayTabControl.Location = New System.Drawing.Point(0, 349)
        Me.displayTabControl.Name = "displayTabControl"
        Me.displayTabControl.SelectedIndex = 0
        Me.displayTabControl.Size = New System.Drawing.Size(1008, 189)
        Me.displayTabControl.TabIndex = 4
        '
        'previewTabPage
        '
        Me.previewTabPage.BackColor = System.Drawing.Color.Transparent
        Me.previewTabPage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.previewTabPage.Controls.Add(Me.bodyTextBox)
        Me.previewTabPage.Location = New System.Drawing.Point(4, 22)
        Me.previewTabPage.Name = "previewTabPage"
        Me.previewTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.previewTabPage.Size = New System.Drawing.Size(1000, 163)
        Me.previewTabPage.TabIndex = 0
        Me.previewTabPage.Text = "Preview"
        '
        'bodyTextBox
        '
        Me.bodyTextBox.BackColor = System.Drawing.SystemColors.ControlLight
        Me.bodyTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.bodyTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bodyTextBox.Location = New System.Drawing.Point(3, 3)
        Me.bodyTextBox.Multiline = True
        Me.bodyTextBox.Name = "bodyTextBox"
        Me.bodyTextBox.ReadOnly = True
        Me.bodyTextBox.Size = New System.Drawing.Size(990, 153)
        Me.bodyTextBox.TabIndex = 0
        '
        'imageTabPage
        '
        Me.imageTabPage.Controls.Add(Me.PictureBox1)
        Me.imageTabPage.Location = New System.Drawing.Point(4, 22)
        Me.imageTabPage.Name = "imageTabPage"
        Me.imageTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.imageTabPage.Size = New System.Drawing.Size(1000, 163)
        Me.imageTabPage.TabIndex = 1
        Me.imageTabPage.Text = "Image"
        Me.imageTabPage.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Location = New System.Drawing.Point(6, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(783, 145)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'titleLabel
        '
        Me.titleLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.titleLabel.AutoSize = True
        Me.titleLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.titleLabel.Location = New System.Drawing.Point(12, 238)
        Me.titleLabel.Name = "titleLabel"
        Me.titleLabel.Size = New System.Drawing.Size(40, 17)
        Me.titleLabel.TabIndex = 2
        Me.titleLabel.Text = "Title"
        '
        'creationDateLabel
        '
        Me.creationDateLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.creationDateLabel.AutoSize = True
        Me.creationDateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.creationDateLabel.Location = New System.Drawing.Point(12, 269)
        Me.creationDateLabel.Name = "creationDateLabel"
        Me.creationDateLabel.Size = New System.Drawing.Size(108, 17)
        Me.creationDateLabel.TabIndex = 3
        Me.creationDateLabel.Text = "Creation Date"
        '
        'categoryLabel
        '
        Me.categoryLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.categoryLabel.AutoSize = True
        Me.categoryLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.categoryLabel.Location = New System.Drawing.Point(9, 299)
        Me.categoryLabel.Name = "categoryLabel"
        Me.categoryLabel.Size = New System.Drawing.Size(73, 17)
        Me.categoryLabel.TabIndex = 4
        Me.categoryLabel.Text = "Category"
        '
        'titleTextBox
        '
        Me.titleTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.titleTextBox.Location = New System.Drawing.Point(139, 235)
        Me.titleTextBox.Name = "titleTextBox"
        Me.titleTextBox.ReadOnly = True
        Me.titleTextBox.Size = New System.Drawing.Size(857, 20)
        Me.titleTextBox.TabIndex = 5
        '
        'creationDateTextBox
        '
        Me.creationDateTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.creationDateTextBox.Location = New System.Drawing.Point(139, 266)
        Me.creationDateTextBox.Name = "creationDateTextBox"
        Me.creationDateTextBox.ReadOnly = True
        Me.creationDateTextBox.Size = New System.Drawing.Size(857, 20)
        Me.creationDateTextBox.TabIndex = 6
        '
        'categoryTextBox
        '
        Me.categoryTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.categoryTextBox.Location = New System.Drawing.Point(139, 296)
        Me.categoryTextBox.Name = "categoryTextBox"
        Me.categoryTextBox.ReadOnly = True
        Me.categoryTextBox.Size = New System.Drawing.Size(857, 20)
        Me.categoryTextBox.TabIndex = 7
        '
        'Splitter1
        '
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Splitter1.Location = New System.Drawing.Point(0, 346)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(1008, 3)
        Me.Splitter1.TabIndex = 8
        Me.Splitter1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ResetButton)
        Me.GroupBox1.Controls.Add(Me.SearchButton)
        Me.GroupBox1.Controls.Add(Me.SearchTabControl)
        Me.GroupBox1.Controls.Add(Me.titleLabel)
        Me.GroupBox1.Controls.Add(Me.creationDateLabel)
        Me.GroupBox1.Controls.Add(Me.categoryLabel)
        Me.GroupBox1.Controls.Add(Me.categoryTextBox)
        Me.GroupBox1.Controls.Add(Me.titleTextBox)
        Me.GroupBox1.Controls.Add(Me.newsDataGridView)
        Me.GroupBox1.Controls.Add(Me.creationDateTextBox)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 24)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1008, 322)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'SearchTabControl
        '
        Me.SearchTabControl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SearchTabControl.Controls.Add(Me.IDTabPage)
        Me.SearchTabControl.Controls.Add(Me.CreationDateTabPage)
        Me.SearchTabControl.Controls.Add(Me.NameTabPage)
        Me.SearchTabControl.Controls.Add(Me.ClassIDTabPage)
        Me.SearchTabControl.Controls.Add(Me.LastModifierTabPage)
        Me.SearchTabControl.Controls.Add(Me.BodyTabPage)
        Me.SearchTabControl.Location = New System.Drawing.Point(0, 3)
        Me.SearchTabControl.Name = "SearchTabControl"
        Me.SearchTabControl.SelectedIndex = 0
        Me.SearchTabControl.Size = New System.Drawing.Size(915, 112)
        Me.SearchTabControl.TabIndex = 8
        '
        'IDTabPage
        '
        Me.IDTabPage.Controls.Add(Me.IDFilterCheckBox)
        Me.IDTabPage.Controls.Add(Me.IDSearchTextBox2)
        Me.IDTabPage.Controls.Add(Me.Label3)
        Me.IDTabPage.Controls.Add(Me.Label2)
        Me.IDTabPage.Controls.Add(Me.IDConditionComboBox)
        Me.IDTabPage.Controls.Add(Me.IDSearchTextBox)
        Me.IDTabPage.Controls.Add(Me.Label1)
        Me.IDTabPage.Location = New System.Drawing.Point(4, 22)
        Me.IDTabPage.Name = "IDTabPage"
        Me.IDTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.IDTabPage.Size = New System.Drawing.Size(907, 86)
        Me.IDTabPage.TabIndex = 0
        Me.IDTabPage.Text = "ID Filter"
        Me.IDTabPage.UseVisualStyleBackColor = True
        '
        'IDFilterCheckBox
        '
        Me.IDFilterCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.IDFilterCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IDFilterCheckBox.Location = New System.Drawing.Point(6, 64)
        Me.IDFilterCheckBox.Name = "IDFilterCheckBox"
        Me.IDFilterCheckBox.Size = New System.Drawing.Size(147, 24)
        Me.IDFilterCheckBox.TabIndex = 6
        Me.IDFilterCheckBox.Text = "Enable Filter"
        Me.IDFilterCheckBox.UseVisualStyleBackColor = True
        '
        'IDSearchTextBox2
        '
        Me.IDSearchTextBox2.Enabled = False
        Me.IDSearchTextBox2.Location = New System.Drawing.Point(494, 37)
        Me.IDSearchTextBox2.Name = "IDSearchTextBox2"
        Me.IDSearchTextBox2.Size = New System.Drawing.Size(208, 20)
        Me.IDSearchTextBox2.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(364, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(128, 17)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Second ID Value"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(117, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Condition Type"
        '
        'IDConditionComboBox
        '
        Me.IDConditionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.IDConditionComboBox.Enabled = False
        Me.IDConditionComboBox.FormattingEnabled = True
        Me.IDConditionComboBox.Items.AddRange(New Object() {"Exactly", "Greater", "Smaller", "Between"})
        Me.IDConditionComboBox.Location = New System.Drawing.Point(139, 36)
        Me.IDConditionComboBox.Name = "IDConditionComboBox"
        Me.IDConditionComboBox.Size = New System.Drawing.Size(208, 21)
        Me.IDConditionComboBox.TabIndex = 2
        '
        'IDSearchTextBox
        '
        Me.IDSearchTextBox.Enabled = False
        Me.IDSearchTextBox.Location = New System.Drawing.Point(139, 6)
        Me.IDSearchTextBox.Name = "IDSearchTextBox"
        Me.IDSearchTextBox.Size = New System.Drawing.Size(208, 20)
        Me.IDSearchTextBox.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ID Value"
        '
        'CreationDateTabPage
        '
        Me.CreationDateTabPage.Controls.Add(Me.CreationDateFilterCheckBox)
        Me.CreationDateTabPage.Controls.Add(Me.DateTimePickerSearch2)
        Me.CreationDateTabPage.Controls.Add(Me.DateTimePickerSearch)
        Me.CreationDateTabPage.Controls.Add(Me.Label4)
        Me.CreationDateTabPage.Controls.Add(Me.Label5)
        Me.CreationDateTabPage.Controls.Add(Me.CreationDateConditionComboBox)
        Me.CreationDateTabPage.Controls.Add(Me.Label6)
        Me.CreationDateTabPage.Location = New System.Drawing.Point(4, 22)
        Me.CreationDateTabPage.Name = "CreationDateTabPage"
        Me.CreationDateTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.CreationDateTabPage.Size = New System.Drawing.Size(907, 86)
        Me.CreationDateTabPage.TabIndex = 1
        Me.CreationDateTabPage.Text = "Creation Date Filter"
        Me.CreationDateTabPage.UseVisualStyleBackColor = True
        '
        'CreationDateFilterCheckBox
        '
        Me.CreationDateFilterCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CreationDateFilterCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CreationDateFilterCheckBox.Location = New System.Drawing.Point(2, 61)
        Me.CreationDateFilterCheckBox.Name = "CreationDateFilterCheckBox"
        Me.CreationDateFilterCheckBox.Size = New System.Drawing.Size(138, 24)
        Me.CreationDateFilterCheckBox.TabIndex = 13
        Me.CreationDateFilterCheckBox.Text = "Enable Filter"
        Me.CreationDateFilterCheckBox.UseVisualStyleBackColor = True
        '
        'DateTimePickerSearch2
        '
        Me.DateTimePickerSearch2.Enabled = False
        Me.DateTimePickerSearch2.Location = New System.Drawing.Point(445, 34)
        Me.DateTimePickerSearch2.Name = "DateTimePickerSearch2"
        Me.DateTimePickerSearch2.Size = New System.Drawing.Size(208, 20)
        Me.DateTimePickerSearch2.TabIndex = 12
        '
        'DateTimePickerSearch
        '
        Me.DateTimePickerSearch.Enabled = False
        Me.DateTimePickerSearch.Location = New System.Drawing.Point(126, 7)
        Me.DateTimePickerSearch.Name = "DateTimePickerSearch"
        Me.DateTimePickerSearch.Size = New System.Drawing.Size(208, 20)
        Me.DateTimePickerSearch.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(351, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 17)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Date Value"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(2, 37)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(117, 17)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Condition Type"
        '
        'CreationDateConditionComboBox
        '
        Me.CreationDateConditionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CreationDateConditionComboBox.Enabled = False
        Me.CreationDateConditionComboBox.FormattingEnabled = True
        Me.CreationDateConditionComboBox.Items.AddRange(New Object() {"Exactly", "After", "Before", "Between"})
        Me.CreationDateConditionComboBox.Location = New System.Drawing.Point(126, 33)
        Me.CreationDateConditionComboBox.Name = "CreationDateConditionComboBox"
        Me.CreationDateConditionComboBox.Size = New System.Drawing.Size(208, 21)
        Me.CreationDateConditionComboBox.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(2, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 17)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Date Value"
        '
        'NameTabPage
        '
        Me.NameTabPage.Controls.Add(Me.DescriptionFilterCheckBox)
        Me.NameTabPage.Controls.Add(Me.TitleFilterCheckBox)
        Me.NameTabPage.Controls.Add(Me.Label10)
        Me.NameTabPage.Controls.Add(Me.Label8)
        Me.NameTabPage.Controls.Add(Me.DescriptionConditionComboBox)
        Me.NameTabPage.Controls.Add(Me.DescriptionSearchTextBox)
        Me.NameTabPage.Controls.Add(Me.TitleConditionComboBox)
        Me.NameTabPage.Controls.Add(Me.Label7)
        Me.NameTabPage.Controls.Add(Me.TitleSearchTextBox)
        Me.NameTabPage.Controls.Add(Me.Label9)
        Me.NameTabPage.Location = New System.Drawing.Point(4, 22)
        Me.NameTabPage.Name = "NameTabPage"
        Me.NameTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.NameTabPage.Size = New System.Drawing.Size(907, 86)
        Me.NameTabPage.TabIndex = 2
        Me.NameTabPage.Text = "Name Filter"
        Me.NameTabPage.UseVisualStyleBackColor = True
        '
        'DescriptionFilterCheckBox
        '
        Me.DescriptionFilterCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.DescriptionFilterCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DescriptionFilterCheckBox.Location = New System.Drawing.Point(355, 60)
        Me.DescriptionFilterCheckBox.Name = "DescriptionFilterCheckBox"
        Me.DescriptionFilterCheckBox.Size = New System.Drawing.Size(149, 24)
        Me.DescriptionFilterCheckBox.TabIndex = 14
        Me.DescriptionFilterCheckBox.Text = "Enable Filter"
        Me.DescriptionFilterCheckBox.UseVisualStyleBackColor = True
        '
        'TitleFilterCheckBox
        '
        Me.TitleFilterCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.TitleFilterCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TitleFilterCheckBox.Location = New System.Drawing.Point(2, 60)
        Me.TitleFilterCheckBox.Name = "TitleFilterCheckBox"
        Me.TitleFilterCheckBox.Size = New System.Drawing.Size(149, 24)
        Me.TitleFilterCheckBox.TabIndex = 14
        Me.TitleFilterCheckBox.Text = "Enable Filter"
        Me.TitleFilterCheckBox.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(355, 37)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(117, 17)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Condition Type"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(2, 37)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(117, 17)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Condition Type"
        '
        'DescriptionConditionComboBox
        '
        Me.DescriptionConditionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DescriptionConditionComboBox.Enabled = False
        Me.DescriptionConditionComboBox.FormattingEnabled = True
        Me.DescriptionConditionComboBox.Items.AddRange(New Object() {"Exactly", "Start With", "End With", "Contain"})
        Me.DescriptionConditionComboBox.Location = New System.Drawing.Point(490, 33)
        Me.DescriptionConditionComboBox.Name = "DescriptionConditionComboBox"
        Me.DescriptionConditionComboBox.Size = New System.Drawing.Size(208, 21)
        Me.DescriptionConditionComboBox.TabIndex = 8
        '
        'DescriptionSearchTextBox
        '
        Me.DescriptionSearchTextBox.Enabled = False
        Me.DescriptionSearchTextBox.Location = New System.Drawing.Point(490, 6)
        Me.DescriptionSearchTextBox.Name = "DescriptionSearchTextBox"
        Me.DescriptionSearchTextBox.Size = New System.Drawing.Size(208, 20)
        Me.DescriptionSearchTextBox.TabIndex = 7
        '
        'TitleConditionComboBox
        '
        Me.TitleConditionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TitleConditionComboBox.Enabled = False
        Me.TitleConditionComboBox.FormattingEnabled = True
        Me.TitleConditionComboBox.Items.AddRange(New Object() {"Exactly", "Start With", "End With", "Contain"})
        Me.TitleConditionComboBox.Location = New System.Drawing.Point(137, 33)
        Me.TitleConditionComboBox.Name = "TitleConditionComboBox"
        Me.TitleConditionComboBox.Size = New System.Drawing.Size(208, 21)
        Me.TitleConditionComboBox.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(355, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(136, 17)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Description Value"
        '
        'TitleSearchTextBox
        '
        Me.TitleSearchTextBox.Enabled = False
        Me.TitleSearchTextBox.Location = New System.Drawing.Point(137, 6)
        Me.TitleSearchTextBox.Name = "TitleSearchTextBox"
        Me.TitleSearchTextBox.Size = New System.Drawing.Size(208, 20)
        Me.TitleSearchTextBox.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(2, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(86, 17)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Title Value"
        '
        'ClassIDTabPage
        '
        Me.ClassIDTabPage.Controls.Add(Me.ClassIDSearchComboBox)
        Me.ClassIDTabPage.Controls.Add(Me.CategoryFilterCheckBox)
        Me.ClassIDTabPage.Controls.Add(Me.ClassIDFilterCheckBox)
        Me.ClassIDTabPage.Controls.Add(Me.Label13)
        Me.ClassIDTabPage.Controls.Add(Me.CategorySearchComboBox)
        Me.ClassIDTabPage.Controls.Add(Me.Label14)
        Me.ClassIDTabPage.Location = New System.Drawing.Point(4, 22)
        Me.ClassIDTabPage.Name = "ClassIDTabPage"
        Me.ClassIDTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.ClassIDTabPage.Size = New System.Drawing.Size(907, 86)
        Me.ClassIDTabPage.TabIndex = 3
        Me.ClassIDTabPage.Text = "File Type Filter"
        Me.ClassIDTabPage.UseVisualStyleBackColor = True
        '
        'LastModifierTabPage
        '
        Me.LastModifierTabPage.Controls.Add(Me.LastModifierFilterCheckBox)
        Me.LastModifierTabPage.Controls.Add(Me.Label15)
        Me.LastModifierTabPage.Controls.Add(Me.LastModifierConditionComboBox)
        Me.LastModifierTabPage.Controls.Add(Me.LastModifierSearchTextBox)
        Me.LastModifierTabPage.Controls.Add(Me.Label16)
        Me.LastModifierTabPage.Location = New System.Drawing.Point(4, 22)
        Me.LastModifierTabPage.Name = "LastModifierTabPage"
        Me.LastModifierTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.LastModifierTabPage.Size = New System.Drawing.Size(907, 86)
        Me.LastModifierTabPage.TabIndex = 4
        Me.LastModifierTabPage.Text = "Last Modifier Filter"
        Me.LastModifierTabPage.UseVisualStyleBackColor = True
        '
        'BodyTabPage
        '
        Me.BodyTabPage.Controls.Add(Me.BodyFilterCheckBox)
        Me.BodyTabPage.Controls.Add(Me.Label11)
        Me.BodyTabPage.Controls.Add(Me.BodyConditionComboBox)
        Me.BodyTabPage.Controls.Add(Me.BodySearchTextBox)
        Me.BodyTabPage.Controls.Add(Me.Label12)
        Me.BodyTabPage.Location = New System.Drawing.Point(4, 22)
        Me.BodyTabPage.Name = "BodyTabPage"
        Me.BodyTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.BodyTabPage.Size = New System.Drawing.Size(907, 86)
        Me.BodyTabPage.TabIndex = 5
        Me.BodyTabPage.Text = "Body Filter"
        Me.BodyTabPage.UseVisualStyleBackColor = True
        '
        'BodyFilterCheckBox
        '
        Me.BodyFilterCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BodyFilterCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BodyFilterCheckBox.Location = New System.Drawing.Point(322, 30)
        Me.BodyFilterCheckBox.Name = "BodyFilterCheckBox"
        Me.BodyFilterCheckBox.Size = New System.Drawing.Size(149, 24)
        Me.BodyFilterCheckBox.TabIndex = 19
        Me.BodyFilterCheckBox.Text = "Enable Filter"
        Me.BodyFilterCheckBox.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(322, 7)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(117, 17)
        Me.Label11.TabIndex = 18
        Me.Label11.Text = "Condition Type"
        '
        'BodyConditionComboBox
        '
        Me.BodyConditionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.BodyConditionComboBox.Enabled = False
        Me.BodyConditionComboBox.FormattingEnabled = True
        Me.BodyConditionComboBox.Items.AddRange(New Object() {"Exactly", "Start With", "End With", "Contain"})
        Me.BodyConditionComboBox.Location = New System.Drawing.Point(457, 3)
        Me.BodyConditionComboBox.Name = "BodyConditionComboBox"
        Me.BodyConditionComboBox.Size = New System.Drawing.Size(208, 21)
        Me.BodyConditionComboBox.TabIndex = 17
        '
        'BodySearchTextBox
        '
        Me.BodySearchTextBox.Enabled = False
        Me.BodySearchTextBox.Location = New System.Drawing.Point(94, 4)
        Me.BodySearchTextBox.Multiline = True
        Me.BodySearchTextBox.Name = "BodySearchTextBox"
        Me.BodySearchTextBox.Size = New System.Drawing.Size(221, 76)
        Me.BodySearchTextBox.TabIndex = 16
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(2, 7)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(90, 17)
        Me.Label12.TabIndex = 15
        Me.Label12.Text = "Body Value"
        '
        'CategoryFilterCheckBox
        '
        Me.CategoryFilterCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CategoryFilterCheckBox.Enabled = False
        Me.CategoryFilterCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CategoryFilterCheckBox.Location = New System.Drawing.Point(353, 30)
        Me.CategoryFilterCheckBox.Name = "CategoryFilterCheckBox"
        Me.CategoryFilterCheckBox.Size = New System.Drawing.Size(135, 24)
        Me.CategoryFilterCheckBox.TabIndex = 19
        Me.CategoryFilterCheckBox.Text = "Enable Filter"
        Me.CategoryFilterCheckBox.UseVisualStyleBackColor = True
        '
        'ClassIDFilterCheckBox
        '
        Me.ClassIDFilterCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ClassIDFilterCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClassIDFilterCheckBox.Location = New System.Drawing.Point(3, 27)
        Me.ClassIDFilterCheckBox.Name = "ClassIDFilterCheckBox"
        Me.ClassIDFilterCheckBox.Size = New System.Drawing.Size(124, 24)
        Me.ClassIDFilterCheckBox.TabIndex = 20
        Me.ClassIDFilterCheckBox.Text = "Enable Filter"
        Me.ClassIDFilterCheckBox.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(355, 7)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(73, 17)
        Me.Label13.TabIndex = 18
        Me.Label13.Text = "Category"
        '
        'CategorySearchComboBox
        '
        Me.CategorySearchComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CategorySearchComboBox.Enabled = False
        Me.CategorySearchComboBox.FormattingEnabled = True
        Me.CategorySearchComboBox.Items.AddRange(New Object() {"Genera", "Health", "Politics", "Sports"})
        Me.CategorySearchComboBox.Location = New System.Drawing.Point(473, 3)
        Me.CategorySearchComboBox.Name = "CategorySearchComboBox"
        Me.CategorySearchComboBox.Size = New System.Drawing.Size(208, 21)
        Me.CategorySearchComboBox.TabIndex = 17
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(5, 7)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(75, 17)
        Me.Label14.TabIndex = 15
        Me.Label14.Text = "File Type"
        '
        'ClassIDSearchComboBox
        '
        Me.ClassIDSearchComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ClassIDSearchComboBox.Enabled = False
        Me.ClassIDSearchComboBox.FormattingEnabled = True
        Me.ClassIDSearchComboBox.Items.AddRange(New Object() {"All", "News", "Photo"})
        Me.ClassIDSearchComboBox.Location = New System.Drawing.Point(113, 3)
        Me.ClassIDSearchComboBox.Name = "ClassIDSearchComboBox"
        Me.ClassIDSearchComboBox.Size = New System.Drawing.Size(208, 21)
        Me.ClassIDSearchComboBox.TabIndex = 21
        '
        'LastModifierFilterCheckBox
        '
        Me.LastModifierFilterCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LastModifierFilterCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LastModifierFilterCheckBox.Location = New System.Drawing.Point(3, 58)
        Me.LastModifierFilterCheckBox.Name = "LastModifierFilterCheckBox"
        Me.LastModifierFilterCheckBox.Size = New System.Drawing.Size(149, 24)
        Me.LastModifierFilterCheckBox.TabIndex = 19
        Me.LastModifierFilterCheckBox.Text = "Enable Filter"
        Me.LastModifierFilterCheckBox.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(3, 35)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(117, 17)
        Me.Label15.TabIndex = 18
        Me.Label15.Text = "Condition Type"
        '
        'LastModifierConditionComboBox
        '
        Me.LastModifierConditionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.LastModifierConditionComboBox.Enabled = False
        Me.LastModifierConditionComboBox.FormattingEnabled = True
        Me.LastModifierConditionComboBox.Items.AddRange(New Object() {"Exactly", "Start With", "End With", "Contain"})
        Me.LastModifierConditionComboBox.Location = New System.Drawing.Point(138, 31)
        Me.LastModifierConditionComboBox.Name = "LastModifierConditionComboBox"
        Me.LastModifierConditionComboBox.Size = New System.Drawing.Size(208, 21)
        Me.LastModifierConditionComboBox.TabIndex = 17
        '
        'LastModifierSearchTextBox
        '
        Me.LastModifierSearchTextBox.Enabled = False
        Me.LastModifierSearchTextBox.Location = New System.Drawing.Point(138, 4)
        Me.LastModifierSearchTextBox.Name = "LastModifierSearchTextBox"
        Me.LastModifierSearchTextBox.Size = New System.Drawing.Size(208, 20)
        Me.LastModifierSearchTextBox.TabIndex = 16
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(3, 7)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(102, 17)
        Me.Label16.TabIndex = 15
        Me.Label16.Text = "Last Modifier"
        '
        'SearchButton
        '
        Me.SearchButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SearchButton.Location = New System.Drawing.Point(921, 56)
        Me.SearchButton.Name = "SearchButton"
        Me.SearchButton.Size = New System.Drawing.Size(75, 23)
        Me.SearchButton.TabIndex = 9
        Me.SearchButton.Text = "Search"
        Me.SearchButton.UseVisualStyleBackColor = True
        '
        'ResetButton
        '
        Me.ResetButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ResetButton.Location = New System.Drawing.Point(921, 85)
        Me.ResetButton.Name = "ResetButton"
        Me.ResetButton.Size = New System.Drawing.Size(75, 23)
        Me.ResetButton.TabIndex = 9
        Me.ResetButton.Text = "Reset Filters"
        Me.ResetButton.UseVisualStyleBackColor = True
        '
        'newsApplication
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 538)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.displayTabControl)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "newsApplication"
        Me.Text = "News Application"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.newsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.displayTabControl.ResumeLayout(False)
        Me.previewTabPage.ResumeLayout(False)
        Me.previewTabPage.PerformLayout()
        Me.imageTabPage.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.SearchTabControl.ResumeLayout(False)
        Me.IDTabPage.ResumeLayout(False)
        Me.IDTabPage.PerformLayout()
        Me.CreationDateTabPage.ResumeLayout(False)
        Me.CreationDateTabPage.PerformLayout()
        Me.NameTabPage.ResumeLayout(False)
        Me.NameTabPage.PerformLayout()
        Me.ClassIDTabPage.ResumeLayout(False)
        Me.ClassIDTabPage.PerformLayout()
        Me.LastModifierTabPage.ResumeLayout(False)
        Me.LastModifierTabPage.PerformLayout()
        Me.BodyTabPage.ResumeLayout(False)
        Me.BodyTabPage.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private newsDict As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Private userDict As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Private imageDict As Dictionary(Of String, String) = New Dictionary(Of String, String)

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents toolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents displayUsersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents logoutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents newsDataGridView As DataGridView
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UserToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NewsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents displayTabControl As TabControl
    Friend WithEvents previewTabPage As TabPage
    Friend WithEvents imageTabPage As TabPage
    Friend WithEvents bodyTextBox As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents CurrentUserToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents titleLabel As Label
    Friend WithEvents creationDateLabel As Label
    Friend WithEvents categoryLabel As Label
    Friend WithEvents titleTextBox As TextBox
    Friend WithEvents creationDateTextBox As TextBox
    Friend WithEvents categoryTextBox As TextBox
    Friend WithEvents Splitter1 As Splitter
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Title As DataGridViewTextBoxColumn
    Friend WithEvents creationDate As DataGridViewTextBoxColumn
    Friend WithEvents Description As DataGridViewTextBoxColumn
    Friend WithEvents ID As DataGridViewTextBoxColumn
    Friend WithEvents SearchTabControl As TabControl
    Friend WithEvents IDTabPage As TabPage
    Friend WithEvents IDFilterCheckBox As CheckBox
    Friend WithEvents IDSearchTextBox2 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents IDConditionComboBox As ComboBox
    Friend WithEvents IDSearchTextBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents CreationDateTabPage As TabPage
    Friend WithEvents CreationDateFilterCheckBox As CheckBox
    Friend WithEvents DateTimePickerSearch2 As DateTimePicker
    Friend WithEvents DateTimePickerSearch As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents CreationDateConditionComboBox As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents NameTabPage As TabPage
    Friend WithEvents DescriptionFilterCheckBox As CheckBox
    Friend WithEvents TitleFilterCheckBox As CheckBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents DescriptionConditionComboBox As ComboBox
    Friend WithEvents DescriptionSearchTextBox As TextBox
    Friend WithEvents TitleConditionComboBox As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TitleSearchTextBox As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents ClassIDTabPage As TabPage
    Friend WithEvents LastModifierTabPage As TabPage
    Friend WithEvents BodyTabPage As TabPage
    Friend WithEvents BodyFilterCheckBox As CheckBox
    Friend WithEvents Label11 As Label
    Friend WithEvents BodyConditionComboBox As ComboBox
    Friend WithEvents BodySearchTextBox As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents ResetButton As Button
    Friend WithEvents SearchButton As Button
    Friend WithEvents ClassIDSearchComboBox As ComboBox
    Friend WithEvents CategoryFilterCheckBox As CheckBox
    Friend WithEvents ClassIDFilterCheckBox As CheckBox
    Friend WithEvents Label13 As Label
    Friend WithEvents CategorySearchComboBox As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents LastModifierFilterCheckBox As CheckBox
    Friend WithEvents Label15 As Label
    Friend WithEvents LastModifierConditionComboBox As ComboBox
    Friend WithEvents LastModifierSearchTextBox As TextBox
    Friend WithEvents Label16 As Label
End Class
