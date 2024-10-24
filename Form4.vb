Imports Firebase.Database
Imports System.Drawing.Printing
Imports System.IO
Imports FireSharp.Config
Imports FireSharp.Interfaces
Imports FireSharp.Response

Public Class Form4
    ' المتغيرات العامة
    Private invoiceImage As Image
    Private WithEvents PrintDocument1 As New PrintDocument()
    Private PrintPreviewDialog1 As New PrintPreviewDialog()

    ' إعداد الاتصال بـ Firebase
    Private fcon As New FirebaseConfig() With {
        .AuthSecret = "ضع_هنا_المفتاح_السرّي_من_Firebase",
        .BasePath = "https://umrahprograming-default-rtdb.firebaseio.com/"
    }
    Private client As IFirebaseClient

    ' عند تحميل النموذج، قم بتحميل صورة الفاتورة إلى PictureBox
    Private Sub InvoiceForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' الاتصال بـ Firebase
            client = New FireSharp.FirebaseClient(fcon)

            If client Is Nothing Then
                MessageBox.Show("فشل الاتصال بـ Firebase.")
                Return
            End If

            invoiceImage = Image.FromFile(My.Settings.ImageInvois) ' ضع هنا مسار الصورة
            PictureBox1.Image = invoiceImage

            ' توليد رقم فاتورة جديد
            Dim invoiceNumber As String = GetNextInvoiceNumber()
            TextBoxInvoiceNumber.Text = invoiceNumber
        Catch ex As Exception
            MessageBox.Show("حدث خطأ في تحميل الصورة: " & ex.Message)
        End Try
    End Sub

    ' الحصول على رقم الفاتورة التالي من Firebase
    Private Function GetNextInvoiceNumber() As String
        Try
            Dim result = client.Get("Invoices")
            Dim invoices = result.ResultAs(Of Dictionary(Of String, Invoice))
            Dim nextNumber As Integer = 1

            If invoices IsNot Nothing AndAlso invoices.Count > 0 Then
                nextNumber = invoices.Values.Max(Function(i) CInt(i.InvoiceNumber)) + 1
            End If

            Return nextNumber.ToString("D6") ' تنسيق الرقم مع صفر بادئ إذا لزم الأمر
        Catch ex As Exception
            MessageBox.Show("حدث خطأ في جلب رقم الفاتورة التالي: " & ex.Message)
            Return "000001"
        End Try
    End Function

    ' زر لحساب المجموع
    Private Sub BtnCalculateTotal_Click(sender As Object, e As EventArgs) Handles BtnCalculateTotal.Click
        Try
            Dim roomCount As Integer = Integer.Parse(TextBoxRoomCount.Text)
            Dim nightsCount As Integer = Integer.Parse(TextBoxNightsCount.Text)
            Dim roomPrice As Decimal = Decimal.Parse(TextBoxRoomPrice.Text)

            ' حساب المجموع لكل صف
            Dim total As Decimal = roomCount * nightsCount * roomPrice
            TextBoxTotal.Text = total.ToString("F2")

            ' حساب الإجمالي الكلي (إذا كانت هناك صفوف متعددة)
            Dim overallTotal As Decimal = total ' هنا يمكن إضافة إجمالي آخر
            TextBoxOverallTotal.Text = overallTotal.ToString("F2")
        Catch ex As Exception
            MessageBox.Show("تأكد من إدخال البيانات بشكل صحيح: " & ex.Message)
        End Try
    End Sub

    ' زر لعرض المعاينة قبل الطباعة
    Private Sub BtnPrintPreview_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        SaveInvoice()

        Try
            PrintPreviewDialog1.Document = PrintDocument1
            PrintPreviewDialog1.ShowDialog()
        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء المعاينة: " & ex.Message)
        End Try
    End Sub

    ' زر لحفظ الفاتورة في قاعدة بيانات Firebase
    Private Sub SaveInvoice()
        Try
            Dim invoice As New Invoice() With {
                .InvoiceNumber = TextBoxInvoiceNumber.Text,
                .CustomerName = TextBoxCustomerName.Text,
                .ReservationNumber = TextBoxReservationNumber.Text,
                .PhoneNumber = TextBoxPhoneNumber.Text,
                .HotelName = TextBoxHotelName.Text,
                .RoomCount = Integer.Parse(TextBoxRoomCount.Text),
                .NightsCount = Integer.Parse(TextBoxNightsCount.Text),
                .RoomPrice = Decimal.Parse(TextBoxRoomPrice.Text),
                .Total = Decimal.Parse(TextBoxTotal.Text),
                .OverallTotal = Decimal.Parse(TextBoxOverallTotal.Text),
                .ReservationDate = DateTimePickerReservationDate.Value.ToString("yyyy-MM-dd")
            }

            ' إدخال الفاتورة في قاعدة بيانات Firebase
            Dim response As SetResponse = client.Set("Invoices/" & invoice.InvoiceNumber, invoice)
            MessageBox.Show("تم حفظ الفاتورة بنجاح.")
        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء حفظ الفاتورة: " & ex.Message)
        End Try
    End Sub

    ' التعامل مع طباعة الفاتورة
    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument1.PrintPage
        ' طباعة صورة الفاتورة كخلفية
        e.Graphics.DrawImage(invoiceImage, 0, 0)

        ' طباعة رقم الفاتورة
        e.Graphics.DrawString(TextBoxInvoiceNumber.Text, New Font("Montserrat-Arabic", 12), Brushes.Black, New Point(620, 140))
        e.Graphics.DrawString("السادة شركة (" & TextBox2.Text & ") المحترمين نرجو التفضل بتسديد الفاتورة واضافته على حسابينا.", New Font("Montserrat-Arabic", 12), Brushes.Black, New Point(40, 240))

        ' طباعة البيانات المدخلة (اسم العميل، رقم الحجز، وغيرها)
        e.Graphics.DrawString(TextBoxCustomerName.Text, New Font("Montserrat-Arabic", 12), Brushes.Black, New Point(470, 300))
        e.Graphics.DrawString(TextBoxReservationNumber.Text, New Font("Montserrat-Arabic", 12), Brushes.Black, New Point(600, 325))
        e.Graphics.DrawString(TextBoxPhoneNumber.Text, New Font("Montserrat-Arabic", 12), Brushes.Black, New Point(575, 350))

        ' طباعة تفاصيل الحجز
        e.Graphics.DrawString(TextBoxHotelName.Text, New Font("Montserrat-Arabic", 12), Brushes.Black, New Point(675, 500))
        e.Graphics.DrawString(TextBoxRoomCount.Text, New Font("Montserrat-Arabic", 12), Brushes.Black, New Point(525, 500))
        e.Graphics.DrawString(TextBoxNightsCount.Text, New Font("Montserrat-Arabic", 12), Brushes.Black, New Point(400, 500))
        e.Graphics.DrawString(TextBoxRoomPrice.Text & "ر.ع", New Font("Montserrat-Arabic", 12), Brushes.Black, New Point(300, 500))
        e.Graphics.DrawString(TextBoxTotal.Text & "ر.ع", New Font("Montserrat-Arabic", 12), Brushes.Black, New Point(175, 500))

        ' طباعة تاريخ الحجز
        e.Graphics.DrawString(DateTimePickerReservationDate.Value.ToString("dd/MM/yyyy"), New Font("Montserrat-Arabic", 12), Brushes.Black, New Point(35, 500))

        If TextBoxOverallTotal.Text = Nothing Then
            TextBoxOverallTotal.Text = 0
        Else
            e.Graphics.DrawString(TextBoxOverallTotal.Text & "ر.ع", New Font("Montserrat-Arabic", 12), Brushes.Black, New Point(550, 565))
            e.Graphics.DrawString(Math.Round(TextBoxOverallTotal.Text / 3.75, 0).ToString() & "$", New Font("Montserrat-Arabic", 12), Brushes.Black, New Point(550, 690))
        End If
    End Sub
End Class

' تعريف الفاتورة
Public Class Invoice
    Public Property InvoiceNumber As String
    Public Property CustomerName As String
    Public Property ReservationNumber As String
    Public Property PhoneNumber As String
    Public Property HotelName As String
    Public Property RoomCount As Integer
    Public Property NightsCount As Integer
    Public Property RoomPrice As Decimal
    Public Property Total As Decimal
    Public Property OverallTotal As Decimal
    Public Property ReservationDate As String
End Class
