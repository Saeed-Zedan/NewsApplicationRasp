<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserAdd
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
        Me.nameLabel = New System.Windows.Forms.Label()
        Me.longNameLabel = New System.Windows.Forms.Label()
        Me.passwordLabel = New System.Windows.Forms.Label()
        Me.nameTextBox = New System.Windows.Forms.TextBox()
        Me.longNameTextBox = New System.Windows.Forms.TextBox()
        Me.passwordTextBox = New System.Windows.Forms.TextBox()
        Me.saveButton = New System.Windows.Forms.Button()
        Me.exitButton2 = New System.Windows.Forms.Button()
        Me.adminCheckBox = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'nameLabel
        '
        Me.nameLabel.AutoSize = True
        Me.nameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nameLabel.Location = New System.Drawing.Point(23, 13)
        Me.nameLabel.Name = "nameLabel"
        Me.nameLabel.Size = New System.Drawing.Size(49, 17)
        Me.nameLabel.TabIndex = 0
        Me.nameLabel.Text = "Name"
        '
        'longNameLabel
        '
        Me.longNameLabel.AutoSize = True
        Me.longNameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.longNameLabel.Location = New System.Drawing.Point(23, 52)
        Me.longNameLabel.Name = "longNameLabel"
        Me.longNameLabel.Size = New System.Drawing.Size(90, 17)
        Me.longNameLabel.TabIndex = 0
        Me.longNameLabel.Text = "Long Name"
        '
        'passwordLabel
        '
        Me.passwordLabel.AutoSize = True
        Me.passwordLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.passwordLabel.Location = New System.Drawing.Point(23, 87)
        Me.passwordLabel.Name = "passwordLabel"
        Me.passwordLabel.Size = New System.Drawing.Size(77, 17)
        Me.passwordLabel.TabIndex = 0
        Me.passwordLabel.Text = "Password"
        '
        'nameTextBox
        '
        Me.nameTextBox.Location = New System.Drawing.Point(118, 13)
        Me.nameTextBox.MaxLength = 255
        Me.nameTextBox.Name = "nameTextBox"
        Me.nameTextBox.Size = New System.Drawing.Size(204, 20)
        Me.nameTextBox.TabIndex = 0
        '
        'longNameTextBox
        '
        Me.longNameTextBox.Location = New System.Drawing.Point(118, 52)
        Me.longNameTextBox.MaxLength = 255
        Me.longNameTextBox.Name = "longNameTextBox"
        Me.longNameTextBox.Size = New System.Drawing.Size(204, 20)
        Me.longNameTextBox.TabIndex = 1
        '
        'passwordTextBox
        '
        Me.passwordTextBox.Location = New System.Drawing.Point(118, 87)
        Me.passwordTextBox.MaxLength = 255
        Me.passwordTextBox.Name = "passwordTextBox"
        Me.passwordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.passwordTextBox.Size = New System.Drawing.Size(204, 20)
        Me.passwordTextBox.TabIndex = 2
        '
        'saveButton
        '
        Me.saveButton.Location = New System.Drawing.Point(81, 169)
        Me.saveButton.Name = "saveButton"
        Me.saveButton.Size = New System.Drawing.Size(75, 23)
        Me.saveButton.TabIndex = 4
        Me.saveButton.Text = "Save"
        Me.saveButton.UseVisualStyleBackColor = True
        '
        'exitButton2
        '
        Me.exitButton2.Location = New System.Drawing.Point(162, 169)
        Me.exitButton2.Name = "exitButton2"
        Me.exitButton2.Size = New System.Drawing.Size(75, 23)
        Me.exitButton2.TabIndex = 5
        Me.exitButton2.Text = "Cancel"
        Me.exitButton2.UseVisualStyleBackColor = True
        '
        'adminCheckBox
        '
        Me.adminCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.adminCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.adminCheckBox.Location = New System.Drawing.Point(26, 113)
        Me.adminCheckBox.Name = "adminCheckBox"
        Me.adminCheckBox.Size = New System.Drawing.Size(108, 28)
        Me.adminCheckBox.TabIndex = 6
        Me.adminCheckBox.Text = "Admin"
        Me.adminCheckBox.UseVisualStyleBackColor = True
        '
        'addUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(334, 204)
        Me.ControlBox = False
        Me.Controls.Add(Me.adminCheckBox)
        Me.Controls.Add(Me.exitButton2)
        Me.Controls.Add(Me.saveButton)
        Me.Controls.Add(Me.passwordTextBox)
        Me.Controls.Add(Me.longNameTextBox)
        Me.Controls.Add(Me.nameTextBox)
        Me.Controls.Add(Me.passwordLabel)
        Me.Controls.Add(Me.longNameLabel)
        Me.Controls.Add(Me.nameLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "addUser"
        Me.Text = "New User Form"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents nameLabel As Label
    Friend WithEvents longNameLabel As Label
    Friend WithEvents passwordLabel As Label
    Friend WithEvents nameTextBox As TextBox
    Friend WithEvents longNameTextBox As TextBox
    Friend WithEvents passwordTextBox As TextBox
    Friend WithEvents saveButton As Button
    Friend WithEvents exitButton2 As Button
    Friend WithEvents adminCheckBox As CheckBox
End Class
