<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class setup
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
        Me.txtworkfolder = New System.Windows.Forms.TextBox
        Me.txtworkshare = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtorder = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'txtworkfolder
        '
        Me.txtworkfolder.Location = New System.Drawing.Point(109, 32)
        Me.txtworkfolder.Name = "txtworkfolder"
        Me.txtworkfolder.Size = New System.Drawing.Size(255, 20)
        Me.txtworkfolder.TabIndex = 0
        '
        'txtworkshare
        '
        Me.txtworkshare.Location = New System.Drawing.Point(109, 58)
        Me.txtworkshare.Name = "txtworkshare"
        Me.txtworkshare.Size = New System.Drawing.Size(255, 20)
        Me.txtworkshare.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "work folder"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Work share folder"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Order share folder"
        '
        'txtorder
        '
        Me.txtorder.Location = New System.Drawing.Point(109, 85)
        Me.txtorder.Name = "txtorder"
        Me.txtorder.Size = New System.Drawing.Size(255, 20)
        Me.txtorder.TabIndex = 5
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(127, 116)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(107, 29)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Update"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'setup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(376, 157)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtorder)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtworkshare)
        Me.Controls.Add(Me.txtworkfolder)
        Me.Name = "setup"
        Me.Text = "setup"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtworkfolder As System.Windows.Forms.TextBox
    Friend WithEvents txtworkshare As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtorder As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
