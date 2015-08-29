<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Me.components = New System.ComponentModel.Container
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.XItemDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.XPriceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.XIncludeDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.XItemBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PhotoBizDataSet = New WindowsApplication1.PhotoBizDataSet
        Me.X_ItemTableAdapter = New WindowsApplication1.PhotoBizDataSetTableAdapters.x_ItemTableAdapter
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XItemBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PhotoBizDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.XItemDataGridViewTextBoxColumn, Me.XPriceDataGridViewTextBoxColumn, Me.XIncludeDataGridViewCheckBoxColumn})
        Me.DataGridView1.DataSource = Me.XItemBindingSource
        Me.DataGridView1.Location = New System.Drawing.Point(53, 29)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(375, 205)
        Me.DataGridView1.TabIndex = 0
        '
        'XItemDataGridViewTextBoxColumn
        '
        Me.XItemDataGridViewTextBoxColumn.DataPropertyName = "xItem"
        Me.XItemDataGridViewTextBoxColumn.HeaderText = "xItem"
        Me.XItemDataGridViewTextBoxColumn.Name = "XItemDataGridViewTextBoxColumn"
        '
        'XPriceDataGridViewTextBoxColumn
        '
        Me.XPriceDataGridViewTextBoxColumn.DataPropertyName = "xPrice"
        Me.XPriceDataGridViewTextBoxColumn.HeaderText = "xPrice"
        Me.XPriceDataGridViewTextBoxColumn.Name = "XPriceDataGridViewTextBoxColumn"
        '
        'XIncludeDataGridViewCheckBoxColumn
        '
        Me.XIncludeDataGridViewCheckBoxColumn.DataPropertyName = "xInclude"
        Me.XIncludeDataGridViewCheckBoxColumn.HeaderText = "xInclude"
        Me.XIncludeDataGridViewCheckBoxColumn.Name = "XIncludeDataGridViewCheckBoxColumn"
        '
        'XItemBindingSource
        '
        Me.XItemBindingSource.DataMember = "x_Item"
        Me.XItemBindingSource.DataSource = Me.PhotoBizDataSet
        '
        'PhotoBizDataSet
        '
        Me.PhotoBizDataSet.DataSetName = "PhotoBizDataSet"
        Me.PhotoBizDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'X_ItemTableAdapter
        '
        Me.X_ItemTableAdapter.ClearBeforeFill = True
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(458, 339)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "Form2"
        Me.Text = "Form2"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XItemBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PhotoBizDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents PhotoBizDataSet As WindowsApplication1.PhotoBizDataSet
    Friend WithEvents XItemBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents X_ItemTableAdapter As WindowsApplication1.PhotoBizDataSetTableAdapters.x_ItemTableAdapter
    Friend WithEvents XItemDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents XPriceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents XIncludeDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
