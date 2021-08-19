<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class addNews
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
        Me.categoryComboBox1 = New System.Windows.Forms.ComboBox()
        Me.titleLabel = New System.Windows.Forms.Label()
        Me.descriptionLabel = New System.Windows.Forms.Label()
        Me.categoryLabel = New System.Windows.Forms.Label()
        Me.bodyLabel = New System.Windows.Forms.Label()
        Me.exitButton = New System.Windows.Forms.Button()
        Me.saveButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'titleTextBox
        '
        Me.titleTextBox.Location = New System.Drawing.Point(113, 12)
        Me.titleTextBox.Name = "titleTextBox"
        Me.titleTextBox.Size = New System.Drawing.Size(325, 20)
        Me.titleTextBox.TabIndex = 0
        '
        'descriptionTextBox
        '
        Me.descriptionTextBox.Location = New System.Drawing.Point(113, 50)
        Me.descriptionTextBox.Name = "descriptionTextBox"
        Me.descriptionTextBox.Size = New System.Drawing.Size(325, 20)
        Me.descriptionTextBox.TabIndex = 1
        '
        'bodyTextBox
        '
        Me.bodyTextBox.Location = New System.Drawing.Point(113, 132)
        Me.bodyTextBox.Multiline = True
        Me.bodyTextBox.Name = "bodyTextBox"
        Me.bodyTextBox.Size = New System.Drawing.Size(325, 248)
        Me.bodyTextBox.TabIndex = 3
        '
        'categoryComboBox1
        '
        Me.categoryComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.categoryComboBox1.FormattingEnabled = True
        Me.categoryComboBox1.Items.AddRange(New Object() {"Politics", "Science", "Sport"})
        Me.categoryComboBox1.Location = New System.Drawing.Point(113, 91)
        Me.categoryComboBox1.Name = "categoryComboBox1"
        Me.categoryComboBox1.Size = New System.Drawing.Size(325, 21)
        Me.categoryComboBox1.Sorted = True
        Me.categoryComboBox1.TabIndex = 2
        '
        'titleLabel
        '
        Me.titleLabel.AutoSize = True
        Me.titleLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.titleLabel.Location = New System.Drawing.Point(7, 12)
        Me.titleLabel.Name = "titleLabel"
        Me.titleLabel.Size = New System.Drawing.Size(43, 20)
        Me.titleLabel.TabIndex = 2
        Me.titleLabel.Text = "Title"
        '
        'descriptionLabel
        '
        Me.descriptionLabel.AutoSize = True
        Me.descriptionLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.descriptionLabel.Location = New System.Drawing.Point(7, 50)
        Me.descriptionLabel.Name = "descriptionLabel"
        Me.descriptionLabel.Size = New System.Drawing.Size(100, 20)
        Me.descriptionLabel.TabIndex = 2
        Me.descriptionLabel.Text = "Description"
        '
        'categoryLabel
        '
        Me.categoryLabel.AutoSize = True
        Me.categoryLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.categoryLabel.Location = New System.Drawing.Point(7, 92)
        Me.categoryLabel.Name = "categoryLabel"
        Me.categoryLabel.Size = New System.Drawing.Size(81, 20)
        Me.categoryLabel.TabIndex = 2
        Me.categoryLabel.Text = "Category"
        '
        'bodyLabel
        '
        Me.bodyLabel.AutoSize = True
        Me.bodyLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bodyLabel.Location = New System.Drawing.Point(7, 130)
        Me.bodyLabel.Name = "bodyLabel"
        Me.bodyLabel.Size = New System.Drawing.Size(49, 20)
        Me.bodyLabel.TabIndex = 2
        Me.bodyLabel.Text = "Body"
        '
        'exitButton
        '
        Me.exitButton.Location = New System.Drawing.Point(363, 386)
        Me.exitButton.Name = "exitButton"
        Me.exitButton.Size = New System.Drawing.Size(75, 23)
        Me.exitButton.TabIndex = 3
        Me.exitButton.Text = "Cancel"
        Me.exitButton.UseVisualStyleBackColor = True
        '
        'saveButton
        '
        Me.saveButton.Location = New System.Drawing.Point(282, 386)
        Me.saveButton.Name = "saveButton"
        Me.saveButton.Size = New System.Drawing.Size(75, 23)
        Me.saveButton.TabIndex = 4
        Me.saveButton.Text = "Save"
        Me.saveButton.UseVisualStyleBackColor = True
        '
        'addNews
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(450, 419)
        Me.Controls.Add(Me.saveButton)
        Me.Controls.Add(Me.exitButton)
        Me.Controls.Add(Me.bodyLabel)
        Me.Controls.Add(Me.categoryLabel)
        Me.Controls.Add(Me.descriptionLabel)
        Me.Controls.Add(Me.titleLabel)
        Me.Controls.Add(Me.categoryComboBox1)
        Me.Controls.Add(Me.bodyTextBox)
        Me.Controls.Add(Me.descriptionTextBox)
        Me.Controls.Add(Me.titleTextBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "addNews"
        Me.Text = "New news"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents titleTextBox As TextBox
    Friend WithEvents descriptionTextBox As TextBox
    Friend WithEvents bodyTextBox As TextBox
    Friend WithEvents categoryComboBox1 As ComboBox
    Friend WithEvents titleLabel As Label
    Friend WithEvents descriptionLabel As Label
    Friend WithEvents categoryLabel As Label
    Friend WithEvents bodyLabel As Label
    Friend WithEvents exitButton As Button
    Friend WithEvents saveButton As Button
End Class
