<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.btnrefresh = New System.Windows.Forms.Button
        Me.lblQ = New System.Windows.Forms.Label
        Me.FileSystemWatcher1 = New System.IO.FileSystemWatcher
        Me.txtNotes = New System.Windows.Forms.TextBox
        Me.btnUtil = New System.Windows.Forms.Button
        Me.OrderName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NumberOfPics = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AmountDue = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FullFilled = New System.Windows.Forms.DataGridViewButtonColumn
        Me.CreateTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.OrderName, Me.NumberOfPics, Me.AmountDue, Me.FullFilled, Me.CreateTime})
        Me.DataGridView1.Location = New System.Drawing.Point(16, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(544, 150)
        Me.DataGridView1.TabIndex = 0
        '
        'btnrefresh
        '
        Me.btnrefresh.Location = New System.Drawing.Point(425, 197)
        Me.btnrefresh.Name = "btnrefresh"
        Me.btnrefresh.Size = New System.Drawing.Size(135, 41)
        Me.btnrefresh.TabIndex = 1
        Me.btnrefresh.Text = "Refresh"
        Me.btnrefresh.UseVisualStyleBackColor = True
        '
        'lblQ
        '
        Me.lblQ.AutoSize = True
        Me.lblQ.Location = New System.Drawing.Point(448, 176)
        Me.lblQ.Name = "lblQ"
        Me.lblQ.Size = New System.Drawing.Size(15, 13)
        Me.lblQ.TabIndex = 2
        Me.lblQ.Text = "Q"
        '
        'FileSystemWatcher1
        '
        Me.FileSystemWatcher1.EnableRaisingEvents = True
        Me.FileSystemWatcher1.IncludeSubdirectories = True
        Me.FileSystemWatcher1.NotifyFilter = System.IO.NotifyFilters.LastWrite
        Me.FileSystemWatcher1.Path = "C:\Orders\Orders"
        Me.FileSystemWatcher1.SynchronizingObject = Me
        '
        'txtNotes
        '
        Me.txtNotes.Location = New System.Drawing.Point(25, 201)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(208, 78)
        Me.txtNotes.TabIndex = 11
        '
        'btnUtil
        '
        Me.btnUtil.Location = New System.Drawing.Point(425, 244)
        Me.btnUtil.Name = "btnUtil"
        Me.btnUtil.Size = New System.Drawing.Size(135, 41)
        Me.btnUtil.TabIndex = 13
        Me.btnUtil.Text = "Utilities"
        Me.btnUtil.UseVisualStyleBackColor = True
        '
        'OrderName
        '
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OrderName.DefaultCellStyle = DataGridViewCellStyle1
        Me.OrderName.HeaderText = "Order Name"
        Me.OrderName.Name = "OrderName"
        Me.OrderName.ReadOnly = True
        Me.OrderName.Width = 200
        '
        'NumberOfPics
        '
        Me.NumberOfPics.HeaderText = "# of Pics"
        Me.NumberOfPics.Name = "NumberOfPics"
        Me.NumberOfPics.ReadOnly = True
        '
        'AmountDue
        '
        Me.AmountDue.HeaderText = "Amount Due"
        Me.AmountDue.Name = "AmountDue"
        Me.AmountDue.ReadOnly = True
        '
        'FullFilled
        '
        Me.FullFilled.HeaderText = "FullFilled"
        Me.FullFilled.Name = "FullFilled"
        Me.FullFilled.ReadOnly = True
        Me.FullFilled.Text = "Full Filled"
        Me.FullFilled.UseColumnTextForButtonValue = True
        '
        'CreateTime
        '
        Me.CreateTime.HeaderText = "Create Time"
        Me.CreateTime.Name = "CreateTime"
        Me.CreateTime.ReadOnly = True
        Me.CreateTime.Visible = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(581, 326)
        Me.Controls.Add(Me.btnUtil)
        Me.Controls.Add(Me.txtNotes)
        Me.Controls.Add(Me.lblQ)
        Me.Controls.Add(Me.btnrefresh)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "Form1"
        Me.Text = "Jon Baker Photography"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnrefresh As System.Windows.Forms.Button
    Friend WithEvents lblQ As System.Windows.Forms.Label
    Friend WithEvents FileSystemWatcher1 As System.IO.FileSystemWatcher
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Friend WithEvents btnUtil As System.Windows.Forms.Button
    Friend WithEvents OrderName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NumberOfPics As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AmountDue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FullFilled As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents CreateTime As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
