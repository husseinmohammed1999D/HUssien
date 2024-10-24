Imports System.Drawing.Printing
Imports System.Net.Http
Imports Firebase.Database
Imports Newtonsoft.Json

' Form5.vb
Imports System.Text

Public Class Form5
    Private ContractNumber As Integer
    Dim companyPrice As Integer = My.Settings.Companyprice
    Private firebaseClient As New FirebaseClient("https://umrahprograming-default-rtdb.firebaseio.com/")
    Private contractKey As String ' لتخزين مفتاح العقد في Firebase
    ' Declare the DataGridView if it's missing
    Private WithEvents DataGridViewContracts As DataGridView

    ' منشئ افتراضي بدون معاملات
    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub New(contractKey As String) ' Constructor in Form5 to receive contractKey
        InitializeComponent()
        Me.contractKey = contractKey
        LoadContractDetails() ' تحميل بيانات العقد 
    End Sub

    ' ContractData.vb
    Public Class ContractData
        Public Property ClientName As String
        Public Property MakaHotelName As String
        Public Property LastContractNumber As Integer
        Public Property ContractNumber As Integer
        Public Property MadinaHotelName As String
        Public Property MakaRooms As Integer
        Public Property QuadRooms As Integer
        Public Property TripleRooms As Integer
        Public Property DoubleRooms As Integer
        Public Property MadinaRooms As Integer
        Public Property QuadRoomsM As Integer
        Public Property TripleRoomsM As Integer
        Public Property DoubleRoomsM As Integer
        Public Property ChildCount As Integer
        Public Property InfantCount As Integer
        Public Property Infantprice As Integer
        Public Property Childprice As Integer

        Public Property AdultCount As Integer
        Public Property ContractTermS As String
        Public Property VisapricE As Decimal
        Public Property MadenapricE As Decimal
        Public Property MadenanumbeR As String
        Public Property MakapricE As Decimal
        Public Property MakanumbeR As String
        Public Property HiapricE As Decimal
        Public Property TrpricE As Decimal
        Public Property GiftpricE As Decimal
        Public Property AgentpricE As Decimal
        Public Property MultE As Decimal

    End Class

    Private Async Sub LoadContractDetails()
        Try
            ' تحقق من أن contractKey ليس فارغًا
            If String.IsNullOrEmpty(contractKey) Then
                MessageBox.Show("مفتاح العقد غير موجود.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Using httpClient As New HttpClient()
                Dim url As String = $"https://umrahprograming-default-rtdb.firebaseio.com/Contracts/{contractKey}.json"
                Dim response As HttpResponseMessage = Await httpClient.GetAsync(url)
                response.EnsureSuccessStatusCode()

                Dim jsonResponse As String = Await response.Content.ReadAsStringAsync()
                Dim contractData As ContractData = JsonConvert.DeserializeObject(Of ContractData)(jsonResponse)

                If contractData Is Nothing Then
                    MessageBox.Show("لا توجد بيانات للعقد.", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                ' تحديث النصوص فقط إذا كانت القيم موجودة
                'If contractData.ContractNumber > 0 Then
                '    LabelContractNumber.Text = contractData.ContractNumber.ToString()
                'Else
                '    MessageBox.Show("رقم العقد غير صحيح.", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                'End If

                ' Load data into controls
                LabelContractNumber.Text = "رقم العقد :" & contractKey
                TextBox1.Text = contractData.ClientName
                TextBoxMakaHotelName.Text = contractData.MakaHotelName
                TextBoxMadinaHotelName.Text = contractData.MadinaHotelName
                TextBoxTotalRoomsMaka.Text = contractData.MakaRooms.ToString()
                TextBoxMakaQuad.Text = contractData.QuadRooms.ToString()
                TextBoxMakaTriple.Text = contractData.TripleRooms.ToString()
                TextBoxMakaDouble.Text = contractData.DoubleRooms.ToString()
                TextBoxTotalRoomsMadina.Text = contractData.MadinaRooms.ToString()
                TextBoxMadinaQuad.Text = contractData.QuadRoomsM.ToString()
                TextBoxMadinaTriple.Text = contractData.TripleRoomsM.ToString()
                TextBoxMadinaDouble.Text = contractData.DoubleRoomsM.ToString()
                TextBox18.Text = contractData.ChildCount.ToString()
                TextBox17.Text = contractData.InfantCount.ToString()
                TextBox16.Text = contractData.AdultCount.ToString()
                RichTextBox1.Text = contractData.ContractTermS.ToString()
                TextBoxAdultPrice.Text = contractData.AgentpricE
                TextBoxInfantPrice.Text = contractData.Infantprice

                TextBoxChildPrice.Text = contractData.Childprice


                TextBox10.Text = contractData.VisapricE.ToString()
                TextBox2.Text = contractData.MadenapricE.ToString()
                TextBox3.Text = contractData.MadenanumbeR
                TextBox4.Text = contractData.MakapricE.ToString()
                TextBox5.Text = contractData.MakanumbeR
                TextBox6.Text = contractData.HiapricE.ToString()
                TextBox7.Text = contractData.TrpricE.ToString()
                TextBox8.Text = contractData.GiftpricE.ToString()
                TextBox9.Text = contractData.AgentpricE.ToString()
                TextBox11.Text = contractData.MultE.ToString()


            End Using
        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء تحميل بيانات العقد: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        CAL()
        SumMutmer.Text = CAL1()

    End Sub


    ' Calculate the total prices
    Public Function CAL() As (Decimal, Decimal, Decimal)
        Try
            Dim VisaPric As Decimal = Decimal.Parse(TextBox10.Text)
            Dim MadinaPric As Decimal = Decimal.Parse(TextBox2.Text)
            Dim MakePrice As Decimal = Decimal.Parse(TextBox4.Text)
            Dim NumM1 As Decimal = Decimal.Parse(TextBox3.Text)
            Dim Numm As Decimal = Decimal.Parse(TextBox5.Text)
            Dim tNT As Decimal = Decimal.Parse(TextBox7.Text)
            Dim hiap As Decimal = Decimal.Parse(TextBox6.Text)
            Dim hadayap As Decimal = Decimal.Parse(TextBox8.Text)
            Dim AgentPric As Decimal = Decimal.Parse(TextBox9.Text)

            ' تحديد قيمة التقسيم بناءً على حالة CheckBox
            Dim multiplier As Decimal = If(CheckBox1.Checked, Decimal.Parse(TextBox11.Text), 4)

            If multiplier <= 0 Then
                MessageBox.Show("Invalid multiplier value. Please check the input.")
                Return (0, 0, 0)
            Else
                ' إذا كان CheckBox مفعل، قم بالتقسيم فقط لغرف رباعية وتصفير القيم الأخرى
                If CheckBox1.Checked Then
                    Dim TotalPriceQuad = CalculatePrice(VisaPric, MakePrice, MadinaPric, NumM1, Numm, tNT, hiap, hadayap, AgentPric, 4, multiplier)
                    Label20.Text = TotalPriceQuad.ToString("N0")
                    Label21.Text = "0"
                    Label22.Text = "0"

                    Return (TotalPriceQuad, 0, 0)
                Else
                    ' إذا كان CheckBox غير مفعل، قم بحساب جميع الغرف
                    Dim TotalPriceQuad = CalculatePrice(VisaPric, MakePrice, MadinaPric, NumM1, Numm, tNT, hiap, hadayap, AgentPric, 4, 4)
                    Dim TotalPriceDouble = CalculatePrice(VisaPric, MakePrice, MadinaPric, NumM1, Numm, tNT, hiap, hadayap, AgentPric, 2, 2)
                    Dim TotalPriceTriple = CalculatePrice(VisaPric, MakePrice, MadinaPric, NumM1, Numm, tNT, hiap, hadayap, AgentPric, 3, 3)

                    Label20.Text = TotalPriceQuad.ToString("N0")
                    Label21.Text = TotalPriceTriple.ToString("N0")
                    Label22.Text = TotalPriceDouble.ToString("N0")

                    Return (TotalPriceQuad, TotalPriceDouble, TotalPriceTriple)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Error calculating the values: " & ex.Message)
            Return (0, 0, 0)
        End Try
    End Function

    Public Function CAL1()
        Try
            Dim VisaPric As Decimal = Decimal.Parse(TextBox16.Text)
            Dim MadinaPric As Decimal = Decimal.Parse(TextBox17.Text)
            Dim MakePrice As Decimal = Decimal.Parse(TextBox18.Text)



            ' إذا كان CheckBox غير مفعل، قم بحساب جميع الغرف
            Dim TotalPriceQuad = VisaPric + MakePrice + MadinaPric


        Catch ex As Exception
            MessageBox.Show("Error calculating the values: " & ex.Message)

        End Try
    End Function

    ' Helper function to calculate price based on occupancy
    Private Function CalculatePrice(visaPrice As Decimal, makePrice As Decimal, madinaPrice As Decimal, numM1 As Decimal, numm As Decimal, tNT As Decimal, hiap As Decimal, hadayap As Decimal, agentPrice As Decimal, occupancy As Decimal, divider As Decimal) As Decimal
        Return Math.Ceiling((visaPrice / 3.72) + (numm * makePrice / divider / 3.72) + (numM1 * madinaPrice / divider / 3.72) + tNT + hiap + hadayap + agentPrice + companyPrice)
    End Function

    Private Function CalculatePrice1(visaPrice As Decimal, makePrice As Decimal, madinaPrice As Decimal, numM1 As Decimal, numm As Decimal, tNT As Decimal, hiap As Decimal, hadayap As Decimal, agentPrice As Decimal, occupancy As Decimal, multiplier As Decimal) As Decimal
        Return Math.Ceiling((visaPrice / 3.72) + (numm * makePrice / multiplier / 3.72) + (numM1 * madinaPrice / multiplier / 3.72) + tNT + hiap + hadayap + agentPrice + companyPrice)
    End Function
    Private Sub btnSum_Click(sender As Object, e As EventArgs) Handles btnSum.Click
        CAL()
        CalculateTotals()
    End Sub



    Private Function GetSafeInteger(value As String) As Integer
        Dim result As Integer
        If Integer.TryParse(value, result) Then
            Return result
        End If
        Return 0 ' أو أي قيمة افتراضية تريد إرجاعها
    End Function

    Private Function GetSafeDecimal(value As String) As Decimal
        Dim result As Decimal
        If Decimal.TryParse(value, result) Then
            Return result
        End If
        Return 0D ' أو أي قيمة افتراضية تريد إرجاعها
    End Function

    Private Sub ButtonPrint_Click(sender As Object, e As EventArgs) Handles ButtonPrint.Click
        Dim printDocument As New PrintDocument

        Try
            ' Set up print settings
            ConfigurePrintDocument(printDocument)

            ' Show print preview
            Dim printPreviewDialog As New PrintPreviewDialog With {
                .Document = printDocument
            }
            printPreviewDialog.ShowDialog()
        Catch ex As Exception
            MessageBox.Show("Error during printing: " & ex.Message)
        End Try
    End Sub
    ' Configure the print document
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

                ' رسم الشعار كعلامة مائية في وسط الصفحة
                DrawLogoImage(graphics, e.PageBounds)

                ' رسم الجدول والمحتوى النصي
                DrawTables(graphics, font, brush, format)
                DrawDetails(graphics, font, brush, format, e.PageBounds)

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
            ' تحميل الصورة
            Using logoImage As Image = Image.FromFile(imagePath)
                ' تحديد موضع وحجم الصورة لتملأ الصفحة بالكامل
                Dim logoRectangle As New Rectangle(0, 0, pageBounds.Width, pageBounds.Height)

                ' رسم الصورة على الصفحة
                graphics.DrawImage(logoImage, logoRectangle)
            End Using
        Else
            MessageBox.Show("لم يتم العثور على الصورة في المسار المحدد.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub DrawTables(graphics As Graphics, font As Font, brush As SolidBrush, format As StringFormat)
        ' استدعاء الدالة واسترجاع القيم الثلاث
        Dim result = CAL()
        Dim priceQuad As Decimal = result.Item1
        Dim priceDouble As Decimal = result.Item2
        Dim priceTriple As Decimal = result.Item3
        Dim priceQuad2 As Decimal = result.Item1

        ' أسعار الأطفال والرضع والبالغين
        Dim childPrice As Decimal = Decimal.Parse(TextBoxChildPrice.Text)
        Dim infantPrice As Decimal = Decimal.Parse(TextBoxInfantPrice.Text)
        Dim adultPrice As Decimal = Decimal.Parse(TextBoxAdultPrice.Text)

        ' حساب المجموع لكل نوع غرفة
        Dim totalQuad As Decimal = priceQuad * 4 * Decimal.Parse(TextBoxMakaQuad.Text)
        Dim totalTriple As Decimal = priceTriple * 3 * Decimal.Parse(TextBoxMakaTriple.Text)
        Dim totalDouble As Decimal = priceDouble * 2 * Decimal.Parse(TextBoxMakaDouble.Text)

        ' حساب مجموع الأسعار بدون الغرف الثنائية
        Dim grandTotal As Decimal = (childPrice * Decimal.Parse(TextBox18.Text)) +
                                    (infantPrice * Decimal.Parse(TextBox17.Text)) +
                                    (adultPrice * Decimal.Parse(TextBox16.Text))

        ' إذا كانت هناك غرفة ثنائية
        ' تحقق إذا كانت هناك غرفة ثنائية في مكة أو المدينة
        If Integer.Parse(TextBoxMakaDouble.Text) > 0 Or Integer.Parse(TextBoxMadinaDouble.Text) > 0 Then
            ' طرح سعر سريرين من المجموع
            grandTotal -= Integer.Parse(TextBoxMakaDouble.Text) * 2 * adultPrice

            ' إضافة سعر الغرفة الثنائية مضروبًا في 2
            grandTotal += Integer.Parse(TextBoxMakaDouble.Text) * 2 * priceDouble
        End If

        ' تحقق إذا كانت هناك غرفة ثلاثية في مكة أو المدينة
        If Integer.Parse(TextBoxMakaTriple.Text) > 0 Or Integer.Parse(TextBoxMadinaTriple.Text) > 0 Then
            ' طرح سعر ثلاثة أسرة من المجموع
            grandTotal -= Integer.Parse(TextBoxMakaTriple.Text) * 3 * adultPrice

            ' إضافة سعر الغرفة الثلاثية مضروبًا في 3
            grandTotal += Integer.Parse(TextBoxMakaTriple.Text) * 3 * priceTriple
        End If
        ' عرض النتائج في الجدول
        Dim pageWidth As Integer = 800
        Dim tableX As Integer = pageWidth - 775
        Dim tableY As Integer = 600
        Dim rowHeight As Integer = 30
        Dim columnWidth As Integer = 125 ' تعديل عرض الأعمدة لتناسب المحتوى

        ' إعداد محاذاة النص إلى اليمين
        format.Alignment = StringAlignment.Far

        ' رسم خطوط فاصلة بين الأعمدة
        For i As Integer = 1 To 5
            Dim lineX As Integer = tableX + columnWidth * i
            graphics.DrawLine(Pens.Black, lineX, tableY, lineX, tableY + rowHeight * 8)
        Next

        ' رسم العناوين الرئيسية للأعمدة
        DrawTableRow(graphics, font, brush, format, tableX, tableY, columnWidth, rowHeight,
                 "سعر البرنامج للطيران او البر", "نوع الغرف", "عدد الغرف مكة", "اسم فندق مكة", "عدد الغرف المدينة", "اسم فندق المدينة")
        tableY += rowHeight
        graphics.DrawLine(Pens.Black, tableX, tableY, tableX + columnWidth * 6, tableY)

        ' رسم البيانات للغرف الثنائية
        DrawTableRow(graphics, font, brush, format, tableX, tableY, columnWidth, rowHeight,
                 priceDouble.ToString("N2"), "غرف ثنائية", TextBoxMakaDouble.Text, TextBoxMakaHotelName.Text, TextBoxMadinaDouble.Text, TextBoxMadinaHotelName.Text)
        tableY += rowHeight
        graphics.DrawLine(Pens.Black, tableX, tableY, tableX + columnWidth * 6, tableY)

        ' رسم البيانات للغرف الثلاثية
        DrawTableRow(graphics, font, brush, format, tableX, tableY, columnWidth, rowHeight,
                 priceTriple.ToString("N2"), "غرف ثلاثية", TextBoxMakaTriple.Text, TextBoxMakaHotelName.Text, TextBoxMadinaTriple.Text, TextBoxMadinaHotelName.Text)
        tableY += rowHeight
        graphics.DrawLine(Pens.Black, tableX, tableY, tableX + columnWidth * 6, tableY)
        If priceQuad > 0 Then
            DrawTableRow(graphics, font, brush, format, tableX, tableY, columnWidth, rowHeight,
                 priceQuad.ToString("N2"), "غرف رباعية", TextBoxMakaQuad.Text, TextBoxMakaHotelName.Text, TextBoxMadinaQuad.Text, TextBoxMadinaHotelName.Text)
        Else
            DrawTableRow(graphics, font, brush, format, tableX, tableY, columnWidth, rowHeight,
                 priceQuad2.ToString("N2"), "غرف رباعية", TextBoxMakaQuad.Text, TextBoxMakaHotelName.Text, TextBoxMadinaQuad.Text, TextBoxMadinaHotelName.Text)


        End If
        ' رسم البيانات للغرف الرباعية
        tableY += rowHeight
        graphics.DrawLine(Pens.Black, tableX, tableY, tableX + columnWidth * 6, tableY)

        ' إضافة مجموع غرف المدينة ومكة
        Dim s As Integer = (CalculateSum(TextBoxTotalRoomsMadina, TextBoxTotalRoomsMaka)).ToString()
        DrawTableRow(graphics, font, brush, format, tableX, tableY, columnWidth, rowHeight,
                 s, "مجموع الكلي", TextBoxTotalRoomsMaka.Text, "مجموع غ مكة", TextBoxTotalRoomsMadina.Text, "مجموع غ المدينة")
        tableY += rowHeight
        graphics.DrawLine(Pens.Black, tableX, tableY, tableX + columnWidth * 6, tableY)

        ' إضافة عدد الأطفال، الرضع، البالغين
        DrawTableRow(graphics, font, brush, format, tableX, tableY, columnWidth, rowHeight,
TextBox18.Text, "عدد الأطفال", TextBox17.Text, "عدد الرضع", TextBox16.Text, "عدد البالغين")
        tableY += rowHeight
        graphics.DrawLine(Pens.Black, tableX, tableY, tableX + columnWidth * 6, tableY)

        ' إضافة أسعار الطفل، الرضيع، والبالغ
        DrawTableRow(graphics, font, brush, format, tableX, tableY, columnWidth, rowHeight,
                 childPrice.ToString("N2"), "سعر الطفل", infantPrice.ToString("N2"), "سعر الرضيع", adultPrice.ToString("N2"), "سعر البالغ")
        tableY += rowHeight
        graphics.DrawLine(Pens.Black, tableX, tableY, tableX + columnWidth * 6, tableY)

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
    Private Sub DrawDetails(graphics As Graphics, font As Font, brush As SolidBrush, format As StringFormat, pageBounds As Rectangle)
        ' إنشاء StringBuilder لإضافة تفاصيل النص
        Dim sb As New System.Text.StringBuilder()

        ' حساب مجموع الليالي

        Dim totalNights As Integer ' تعريف المتغير خارج جملة If
        Dim nigtMadina As Integer = TextBox3.Text
        Dim nigtmaka As Integer = TextBox5.Text

        totalNights = nigtmaka + nigtMadina



        ' إضافة رقم العقد إلى التفاصيل
        sb.AppendLine($"رقم العقد: {contractKey}")
        sb.AppendLine($"تم الاتفاق بين الطرف الأول شركة المدينة المنورة العالمية للحج والعمرة والطرف الثاني السيد ({TextBox1.Text}) لسنة {Date.Now.ToString("yyyy-MM-dd")} على ما يلي تنظيم برنامج عمرة لمدة ({totalNights}) ليالي وعدد معتمرين عدد {SumMutmer.Text}")
        sb.AppendLine(RichTextBox1.Text)

        ' تحويل StringBuilder إلى نص
        Dim details As String = sb.ToString()

        ' رسم النص مع التفاصيل على الصفحة
        graphics.DrawString(details, font, brush, New RectangleF(50, -30, pageBounds.Width - 100, pageBounds.Height - 200), format)

        ' إنشاء نص التوقيع
        Dim signatureText As String = "توقيع الطرف الأول                                                                               توقيع الطرف الثاني"

        ' حساب موقع التوقيع بناءً على ارتفاع الصفحة وارتفاع النص
        Dim signaturePositionY As Single = pageBounds.Height - 300
        ' تعديل هذه القيمة للتحكم في المسافة من أسفل الصفحة

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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            ' إنشاء كائن ContractData لتخزين البيانات من عناصر التحكم


            Dim contractData As New ContractData With {
                .ContractNumber = contractKey,
            .ClientName = TextBox1.Text,
            .MakaHotelName = TextBoxMakaHotelName.Text,
            .MadinaHotelName = TextBoxMadinaHotelName.Text,
            .MakaRooms = GetSafeInteger(TextBoxTotalRoomsMaka.Text),
            .QuadRooms = GetSafeInteger(TextBoxMakaQuad.Text),
            .TripleRooms = GetSafeInteger(TextBoxMakaTriple.Text),
            .DoubleRooms = GetSafeInteger(TextBoxMakaDouble.Text),
            .MadinaRooms = GetSafeInteger(TextBoxTotalRoomsMadina.Text),
            .QuadRoomsM = GetSafeInteger(TextBoxMadinaQuad.Text),
            .TripleRoomsM = GetSafeInteger(TextBoxMadinaTriple.Text),
            .DoubleRoomsM = GetSafeInteger(TextBoxMadinaDouble.Text),
            .ChildCount = GetSafeInteger(TextBox18.Text),
            .InfantCount = GetSafeInteger(TextBox17.Text),
            .AdultCount = GetSafeInteger(TextBox16.Text),
            .VisapricE = GetSafeDecimal(TextBox1.Text),
            .MadenapricE = GetSafeDecimal(TextBox2.Text),
            .MadenanumbeR = TextBox3.Text,
            .MakapricE = GetSafeDecimal(TextBox4.Text),
            .MakanumbeR = TextBox5.Text,
            .HiapricE = GetSafeDecimal(TextBox6.Text),
            .TrpricE = GetSafeDecimal(TextBox7.Text),
            .GiftpricE = GetSafeDecimal(TextBox8.Text),
            .AgentpricE = GetSafeDecimal(TextBox9.Text),
            .MultE = GetSafeDecimal(TextBox10.Text)
        }

            ' تحديث بيانات العقد في Firebase
            firebaseClient.Child("Contracts/" & contractKey).PutAsync(contractData)

            MessageBox.Show("تم حفظ بيانات العقد بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء حفظ بيانات العقد: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SumMutmer_TextChanged(sender As Object, e As EventArgs) Handles SumMutmer.TextChanged

    End Sub
End Class
