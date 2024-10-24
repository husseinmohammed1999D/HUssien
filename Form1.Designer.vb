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
        MenuStrip1 = New MenuStrip()
        ExitToolStripMenuItem = New ToolStripMenuItem()
        SetttingToolStripMenuItem = New ToolStripMenuItem()
        ادارةعقودToolStripMenuItem = New ToolStripMenuItem()
        سدادToolStripMenuItem = New ToolStripMenuItem()
        GroupBox1 = New GroupBox()
        Label5 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        TextBox5 = New TextBox()
        TextBox4 = New TextBox()
        TextBox3 = New TextBox()
        TextBox2 = New TextBox()
        TextBox1 = New TextBox()
        GroupBox2 = New GroupBox()
        Label10 = New Label()
        Label9 = New Label()
        Label8 = New Label()
        Label7 = New Label()
        Label6 = New Label()
        TextBox9 = New TextBox()
        TextBox8 = New TextBox()
        TextBox6 = New TextBox()
        TextBox7 = New TextBox()
        btnSum = New Button()
        ButtonPrint = New Button()
        GroupBox3 = New GroupBox()
        Label14 = New Label()
        GroupBox4 = New GroupBox()
        Label13 = New Label()
        GroupBox5 = New GroupBox()
        Label11 = New Label()
        CheckBox1 = New CheckBox()
        TextBox10 = New TextBox()
        MenuStrip1.SuspendLayout()
        GroupBox1.SuspendLayout()
        GroupBox2.SuspendLayout()
        GroupBox3.SuspendLayout()
        GroupBox4.SuspendLayout()
        GroupBox5.SuspendLayout()
        SuspendLayout()
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.Items.AddRange(New ToolStripItem() {ExitToolStripMenuItem, SetttingToolStripMenuItem, ادارةعقودToolStripMenuItem, سدادToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(1074, 24)
        MenuStrip1.TabIndex = 0
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' ExitToolStripMenuItem
        ' 
        ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        ExitToolStripMenuItem.Size = New Size(38, 20)
        ExitToolStripMenuItem.Text = "Exit"
        ' 
        ' SetttingToolStripMenuItem
        ' 
        SetttingToolStripMenuItem.Name = "SetttingToolStripMenuItem"
        SetttingToolStripMenuItem.Size = New Size(60, 20)
        SetttingToolStripMenuItem.Text = "Settting"
        ' 
        ' ادارةعقودToolStripMenuItem
        ' 
        ادارةعقودToolStripMenuItem.Name = "ادارةعقودToolStripMenuItem"
        ادارةعقودToolStripMenuItem.Size = New Size(96, 20)
        ادارةعقودToolStripMenuItem.Text = "ادارة عقود وكلاء"
        ' 
        ' سدادToolStripMenuItem
        ' 
        سدادToolStripMenuItem.Name = "سدادToolStripMenuItem"
        سدادToolStripMenuItem.Size = New Size(44, 20)
        سدادToolStripMenuItem.Text = "سداد"
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right
        GroupBox1.BackColor = Color.FromArgb(CByte(128), CByte(255), CByte(128))
        GroupBox1.BackgroundImageLayout = ImageLayout.None
        GroupBox1.Controls.Add(Label5)
        GroupBox1.Controls.Add(Label4)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Controls.Add(TextBox5)
        GroupBox1.Controls.Add(TextBox4)
        GroupBox1.Controls.Add(TextBox3)
        GroupBox1.Controls.Add(TextBox2)
        GroupBox1.Controls.Add(TextBox1)
        GroupBox1.Location = New Point(787, 27)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(283, 534)
        GroupBox1.TabIndex = 36
        GroupBox1.TabStop = False
        GroupBox1.Text = "ريال"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 15F)
        Label5.Location = New Point(144, 387)
        Label5.Name = "Label5"
        Label5.RightToLeft = RightToLeft.Yes
        Label5.Size = New Size(115, 28)
        Label5.TabIndex = 9
        Label5.Text = "عدد ايام مكه"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 15F)
        Label4.Location = New Point(144, 317)
        Label4.Name = "Label4"
        Label4.RightToLeft = RightToLeft.Yes
        Label4.Size = New Size(91, 28)
        Label4.TabIndex = 8
        Label4.Text = "سعر مكةا"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 15F)
        Label3.Location = New Point(142, 221)
        Label3.Name = "Label3"
        Label3.RightToLeft = RightToLeft.Yes
        Label3.Size = New Size(141, 28)
        Label3.TabIndex = 7
        Label3.Text = "عدد ايام المدينة"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 15F)
        Label2.Location = New Point(142, 139)
        Label2.Name = "Label2"
        Label2.RightToLeft = RightToLeft.Yes
        Label2.Size = New Size(112, 28)
        Label2.TabIndex = 6
        Label2.Text = "سعر المدينة"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 15F)
        Label1.Location = New Point(160, 50)
        Label1.Name = "Label1"
        Label1.RightToLeft = RightToLeft.Yes
        Label1.Size = New Size(94, 28)
        Label1.TabIndex = 5
        Label1.Text = "سعر الفيزا"
        ' 
        ' TextBox5
        ' 
        TextBox5.Font = New Font("Segoe UI", 22F)
        TextBox5.Location = New Point(6, 366)
        TextBox5.Multiline = True
        TextBox5.Name = "TextBox5"
        TextBox5.Size = New Size(132, 80)
        TextBox5.TabIndex = 4
        TextBox5.Text = "0"
        ' 
        ' TextBox4
        ' 
        TextBox4.Font = New Font("Segoe UI", 22F)
        TextBox4.Location = New Point(6, 280)
        TextBox4.Multiline = True
        TextBox4.Name = "TextBox4"
        TextBox4.Size = New Size(132, 80)
        TextBox4.TabIndex = 3
        TextBox4.Text = "0"
        ' 
        ' TextBox3
        ' 
        TextBox3.Font = New Font("Segoe UI", 22F)
        TextBox3.Location = New Point(6, 194)
        TextBox3.Multiline = True
        TextBox3.Name = "TextBox3"
        TextBox3.Size = New Size(132, 80)
        TextBox3.TabIndex = 2
        TextBox3.Text = "0"
        ' 
        ' TextBox2
        ' 
        TextBox2.Font = New Font("Segoe UI", 22F)
        TextBox2.Location = New Point(6, 108)
        TextBox2.Multiline = True
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(132, 80)
        TextBox2.TabIndex = 1
        TextBox2.Text = "0"
        ' 
        ' TextBox1
        ' 
        TextBox1.Font = New Font("Segoe UI", 22F)
        TextBox1.Location = New Point(6, 22)
        TextBox1.Multiline = True
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(132, 80)
        TextBox1.TabIndex = 0
        TextBox1.Tag = " بي"
        TextBox1.Text = "0"
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right
        GroupBox2.BackColor = Color.Cyan
        GroupBox2.Controls.Add(Label10)
        GroupBox2.Controls.Add(Label9)
        GroupBox2.Controls.Add(Label8)
        GroupBox2.Controls.Add(Label7)
        GroupBox2.Controls.Add(Label6)
        GroupBox2.Controls.Add(TextBox9)
        GroupBox2.Controls.Add(TextBox8)
        GroupBox2.Controls.Add(TextBox6)
        GroupBox2.Controls.Add(TextBox7)
        GroupBox2.Location = New Point(492, 27)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(289, 534)
        GroupBox2.TabIndex = 37
        GroupBox2.TabStop = False
        GroupBox2.Text = "دولار"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Segoe UI", 15F)
        Label10.Location = New Point(92, 390)
        Label10.Name = "Label10"
        Label10.RightToLeft = RightToLeft.Yes
        Label10.Size = New Size(162, 56)
        Label10.TabIndex = 13
        Label10.Text = "ملاحظه : " & vbCrLf & "عمولة الشركة ثابته"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Segoe UI", 15F)
        Label9.Location = New Point(139, 317)
        Label9.Name = "Label9"
        Label9.RightToLeft = RightToLeft.Yes
        Label9.Size = New Size(120, 28)
        Label9.TabIndex = 12
        Label9.Text = "عمولة الوكيل"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI", 15F)
        Label8.Location = New Point(144, 221)
        Label8.Name = "Label8"
        Label8.RightToLeft = RightToLeft.Yes
        Label8.Size = New Size(103, 28)
        Label8.TabIndex = 11
        Label8.Text = "سعر الهدايا"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI", 15F)
        Label7.Location = New Point(154, 139)
        Label7.Name = "Label7"
        Label7.RightToLeft = RightToLeft.Yes
        Label7.Size = New Size(100, 28)
        Label7.TabIndex = 10
        Label7.Text = "سعر الهيئه"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 15F)
        Label6.Location = New Point(152, 22)
        Label6.Name = "Label6"
        Label6.RightToLeft = RightToLeft.Yes
        Label6.Size = New Size(96, 84)
        Label6.TabIndex = 9
        Label6.Text = "سعر النقل" & vbCrLf & "بر" & vbCrLf & "طيران" & vbCrLf
        ' 
        ' TextBox9
        ' 
        TextBox9.Font = New Font("Segoe UI", 22F)
        TextBox9.Location = New Point(6, 284)
        TextBox9.Multiline = True
        TextBox9.Name = "TextBox9"
        TextBox9.Size = New Size(132, 80)
        TextBox9.TabIndex = 8
        TextBox9.Text = "0"
        ' 
        ' TextBox8
        ' 
        TextBox8.Font = New Font("Segoe UI", 22F)
        TextBox8.Location = New Point(6, 198)
        TextBox8.Multiline = True
        TextBox8.Name = "TextBox8"
        TextBox8.Size = New Size(132, 80)
        TextBox8.TabIndex = 7
        TextBox8.Text = "0"
        ' 
        ' TextBox6
        ' 
        TextBox6.Font = New Font("Segoe UI", 22F)
        TextBox6.Location = New Point(6, 112)
        TextBox6.Multiline = True
        TextBox6.Name = "TextBox6"
        TextBox6.Size = New Size(132, 80)
        TextBox6.TabIndex = 6
        TextBox6.Text = "0"
        ' 
        ' TextBox7
        ' 
        TextBox7.Font = New Font("Segoe UI", 22F)
        TextBox7.Location = New Point(6, 22)
        TextBox7.Multiline = True
        TextBox7.Name = "TextBox7"
        TextBox7.Size = New Size(132, 84)
        TextBox7.TabIndex = 5
        TextBox7.Text = "0"
        ' 
        ' btnSum
        ' 
        btnSum.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        btnSum.Font = New Font("Segoe UI", 25F)
        btnSum.Location = New Point(3, 148)
        btnSum.Name = "btnSum"
        btnSum.Size = New Size(482, 213)
        btnSum.TabIndex = 40
        btnSum.Text = "جمع"
        btnSum.UseVisualStyleBackColor = True
        ' 
        ' ButtonPrint
        ' 
        ButtonPrint.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        ButtonPrint.Font = New Font("Segoe UI", 25F)
        ButtonPrint.Location = New Point(4, 367)
        ButtonPrint.Name = "ButtonPrint"
        ButtonPrint.Size = New Size(482, 195)
        ButtonPrint.TabIndex = 38
        ButtonPrint.Text = "ابرام عقد"
        ButtonPrint.UseVisualStyleBackColor = True
        ' 
        ' GroupBox3
        ' 
        GroupBox3.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        GroupBox3.BackColor = Color.Salmon
        GroupBox3.Controls.Add(Label14)
        GroupBox3.Location = New Point(242, 52)
        GroupBox3.Name = "GroupBox3"
        GroupBox3.Size = New Size(113, 84)
        GroupBox3.TabIndex = 32
        GroupBox3.TabStop = False
        GroupBox3.Text = "ثنائي"
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Font = New Font("Segoe UI", 20F)
        Label14.Location = New Point(40, 28)
        Label14.Name = "Label14"
        Label14.RightToLeft = RightToLeft.Yes
        Label14.Size = New Size(47, 37)
        Label14.TabIndex = 17
        Label14.Text = "00"
        ' 
        ' GroupBox4
        ' 
        GroupBox4.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        GroupBox4.BackColor = Color.MediumSpringGreen
        GroupBox4.Controls.Add(Label13)
        GroupBox4.Font = New Font("Segoe UI", 12F)
        GroupBox4.Location = New Point(123, 52)
        GroupBox4.Name = "GroupBox4"
        GroupBox4.Size = New Size(113, 84)
        GroupBox4.TabIndex = 33
        GroupBox4.TabStop = False
        GroupBox4.Text = "ثلاثي"
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Font = New Font("Segoe UI", 20F)
        Label13.Location = New Point(41, 28)
        Label13.Name = "Label13"
        Label13.RightToLeft = RightToLeft.Yes
        Label13.Size = New Size(47, 37)
        Label13.TabIndex = 16
        Label13.Text = "00"
        ' 
        ' GroupBox5
        ' 
        GroupBox5.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        GroupBox5.BackColor = Color.Cyan
        GroupBox5.Controls.Add(Label11)
        GroupBox5.Font = New Font("Segoe UI", 12F)
        GroupBox5.Location = New Point(4, 52)
        GroupBox5.Name = "GroupBox5"
        GroupBox5.Size = New Size(113, 84)
        GroupBox5.TabIndex = 34
        GroupBox5.TabStop = False
        GroupBox5.Text = "رباعي"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Segoe UI", 20F)
        Label11.Location = New Point(21, 28)
        Label11.Name = "Label11"
        Label11.RightToLeft = RightToLeft.Yes
        Label11.Size = New Size(47, 37)
        Label11.TabIndex = 14
        Label11.Text = "00"
        ' 
        ' CheckBox1
        ' 
        CheckBox1.AllowDrop = True
        CheckBox1.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        CheckBox1.AutoSize = True
        CheckBox1.Location = New Point(400, 27)
        CheckBox1.Name = "CheckBox1"
        CheckBox1.RightToLeft = RightToLeft.Yes
        CheckBox1.Size = New Size(86, 19)
        CheckBox1.TabIndex = 30
        CheckBox1.Text = "تقسيم خاص"
        CheckBox1.TextAlign = ContentAlignment.MiddleRight
        CheckBox1.UseVisualStyleBackColor = True
        ' 
        ' TextBox10
        ' 
        TextBox10.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        TextBox10.Font = New Font("Segoe UI", 22F)
        TextBox10.Location = New Point(362, 52)
        TextBox10.Multiline = True
        TextBox10.Name = "TextBox10"
        TextBox10.Size = New Size(123, 84)
        TextBox10.TabIndex = 31
        TextBox10.Text = "0"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1074, 565)
        Controls.Add(GroupBox3)
        Controls.Add(GroupBox4)
        Controls.Add(GroupBox1)
        Controls.Add(GroupBox2)
        Controls.Add(GroupBox5)
        Controls.Add(CheckBox1)
        Controls.Add(btnSum)
        Controls.Add(TextBox10)
        Controls.Add(ButtonPrint)
        Controls.Add(MenuStrip1)
        MainMenuStrip = MenuStrip1
        Name = "Form1"
        Text = "الواجهة الرئيسيه"
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        GroupBox3.ResumeLayout(False)
        GroupBox3.PerformLayout()
        GroupBox4.ResumeLayout(False)
        GroupBox4.PerformLayout()
        GroupBox5.ResumeLayout(False)
        GroupBox5.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SetttingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents TextBox9 As TextBox
    Friend WithEvents TextBox8 As TextBox
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents TextBox7 As TextBox
    Friend WithEvents btnSum As Button
    Friend WithEvents ButtonPrint As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label14 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label13 As Label
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents Label11 As Label
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents TextBox10 As TextBox
    Friend WithEvents ادارةعقودToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents سدادToolStripMenuItem As ToolStripMenuItem
End Class
