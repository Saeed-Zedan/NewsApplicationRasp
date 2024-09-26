<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImageEdit
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.titleTextBox = New System.Windows.Forms.TextBox()
        Me.descriptionTextBox = New System.Windows.Forms.TextBox()
        Me.bodyTextBox = New System.Windows.Forms.TextBox()
        Me.titleLabel = New System.Windows.Forms.Label()
        Me.descriptionLabel = New System.Windows.Forms.Label()
        Me.bodyLabel = New System.Windows.Forms.Label()
        Me.editImageTabControl = New System.Windows.Forms.TabControl()
        Me.fileDescriptionTabPage = New System.Windows.Forms.TabPage()
        Me.cancelButton = New System.Windows.Forms.Button()
        Me.editButton = New System.Windows.Forms.Button()
        Me.imageTabPage = New System.Windows.Forms.TabPage()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.imagePathTextBox = New System.Windows.Forms.TextBox()
        Me.browseButton = New System.Windows.Forms.Button()
        Me.editImageTabControl.SuspendLayout()
        Me.fileDescriptionTabPage.SuspendLayout()
        Me.imageTabPage.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'titleTextBox
        '
        Me.titleTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.titleTextBox.Location = New System.Drawing.Point(104, 13)
        Me.titleTextBox.MaxLength = 255
        Me.titleTextBox.Name = "titleTextBox"
        Me.titleTextBox.Size = New System.Drawing.Size(301, 20)
        Me.titleTextBox.TabIndex = 0
        '
        'descriptionTextBox
        '
        Me.descriptionTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.descriptionTextBox.Location = New System.Drawing.Point(104, 39)
        Me.descriptionTextBox.MaxLength = 255
        Me.descriptionTextBox.Name = "descriptionTextBox"
        Me.descriptionTextBox.Size = New System.Drawing.Size(301, 20)
        Me.descriptionTextBox.TabIndex = 1
        '
        'bodyTextBox
        '
        Me.bodyTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bodyTextBox.Location = New System.Drawing.Point(104, 65)
        Me.bodyTextBox.MaxLength = 10000
        Me.bodyTextBox.Multiline = True
        Me.bodyTextBox.Name = "bodyTextBox"
        Me.bodyTextBox.Size = New System.Drawing.Size(301, 267)
        Me.bodyTextBox.TabIndex = 2
        '
        'titleLabel
        '
        Me.titleLabel.AutoSize = True
        Me.titleLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.titleLabel.Location = New System.Drawing.Point(3, 16)
        Me.titleLabel.Name = "titleLabel"
        Me.titleLabel.Size = New System.Drawing.Size(40, 17)
        Me.titleLabel.TabIndex = 3
        Me.titleLabel.Text = "Title"
        '
        'descriptionLabel
        '
        Me.descriptionLabel.AutoSize = True
        Me.descriptionLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.descriptionLabel.Location = New System.Drawing.Point(3, 42)
        Me.descriptionLabel.Name = "descriptionLabel"
        Me.descriptionLabel.Size = New System.Drawing.Size(90, 17)
        Me.descriptionLabel.TabIndex = 4
        Me.descriptionLabel.Text = "Description"
        '
        'bodyLabel
        '
        Me.bodyLabel.AutoSize = True
        Me.bodyLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bodyLabel.Location = New System.Drawing.Point(3, 67)
        Me.bodyLabel.Name = "bodyLabel"
        Me.bodyLabel.Size = New System.Drawing.Size(44, 17)
        Me.bodyLabel.TabIndex = 5
        Me.bodyLabel.Text = "Body"
        '
        'editImageTabControl
        '
        Me.editImageTabControl.Controls.Add(Me.fileDescriptionTabPage)
        Me.editImageTabControl.Controls.Add(Me.imageTabPage)
        Me.editImageTabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.editImageTabControl.Location = New System.Drawing.Point(0, 0)
        Me.editImageTabControl.Name = "editImageTabControl"
        Me.editImageTabControl.SelectedIndex = 0
        Me.editImageTabControl.Size = New System.Drawing.Size(421, 395)
        Me.editImageTabControl.TabIndex = 6
        '
        'fileDescriptionTabPage
        '
        Me.fileDescriptionTabPage.Controls.Add(Me.cancelButton)
        Me.fileDescriptionTabPage.Controls.Add(Me.editButton)
        Me.fileDescriptionTabPage.Controls.Add(Me.titleTextBox)
        Me.fileDescriptionTabPage.Controls.Add(Me.bodyLabel)
        Me.fileDescriptionTabPage.Controls.Add(Me.descriptionTextBox)
        Me.fileDescriptionTabPage.Controls.Add(Me.descriptionLabel)
        Me.fileDescriptionTabPage.Controls.Add(Me.bodyTextBox)
        Me.fileDescriptionTabPage.Controls.Add(Me.titleLabel)
        Me.fileDescriptionTabPage.Location = New System.Drawing.Point(4, 22)
        Me.fileDescriptionTabPage.Name = "fileDescriptionTabPage"
        Me.fileDescriptionTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.fileDescriptionTabPage.Size = New System.Drawing.Size(413, 369)
        Me.fileDescriptionTabPage.TabIndex = 0
        Me.fileDescriptionTabPage.Text = "File Description"
        Me.fileDescriptionTabPage.UseVisualStyleBackColor = True
        '
        'cancelButton
        '
        Me.cancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cancelButton.Location = New System.Drawing.Point(330, 338)
        Me.cancelButton.Name = "cancelButton"
        Me.cancelButton.Size = New System.Drawing.Size(75, 23)
        Me.cancelButton.TabIndex = 7
        Me.cancelButton.Text = "Cancel"
        Me.cancelButton.UseVisualStyleBackColor = True
        '
        'editButton
        '
        Me.editButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.editButton.Location = New System.Drawing.Point(249, 338)
        Me.editButton.Name = "editButton"
        Me.editButton.Size = New System.Drawing.Size(75, 23)
        Me.editButton.TabIndex = 6
        Me.editButton.Text = "Edit"
        Me.editButton.UseVisualStyleBackColor = True
        '
        'imageTabPage
        '
        Me.imageTabPage.Controls.Add(Me.PictureBox1)
        Me.imageTabPage.Controls.Add(Me.imagePathTextBox)
        Me.imageTabPage.Controls.Add(Me.browseButton)
        Me.imageTabPage.Location = New System.Drawing.Point(4, 22)
        Me.imageTabPage.Name = "imageTabPage"
        Me.imageTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.imageTabPage.Size = New System.Drawing.Size(413, 369)
        Me.imageTabPage.TabIndex = 1
        Me.imageTabPage.Text = "Image"
        Me.imageTabPage.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Location = New System.Drawing.Point(8, 32)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(397, 329)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'imagePathTextBox
        '
        Me.imagePathTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.imagePathTextBox.Location = New System.Drawing.Point(89, 6)
        Me.imagePathTextBox.Name = "imagePathTextBox"
        Me.imagePathTextBox.ReadOnly = True
        Me.imagePathTextBox.Size = New System.Drawing.Size(316, 20)
        Me.imagePathTextBox.TabIndex = 1
        '
        'browseButton
        '
        Me.browseButton.Location = New System.Drawing.Point(8, 6)
        Me.browseButton.Name = "browseButton"
        Me.browseButton.Size = New System.Drawing.Size(75, 20)
        Me.browseButton.TabIndex = 0
        Me.browseButton.Text = "Browse"
        Me.browseButton.UseVisualStyleBackColor = True
        '
        'ImageEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(421, 395)
        Me.Controls.Add(Me.editImageTabControl)
        Me.Name = "ImageEdit"
        Me.Text = "Edit Image"
        Me.editImageTabControl.ResumeLayout(False)
        Me.fileDescriptionTabPage.ResumeLayout(False)
        Me.fileDescriptionTabPage.PerformLayout()
        Me.imageTabPage.ResumeLayout(False)
        Me.imageTabPage.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents titleTextBox As TextBox
    Friend WithEvents descriptionTextBox As TextBox
    Friend WithEvents bodyTextBox As TextBox
    Friend WithEvents titleLabel As Label
    Friend WithEvents descriptionLabel As Label
    Friend WithEvents bodyLabel As Label
    Friend WithEvents editImageTabControl As TabControl
    Friend WithEvents fileDescriptionTabPage As TabPage
    Friend WithEvents imageTabPage As TabPage
    Friend WithEvents cancelButton As Button
    Friend WithEvents editButton As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents imagePathTextBox As TextBox
    Friend WithEvents browseButton As Button
End Class
