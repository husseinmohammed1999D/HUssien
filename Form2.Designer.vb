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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        RichTextBox1 = New RichTextBox()
        Panel1 = New Panel()
        LabelContractNumber = New Label()
        Label1 = New Label()
        TextBox1 = New TextBox()
        ButtonPrint = New Button()
        Panel2 = New Panel()
        TextBoxMadinaHotelName = New TextBox()
        Label4 = New Label()
        TextBoxTotalRoomsMadina = New TextBox()
        Label2 = New Label()
        TextBoxMadinaQuad = New TextBox()
        TextBoxMadinaDouble = New TextBox()
        TextBoxMadinaTriple = New TextBox()
        TextBoxMakaQuad = New TextBox()
        TextBoxMakaTriple = New TextBox()
        TextBoxMakaDouble = New TextBox()
        Panel3 = New Panel()
        Label5 = New Label()
        TextBoxTotalRoomsMaka = New TextBox()
        Label3 = New Label()
        TextBoxMakaHotelName = New TextBox()
        Panel4 = New Panel()
        TextBox18 = New TextBox()
        Label9 = New Label()
        TextBox17 = New TextBox()
        Label8 = New Label()
        Label7 = New Label()
        TextBox16 = New TextBox()
        Label6 = New Label()
        SumMutmer = New TextBox()
        TextBoxChildPrice = New TextBox()
        TextBoxInfantPrice = New TextBox()
        TextBoxAdultPrice = New TextBox()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        Panel4.SuspendLayout()
        SuspendLayout()
        ' 
        ' RichTextBox1
        ' 
        RichTextBox1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        RichTextBox1.Font = New Font("Segoe UI", 15F)
        RichTextBox1.Location = New Point(12, 12)
        RichTextBox1.Name = "RichTextBox1"
        RichTextBox1.RightToLeft = RightToLeft.Yes
        RichTextBox1.Size = New Size(1131, 963)
        RichTextBox1.TabIndex = 0
        RichTextBox1.Text = resources.GetString("RichTextBox1.Text")
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Panel1.BackColor = Color.FromArgb(0, 192, 192)
        Panel1.Controls.Add(LabelContractNumber)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(TextBox1)
        Panel1.Controls.Add(ButtonPrint)
        Panel1.Location = New Point(1152, 12)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(349, 241)
        Panel1.TabIndex = 1
        ' 
        ' LabelContractNumber
        ' 
        LabelContractNumber.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LabelContractNumber.AutoSize = True
        LabelContractNumber.Location = New Point(263, 0)
        LabelContractNumber.Name = "LabelContractNumber"
        LabelContractNumber.Size = New Size(78, 15)
        LabelContractNumber.TabIndex = 3
        LabelContractNumber.Text = "تفاصيل الوكيل"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(282, 181)
        Label1.Name = "Label1"
        Label1.RightToLeft = RightToLeft.Yes
        Label1.Size = New Size(61, 15)
        Label1.TabIndex = 2
        Label1.Text = "اسم الوكيل"
        ' 
        ' TextBox1
        ' 
        TextBox1.Font = New Font("Segoe UI", 15F)
        TextBox1.Location = New Point(6, 199)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(337, 34)
        TextBox1.TabIndex = 1
        TextBox1.Text = "مثلا : حسين"
        TextBox1.TextAlign = HorizontalAlignment.Right
        ' 
        ' ButtonPrint
        ' 
        ButtonPrint.Font = New Font("Segoe UI", 25F)
        ButtonPrint.Location = New Point(3, 18)
        ButtonPrint.Name = "ButtonPrint"
        ButtonPrint.Size = New Size(340, 160)
        ButtonPrint.TabIndex = 0
        ButtonPrint.Text = "ابرام عقد"
        ButtonPrint.UseVisualStyleBackColor = True
        ' 
        ' Panel2
        ' 
        Panel2.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Panel2.BackColor = Color.Cyan
        Panel2.Controls.Add(TextBoxMadinaHotelName)
        Panel2.Controls.Add(Label4)
        Panel2.Controls.Add(TextBoxTotalRoomsMadina)
        Panel2.Controls.Add(Label2)
        Panel2.Controls.Add(TextBoxMadinaQuad)
        Panel2.Controls.Add(TextBoxMadinaDouble)
        Panel2.Controls.Add(TextBoxMadinaTriple)
        Panel2.Location = New Point(1152, 259)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(349, 216)
        Panel2.TabIndex = 3
        ' 
        ' TextBoxMadinaHotelName
        ' 
        TextBoxMadinaHotelName.Font = New Font("Segoe UI", 15F)
        TextBoxMadinaHotelName.Location = New Point(3, 29)
        TextBoxMadinaHotelName.Name = "TextBoxMadinaHotelName"
        TextBoxMadinaHotelName.Size = New Size(337, 34)
        TextBoxMadinaHotelName.TabIndex = 4
        TextBoxMadinaHotelName.Text = "مركزي"
        TextBoxMadinaHotelName.TextAlign = HorizontalAlignment.Right
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(258, 73)
        Label4.Name = "Label4"
        Label4.Size = New Size(82, 15)
        Label4.TabIndex = 7
        Label4.Text = "عدد غرف مدينة"
        ' 
        ' TextBoxTotalRoomsMadina
        ' 
        TextBoxTotalRoomsMadina.Font = New Font("Segoe UI", 15F)
        TextBoxTotalRoomsMadina.Location = New Point(3, 69)
        TextBoxTotalRoomsMadina.Multiline = True
        TextBoxTotalRoomsMadina.Name = "TextBoxTotalRoomsMadina"
        TextBoxTotalRoomsMadina.Size = New Size(149, 136)
        TextBoxTotalRoomsMadina.TabIndex = 6
        TextBoxTotalRoomsMadina.Text = "مجموع غرف مدينة"
        TextBoxTotalRoomsMadina.TextAlign = HorizontalAlignment.Center
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(281, -3)
        Label2.Name = "Label2"
        Label2.RightToLeft = RightToLeft.Yes
        Label2.Size = New Size(62, 15)
        Label2.TabIndex = 2
        Label2.Text = "فندق مدينة"
        ' 
        ' TextBoxMadinaQuad
        ' 
        TextBoxMadinaQuad.Font = New Font("Segoe UI", 15F)
        TextBoxMadinaQuad.Location = New Point(155, 171)
        TextBoxMadinaQuad.Name = "TextBoxMadinaQuad"
        TextBoxMadinaQuad.Size = New Size(182, 34)
        TextBoxMadinaQuad.TabIndex = 5
        TextBoxMadinaQuad.Text = "رباعي"
        TextBoxMadinaQuad.TextAlign = HorizontalAlignment.Right
        ' 
        ' TextBoxMadinaDouble
        ' 
        TextBoxMadinaDouble.Font = New Font("Segoe UI", 15F)
        TextBoxMadinaDouble.Location = New Point(155, 91)
        TextBoxMadinaDouble.Name = "TextBoxMadinaDouble"
        TextBoxMadinaDouble.Size = New Size(182, 34)
        TextBoxMadinaDouble.TabIndex = 3
        TextBoxMadinaDouble.Text = "ثنائي"
        TextBoxMadinaDouble.TextAlign = HorizontalAlignment.Right
        ' 
        ' TextBoxMadinaTriple
        ' 
        TextBoxMadinaTriple.Font = New Font("Segoe UI", 15F)
        TextBoxMadinaTriple.Location = New Point(155, 131)
        TextBoxMadinaTriple.Name = "TextBoxMadinaTriple"
        TextBoxMadinaTriple.Size = New Size(182, 34)
        TextBoxMadinaTriple.TabIndex = 4
        TextBoxMadinaTriple.Text = "ثلاثي"
        TextBoxMadinaTriple.TextAlign = HorizontalAlignment.Right
        ' 
        ' TextBoxMakaQuad
        ' 
        TextBoxMakaQuad.Font = New Font("Segoe UI", 15F)
        TextBoxMakaQuad.Location = New Point(155, 171)
        TextBoxMakaQuad.Name = "TextBoxMakaQuad"
        TextBoxMakaQuad.Size = New Size(182, 34)
        TextBoxMakaQuad.TabIndex = 3
        TextBoxMakaQuad.Text = "رباعي"
        TextBoxMakaQuad.TextAlign = HorizontalAlignment.Right
        ' 
        ' TextBoxMakaTriple
        ' 
        TextBoxMakaTriple.Font = New Font("Segoe UI", 15F)
        TextBoxMakaTriple.Location = New Point(155, 131)
        TextBoxMakaTriple.Name = "TextBoxMakaTriple"
        TextBoxMakaTriple.Size = New Size(182, 34)
        TextBoxMakaTriple.TabIndex = 4
        TextBoxMakaTriple.Text = "ثلاثي"
        TextBoxMakaTriple.TextAlign = HorizontalAlignment.Right
        ' 
        ' TextBoxMakaDouble
        ' 
        TextBoxMakaDouble.Font = New Font("Segoe UI", 15F)
        TextBoxMakaDouble.Location = New Point(155, 91)
        TextBoxMakaDouble.Name = "TextBoxMakaDouble"
        TextBoxMakaDouble.Size = New Size(182, 34)
        TextBoxMakaDouble.TabIndex = 5
        TextBoxMakaDouble.Text = "ثنائي"
        TextBoxMakaDouble.TextAlign = HorizontalAlignment.Right
        ' 
        ' Panel3
        ' 
        Panel3.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Panel3.BackColor = Color.FromArgb(0, 192, 0)
        Panel3.Controls.Add(Label5)
        Panel3.Controls.Add(TextBoxTotalRoomsMaka)
        Panel3.Controls.Add(TextBoxMakaDouble)
        Panel3.Controls.Add(TextBoxMakaTriple)
        Panel3.Controls.Add(TextBoxMakaQuad)
        Panel3.Controls.Add(Label3)
        Panel3.Controls.Add(TextBoxMakaHotelName)
        Panel3.Location = New Point(1149, 481)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(352, 214)
        Panel3.TabIndex = 7
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(266, 73)
        Label5.Name = "Label5"
        Label5.Size = New Size(74, 15)
        Label5.TabIndex = 7
        Label5.Text = "عدد غرف مكه"
        ' 
        ' TextBoxTotalRoomsMaka
        ' 
        TextBoxTotalRoomsMaka.Font = New Font("Segoe UI", 15F)
        TextBoxTotalRoomsMaka.Location = New Point(3, 69)
        TextBoxTotalRoomsMaka.Multiline = True
        TextBoxTotalRoomsMaka.Name = "TextBoxTotalRoomsMaka"
        TextBoxTotalRoomsMaka.Size = New Size(149, 136)
        TextBoxTotalRoomsMaka.TabIndex = 6
        TextBoxTotalRoomsMaka.Text = "مجموع غرف مكة"
        TextBoxTotalRoomsMaka.TextAlign = HorizontalAlignment.Center
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(289, -3)
        Label3.Name = "Label3"
        Label3.RightToLeft = RightToLeft.Yes
        Label3.Size = New Size(54, 15)
        Label3.TabIndex = 2
        Label3.Text = "فندق مكه"
        ' 
        ' TextBoxMakaHotelName
        ' 
        TextBoxMakaHotelName.Font = New Font("Segoe UI", 15F)
        TextBoxMakaHotelName.Location = New Point(3, 29)
        TextBoxMakaHotelName.Name = "TextBoxMakaHotelName"
        TextBoxMakaHotelName.Size = New Size(334, 34)
        TextBoxMakaHotelName.TabIndex = 1
        TextBoxMakaHotelName.Text = "مكه"
        TextBoxMakaHotelName.TextAlign = HorizontalAlignment.Right
        ' 
        ' Panel4
        ' 
        Panel4.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right
        Panel4.BackColor = Color.Lime
        Panel4.Controls.Add(TextBox18)
        Panel4.Controls.Add(Label9)
        Panel4.Controls.Add(TextBox17)
        Panel4.Controls.Add(Label8)
        Panel4.Controls.Add(Label7)
        Panel4.Controls.Add(TextBox16)
        Panel4.Controls.Add(Label6)
        Panel4.Controls.Add(SumMutmer)
        Panel4.Controls.Add(TextBoxChildPrice)
        Panel4.Controls.Add(TextBoxInfantPrice)
        Panel4.Controls.Add(TextBoxAdultPrice)
        Panel4.Location = New Point(1149, 701)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(352, 264)
        Panel4.TabIndex = 8
        ' 
        ' TextBox18
        ' 
        TextBox18.Font = New Font("Segoe UI", 15F)
        TextBox18.Location = New Point(161, 178)
        TextBox18.Name = "TextBox18"
        TextBox18.Size = New Size(179, 34)
        TextBox18.TabIndex = 13
        TextBox18.Text = "طفل"
        TextBox18.TextAlign = HorizontalAlignment.Right
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(170, 221)
        Label9.Name = "Label9"
        Label9.RightToLeft = RightToLeft.Yes
        Label9.Size = New Size(66, 15)
        Label9.TabIndex = 12
        Label9.Text = "سعر  الطفل"
        ' 
        ' TextBox17
        ' 
        TextBox17.Font = New Font("Segoe UI", 15F)
        TextBox17.Location = New Point(161, 98)
        TextBox17.Name = "TextBox17"
        TextBox17.Size = New Size(179, 34)
        TextBox17.TabIndex = 11
        TextBox17.Text = "رضيع"
        TextBox17.TextAlign = HorizontalAlignment.Right
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(173, 152)
        Label8.Name = "Label8"
        Label8.RightToLeft = RightToLeft.Yes
        Label8.Size = New Size(66, 15)
        Label8.TabIndex = 10
        Label8.Text = "سعر الرضيع"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(179, 72)
        Label7.Name = "Label7"
        Label7.RightToLeft = RightToLeft.Yes
        Label7.Size = New Size(57, 15)
        Label7.TabIndex = 9
        Label7.Text = "سعر البالغ"
        ' 
        ' TextBox16
        ' 
        TextBox16.Font = New Font("Segoe UI", 15F)
        TextBox16.Location = New Point(164, 18)
        TextBox16.Name = "TextBox16"
        TextBox16.Size = New Size(179, 34)
        TextBox16.TabIndex = 8
        TextBox16.Text = "بالغ"
        TextBox16.TextAlign = HorizontalAlignment.Right
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(255, 0)
        Label6.Name = "Label6"
        Label6.RightToLeft = RightToLeft.Yes
        Label6.Size = New Size(85, 15)
        Label6.TabIndex = 7
        Label6.Text = "اعداد المعتمرين"
        ' 
        ' SumMutmer
        ' 
        SumMutmer.Font = New Font("Segoe UI", 15F)
        SumMutmer.Location = New Point(3, 3)
        SumMutmer.Multiline = True
        SumMutmer.Name = "SumMutmer"
        SumMutmer.Size = New Size(155, 249)
        SumMutmer.TabIndex = 6
        SumMutmer.Text = "مجموع المعتمرين"
        SumMutmer.TextAlign = HorizontalAlignment.Center
        ' 
        ' TextBoxChildPrice
        ' 
        TextBoxChildPrice.Font = New Font("Segoe UI", 15F)
        TextBoxChildPrice.Location = New Point(237, 218)
        TextBoxChildPrice.Name = "TextBoxChildPrice"
        TextBoxChildPrice.Size = New Size(101, 34)
        TextBoxChildPrice.TabIndex = 5
        TextBoxChildPrice.Text = "0"
        TextBoxChildPrice.TextAlign = HorizontalAlignment.Right
        ' 
        ' TextBoxInfantPrice
        ' 
        TextBoxInfantPrice.Font = New Font("Segoe UI", 15F)
        TextBoxInfantPrice.Location = New Point(240, 138)
        TextBoxInfantPrice.Name = "TextBoxInfantPrice"
        TextBoxInfantPrice.Size = New Size(98, 34)
        TextBoxInfantPrice.TabIndex = 4
        TextBoxInfantPrice.Text = "0"
        TextBoxInfantPrice.TextAlign = HorizontalAlignment.Right
        ' 
        ' TextBoxAdultPrice
        ' 
        TextBoxAdultPrice.Font = New Font("Segoe UI", 15F)
        TextBoxAdultPrice.Location = New Point(242, 58)
        TextBoxAdultPrice.Name = "TextBoxAdultPrice"
        TextBoxAdultPrice.Size = New Size(98, 34)
        TextBoxAdultPrice.TabIndex = 3
        TextBoxAdultPrice.Text = "0"
        TextBoxAdultPrice.TextAlign = HorizontalAlignment.Right
        ' 
        ' Form2
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1513, 987)
        Controls.Add(Panel4)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Controls.Add(RichTextBox1)
        Name = "Form2"
        Text = "ابرام عقد"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents ButtonPrint As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TextBoxTotalRoomsMadina As TextBox
    Friend WithEvents TextBoxMakaDouble As TextBox
    Friend WithEvents TextBoxMakaTriple As TextBox
    Friend WithEvents TextBoxMakaQuad As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBoxTotalRoomsMaka As TextBox
    Friend WithEvents TextBoxMadinaQuad As TextBox
    Friend WithEvents TextBoxMadinaTriple As TextBox
    Friend WithEvents TextBoxMadinaDouble As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBoxMakaHotelName As TextBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents SumMutmer As TextBox
    Friend WithEvents TextBoxChildPrice As TextBox
    Friend WithEvents TextBoxInfantPrice As TextBox
    Friend WithEvents TextBoxAdultPrice As TextBox
    Friend WithEvents TextBox18 As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TextBox17 As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents TextBox16 As TextBox
    Friend WithEvents LabelContractNumber As Label
    Friend WithEvents TextBoxMadinaHotelName As TextBox
End Class
