<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAgents
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
        DataGridViewContracts = New DataGridView()
        MenuStrip1 = New MenuStrip()
        اعادةتعينToolStripMenuItem = New ToolStripMenuItem()
        CType(DataGridViewContracts, ComponentModel.ISupportInitialize).BeginInit()
        MenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' DataGridViewContracts
        ' 
        DataGridViewContracts.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        DataGridViewContracts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewContracts.Location = New Point(0, 28)
        DataGridViewContracts.Name = "DataGridViewContracts"
        DataGridViewContracts.Size = New Size(800, 422)
        DataGridViewContracts.TabIndex = 0
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.Items.AddRange(New ToolStripItem() {اعادةتعينToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(800, 24)
        MenuStrip1.TabIndex = 1
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' اعادةتعينToolStripMenuItem
        ' 
        اعادةتعينToolStripMenuItem.Name = "اعادةتعينToolStripMenuItem"
        اعادةتعينToolStripMenuItem.Size = New Size(70, 20)
        اعادةتعينToolStripMenuItem.Text = "اعادة تعين"
        ' 
        ' FormAgents
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(DataGridViewContracts)
        Controls.Add(MenuStrip1)
        MainMenuStrip = MenuStrip1
        Name = "FormAgents"
        Text = "FormAgents"
        CType(DataGridViewContracts, ComponentModel.ISupportInitialize).EndInit()
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents DataGridViewContracts As DataGridView
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents اعادةتعينToolStripMenuItem As ToolStripMenuItem
End Class
