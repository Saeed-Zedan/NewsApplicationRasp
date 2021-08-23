<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewsEdit
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.titleLabel = New System.Windows.Forms.Label()
        Me.descriptionLabel = New System.Windows.Forms.Label()
        Me.categoryLabel = New System.Windows.Forms.Label()
        Me.bodyLabel = New System.Windows.Forms.Label()
        Me.titleTextBox = New System.Windows.Forms.TextBox()
        Me.descriptionTextBox = New System.Windows.Forms.TextBox()
        Me.bodyTextBox = New System.Windows.Forms.TextBox()
        Me.categoryComboBox = New System.Windows.Forms.ComboBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(66, 274)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 5
        Me.Cancel_Button.Text = "Cancel"
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 4
        Me.OK_Button.Text = "Edit"
        '
        'titleLabel
        '
        Me.titleLabel.AutoSize = True
        Me.titleLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.titleLabel.Location = New System.Drawing.Point(12, 21)
        Me.titleLabel.Name = "titleLabel"
        Me.titleLabel.Size = New System.Drawing.Size(40, 17)
        Me.titleLabel.TabIndex = 1
        Me.titleLabel.Text = "Title"
        '
        'descriptionLabel
        '
        Me.descriptionLabel.AutoSize = True
        Me.descriptionLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.descriptionLabel.Location = New System.Drawing.Point(12, 49)
        Me.descriptionLabel.Name = "descriptionLabel"
        Me.descriptionLabel.Size = New System.Drawing.Size(90, 17)
        Me.descriptionLabel.TabIndex = 1
        Me.descriptionLabel.Text = "Description"
        '
        'categoryLabel
        '
        Me.categoryLabel.AutoSize = True
        Me.categoryLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.categoryLabel.Location = New System.Drawing.Point(12, 77)
        Me.categoryLabel.Name = "categoryLabel"
        Me.categoryLabel.Size = New System.Drawing.Size(73, 17)
        Me.categoryLabel.TabIndex = 1
        Me.categoryLabel.Text = "Category"
        '
        'bodyLabel
        '
        Me.bodyLabel.AutoSize = True
        Me.bodyLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bodyLabel.Location = New System.Drawing.Point(12, 106)
        Me.bodyLabel.Name = "bodyLabel"
        Me.bodyLabel.Size = New System.Drawing.Size(44, 17)
        Me.bodyLabel.TabIndex = 1
        Me.bodyLabel.Text = "Body"
        '
        'titleTextBox
        '
        Me.titleTextBox.Location = New System.Drawing.Point(108, 21)
        Me.titleTextBox.Name = "titleTextBox"
        Me.titleTextBox.Size = New System.Drawing.Size(151, 20)
        Me.titleTextBox.TabIndex = 0
        '
        'descriptionTextBox
        '
        Me.descriptionTextBox.Location = New System.Drawing.Point(108, 49)
        Me.descriptionTextBox.Name = "descriptionTextBox"
        Me.descriptionTextBox.Size = New System.Drawing.Size(151, 20)
        Me.descriptionTextBox.TabIndex = 1
        '
        'bodyTextBox
        '
        Me.bodyTextBox.Location = New System.Drawing.Point(108, 106)
        Me.bodyTextBox.Multiline = True
        Me.bodyTextBox.Name = "bodyTextBox"
        Me.bodyTextBox.Size = New System.Drawing.Size(151, 141)
        Me.bodyTextBox.TabIndex = 3
        '
        'categoryComboBox
        '
        Me.categoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.categoryComboBox.FormattingEnabled = True
        Me.categoryComboBox.Items.AddRange(New Object() {"Genera", "Sports", "Health", "Politics"})
        Me.categoryComboBox.Location = New System.Drawing.Point(108, 77)
        Me.categoryComboBox.Name = "categoryComboBox"
        Me.categoryComboBox.Size = New System.Drawing.Size(151, 21)
        Me.categoryComboBox.TabIndex = 2
        '
        'editNews
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(291, 315)
        Me.Controls.Add(Me.categoryComboBox)
        Me.Controls.Add(Me.bodyTextBox)
        Me.Controls.Add(Me.descriptionTextBox)
        Me.Controls.Add(Me.titleTextBox)
        Me.Controls.Add(Me.bodyLabel)
        Me.Controls.Add(Me.categoryLabel)
        Me.Controls.Add(Me.descriptionLabel)
        Me.Controls.Add(Me.titleLabel)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "editNews"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Edit news"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents titleLabel As Label
    Friend WithEvents descriptionLabel As Label
    Friend WithEvents categoryLabel As Label
    Friend WithEvents bodyLabel As Label
    Friend WithEvents titleTextBox As TextBox
    Friend WithEvents descriptionTextBox As TextBox
    Friend WithEvents bodyTextBox As TextBox
    Friend WithEvents categoryComboBox As ComboBox
End Class
