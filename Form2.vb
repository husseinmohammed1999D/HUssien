Imports Firebase.Database
Imports Firebase.Database.Query
Imports Newtonsoft.Json
Imports System.Drawing.Printing
Imports System.IO
Imports System.Net.Http
Imports System.Text
Imports System.Threading
Public Class Form2
    Private firebaseClient As New FirebaseClient("https://umrahprograming-default-rtdb.firebaseio.com/")
    Private LastContractNumber = GetLastContractNumber()

    Private newContractNumber As Integer
    Private ContractNumber As Integer = 1 ' تهيئة ContractNumber بقيمة ابتدائية

    Dim MadenaPrice As Decimal = Decimal.Parse(Form1.TextBox2.Text)
    Dim nigtMadina As Integer = Integer.Parse(Form1.TextBox3.Text)
    Dim nigtmaka As Integer = Integer.Parse(Form1.TextBox5.Text)
    Dim MakaPrice As Decimal = Decimal.Parse(Form1.TextBox4.Text)

    Dim form1Instance As New Form1()
    Dim programPrices = form1Instance.CAL()

    Dim programPriceQuad As Decimal = programPrices.Item1
    Dim programPriceDouble As Decimal = programPrices.Item2
    Dim programPriceTriple As Decimal = programPrices.Item3

    Dim grandTotal As Decimal

    Async Function GetLastContractNumber() As Task(Of Integer)
        Try
            ' جلب آخر رقم عقد من Firebase
            Dim lastContractRef = firebaseClient.Child("LastContractNumber")
            Dim lastContractData = Await lastContractRef.OnceSingleAsync(Of Integer)()
            If lastContractData = 0 Then

            End If
            Return lastContractData
        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء جلب آخر رقم عقد: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 0 ' إذا حدث خطأ، نبدأ من 0
        End Try
    End Function

    Private Async Function UpdateLastContractNumber(newNumber As Integer) As Task
        Try
            ' تحديث آخر رقم عقد في Firebase
            Dim lastContractRef = firebaseClient.Child("LastContractNumber")
            Await lastContractRef.PutAsync(newNumber)
        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء تحديث آخر رقم عقد: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function


    Public Async Function SaveContractToFirebase(contract As Contract) As Task(Of Integer)
        Try
            ' الحصول على آخر رقم عقد من Firebase
            Dim lastContractNumber = Await GetLastContractNumber() + 1

            ' زيادة الرقم لخلق رقم عقد جديد
            Dim newContractNumber = lastContractNumber

            ' تعيين رقم العقد للكائن
            contract.ContractNumber = newContractNumber

            ' حفظ العقد داخل Contracts مع رقم عقد جديد
            Await firebaseClient.Child("Contracts").Child(newContractNumber.ToString()).PutAsync(contract)

            ' تحديث آخر رقم عقد في Firebase
            Await UpdateLastContractNumber(newContractNumber)

            Return newContractNumber
        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء حفظ العقد: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
    End Function


    Private Sub ConfigurePrintDocument(printDocument As PrintDocument)
        Dim a4PaperSize As New PaperSize("A4", 827, 1169)
        printDocument.DefaultPageSettings.PaperSize = a4PaperSize
        printDocument.PrinterSettings.Copies = 3
        AddHandler printDocument.PrintPage, AddressOf OnPrintPage
    End Sub
    Private Sub OnPrintPage(sender As Object, e As PrintPageEventArgs)
        Try
            Using graphics As Graphics = e.Graphics
                Dim font As New Font("Arial", 12.5, FontStyle.Bold)
                Dim brush As New SolidBrush(Color.Black)
                Dim format As New StringFormat() With {
                    .Alignment = StringAlignment.Far,
                    .LineAlignment = StringAlignment.Center
                }

                DrawLogoImage(graphics, e.PageBounds)

                DrawTables(graphics, font, brush, format)
                DrawDetails(graphics, font, brush, format, e.PageBounds, newContractNumber)

                e.HasMorePages = False
            End Using
        Catch ex As InvalidOperationException
            MessageBox.Show("InvalidOperationException occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DrawLogoImage(graphics As Graphics, pageBounds As Rectangle)
        Dim imagePath As String = My.Settings.Image

        If Not String.IsNullOrEmpty(imagePath) AndAlso System.IO.File.Exists(imagePath) Then
            Using logoImage As Image = Image.FromFile(imagePath)
                Dim logoRectangle As New Rectangle(0, 0, pageBounds.Width, pageBounds.Height)

                graphics.DrawImage(logoImage, logoRectangle)
            End Using
        Else
            MessageBox.Show("Image not found at the specified path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub DrawTables(graphics As Graphics, font As Font, brush As SolidBrush, format As StringFormat)
        Dim result = Form1.CAL()
        Dim priceQuad As Decimal = result.Item1
        Dim priceDouble As Decimal = result.Item2
        Dim priceTriple As Decimal = result.Item3

        Dim childPrice As Decimal = Decimal.Parse(TextBoxChildPrice.Text)
        Dim infantPrice As Decimal = Decimal.Parse(TextBoxInfantPrice.Text)
        Dim adultPrice As Decimal = Decimal.Parse(TextBoxAdultPrice.Text)

        grandTotal = (childPrice * Decimal.Parse(TextBox18.Text)) +
                      (infantPrice * Decimal.Parse(TextBox17.Text)) +
                      (adultPrice * Decimal.Parse(TextBox16.Text))

        If Integer.Parse(TextBoxMakaDouble.Text) > 0 Or Integer.Parse(TextBoxMadinaDouble.Text) > 0 Then
            grandTotal -= Integer.Parse(TextBoxMakaDouble.Text) * 2 * adultPrice
            grandTotal += Integer.Parse(TextBoxMakaDouble.Text) * 2 * priceDouble
        End If

        If Integer.Parse(TextBoxMakaTriple.Text) > 0 Or Integer.Parse(TextBoxMadinaTriple.Text) > 0 Then
            grandTotal -= Integer.Parse(TextBoxMakaTriple.Text) * 3 * adultPrice
            grandTotal += Integer.Parse(TextBoxMakaTriple.Text) * 3 * priceTriple
        End If

        Dim pageWidth As Integer = 800
        Dim tableX As Integer = pageWidth - 775
        Dim tableY As Integer = 600
        Dim rowHeight As Integer = 30
        Dim columnWidth As Integer = 125

        format.Alignment = StringAlignment.Far

        For i As Integer = 1 To 5
            Dim lineX As Integer = tableX + columnWidth * i
            graphics.DrawLine(Pens.Black, lineX, tableY, lineX, tableY + rowHeight * 8)
        Next

        DrawTableRow(graphics, font, brush, format, tableX, tableY, columnWidth, rowHeight,
                     "سعر البرنامج", "نوع غ", "غ مكة", "فندق مكه", "غ مدينة", "فندق مدينة")
        tableY += rowHeight
        graphics.DrawLine(Pens.Black, tableX, tableY, tableX + columnWidth * 6, tableY)

        DrawTableRow(graphics, font, brush, format, tableX, tableY, columnWidth, rowHeight,
                     priceDouble.ToString("N2"), "ثنائي", TextBoxMakaDouble.Text, TextBoxMakaHotelName.Text, TextBoxMadinaDouble.Text, TextBoxMadinaHotelName.Text)
        tableY += rowHeight
        graphics.DrawLine(Pens.Black, tableX, tableY, tableX + columnWidth * 6, tableY)

        DrawTableRow(graphics, font, brush, format, tableX, tableY, columnWidth, rowHeight,
                     priceTriple.ToString("N2"), "ثلاثي", TextBoxMakaTriple.Text, TextBoxMakaHotelName.Text, TextBoxMadinaTriple.Text, TextBoxMadinaHotelName.Text)
        tableY += rowHeight
        graphics.DrawLine(Pens.Black, tableX, tableY, tableX + columnWidth * 6, tableY)

        DrawTableRow(graphics, font, brush, format, tableX, tableY, columnWidth, rowHeight,
                     priceQuad.ToString("N2"), "رباعي", TextBoxMakaQuad.Text, TextBoxMakaHotelName.Text, TextBoxMadinaQuad.Text, TextBoxMadinaHotelName.Text)

        tableY += rowHeight
        graphics.DrawLine(Pens.Black, tableX, tableY, tableX + columnWidth * 6, tableY)

        Dim s As Integer = (CalculateSum(TextBoxTotalRoomsMadina, TextBoxTotalRoomsMaka)).ToString()
        DrawTableRow(graphics, font, brush, format, tableX, tableY, columnWidth, rowHeight,
                     s, "المجموع", TextBoxTotalRoomsMaka.Text, "م مكه", TextBoxTotalRoomsMadina.Text, "م مدينة")
        tableY += rowHeight
        graphics.DrawLine(Pens.Black, tableX, tableY, tableX + columnWidth * 6, tableY)

        DrawTableRow(graphics, font, brush, format, tableX, tableY, columnWidth, rowHeight,
                     TextBox18.Text, "طفل", TextBox17.Text, "رضيع", TextBox16.Text, "بالغ")
        tableY += rowHeight
        graphics.DrawLine(Pens.Black, tableX, tableY, tableX + columnWidth * 6, tableY)

        DrawTableRow(graphics, font, brush, format, tableX, tableY, columnWidth, rowHeight,
                     childPrice.ToString("N2"), "سعر طفل", infantPrice.ToString("N2"), "سعر رضيع", adultPrice.ToString("N2"), "سعر بالغ")
        tableY += rowHeight
        ' إضافة المجموع الكلي
        DrawTableRow(graphics, font, brush, format, tableX, tableY, columnWidth, rowHeight,
                 grandTotal.ToString("N2"), "المجموع الكلي", "", "", "", "")
        tableY += rowHeight
        graphics.DrawLine(Pens.Black, tableX, tableY, tableX + columnWidth * 6, tableY)
    End Sub
    ' دالة للمساعدة في رسم الصفوف
    Private Sub DrawTableRow(graphics As Graphics, font As Font, brush As SolidBrush, format As StringFormat,
                         tableX As Integer, tableY As Integer, columnWidth As Integer, rowHeight As Integer,
                         ByVal value1 As String, ByVal value2 As String, ByVal value3 As String, ByVal value4 As String,
                         ByVal value5 As String, ByVal value6 As String)
        ' رسم القيم
        graphics.DrawString(value1, font, brush, New RectangleF(tableX, tableY, columnWidth, rowHeight), format)
        graphics.DrawString(value2, font, brush, New RectangleF(tableX + columnWidth, tableY, columnWidth, rowHeight), format)
        graphics.DrawString(value3, font, brush, New RectangleF(tableX + columnWidth * 2, tableY, columnWidth, rowHeight), format)
        graphics.DrawString(value4, font, brush, New RectangleF(tableX + columnWidth * 3, tableY, columnWidth, rowHeight), format)
        graphics.DrawString(value5, font, brush, New RectangleF(tableX + columnWidth * 4, tableY, columnWidth, rowHeight), format)
        graphics.DrawString(value6, font, brush, New RectangleF(tableX + columnWidth * 5, tableY, columnWidth, rowHeight), format)
    End Sub
    Private Async Sub DrawDetails(graphics As Graphics, font As Font, brush As SolidBrush, format As StringFormat, pageBounds As Rectangle, contractNumber As Integer)
        ' Ensure font and brush are valid
        If font Is Nothing OrElse brush Is Nothing Then
            Throw New ArgumentNullException("Font or brush cannot be null.")
        End If

        ' إنشاء StringBuilder لإضافة تفاصيل النص
        Dim sb As New System.Text.StringBuilder()

        ' حساب مجموع الليالي
        Dim totalNights As Integer
        totalNights = nigtmaka + nigtMadina


        ' إضافة رقم العقد إلى التفاصيل
        sb.AppendLine(LabelContractNumber.Text)
        sb.AppendLine($"تم الاتفاق بين الطرف الأول شركة المدينة المنورة العالمية للحج والعمرة والطرف الثاني السيد ({TextBox1.Text}) لسنة {Date.Now.ToString("yyyy-MM-dd")} على ما يلي تنظيم برنامج عمرة لمدة ({totalNights}) ليالي وعدد معتمرين عدد {SumMutmer.Text}")
        sb.AppendLine(RichTextBox1.Text)

        ' تحويل StringBuilder إلى نص
        Dim details As String = sb.ToString()

        ' Define the layout rectangle
        Dim layoutRectangle As New RectangleF(50, -30, Math.Max(0, pageBounds.Width - 100), Math.Max(0, pageBounds.Height - 200))

        ' رسم النص مع التفاصيل على الصفحة
        graphics.DrawString(details, font, brush, layoutRectangle, format)

        ' إنشاء نص التوقيع
        Dim signatureText As String = "توقيع الطرف الأول                                                                               توقيع الطرف الثاني"

        ' حساب موقع التوقيع بناءً على ارتفاع الصفحة وارتفاع النص
        Dim signaturePositionY As Single = Math.Max(pageBounds.Top, pageBounds.Height - 300)

        ' رسم التوقيع في الجزء السفلي من الصفحة
        graphics.DrawString(signatureText, font, brush, New RectangleF(50, signaturePositionY, pageBounds.Width - 100, 100), format)
    End Sub

    Private Sub CalculateTotals()
        ' حساب القيم للمجموعات وتحديث الحقول
        TextBoxTotalRoomsMaka.Text = (CalculateSum(TextBoxMakaDouble, TextBoxMakaTriple, TextBoxMakaQuad)).ToString()
        TextBoxTotalRoomsMadina.Text = (CalculateSum(TextBoxMadinaDouble, TextBoxMadinaTriple, TextBoxMadinaQuad)).ToString()
        SumMutmer.Text = (CalculateSum(TextBox16, TextBox17, TextBox18)).ToString()
    End Sub
    Private Function CalculateSum(ParamArray textboxes As TextBox()) As Decimal
        Dim sum As Decimal = 0
        For Each textbox As TextBox In textboxes
            Dim value As Decimal
            Decimal.TryParse(textbox.Text, value)
            sum += value
        Next
        Return sum
    End Function
    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint
        CalculateTotals()
    End Sub
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        CalculateTotals()

    End Sub
    Private Function CalculatePrice(price As Decimal, nights As Integer, multiplier As Integer, value As String) As String
        Try
            ' التحقق من أن value يمكن تحويله إلى Decimal
            Dim numericValue As Decimal
            If Decimal.TryParse(value, numericValue) Then
                ' حساب السعر
                Dim calculatedPrice As Decimal = (price * nights / multiplier / 3.72 * numericValue * multiplier)
                Return calculatedPrice.ToString("N2") ' تحويل النتيجة إلى نص مع تنسيق رقمين بعد الفاصلة العشرية
            Else
                ' إذا كانت القيمة غير صالحة، إرجاع رسالة أو قيمة افتراضية
                Return "Invalid value"
            End If
        Catch ex As Exception
            ' في حالة حدوث أي خطأ آخر، إرجاع رسالة خطأ
            Return "Error calculating price"
        End Try
    End Function
    Private Sub TextBoxAdultPrice_TextChanged(sender As Object, e As EventArgs)
        Form1.CAL()

    End Sub
    Private Async Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim result = Form1.CAL()
        Dim priceQuad As Decimal = result.Item1
        TextBoxAdultPrice.Text = priceQuad
        If Await GetLastContractNumber() = 0 Then
            LabelContractNumber.Text = "رقم عقد : " & Await GetLastContractNumber() + 1
        Else
            LabelContractNumber.Text = "رقم عقد : " & Await GetLastContractNumber()

        End If

        ' عرض رقم العقد الحالي في فورم أو تخزينه في مكان ما
        ' حلقة تمر على جميع عناصر التحكم في النموذج
        For Each ctrl As Control In Me.Controls
            ' التحقق إذا كان العنصر هو TextBox
            If TypeOf ctrl Is TextBox Then
                Dim txtBox As TextBox = CType(ctrl, TextBox)
                ' حفظ النص الافتراضي داخل خاصية Tag
                txtBox.Tag = txtBox.Text
                ' تعيين لون النص الافتراضي إلى رمادي
                txtBox.ForeColor = Color.Gray
                ' إضافة أحداث Enter و Leave
                AddHandler txtBox.Enter, AddressOf TextBox_Enter
                AddHandler txtBox.Leave, AddressOf TextBox_Leave
            End If
        Next
        For Each ctrl As Control In Panel1.Controls
            ' التحقق إذا كان العنصر هو TextBox
            If TypeOf ctrl Is TextBox Then
                Dim txtBox As TextBox = CType(ctrl, TextBox)
                ' حفظ النص الافتراضي داخل خاصية Tag
                txtBox.Tag = txtBox.Text
                ' تعيين لون النص الافتراضي إلى رمادي
                txtBox.ForeColor = Color.Gray
                ' إضافة أحداث Enter و Leave
                AddHandler txtBox.Enter, AddressOf TextBox_Enter
                AddHandler txtBox.Leave, AddressOf TextBox_Leave
            End If
        Next
        For Each ctrl As Control In Panel2.Controls
            ' التحقق إذا كان العنصر هو TextBox
            If TypeOf ctrl Is TextBox Then
                Dim txtBox As TextBox = CType(ctrl, TextBox)
                ' حفظ النص الافتراضي داخل خاصية Tag
                txtBox.Tag = txtBox.Text
                ' تعيين لون النص الافتراضي إلى رمادي
                txtBox.ForeColor = Color.Gray
                ' إضافة أحداث Enter و Leave
                AddHandler txtBox.Enter, AddressOf TextBox_Enter
                AddHandler txtBox.Leave, AddressOf TextBox_Leave
            End If
        Next
        For Each ctrl As Control In Panel3.Controls
            ' التحقق إذا كان العنصر هو TextBox
            If TypeOf ctrl Is TextBox Then
                Dim txtBox As TextBox = CType(ctrl, TextBox)
                ' حفظ النص الافتراضي داخل خاصية Tag
                txtBox.Tag = txtBox.Text
                ' تعيين لون النص الافتراضي إلى رمادي
                txtBox.ForeColor = Color.Gray
                ' إضافة أحداث Enter و Leave
                AddHandler txtBox.Enter, AddressOf TextBox_Enter
                AddHandler txtBox.Leave, AddressOf TextBox_Leave
            End If
        Next
        For Each ctrl As Control In Panel4.Controls
            ' التحقق إذا كان العنصر هو TextBox
            If TypeOf ctrl Is TextBox Then
                Dim txtBox As TextBox = CType(ctrl, TextBox)
                ' حفظ النص الافتراضي داخل خاصية Tag
                txtBox.Tag = txtBox.Text
                ' تعيين لون النص الافتراضي إلى رمادي
                txtBox.ForeColor = Color.Gray
                ' إضافة أحداث Enter و Leave
                AddHandler txtBox.Enter, AddressOf TextBox_Enter
                AddHandler txtBox.Leave, AddressOf TextBox_Leave
            End If
        Next

    End Sub


    Private Async Sub ButtonPrint_Click(sender As Object, e As EventArgs) Handles ButtonPrint.Click
        Dim printDocument As New PrintDocument
        If String.IsNullOrEmpty(TextBox18.Text) Then
            TextBox18.Text = "0"
        End If
        If String.IsNullOrEmpty(TextBox17.Text) Then
            TextBox17.Text = "0"
        End If
        If String.IsNullOrEmpty(TextBox16.Text) Then
            TextBox16.Text = "0"
        End If
        If String.IsNullOrEmpty(TextBoxChildPrice.Text) Then
            TextBoxChildPrice.Text = "0"
        End If
        If String.IsNullOrEmpty(TextBoxInfantPrice.Text) Then
            TextBoxInfantPrice.Text = "0"
        End If
        If String.IsNullOrEmpty(TextBoxAdultPrice.Text) Then
            TextBoxAdultPrice.Text = "0"
        End If
        Try
            ConfigurePrintDocument(printDocument)

            Dim printPreviewDialog As New PrintPreviewDialog With {
                .Document = printDocument
            }
            printPreviewDialog.ShowDialog()
        Catch ex As Exception
            MessageBox.Show("Error during printing: " & ex.Message)
        End Try

        ' حفظ العقد في Firebase
        Dim contract As New Contract() With {
            .ClientName = TextBox1.Text,
            .MakaHotelName = TextBoxMakaHotelName.Text,
            .MadinaHotelName = TextBoxMadinaHotelName.Text,
            .MakaRooms = TextBoxTotalRoomsMaka.Text,
            .QuadRooms = TextBoxMakaQuad.Text,
            .TripleRooms = TextBoxMakaTriple.Text,
            .DoubleRooms = TextBoxMakaDouble.Text,
            .MadinaRooms = TextBoxTotalRoomsMadina.Text,
            .QuadRoomsM = TextBoxMadinaQuad.Text,
            .TripleRoomsM = TextBoxMadinaTriple.Text,
            .DoubleRoomsM = TextBoxMadinaDouble.Text,
            .ChildCount = TextBox18.Text,
            .InfantCount = TextBox17.Text,
            .AdultCount = TextBox16.Text,
            .Childprice = TextBoxChildPrice.Text,
            .Infantprice = TextBoxInfantPrice.Text,
            .Adultprice = TextBoxAdultPrice.Text,
            .TotalNightS = nigtmaka + nigtMadina,
            .totalCosT = CalculateTotalCost(),
            .contractTermS = RichTextBox1.Text,
            .contractDatE = Date.Now.ToString("yyyy-MM-dd"),
            .VisapricE = Form1.TextBox1.Text,
            .MadenapricE = Form1.TextBox2.Text,
            .MadenanumbeR = Form1.TextBox3.Text,
            .MakapricE = Form1.TextBox4.Text,
            .MakanumbeR = Form1.TextBox5.Text,
            .HiapricE = Form1.TextBox6.Text,
            .TrpricE = Form1.TextBox7.Text,
            .GiftpricE = Form1.TextBox8.Text,
            .AgentpricE = Form1.TextBox9.Text,
            .MultE = Form1.TextBox10.Text,
            .ConfirmedBy = "غير مؤكد"
        }
        ' حفظ العقد والحصول على رقم العقد الجديد
        Dim newContractNumber = Await SaveContractToFirebase(contract)

        If newContractNumber > 0 Then
            MessageBox.Show("تم حفظ العقد بنجاح برقم: " & newContractNumber.ToString(), "تم الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' تحديث LabelContractNumber بعد حفظ العقد
            LabelContractNumber.Text = "رقم العقد: " & newContractNumber.ToString() + 1
        End If
    End Sub


    Private Function CalculateTotalCost() As Decimal
        ' حساب التكلفة الإجمالية بناءً على البيانات الموجودة
        ' يمكنك تعديل هذه الحسابات بناءً على معادلتك
        Dim totalCost As Decimal = 0
        Dim childPrice As Decimal = Decimal.Parse(TextBoxChildPrice.Text)
        Dim infantPrice As Decimal = Decimal.Parse(TextBoxInfantPrice.Text)
        Dim adultPrice As Decimal = Decimal.Parse(TextBoxAdultPrice.Text)

        totalCost += childPrice * Decimal.Parse(TextBox18.Text)
        totalCost += infantPrice * Decimal.Parse(TextBox17.Text)
        totalCost += adultPrice * Decimal.Parse(TextBox16.Text)

        ' إذا كانت هناك غرف إضافية أو عوامل أخرى، يمكنك تضمينها هنا
        ' تعديل المجموع بناءً على حسابات الغرف
        totalCost += (Decimal.Parse(TextBoxMakaQuad.Text) + Decimal.Parse(TextBoxMakaTriple.Text) + Decimal.Parse(TextBoxMakaDouble.Text)) * 100 ' مثال على حساب إضافي

        Return totalCost
    End Function

    ' هذا الحدث يتم تشغيله عند دخول المستخدم إلى TextBox
    Private Sub TextBox_Enter(sender As Object, e As EventArgs)
        Dim txtBox As TextBox = CType(sender, TextBox)
        ' إذا كان النص الحالي هو النص الافتراضي، قم بمسحه
        If txtBox.Text = txtBox.Tag.ToString() Then
            txtBox.Text = ""
            txtBox.ForeColor = Color.Black
        End If
    End Sub

    ' هذا الحدث يتم تشغيله عند مغادرة المستخدم لـ TextBox
    Private Sub TextBox_Leave(sender As Object, e As EventArgs)
        Dim txtBox As TextBox = CType(sender, TextBox)
        ' إذا كان TextBox فارغًا، قم بإعادة النص الافتراضي
        If String.IsNullOrWhiteSpace(txtBox.Text) Then
            txtBox.Text = txtBox.Tag.ToString()
            txtBox.ForeColor = Color.Gray
        End If
    End Sub


    Private Sub TextBoxMadinaHotelName_TextChanged(sender As Object, e As EventArgs)
        Dim numericValue As Decimal
        If Decimal.TryParse(TextBoxMadinaHotelName.Text, numericValue) Then
            ' النص صالح وتم تحويله بنجاح
        Else
            MessageBox.Show("الرجاء إدخال قيمة رقمية صحيحة.", "خطأ في التنسيق", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub


    Private Async Function SaveLastContractNumberToFirebase() As Task
        Try
            LastContractNumber += 2
            Await firebaseClient.Child("LastContractNumber").PutAsync(LastContractNumber)
        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء حفظ رقم العقد الأخير: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

End Class
Public Class Contract
    Public Property ContractNumber As String ' Use String to store the Firebase key

    Public Property ClientName As String
    Public Property MakaHotelName As String
    Public Property MadinaHotelName As String
    Public Property MakaRooms As String
    Public Property QuadRooms As String
    Public Property TripleRooms As String
    Public Property DoubleRooms As String
    Public Property MadinaRooms As String
    Public Property QuadRoomsM As String
    Public Property TripleRoomsM As String
    Public Property DoubleRoomsM As String
    Public Property ChildCount As String
    Public Property InfantCount As String
    Public Property AdultCount As String
    Public Property TotalNightS As String
    Public Property totalCosT As String
    Public Property contractTermS As String
    Public Property contractDatE As String
    Public Property VisapricE As String
    Public Property MadenapricE As String
    Public Property MadenanumbeR As String
    Public Property MakapricE As String
    Public Property MakanumbeR As String
    Public Property HiapricE As String
    Public Property TrpricE As String
    Public Property GiftpricE As String
    Public Property AgentpricE As String
    Public Property MultE As String
    Public Property Adultprice As String
    Public Property Childprice As String
    Public Property Infantprice As String
    Public Property ConfirmedBy As String


End Class