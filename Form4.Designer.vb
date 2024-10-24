<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form4
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form4))
        TextBox2 = New TextBox()
        Label1 = New Label()
        BtnCalculateTotal = New Button()
        PictureBox1 = New PictureBox()
        TextBoxCustomerName = New TextBox()
        TextBoxReservationNumber = New TextBox()
        TextBoxPhoneNumber = New TextBox()
        TextBoxInvoiceNumber = New TextBox()
        TextBoxRoomCount = New TextBox()
        TextBoxNightsCount = New TextBox()
        TextBoxRoomPrice = New TextBox()
        TextBoxTotal = New TextBox()
        TextBoxOverallTotal = New TextBox()
        BtnPrint = New Button()
        TextBoxHotelName = New TextBox()
        DateTimePickerReservationDate = New DateTimePicker()
        Label2 = New Label()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' TextBox2
        ' 
        TextBox2.Font = New Font("Montserrat-Arabic", 9F)
        TextBox2.Location = New Point(427, 188)
        TextBox2.Multiline = True
        TextBox2.Name = "TextBox2"
        TextBox2.RightToLeft = RightToLeft.Yes
        TextBox2.Size = New Size(199, 24)
        TextBox2.TabIndex = 15
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Montserrat-Arabic", 12F)
        Label1.Location = New Point(124, 186)
        Label1.Name = "Label1"
        Label1.RightToLeft = RightToLeft.Yes
        Label1.Size = New Size(0, 26)
        Label1.TabIndex = 26
        ' 
        ' BtnCalculateTotal
        ' 
        BtnCalculateTotal.AutoSizeMode = AutoSizeMode.GrowAndShrink
        BtnCalculateTotal.BackColor = Color.White
        BtnCalculateTotal.BackgroundImageLayout = ImageLayout.Center
        BtnCalculateTotal.Font = New Font("Montserrat-Arabic", 25F)
        BtnCalculateTotal.Location = New Point(346, 675)
        BtnCalculateTotal.Name = "BtnCalculateTotal"
        BtnCalculateTotal.Size = New Size(317, 199)
        BtnCalculateTotal.TabIndex = 25
        BtnCalculateTotal.Text = "طباعه"
        BtnCalculateTotal.UseVisualStyleBackColor = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(1, -2)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(808, 1022)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 14
        PictureBox1.TabStop = False
        ' 
        ' TextBoxCustomerName
        ' 
        TextBoxCustomerName.Font = New Font("Montserrat-Arabic", 9F)
        TextBoxCustomerName.Location = New Point(346, 256)
        TextBoxCustomerName.Multiline = True
        TextBoxCustomerName.Name = "TextBoxCustomerName"
        TextBoxCustomerName.RightToLeft = RightToLeft.Yes
        TextBoxCustomerName.Size = New Size(199, 24)
        TextBoxCustomerName.TabIndex = 27
        ' 
        ' TextBoxReservationNumber
        ' 
        TextBoxReservationNumber.Font = New Font("Montserrat-Arabic", 9F)
        TextBoxReservationNumber.Location = New Point(475, 280)
        TextBoxReservationNumber.Multiline = True
        TextBoxReservationNumber.Name = "TextBoxReservationNumber"
        TextBoxReservationNumber.RightToLeft = RightToLeft.Yes
        TextBoxReservationNumber.Size = New Size(199, 24)
        TextBoxReservationNumber.TabIndex = 28
        ' 
        ' TextBoxPhoneNumber
        ' 
        TextBoxPhoneNumber.Font = New Font("Montserrat-Arabic", 9F)
        TextBoxPhoneNumber.Location = New Point(449, 304)
        TextBoxPhoneNumber.Multiline = True
        TextBoxPhoneNumber.Name = "TextBoxPhoneNumber"
        TextBoxPhoneNumber.RightToLeft = RightToLeft.Yes
        TextBoxPhoneNumber.Size = New Size(199, 24)
        TextBoxPhoneNumber.TabIndex = 29
        ' 
        ' TextBoxInvoiceNumber
        ' 
        TextBoxInvoiceNumber.Font = New Font("Montserrat-Arabic", 9F)
        TextBoxInvoiceNumber.Location = New Point(475, 118)
        TextBoxInvoiceNumber.Multiline = True
        TextBoxInvoiceNumber.Name = "TextBoxInvoiceNumber"
        TextBoxInvoiceNumber.RightToLeft = RightToLeft.Yes
        TextBoxInvoiceNumber.Size = New Size(199, 24)
        TextBoxInvoiceNumber.TabIndex = 30
        ' 
        ' TextBoxRoomCount
        ' 
        TextBoxRoomCount.Font = New Font("Montserrat-Arabic", 9F)
        TextBoxRoomCount.Location = New Point(490, 424)
        TextBoxRoomCount.Multiline = True
        TextBoxRoomCount.Name = "TextBoxRoomCount"
        TextBoxRoomCount.RightToLeft = RightToLeft.Yes
        TextBoxRoomCount.Size = New Size(110, 50)
        TextBoxRoomCount.TabIndex = 31
        ' 
        ' TextBoxNightsCount
        ' 
        TextBoxNightsCount.Font = New Font("Montserrat-Arabic", 9F)
        TextBoxNightsCount.Location = New Point(380, 424)
        TextBoxNightsCount.Multiline = True
        TextBoxNightsCount.Name = "TextBoxNightsCount"
        TextBoxNightsCount.RightToLeft = RightToLeft.Yes
        TextBoxNightsCount.Size = New Size(110, 50)
        TextBoxNightsCount.TabIndex = 32
        ' 
        ' TextBoxRoomPrice
        ' 
        TextBoxRoomPrice.Font = New Font("Montserrat-Arabic", 9F)
        TextBoxRoomPrice.Location = New Point(263, 424)
        TextBoxRoomPrice.Multiline = True
        TextBoxRoomPrice.Name = "TextBoxRoomPrice"
        TextBoxRoomPrice.RightToLeft = RightToLeft.Yes
        TextBoxRoomPrice.Size = New Size(116, 50)
        TextBoxRoomPrice.TabIndex = 33
        ' 
        ' TextBoxTotal
        ' 
        TextBoxTotal.Font = New Font("Montserrat-Arabic", 9F)
        TextBoxTotal.Location = New Point(137, 424)
        TextBoxTotal.Multiline = True
        TextBoxTotal.Name = "TextBoxTotal"
        TextBoxTotal.RightToLeft = RightToLeft.Yes
        TextBoxTotal.Size = New Size(126, 50)
        TextBoxTotal.TabIndex = 34
        ' 
        ' TextBoxOverallTotal
        ' 
        TextBoxOverallTotal.Font = New Font("Montserrat-Arabic", 9F)
        TextBoxOverallTotal.Location = New Point(500, 582)
        TextBoxOverallTotal.Multiline = True
        TextBoxOverallTotal.Name = "TextBoxOverallTotal"
        TextBoxOverallTotal.RightToLeft = RightToLeft.Yes
        TextBoxOverallTotal.Size = New Size(126, 50)
        TextBoxOverallTotal.TabIndex = 35
        ' 
        ' BtnPrint
        ' 
        BtnPrint.AutoSizeMode = AutoSizeMode.GrowAndShrink
        BtnPrint.BackColor = Color.White
        BtnPrint.BackgroundImageLayout = ImageLayout.Center
        BtnPrint.Font = New Font("Montserrat-Arabic", 25F)
        BtnPrint.Location = New Point(23, 675)
        BtnPrint.Name = "BtnPrint"
        BtnPrint.Size = New Size(317, 199)
        BtnPrint.TabIndex = 36
        BtnPrint.Text = "طباعه"
        BtnPrint.UseVisualStyleBackColor = False
        ' 
        ' TextBoxHotelName
        ' 
        TextBoxHotelName.Font = New Font("Montserrat-Arabic", 9F)
        TextBoxHotelName.Location = New Point(597, 424)
        TextBoxHotelName.Multiline = True
        TextBoxHotelName.Name = "TextBoxHotelName"
        TextBoxHotelName.RightToLeft = RightToLeft.Yes
        TextBoxHotelName.Size = New Size(169, 50)
        TextBoxHotelName.TabIndex = 37
        ' 
        ' DateTimePickerReservationDate
        ' 
        DateTimePickerReservationDate.Location = New Point(32, 424)
        DateTimePickerReservationDate.Name = "DateTimePickerReservationDate"
        DateTimePickerReservationDate.Size = New Size(107, 23)
        DateTimePickerReservationDate.TabIndex = 38
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Montserrat-Arabic", 12F)
        Label2.Location = New Point(128, 186)
        Label2.Name = "Label2"
        Label2.Size = New Size(613, 52)
        Label2.TabIndex = 39
        Label2.Text = "السادة شركة (                                                    ) المحترمين نرجو التفضل بتسديد الفاتورة " & vbCrLf & "واضافته على حسابينا ." & vbCrLf
        Label2.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' Form4
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(807, 985)
        Controls.Add(TextBox2)
        Controls.Add(Label2)
        Controls.Add(DateTimePickerReservationDate)
        Controls.Add(TextBoxHotelName)
        Controls.Add(BtnPrint)
        Controls.Add(TextBoxOverallTotal)
        Controls.Add(TextBoxTotal)
        Controls.Add(TextBoxRoomPrice)
        Controls.Add(TextBoxNightsCount)
        Controls.Add(TextBoxRoomCount)
        Controls.Add(TextBoxInvoiceNumber)
        Controls.Add(TextBoxPhoneNumber)
        Controls.Add(TextBoxReservationNumber)
        Controls.Add(TextBoxCustomerName)
        Controls.Add(Label1)
        Controls.Add(BtnCalculateTotal)
        Controls.Add(PictureBox1)
        MaximumSize = New Size(823, 1024)
        MinimumSize = New Size(823, 1024)
        Name = "Form4"
        Text = "سداد فواتير "
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnCalculateTotal As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents TextBoxCustomerName As TextBox
    Friend WithEvents TextBoxReservationNumber As TextBox
    Friend WithEvents TextBoxPhoneNumber As TextBox
    Friend WithEvents TextBoxInvoiceNumber As TextBox
    Friend WithEvents TextBoxRoomCount As TextBox
    Friend WithEvents TextBoxNightsCount As TextBox
    Friend WithEvents TextBoxRoomPrice As TextBox
    Friend WithEvents TextBoxTotal As TextBox
    Friend WithEvents TextBoxOverallTotal As TextBox
    Friend WithEvents BtnPrint As Button
    Friend WithEvents TextBoxHotelName As TextBox
    Friend WithEvents DateTimePickerReservationDate As DateTimePicker
    Friend WithEvents Label2 As Label
End Class
