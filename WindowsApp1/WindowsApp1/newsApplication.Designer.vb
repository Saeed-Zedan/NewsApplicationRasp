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
        Me.MenuStrip1.SuspendLayout()
        CType(Me.newsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.displayTabControl.SuspendLayout()
        Me.previewTabPage.SuspendLayout()
        Me.imageTabPage.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ToolsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(800, 24)
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
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
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
        Me.toolStripSeparator2.Size = New System.Drawing.Size(177, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
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
        Me.logoutToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.logoutToolStripMenuItem.Text = "&Logout"
        '
        'CurrentUserToolStripMenuItem
        '
        Me.CurrentUserToolStripMenuItem.Name = "CurrentUserToolStripMenuItem"
        Me.CurrentUserToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
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
        Me.newsDataGridView.Location = New System.Drawing.Point(0, 3)
        Me.newsDataGridView.Name = "newsDataGridView"
        Me.newsDataGridView.ReadOnly = True
        Me.newsDataGridView.RowHeadersVisible = False
        Me.newsDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader
        Me.newsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.newsDataGridView.Size = New System.Drawing.Size(800, 138)
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
        Me.displayTabControl.Location = New System.Drawing.Point(0, 261)
        Me.displayTabControl.Name = "displayTabControl"
        Me.displayTabControl.SelectedIndex = 0
        Me.displayTabControl.Size = New System.Drawing.Size(800, 189)
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
        Me.previewTabPage.Size = New System.Drawing.Size(792, 163)
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
        Me.bodyTextBox.Size = New System.Drawing.Size(782, 153)
        Me.bodyTextBox.TabIndex = 0
        '
        'imageTabPage
        '
        Me.imageTabPage.Controls.Add(Me.PictureBox1)
        Me.imageTabPage.Location = New System.Drawing.Point(4, 22)
        Me.imageTabPage.Name = "imageTabPage"
        Me.imageTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.imageTabPage.Size = New System.Drawing.Size(792, 163)
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
        Me.titleLabel.Location = New System.Drawing.Point(12, 150)
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
        Me.creationDateLabel.Location = New System.Drawing.Point(12, 181)
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
        Me.categoryLabel.Location = New System.Drawing.Point(9, 211)
        Me.categoryLabel.Name = "categoryLabel"
        Me.categoryLabel.Size = New System.Drawing.Size(73, 17)
        Me.categoryLabel.TabIndex = 4
        Me.categoryLabel.Text = "Category"
        '
        'titleTextBox
        '
        Me.titleTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.titleTextBox.Location = New System.Drawing.Point(139, 147)
        Me.titleTextBox.Name = "titleTextBox"
        Me.titleTextBox.ReadOnly = True
        Me.titleTextBox.Size = New System.Drawing.Size(649, 20)
        Me.titleTextBox.TabIndex = 5
        '
        'creationDateTextBox
        '
        Me.creationDateTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.creationDateTextBox.Location = New System.Drawing.Point(139, 178)
        Me.creationDateTextBox.Name = "creationDateTextBox"
        Me.creationDateTextBox.ReadOnly = True
        Me.creationDateTextBox.Size = New System.Drawing.Size(649, 20)
        Me.creationDateTextBox.TabIndex = 6
        '
        'categoryTextBox
        '
        Me.categoryTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.categoryTextBox.Location = New System.Drawing.Point(139, 208)
        Me.categoryTextBox.Name = "categoryTextBox"
        Me.categoryTextBox.ReadOnly = True
        Me.categoryTextBox.Size = New System.Drawing.Size(649, 20)
        Me.categoryTextBox.TabIndex = 7
        '
        'Splitter1
        '
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Splitter1.Location = New System.Drawing.Point(0, 258)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(800, 3)
        Me.Splitter1.TabIndex = 8
        Me.Splitter1.TabStop = False
        '
        'GroupBox1
        '
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
        Me.GroupBox1.Size = New System.Drawing.Size(800, 234)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'newsApplication
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
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
End Class
