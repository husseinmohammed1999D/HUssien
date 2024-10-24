<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Home
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Home))
        Button1 = New Button()
        Button2 = New Button()
        Button3 = New Button()
        Button4 = New Button()
        Button5 = New Button()
        PictureBox1 = New PictureBox()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button1.AutoEllipsis = True
        Button1.AutoSizeMode = AutoSizeMode.GrowAndShrink
        Button1.Font = New Font("Showcard Gothic", 12F)
        Button1.ImageAlign = ContentAlignment.MiddleRight
        Button1.Location = New Point(822, 12)
        Button1.Name = "Button1"
        Button1.Size = New Size(121, 103)
        Button1.TabIndex = 0
        Button1.Text = "جيك برنامج"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button2.AutoEllipsis = True
        Button2.AutoSizeMode = AutoSizeMode.GrowAndShrink
        Button2.Font = New Font("Showcard Gothic", 12F)
        Button2.ImageAlign = ContentAlignment.MiddleRight
        Button2.Location = New Point(822, 121)
        Button2.Name = "Button2"
        Button2.Size = New Size(121, 103)
        Button2.TabIndex = 2
        Button2.Text = "سداد "
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button3.AutoEllipsis = True
        Button3.AutoSizeMode = AutoSizeMode.GrowAndShrink
        Button3.Font = New Font("Showcard Gothic", 12F)
        Button3.ImageAlign = ContentAlignment.MiddleRight
        Button3.Location = New Point(822, 230)
        Button3.Name = "Button3"
        Button3.Size = New Size(121, 103)
        Button3.TabIndex = 3
        Button3.Text = "عرض العقود"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button4
        ' 
        Button4.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button4.AutoEllipsis = True
        Button4.AutoSizeMode = AutoSizeMode.GrowAndShrink
        Button4.Font = New Font("Showcard Gothic", 12F)
        Button4.ImageAlign = ContentAlignment.MiddleRight
        Button4.Location = New Point(822, 339)
        Button4.Name = "Button4"
        Button4.Size = New Size(121, 103)
        Button4.TabIndex = 4
        Button4.Text = "اعدادات"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' Button5
        ' 
        Button5.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button5.AutoEllipsis = True
        Button5.AutoSizeMode = AutoSizeMode.GrowAndShrink
        Button5.ImageAlign = ContentAlignment.MiddleRight
        Button5.Location = New Point(822, 448)
        Button5.Name = "Button5"
        Button5.Size = New Size(121, 103)
        Button5.TabIndex = 5
        Button5.Text = "الرحلات"
        Button5.UseVisualStyleBackColor = True
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Dock = DockStyle.Fill
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(0, 0)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(955, 712)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 6
        PictureBox1.TabStop = False
        ' 
        ' Home
        ' 
        AccessibleRole = AccessibleRole.Grip
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSizeMode = AutoSizeMode.GrowAndShrink
        AutoValidate = AutoValidate.EnableAllowFocusChange
        BackColor = Color.White
        BackgroundImageLayout = ImageLayout.Center
        ClientSize = New Size(955, 712)
        Controls.Add(Button5)
        Controls.Add(Button4)
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(PictureBox1)
        ForeColor = SystemColors.ControlText
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        HelpButton = True
        ImeMode = ImeMode.AlphaFull
        Name = "Home"
        Text = "Home"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents PictureBox1 As PictureBox
End Class
