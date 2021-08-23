<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ImageAdd
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
        Me.imageTabControl = New System.Windows.Forms.TabControl()
        Me.imageInfoTabPage = New System.Windows.Forms.TabPage()
        Me.cancelButton = New System.Windows.Forms.Button()
        Me.saveButton = New System.Windows.Forms.Button()
        Me.bodyTextBox = New System.Windows.Forms.TextBox()
        Me.descriptionTextBox = New System.Windows.Forms.TextBox()
        Me.titleTextBox = New System.Windows.Forms.TextBox()
        Me.bodyLabel = New System.Windows.Forms.Label()
        Me.descriptionLabel = New System.Windows.Forms.Label()
        Me.titleLabel = New System.Windows.Forms.Label()
        Me.imageTabPage = New System.Windows.Forms.TabPage()
        Me.imagePathTextBox = New System.Windows.Forms.TextBox()
        Me.browseButton = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.imageTabControl.SuspendLayout()
        Me.imageInfoTabPage.SuspendLayout()
        Me.imageTabPage.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'imageTabControl
        '
        Me.imageTabControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.imageTabControl.Controls.Add(Me.imageInfoTabPage)
        Me.imageTabControl.Controls.Add(Me.imageTabPage)
        Me.imageTabControl.Location = New System.Drawing.Point(1, 1)
        Me.imageTabControl.Name = "imageTabControl"
        Me.imageTabControl.SelectedIndex = 0
        Me.imageTabControl.Size = New System.Drawing.Size(437, 395)
        Me.imageTabControl.TabIndex = 0
        '
        'imageInfoTabPage
        '
        Me.imageInfoTabPage.Controls.Add(Me.cancelButton)
        Me.imageInfoTabPage.Controls.Add(Me.saveButton)
        Me.imageInfoTabPage.Controls.Add(Me.bodyTextBox)
        Me.imageInfoTabPage.Controls.Add(Me.descriptionTextBox)
        Me.imageInfoTabPage.Controls.Add(Me.titleTextBox)
        Me.imageInfoTabPage.Controls.Add(Me.bodyLabel)
        Me.imageInfoTabPage.Controls.Add(Me.descriptionLabel)
        Me.imageInfoTabPage.Controls.Add(Me.titleLabel)
        Me.imageInfoTabPage.Location = New System.Drawing.Point(4, 22)
        Me.imageInfoTabPage.Name = "imageInfoTabPage"
        Me.imageInfoTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.imageInfoTabPage.Size = New System.Drawing.Size(429, 369)
        Me.imageInfoTabPage.TabIndex = 0
        Me.imageInfoTabPage.Text = "File description"
        Me.imageInfoTabPage.UseVisualStyleBackColor = True
        '
        'cancelButton
        '
        Me.cancelButton.Location = New System.Drawing.Point(347, 338)
        Me.cancelButton.Name = "cancelButton"
        Me.cancelButton.Size = New System.Drawing.Size(75, 23)
        Me.cancelButton.TabIndex = 7
        Me.cancelButton.Text = "Cancel"
        Me.cancelButton.UseVisualStyleBackColor = True
        '
        'saveButton
        '
        Me.saveButton.Location = New System.Drawing.Point(266, 338)
        Me.saveButton.Name = "saveButton"
        Me.saveButton.Size = New System.Drawing.Size(75, 23)
        Me.saveButton.TabIndex = 6
        Me.saveButton.Text = "Save"
        Me.saveButton.UseVisualStyleBackColor = True
        '
        'bodyTextBox
        '
        Me.bodyTextBox.Location = New System.Drawing.Point(118, 99)
        Me.bodyTextBox.MaxLength = 10000
        Me.bodyTextBox.Multiline = True
        Me.bodyTextBox.Name = "bodyTextBox"
        Me.bodyTextBox.Size = New System.Drawing.Size(304, 233)
        Me.bodyTextBox.TabIndex = 5
        '
        'descriptionTextBox
        '
        Me.descriptionTextBox.Location = New System.Drawing.Point(118, 61)
        Me.descriptionTextBox.MaxLength = 255
        Me.descriptionTextBox.Name = "descriptionTextBox"
        Me.descriptionTextBox.Size = New System.Drawing.Size(304, 20)
        Me.descriptionTextBox.TabIndex = 4
        '
        'titleTextBox
        '
        Me.titleTextBox.Location = New System.Drawing.Point(118, 21)
        Me.titleTextBox.MaxLength = 255
        Me.titleTextBox.Name = "titleTextBox"
        Me.titleTextBox.Size = New System.Drawing.Size(304, 20)
        Me.titleTextBox.TabIndex = 3
        '
        'bodyLabel
        '
        Me.bodyLabel.AutoSize = True
        Me.bodyLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bodyLabel.Location = New System.Drawing.Point(16, 99)
        Me.bodyLabel.Name = "bodyLabel"
        Me.bodyLabel.Size = New System.Drawing.Size(44, 17)
        Me.bodyLabel.TabIndex = 2
        Me.bodyLabel.Text = "Body"
        '
        'descriptionLabel
        '
        Me.descriptionLabel.AutoSize = True
        Me.descriptionLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.descriptionLabel.Location = New System.Drawing.Point(16, 61)
        Me.descriptionLabel.Name = "descriptionLabel"
        Me.descriptionLabel.Size = New System.Drawing.Size(90, 17)
        Me.descriptionLabel.TabIndex = 1
        Me.descriptionLabel.Text = "Description"
        '
        'titleLabel
        '
        Me.titleLabel.AutoSize = True
        Me.titleLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.titleLabel.Location = New System.Drawing.Point(16, 21)
        Me.titleLabel.Name = "titleLabel"
        Me.titleLabel.Size = New System.Drawing.Size(40, 17)
        Me.titleLabel.TabIndex = 0
        Me.titleLabel.Text = "Title"
        '
        'imageTabPage
        '
        Me.imageTabPage.Controls.Add(Me.imagePathTextBox)
        Me.imageTabPage.Controls.Add(Me.browseButton)
        Me.imageTabPage.Controls.Add(Me.PictureBox1)
        Me.imageTabPage.Location = New System.Drawing.Point(4, 22)
        Me.imageTabPage.Name = "imageTabPage"
        Me.imageTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.imageTabPage.Size = New System.Drawing.Size(429, 369)
        Me.imageTabPage.TabIndex = 1
        Me.imageTabPage.Text = "Image"
        Me.imageTabPage.UseVisualStyleBackColor = True
        '
        'imagePathTextBox
        '
        Me.imagePathTextBox.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.imagePathTextBox.Location = New System.Drawing.Point(89, 8)
        Me.imagePathTextBox.Name = "imagePathTextBox"
        Me.imagePathTextBox.ReadOnly = True
        Me.imagePathTextBox.Size = New System.Drawing.Size(333, 20)
        Me.imagePathTextBox.TabIndex = 2
        '
        'browseButton
        '
        Me.browseButton.Location = New System.Drawing.Point(7, 8)
        Me.browseButton.Name = "browseButton"
        Me.browseButton.Size = New System.Drawing.Size(75, 20)
        Me.browseButton.TabIndex = 1
        Me.browseButton.Text = "Browse"
        Me.browseButton.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(7, 37)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(415, 322)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'addImage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(439, 394)
        Me.Controls.Add(Me.imageTabControl)
        Me.Name = "addImage"
        Me.Text = "New Image Form"
        Me.imageTabControl.ResumeLayout(False)
        Me.imageInfoTabPage.ResumeLayout(False)
        Me.imageInfoTabPage.PerformLayout()
        Me.imageTabPage.ResumeLayout(False)
        Me.imageTabPage.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents imageTabControl As TabControl
    Friend WithEvents imageInfoTabPage As TabPage
    Friend WithEvents bodyTextBox As TextBox
    Friend WithEvents descriptionTextBox As TextBox
    Friend WithEvents titleTextBox As TextBox
    Friend WithEvents bodyLabel As Label
    Friend WithEvents descriptionLabel As Label
    Friend WithEvents titleLabel As Label
    Friend WithEvents imageTabPage As TabPage
    Friend WithEvents cancelButton As Button
    Friend WithEvents saveButton As Button
    Friend WithEvents imagePathTextBox As TextBox
    Friend WithEvents browseButton As Button
    Friend WithEvents PictureBox1 As PictureBox
End Class
